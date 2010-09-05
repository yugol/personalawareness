#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <DbUtil.h>
#include <cmd/DeleteTransactionCommand.h>
#include <cmd/UpdateTransactionCommand.h>
#include <cmd/InsertTransactionCommand.h>

using namespace std;

namespace adb {

    void InsertTransactionCommand::buildSqlCommand(ostream& out, const Transaction& transaction)
    {
        out << "INSERT INTO [" << Configuration::TABLE_TRANSACTIONS << "] (";
        out << "[" << Configuration::COLUMN_DATE << "], ";
        out << "[" << Configuration::COLUMN_VALUE << "], ";
        out << "[" << Configuration::COLUMN_SOURCE << "], ";
        out << "[" << Configuration::COLUMN_DESTINATION << "], ";
        out << "[" << Configuration::COLUMN_DESCRIPTION << "], ";
        out << "[" << Configuration::COLUMN_COMMENT << "]) ";
        out << "VALUES ( ";
        out << "'" << transaction.getDate() << "', ";
        out << transaction.getValue() << ", ";
        out << transaction.getFromId() << ", ";
        out << transaction.getToId() << ", ";
        out << transaction.getItemId() << ", ";
        out << DbUtil::toDbParameter(transaction.getDescription()) << " );" << endl;
    }

    InsertTransactionCommand::InsertTransactionCommand(sqlite3* database, const Transaction& transaction) :
        ReversibleDatabaseCommand(database), transaction_(transaction)
    {
        transaction_.validate();
    }

    void InsertTransactionCommand::buildSqlCommand()
    {
        ostringstream sout;
        buildSqlCommand(sout, transaction_);
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
