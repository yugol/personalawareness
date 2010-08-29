#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <cmd/DeleteTransactionCommand.h>
#include <cmd/UpdateTransactionCommand.h>
#include <cmd/InsertTransactionCommand.h>

using namespace std;

namespace adb {

    InsertTransactionCommand::InsertTransactionCommand(sqlite3* database, const Transaction& transaction) :
        ReversibleDatabaseCommand(database), transaction_(transaction)
    {
        transaction_.validate();
    }

    void InsertTransactionCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "INSERT INTO [" << Configuration::TRANSACTIONS_TABLE_NAME << "] (";
        sout << "[" << Configuration::DATE_COLUMN_NAME << "], ";
        sout << "[" << Configuration::VAL_COLUMN_NAME << "], ";
        sout << "[" << Configuration::FROM_COLUMN_NAME << "], ";
        sout << "[" << Configuration::TO_COLUMN_NAME << "], ";
        sout << "[" << Configuration::ITEM_COLUMN_NAME << "], ";
        sout << "[" << Configuration::DESC_COLUMN_NAME << "]) ";
        sout << "VALUES ( ";
        sout << "'" << transaction_.getDate() << "', ";
        sout << transaction_.getValue() << ", ";
        sout << transaction_.getFromId() << ", ";
        sout << transaction_.getToId() << ", ";
        sout << transaction_.getItemId() << ", ";
        sout << toParameter(transaction_.getDescription()) << " );" << endl;

        sql_ = sout.rdbuf()->str();
    }

    void InsertTransactionCommand::buildReverseSqlCommand()
    {
    }

    void InsertTransactionCommand::execute()
    {
        if (0 == transaction_.getId()) {
            DatabaseCommand::execute();
            transaction_.setId(::sqlite3_last_insert_rowid(database_));
        } else {
            DeleteTransactionCommand deleteCmd(database_, transaction_.getId());
            deleteCmd.unexecute();
            UpdateTransactionCommand updateCmd(database_, transaction_);
            updateCmd.execute();
        }
    }

    void InsertTransactionCommand::unexecute()
    {
        DeleteTransactionCommand cmd(database_, transaction_.getId());
        cmd.execute();
    }

} // namespac eadb
