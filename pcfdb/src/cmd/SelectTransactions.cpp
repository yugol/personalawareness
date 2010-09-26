#include <sstream>
#include <Configuration.h>
#include <Account.h>
#include <SelectionParameters.h>
#include <cmd/SelectTransactions.h>

using namespace std;

SelectTransactions::SelectTransactions(sqlite3* database, vector<int>* selection, const SelectionParameters* parameters) :
    SelectCommand(database, selection, parameters)
{
}

void SelectTransactions::buildSqlCommand()
{
    ostringstream sout;

    sout << "SELECT [" << Configuration::TABLE_TRANSACTIONS << "].[" << Configuration::COLUMN_ID << "] ";

    sout << "FROM [" << Configuration::TABLE_TRANSACTIONS << "] ";
    if (parameters_) {
        if (parameters_->getAccountType() != Account::ALL) {
            sout << "JOIN [" << Configuration::TABLE_ACCOUNTS << "] AS [" << Configuration::TABLE_ACCOUNTS << "01] ";
            sout << "ON [" << Configuration::COLUMN_SOURCE << "] = [" << Configuration::TABLE_ACCOUNTS << "01].[" << Configuration::COLUMN_ID << "] ";
            sout << "JOIN [" << Configuration::TABLE_ACCOUNTS << "] AS [" << Configuration::TABLE_ACCOUNTS << "02] ";
            sout << "ON [" << Configuration::COLUMN_DESTINATION << "] = [" << Configuration::TABLE_ACCOUNTS << "02].[" << Configuration::COLUMN_ID << "] ";
        }
        if (parameters_->hasNamePattern()) {
            sout << "JOIN [" << Configuration::TABLE_ITEMS << "] ";
            sout << "ON [" << Configuration::COLUMN_ITEM << "] = [" << Configuration::TABLE_ITEMS << "].[" << Configuration::COLUMN_ID << "] ";
        }
    }

    sout << "WHERE [" << Configuration::TABLE_TRANSACTIONS << "].[" << Configuration::COLUMN_DELETED << "] IS NULL ";
    if (parameters_) {
        if (parameters_->getItemId() != Configuration::DEFAULT_ID) {
            sout << "AND [" << Configuration::COLUMN_ITEM << "] = " << parameters_->getItemId() << " ";
        } else {
            if (parameters_->getAccountId() != Configuration::DEFAULT_ID) {
                sout << "AND ([" << Configuration::COLUMN_SOURCE << "] = " << parameters_->getAccountId() << " ";
                sout << "OR [" << Configuration::COLUMN_DESTINATION << "] = " << parameters_->getAccountId() << ") ";
            }
            if (!(parameters_->getFirstDate()).isNull()) {
                sout << "AND [" << Configuration::COLUMN_DATE << "] >= '" << parameters_->getFirstDate() << "' ";
            }
            if (!(parameters_->getLastDate()).isNull()) {
                sout << "AND [" << Configuration::COLUMN_DATE << "] <= '" << parameters_->getLastDate() << "' ";
            }
            if (parameters_->getAccountType() == Account::CREDIT) {
                sout << "AND [" << Configuration::TABLE_ACCOUNTS << "01].[" << Configuration::COLUMN_TYPE << "] = " << Account::CREDIT << " ";
            }
            if (parameters_->getAccountType() == Account::DEBT) {
                sout << "AND [" << Configuration::TABLE_ACCOUNTS << "02].[" << Configuration::COLUMN_TYPE << "] = " << Account::DEBT << " ";
            }
            if (parameters_->hasNamePattern()) {
                sout << "AND [" << Configuration::TABLE_ITEMS << "].[" << Configuration::COLUMN_NAME << "] LIKE '%" << parameters_->getNamePattern() << "%' ";
            }
        }
    }

    if (parameters_ && parameters_->isLastTransactionOnly()) {
        sout << "ORDER BY [" << Configuration::COLUMN_DATE << "] DESC ";
        sout << "LIMIT 1;" << endl;
    } else if (parameters_ && parameters_->isCheckUsage()) {
        sout << "LIMIT 1;" << endl;
    } else {
        sout << "ORDER BY [" << Configuration::COLUMN_DATE << "] ASC;" << endl;
    }

    sql_ = sout.rdbuf()->str();
}

