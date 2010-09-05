#include <iostream>
#include <sstream>
#include <Exception.h>
#include <DbUtil.h>
#include <Transaction.h>
#include <cmd/SelectPreferences.h>
#include <cmd/UpdatePreference.h>
#include <DatabaseConnection.h>

using namespace std;

namespace adb {

    void DatabaseConnection::dumpSql(ostream& out) const
    {
        cashAccounts();
        cashItems();

        // dump properties
        writePreferences(database_);
        SelectPreferences prefs(database_);
        prefs.execute();
        map<const string, const string>::iterator it;
        for (it = prefs.begin(); it != prefs.end(); ++it) {
            UpdatePreference::buildSqlCommand(out, it->first, it->second);
        }

        // dump accounts
        int accountNo = 0;
        map<int, int> accountIds;
        vector<Account>::iterator iAccounts;
        for (iAccounts = accounts_.begin(); iAccounts != accounts_.end(); ++iAccounts) {
            accountIds[iAccounts->getId()] = ++accountNo;

            out << "INSERT INTO accounts (type, ival, name, [group], [desc]) VALUES ( "; // TBD+: use Configuration names
            out << iAccounts->getType() << ", ";
            out << iAccounts->getInitialValue() << ", ";
            out << DbUtil::toDbParameter(iAccounts->getName()) << ", ";
            out << DbUtil::toDbParameter(iAccounts->getGroup()) << ", ";
            out << DbUtil::toDbParameter(iAccounts->getDescription()) << " );" << endl;
        }

        // dump items
        int itemNo = 0;
        map<int, int> itemIds;
        map<int, Item>::iterator iItems;
        for (iItems = items_.begin(); iItems != items_.end(); ++iItems) {
            Item* item = &(iItems->second);
            itemIds[item->getId()] = ++itemNo;

            out << "INSERT INTO items (name) VALUES ( "; // TBD+: use Configuration names
            out << DbUtil::toDbParameter(item->getName()) << " );" << endl;
        }

        // dump transactions
        vector<int> allTransactions;
        selectTransactions(&allTransactions, 0);
        vector<int>::iterator iTransactions;
        for (iTransactions = allTransactions.begin(); iTransactions != allTransactions.end(); ++iTransactions) {
            Transaction transaction(*iTransactions);
            getTransaction(&transaction);

            out << "INSERT INTO transactions ([date], val, [from], [to], item, [desc]) VALUES ( "; // TBD+: use Configuration names
            out << "'" << transaction.getDate() << "', ";
            out << transaction.getValue() << ", ";
            out << accountIds[transaction.getFromId()] << ", ";
            out << accountIds[transaction.getToId()] << ", ";
            out << itemIds[transaction.getItemId()] << ", ";
            out << DbUtil::toDbParameter(transaction.getDescription()) << " );" << endl;
        }
    }

    void DatabaseConnection::loadSql(istream& in)
    {
        char statement[Configuration::LINE_BUFFER_LENGTH];

        if (SQLITE_OK != ::sqlite3_exec(database_, "BEGIN;", NULL, NULL, NULL)) {
            string errMessage(Exception::SQL_ERROR_MESSAGE);
            errMessage.append(": ");
            errMessage.append(::sqlite3_errmsg(database_));
            THROW(errMessage.c_str());
        }

        int lineNo = 0;
        while (in.getline(statement, Configuration::LINE_BUFFER_LENGTH)) {
            ++lineNo;
            if (SQLITE_OK != ::sqlite3_exec(database_, statement, NULL, NULL, NULL)) {

                ostringstream msgOut;
                msgOut << Exception::SQL_ERROR_MESSAGE << ": ";
                msgOut << ::sqlite3_errmsg(database_) << " at line no. " << lineNo;

                if (SQLITE_OK != ::sqlite3_exec(database_, "ROLLBACK;", NULL, NULL, NULL)) {
                    string errMessage(Exception::SQL_ERROR_MESSAGE);
                    errMessage.append(": ");
                    errMessage.append(::sqlite3_errmsg(database_));
                    THROW(errMessage.c_str());
                }

                THROW(msgOut.rdbuf()->str().c_str());
            }
        }

        if (SQLITE_OK != ::sqlite3_exec(database_, "COMMIT;", NULL, NULL, NULL)) {
            string errMessage(Exception::SQL_ERROR_MESSAGE);
            errMessage.append(": ");
            errMessage.append(::sqlite3_errmsg(database_));
            THROW(errMessage.c_str());
        }
    }

} // namespace adb
