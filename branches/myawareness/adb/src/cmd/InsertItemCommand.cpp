#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <DbUtil.h>
#include <cmd/DeleteItemCommand.h>
#include <cmd/UpdateItemCommand.h>
#include <cmd/InsertItemCommand.h>

using namespace std;

namespace adb {

    InsertItemCommand::InsertItemCommand(sqlite3* database, const Item& item) :
        ReversibleDatabaseCommand(database), item_(item)
    {
        item_.validate();
    }

    void InsertItemCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "INSERT INTO [" << Configuration::TABLE_DESCRIPTIONS << "] ( ";
        sout << "[" << Configuration::COLUMN_NAME << "], ";
        sout << "[" << Configuration::COLUMN_TRANSACTION << "] ) ";
        sout << "VALUES ( ";
        sout << DbUtil::toDbParameter(item_.getName()) << ", ";
        sout << item_.getLastTransactionId() << " );" << endl;

        sql_ = sout.rdbuf()->str();
    }

    void InsertItemCommand::buildReverseSqlCommand()
    {
    }

    void InsertItemCommand::execute()
    {
        if (0 == item_.getId()) {
            DatabaseCommand::execute();
            item_.setId(::sqlite3_last_insert_rowid(database_));
        } else {
            DeleteItemCommand deleteCmd(database_, item_.getId());
            deleteCmd.unexecute();
            UpdateItemCommand updateCmd(database_, item_);
            updateCmd.execute();
        }
    }

    void InsertItemCommand::unexecute()
    {
        DeleteItemCommand cmd(database_, item_.getId());
        cmd.execute();
    }

} // namespace adb
