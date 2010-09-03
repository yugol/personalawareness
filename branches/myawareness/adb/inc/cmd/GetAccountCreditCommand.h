#ifndef GETACCOUNTCREDITCOMMAND_H_
#define GETACCOUNTCREDITCOMMAND_H_

#include "DatabaseCommand.h"

namespace adb {

    class Account;

    class GetAccountCreditCommand: public DatabaseCommand {
    public:
        GetAccountCreditCommand(sqlite3* database, const Account* account);

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

    inline double GetAccountCreditCommand::getCredit() const
    {
        return credit_;
    }

} // namespace adb

#endif /* GETACCOUNTCREDITCOMMAND_H_ */
