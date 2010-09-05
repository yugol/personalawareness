#include <iostream>
#include <sstream>
#include <Exception.h>
#include <DbUtil.h>
#include <Transaction.h>
#include <cmd/SelectPreferences.h>
#include <cmd/UpdatePreference.h>
#include <cmd/InsertAccountCommand.h>
#include <cmd/InsertItemCommand.h>
#include <cmd/InsertTransactionCommand.h>
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
            InsertAccountCommand::buildReverseSqlCommand(out, *iAccounts);
        }

        // dump items
        int itemNo = 0;
        map<int, int> itemIds;
        map<int, Item>::iterator iItems;
        for (iItems = items_.begin(); iItems != items_.end(); ++iItems) {
            Item* item = &(iItems->second);
            itemIds[item->getId()] = ++itemNo;
            InsertItemCommand::buildSqlCommand(out, *item, true);
        }

        // dump transactions
        vector<int> allTransactions;
        selectTransactions(&allTransactions, 0);
        vector<int>::iterator iTransactions;
        for (iTransactions = allTransactions.begin(); iTransactions != allTransactions.end(); ++iTransactions) {
            Transaction transaction(*iTransactions);
            getTransaction(&transaction);
            InsertTransactionCommand::buildSqlCommand(out, transaction);
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
