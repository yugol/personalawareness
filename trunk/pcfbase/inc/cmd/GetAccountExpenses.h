#ifndef GETACCOUNTEXPENSES_H_
#define GETACCOUNTEXPENSES_H_

#include <DatabaseCommand.h>

class Account;

class GetAccountExpenses: public DatabaseCommand {
public:
    GetAccountExpenses(sqlite3* database, const Account* account);

    virtual sqlite3_callback getCallbackFunction();
    virtual void* getCallbackParameter();
    virtual void execute();

    double getBalance() const;

protected:
    virtual void buildSqlCommand();

private:
    const Account* account_;
    double balance_;
};

inline double GetAccountExpenses::getBalance() const
{
    return balance_;
}

#endif /* GETACCOUNTEXPENSES_H_ */
