#ifndef GETACCOUNT_H_
#define GETACCOUNT_H_

#include <DatabaseCommand.h>

class Account;

class GetAccount: public DatabaseCommand {
public:
    GetAccount(sqlite3* database, Account* account);

    virtual void execute();

protected:
    virtual void buildSqlCommand();
    virtual sqlite3_callback getCallbackFunction();
    virtual void* getCallbackParameter();

private:
    Account* account_;
};

#endif /* GETACCOUNT_H_ */
