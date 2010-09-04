#include <sstream>
#include <Configuration.h>
#include <Account.h>
#include <SelectionParameters.h>
#include <cmd/SelectTransactionsCommand.h>

using namespace std;

namespace adb {

    SelectTransactionsCommand::SelectTransactionsCommand(sqlite3* database, vector<int>* selection, const SelectionParameters* parameters) :
        SelectCommand(database, selection, parameters)
    {
    }

    void SelectTransactionsCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT [" << Configuration::TRANSACTIONS_TABLE_NAME << "].[" << Configuration::ID_COLUMN_NAME << "] ";

        sout << "FROM [" << Configuration::TRANSACTIONS_TABLE_NAME << "] ";
        if (parameters_) {
            if (parameters_->getAccountType() != Account::ALL) {
                sout << "JOIN [" << Configuration::ACCOUNTS_TABLE_NAME << "] AS [" << Configuration::ACCOUNTS_TABLE_NAME << "01] ";
                sout << "ON [" << Configuration::FROM_COLUMN_NAME << "] = [" << Configuration::ACCOUNTS_TABLE_NAME << "01].[" << Configuration::ID_COLUMN_NAME << "] ";
                sout << "JOIN [" << Configuration::ACCOUNTS_TABLE_NAME << "] AS [" << Configuration::ACCOUNTS_TABLE_NAME << "02] ";
                sout << "ON [" << Configuration::TO_COLUMN_NAME << "] = [" << Configuration::ACCOUNTS_TABLE_NAME << "02].[" << Configuration::ID_COLUMN_NAME << "] ";
            }
            if (parameters_->hasNamePattern()) {
                sout << "JOIN [" << Configuration::ITEMS_TABLE_NAME << "] ";
                sout << "ON [" << Configuration::ITEM_COLUMN_NAME << "] = [" << Configuration::ITEMS_TABLE_NAME << "].[" << Configuration::ID_COLUMN_NAME << "] ";
            }
        }

        sout << "WHERE [" << Configuration::TRANSACTIONS_TABLE_NAME << "].[" << Configuration::DEL_COLUMN_NAME << "] IS NULL ";
        if (parameters_) {
            if (parameters_->getItemId() != Configuration::DEFAULT_ID) {
                sout << "AND [" << Configuration::ITEM_COLUMN_NAME << "] = " << parameters_->getItemId() << " ";
            } else {
                if (parameters_->getAccountId() != Configuration::DEFAULT_ID) {
                    sout << "AND ([" << Configuration::FROM_COLUMN_NAME << "] = " << parameters_->getAccountId() << " ";
                    sout << "OR [" << Configuration::TO_COLUMN_NAME << "] = " << parameters_->getAccountId() << ") ";
                }
                if (!(parameters_->getFirstDate()).isNull()) {
                    sout << "AND [" << Configuration::DATE_COLUMN_NAME << "] >= '" << parameters_->getFirstDate() << "' ";
                }
                if (!(parameters_->getLastDate()).isNull()) {
                    sout << "AND [" << Configuration::DATE_COLUMN_NAME << "] <= '" << parameters_->getLastDate() << "' ";
                }
                if (parameters_->getAccountType() == Account::CREDIT) {
                    sout << "AND [" << Configuration::ACCOUNTS_TABLE_NAME << "01].[" << Configuration::TYPE_COLUMN_NAME << "] = " << Account::CREDIT << " ";
                }
                if (parameters_->getAccountType() == Account::DEBT) {
                    sout << "AND [" << Configuration::ACCOUNTS_TABLE_NAME << "02].[" << Configuration::TYPE_COLUMN_NAME << "] = " << Account::DEBT << " ";
                }
                if (parameters_->hasNamePattern()) {
                    sout << "AND [" << Configuration::ITEMS_TABLE_NAME << "].[" << Configuration::NAME_COLUMN_NAME << "] LIKE '%" << parameters_->getNamePattern() << "%' ";
                }
            }
        }

        if (parameters_ && parameters_->isLastTransactionOnly()) {
            sout << "ORDER BY [" << Configuration::DATE_COLUMN_NAME << "] DESC ";
            sout << "LIMIT 1;" << endl;
        } else if (parameters_ && parameters_->isCheckUsage()) {
            sout << "LIMIT 1;" << endl;
        } else {
            sout << "ORDER BY [" << Configuration::DATE_COLUMN_NAME << "] ASC;" << endl;
        }

        sql_ = sout.rdbuf()->str();
    }

} // namespace adb
