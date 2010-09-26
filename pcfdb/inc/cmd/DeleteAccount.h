#ifndef DELETEACCOUNT_H_
#define DELETEACCOUNT_H_

#include <Account.h>
#include <ReversibleDatabaseCommand.h>

class DeleteAccount: public ReversibleDatabaseCommand {
public:
    DeleteAccount(sqlite3* database, int id);

    virtual std::string getDescription() const;

protected:
    virtual void buildSqlCommand();
    virtual void buildReverseSqlCommand();

private:
    Account account_;
};

#endif /* DELETEACCOUNT_H_ */
