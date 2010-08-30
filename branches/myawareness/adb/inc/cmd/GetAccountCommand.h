#ifndef GETACCOUNTCOMMAND_H_
#define GETACCOUNTCOMMAND_H_

#include "DatabaseCommand.h"

namespace adb {

    class Account;

    class GetAccountCommand: public DatabaseCommand {
    public:
        GetAccountCommand(sqlite3* database, Account* account);

        virtual void execute();

    protected:
        virtual void buildSqlCommand();
        virtual sqlite3_callback getCallbackFunction();
        virtual void* getCallbackParameter();

    private:
        Account* account_;
    };

} // namespace adb

#endif /* GETACCOUNTCOMMAND_H_ */