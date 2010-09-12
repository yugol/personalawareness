#ifndef UPDATEACCOUNT_H_
#define UPDATEACCOUNT_H_

#include <Account.h>
#include <ReversibleDatabaseCommand.h>

class UpdateAccount: public ReversibleDatabaseCommand {
public:
    UpdateAccount(sqlite3* database, const Account& item);

    virtual std::string getDescription() const;

protected:
    virtual void buildSqlCommand();
    virtual void buildReverseSqlCommand();

private:
    Account newAccount_;
    Account previousAccount_;

    void buildUpdateAccountSqlCommand(std::string& sql, const Account& item);
};

#endif /* UPDATEACCOUNT_H_ */
