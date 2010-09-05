#ifndef INSERTACCOUNTCOMMAND_H_
#define INSERTACCOUNTCOMMAND_H_

#include <Account.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

    class InsertAccountCommand: public ReversibleDatabaseCommand {
    public:
        static void buildReverseSqlCommand(std::ostream& out, const Account& account);

        InsertAccountCommand(sqlite3* database, const Account& item);

        const Account& getAccount() const;

        virtual void execute();
        virtual void unexecute();

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Account account_;
    };

    inline const Account& InsertAccountCommand::getAccount() const
    {
        return account_;
    }

} // namespace adb

#endif /* INSERTACCOUNTCOMMAND_H_ */
