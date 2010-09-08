#ifndef UPDATEACCOUNT_H_
#define UPDATEACCOUNT_H_

#include <Account.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

    class UpdateAccount: public ReversibleDatabaseCommand {
    public:
        UpdateAccount(sqlite3* database, const Account& item);

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Account newAccount_;
        Account previousAccount_;

        void buildUpdateAccountSqlCommand(std::string& sql, const Account& item);
    };

} // namespace adb

#endif /* UPDATEACCOUNT_H_ */
