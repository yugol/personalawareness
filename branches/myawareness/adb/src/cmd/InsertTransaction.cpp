#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <DbUtil.h>
#include <cmd/DeleteTransaction.h>
#include <cmd/UpdateTransaction.h>
#include <cmd/InsertTransaction.h>

using namespace std;

namespace adb {

    void InsertTransaction::buildSqlCommand(ostream& out, const Transaction& transaction)
    {
        out << "INSERT INTO [" << Configuration::TABLE_TRANSACTIONS << "] (";
        out << "[" << Configuration::COLUMN_DATE << "], ";
        out << "[" << Configuration::COLUMN_VALUE << "], ";
        out << "[" << Configuration::COLUMN_SOURCE << "], ";
        out << "[" << Configuration::COLUMN_DESTINATION << "], ";
        out << "[" << Configuration::COLUMN_ITEM << "], ";
        out << "[" << Configuration::COLUMN_COMMENT << "]) ";
        out << "VALUES ( ";
        out << "'" << transaction.getDate() << "', ";
        out << transaction.getValue() << ", ";
        out << transaction.getFromId() << ", ";
        out << transaction.getToId() << ", ";
        out << transaction.getItemId() << ", ";
        out << DbUtil::toDbParameter(transaction.getComment()) << " );" << endl;
    }

    InsertTransaction::InsertTransaction(sqlite3* database, const Transaction& transaction) :
        ReversibleDatabaseCommand(database), transaction_(transaction)
    {
        transaction_.validate();
    }

    void InsertTransaction::buildSqlCommand()
    {
        ostringstream sout;
        buildSqlCommand(sout, transaction_);
        sql_ = sout.rdbuf()->str();
    }

    void InsertTransaction::buildReverseSqlCommand()
    {
    }

    void InsertTransaction::execute()
    {
        if (0 == transaction_.getId()) {
            DatabaseCommand::execute();
            transaction_.setId(::sqlite3_last_insert_rowid(database_));
        } else {
            DeleteTransaction deleteCmd(database_, transaction_.getId());
            deleteCmd.unexecute();
            UpdateTransaction updateCmd(database_, transaction_);
            updateCmd.execute();
        }
    }

    void InsertTransaction::unexecute()
    {
        DeleteTransaction cmd(database_, transaction_.getId());
        cmd.execute();
    }

    string InsertTransaction::getDescription() const
    {
        return "insert transaction";
    }

} // namespac eadb
