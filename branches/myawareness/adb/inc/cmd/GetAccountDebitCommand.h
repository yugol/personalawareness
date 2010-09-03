#ifndef GETACCOUNTDEBITCOMMAND_H_
#define GETACCOUNTDEBITCOMMAND_H_

#include "DatabaseCommand.h"

namespace adb {

    class Account;

    class GetAccountDebitCommand: public DatabaseCommand {
    public:
        GetAccountDebitCommand(sqlite3* database, const Account* account);

        virtual sqlite3_callback getCallbackFunction();
        virtual void* getCallbackParameter();
        virtual void execute();

        double getDebit() const;

    protected:
        virtual void buildSqlCommand();

    private:
        const Account* account_;
        double debit_;
    };

    inline double GetAccountDebitCommand::getDebit() const
    {
        return debit_;
    }

} // namespace adb

#endif /* GETACCOUNTDEBITCOMMAND_H_ */
