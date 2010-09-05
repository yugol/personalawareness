#include <cstdlib>
#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <Transaction.h>
#include <cmd/GetTransactionCommand.h>

using namespace std;

namespace adb {

    GetTransactionCommand::GetTransactionCommand(sqlite3* database, Transaction* transaction) :
        DatabaseCommand(database), transaction_(transaction)
    {
    }

    static int readTransaction(void *param, int colCount, char **values, char **names)
    {
        Transaction* t = reinterpret_cast<Transaction*> (param);
        t->setId(::atof(values[0]));
        t->setDate(values[1]);
        t->setValue(::atof(values[2]));
        t->setFromId(::atoi(values[3]));
        t->setToId(::atoi(values[4]));
        t->setItemId(::atoi(values[5]));
        t->setDescription(values[6]);
        return 0;
    }

    sqlite3_callback GetTransactionCommand::getCallbackFunction()
    {
        return readTransaction;
    }

    void* GetTransactionCommand::getCallbackParameter()
    {
        return transaction_;
    }

    void GetTransactionCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT ";
        sout << "[" << Configuration::COLUMN_ID << "], ";
        sout << "[" << Configuration::COLUMN_DATE << "], ";
        sout << "[" << Configuration::COLUMN_VALUE << "], ";
        sout << "[" << Configuration::COLUMN_SOURCE << "], ";
        sout << "[" << Configuration::COLUMN_DESTINATION << "], ";
        sout << "[" << Configuration::COLUMN_DESCRIPTION << "], ";
        sout << "[" << Configuration::COLUMN_COMMENT << "] ";
        sout << "FROM [" << Configuration::TABLE_TRANSACTIONS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << transaction_->getId() << ";" << endl;

        sql_ = sout.rdbuf()->str();
    }

    void GetTransactionCommand::execute()
    {
        buildSqlCommand();
        int tempId = transaction_->getId();
        transaction_->setId(0);
        DatabaseCommand::execute();
        if (tempId != transaction_->getId()) {
            transaction_->setId(tempId);
            THROW(Exception::NO_RECORD_MESSAGE);
        }
    }

} // namespac eadb
