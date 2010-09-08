#ifndef GETACCOUNTDEBIT_H_
#define GETACCOUNTDEBIT_H_

#include "DatabaseCommand.h"

namespace adb {

    class Account;

    class GetAccountDebit: public DatabaseCommand {
    public:
        GetAccountDebit(sqlite3* database, const Account* account);

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

    inline double GetAccountDebit::getDebit() const
    {
        return debit_;
    }

} // namespace adb

#endif /* GETACCOUNTDEBIT_H_ */
