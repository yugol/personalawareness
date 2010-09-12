#ifndef GETTRANSACTION_H_
#define GETTRANSACTION_H_

#include <DatabaseCommand.h>

class Transaction;

class GetTransaction: public DatabaseCommand {
public:
    GetTransaction(sqlite3* database, Transaction* transaction);

    virtual void execute();

protected:
    virtual void buildSqlCommand();
    virtual sqlite3_callback getCallbackFunction();
    virtual void* getCallbackParameter();

private:
    Transaction* transaction_;
};

#endif /* GETTRANSACTION_H_ */
