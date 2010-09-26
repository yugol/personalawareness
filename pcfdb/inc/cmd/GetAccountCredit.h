#ifndef GETACCOUNTCREDIT_H_
#define GETACCOUNTCREDIT_H_

#include <DatabaseCommand.h>

class Account;

class GetAccountCredit: public DatabaseCommand {
public:
    GetAccountCredit(sqlite3* database, const Account* account);

    virtual sqlite3_callback getCallbackFunction();
    virtual void* getCallbackParameter();
    virtual void execute();

    double getCredit() const;

protected:
    virtual void buildSqlCommand();

private:
    const Account* account_;
    double credit_;
};

inline double GetAccountCredit::getCredit() const
{
    return credit_;
}

#endif /* GETACCOUNTCREDIT_H_ */
