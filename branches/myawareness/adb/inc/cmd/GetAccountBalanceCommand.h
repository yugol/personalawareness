#ifndef GETACCOUNTBALANCECOMMAND_H_
#define GETACCOUNTBALANCECOMMAND_H_

#include "DatabaseCommand.h"

namespace adb {

    class Account;

    class GetAccountBalanceCommand: public DatabaseCommand {
    public:
        GetAccountBalanceCommand(sqlite3* database, const Account* account);

        virtual void execute();

        double getBalance() const;

    protected:
        virtual void buildSqlCommand();

    private:
        const Account* account_;
        double balance_;
    };

    inline double GetAccountBalanceCommand::getBalance() const
    {
        return balance_;
    }

} // namespace adb

#endif /* GETACCOUNTBALANCECOMMAND_H_ */
