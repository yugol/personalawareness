#ifndef GETTRANSACTIONCOMMAND_H_
#define GETTRANSACTIONCOMMAND_H_

#include "DatabaseCommand.h"

namespace adb {

class Transaction;

class GetTransactionCommand: public adb::DatabaseCommand {
public:
	GetTransactionCommand(sqlite3* database, Transaction* transaction);

	virtual void execute();

protected:
	virtual void buildSqlCommand();
    virtual sqlite3_callback getCallbackFunction();
    virtual void* getCallbackParameter();

private:
	Transaction* transaction_;
};

}

#endif /* GETTRANSACTIONCOMMAND_H_ */
