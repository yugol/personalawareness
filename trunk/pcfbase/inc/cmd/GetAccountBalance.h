#ifndef GETACCOUNTBALANCE_H_
#define GETACCOUNTBALANCE_H_

#include <DatabaseCommand.h>

class Account;

class GetAccountBalance: public DatabaseCommand {
public:
    GetAccountBalance(sqlite3* database, const Account* account);

    virtual void execute();

    double getBalance() const;

protected:
    virtual void buildSqlCommand();

private:
    const Account* account_;
    double balance_;
};

inline double GetAccountBalance::getBalance() const
{
    return balance_;
}

#endif /* GETACCOUNTBALANCE_H_ */
