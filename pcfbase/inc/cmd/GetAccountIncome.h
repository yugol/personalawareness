#ifndef GETACCOUNTINCOME_H_
#define GETACCOUNTINCOME_H_

#include <DatabaseCommand.h>

class Account;

class GetAccountIncome: public DatabaseCommand {
public:
    GetAccountIncome(sqlite3* database, const Account* account);

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

inline double GetAccountIncome::getBalance() const
{
    return balance_;
}

#endif /* GETACCOUNTINCOME_H_ */
