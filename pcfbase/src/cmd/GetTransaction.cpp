#include <cstdlib>
#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <BaseUtil.h>
#include <Transaction.h>
#include <cmd/GetTransaction.h>

using namespace std;

GetTransaction::GetTransaction(sqlite3* database, Transaction* transaction) :
    DatabaseCommand(database), transaction_(transaction)
{
}

static int readTransaction(void *param, int colCount, char **values, char **names)
{
    Transaction* t = reinterpret_cast<Transaction*> (param);
    t->setId(::atoi(values[0]));
    t->setDate(values[1]);
    t->setValue(::atof(values[2]));
    t->setSourceId(::atoi(values[3]));
    t->setDestinationId(::atoi(values[4]));
    t->setItemId(::atoi(values[5]));
    t->setComment(values[6]);
    return 0;
}

sqlite3_callback GetTransaction::getCallbackFunction()
{
    return readTransaction;
}

void* GetTransaction::getCallbackParameter()
{
    return transaction_;
}

void GetTransaction::buildSqlCommand()
{
    ostringstream sout;

    sout << "SELECT ";
    sout << "[" << Configuration::COLUMN_ID << "], ";
    sout << "[" << Configuration::COLUMN_DATE << "], ";
    sout << "[" << Configuration::COLUMN_VALUE << "], ";
    sout << "[" << Configuration::COLUMN_SOURCE << "], ";
    sout << "[" << Configuration::COLUMN_DESTINATION << "], ";
    sout << "[" << Configuration::COLUMN_ITEM << "], ";
    sout << "[" << Configuration::COLUMN_COMMENT << "] ";
    sout << "FROM [" << Configuration::TABLE_TRANSACTIONS << "] ";
    sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << transaction_->getId() << ";" << endl;

    sql_ = sout.rdbuf()->str();
}

void GetTransaction::execute()
{
    buildSqlCommand();
    int tempId = transaction_->getId();
    transaction_->setId(0);
    DatabaseCommand::execute();
    if (tempId != transaction_->getId()) {
        transaction_->setId(tempId);
        THROW(BaseUtil::EMSG_NO_RECORD);
    }
}

