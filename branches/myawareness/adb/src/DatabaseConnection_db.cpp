#include <cstdio>
#include <util.h>
#include <LoadSqlCommand.h>
#include <cmd/CreateDatabaseCommand.h>
#include <cmd/PurgeDatabaseCommand.h>
#include <DatabaseConnection.h>

using namespace std;

namespace adb {

int DatabaseConnection::createNewDatabase()
{
    CreateDatabaseCommand cmd(database_);
    cmd.execute();
    return OK;
}

void DatabaseConnection::purgeDatabase()
{
    PurgeDatabaseCommand cmd(database_);
    cmd.execute();
}

void DatabaseConnection::dumpSql(ostream& out) const
{
    cashAccounts();
    cashItems();

    // dump accounts
    // TODO: use select
    map<int, int> accountIds;
    int accountNo = 0;

    vector<Account>::iterator iAccounts;
    for (iAccounts = accounts_.begin(); iAccounts != accounts_.end(); ++iAccounts) {
        accountIds[iAccounts->getId()] = ++accountNo;

        out << "INSERT INTO accounts (type, ival, name, [group], [desc]) VALUES ( ";
        out << iAccounts->getType() << ", ";
        out << iAccounts->getInitialValue() << ", ";
        out << DatabaseCommand::toParameter(iAccounts->getName()) << ", ";
        out << DatabaseCommand::toParameter(iAccounts->getGroup()) << ", ";
        out << DatabaseCommand::toParameter(iAccounts->getDescription()) << " );" << endl;
    }

    // dump items
    // TODO: use select
    map<int, int> itemIds;
    int itemNo = 0;

    map<int, Item>::iterator iItems;
    for (iItems = items_.begin(); iItems != items_.end(); ++iItems) {
        Item* item = &(iItems->second);
        itemIds[item->getId()] = ++itemNo;

        out << "INSERT INTO items (name) VALUES ( ";
        out << DatabaseCommand::toParameter(item->getName()) << " );" << endl;
    }

    // dump transactions
    vector<int> allTransactions;
    selectTransactions(&allTransactions, 0);

    vector<int>::iterator iTransactions;
    for (iTransactions = allTransactions.begin(); iTransactions != allTransactions.end(); ++iTransactions) {
        Transaction transaction(*iTransactions);
        getTransaction(&transaction);

        out << "INSERT INTO transactions ([date], val, [from], [to], item, [desc]) VALUES ( ";
        out << "'" << transaction.getDate() << "', ";
        out << transaction.getValue() << ", ";
        out << accountIds[transaction.getFromId()] << ", ";
        out << accountIds[transaction.getToId()] << ", ";
        out << itemIds[transaction.getItemId()] << ", ";
        out << DatabaseCommand::toParameter(transaction.getDescription()) << " );" << endl;
    }
}

void DatabaseConnection::loadSql(std::istream& in, LoadSqlCommand* callback)
{
    char statement[STATEMENT_LEN];

    int lineNo = 0;
    while (in.getline(statement, STATEMENT_LEN)) {
        ++lineNo;
        if (SQLITE_OK != ::sqlite3_exec(database_, statement, NULL, NULL, NULL)) {
            ::sprintf(statement, "error loading from SQL script: line %d", lineNo);
            THROW(statement);
        }
        if (0 != callback) {
            callback->setLineNo(lineNo);
            callback->execute();
        }
    }
}

} // namespace adb
