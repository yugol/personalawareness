#include <sstream>
#include <Configuration.h>
#include <cmd/SelectTransactionsCommand.h>

using namespace std;

namespace adb {

SelectTransactionsCommand::SelectTransactionsCommand(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters) :
    SelectCommand(database, selection, parameters)
{
}

void SelectTransactionsCommand::buildSqlCommand()
{
    ostringstream sout;

    sout << "SELECT [" << Configuration::ID_COLUMN_NAME << "] ";
    sout << "FROM [" << Configuration::TRANSACTIONS_TABLE_NAME << "] ";
    sout << "WHERE [" << Configuration::DEL_COLUMN_NAME << "] IS NULL ";

    if (parameters_ && parameters_->getItemId() != Configuration::DEFAULT_ID) {
        sout << "AND [" << Configuration::ITEM_COLUMN_NAME << "] = " << parameters_->getItemId() << " ";
    } else {
        if (parameters_ && parameters_->getAccountId() != Configuration::DEFAULT_ID) {
            sout << "AND ([" << Configuration::FROM_COLUMN_NAME << "] = " << parameters_->getAccountId() << " ";
            sout << "OR [" << Configuration::TO_COLUMN_NAME << "] = " << parameters_->getAccountId() << ") ";
        }

        if (parameters_ && !(parameters_->getFirstDate()).isNull()) {
            sout << "AND [" << Configuration::DATE_COLUMN_NAME << "] >= '" << parameters_->getFirstDate() << "' ";
        }

        if (parameters_ && !(parameters_->getLastDate()).isNull()) {
            sout << "AND [" << Configuration::DATE_COLUMN_NAME << "] <= '" << parameters_->getLastDate() << "' ";
        }
    }

    if (parameters_ && parameters_->isLastTransactionOnly()) {
        sout << "ORDER BY [" << Configuration::DATE_COLUMN_NAME << "] DESC ";
        sout << "LIMIT 1;" << endl;
    } else {
        sout << "ORDER BY [" << Configuration::DATE_COLUMN_NAME << "] ASC;" << endl;
    }

    sql_ = sout.rdbuf()->str();
}

} // namespace adb
