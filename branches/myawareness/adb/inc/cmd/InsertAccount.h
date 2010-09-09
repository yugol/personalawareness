#ifndef INSERTACCOUNT_H_
#define INSERTACCOUNT_H_

#include <Account.h>
#include <ReversibleDatabaseCommand.h>

namespace adb {

    class InsertAccount: public ReversibleDatabaseCommand {
    public:
        static void buildReverseSqlCommand(std::ostream& out, const Account& account);

        InsertAccount(sqlite3* database, const Account& item);

        const Account& getAccount() const;

        virtual void execute();
        virtual void unexecute();

        virtual std::string getDescription() const;

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Account account_;
    };

    inline const Account& InsertAccount::getAccount() const
    {
        return account_;
    }

} // namespace adb

#endif /* INSERTACCOUNT_H_ */
