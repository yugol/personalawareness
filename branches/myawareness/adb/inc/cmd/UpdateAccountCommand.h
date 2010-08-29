#ifndef UPDATEACCOUNTCOMMAND_H_
#define UPDATEACCOUNTCOMMAND_H_

#include <Account.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

    class UpdateAccountCommand: public ReversibleDatabaseCommand {
    public:
        UpdateAccountCommand(sqlite3* database, const Account& item);

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Account newAccount_;
        Account previousAccount_;

        void buildUpdateAccountSqlCommand(std::string& sql, const Account& item);
    };

} // namespace adb

#endif /* UPDATEACCOUNTCOMMAND_H_ */
