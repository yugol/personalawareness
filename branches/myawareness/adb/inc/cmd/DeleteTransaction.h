#ifndef DELETETRANSACTION_H_
#define DELETETRANSACTION_H_

#include <Transaction.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

    class DeleteTransaction: public ReversibleDatabaseCommand {
    public:
        DeleteTransaction(sqlite3* database, int id);

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Transaction transaction_;
    };

} // namespace adb

#endif /* DELETETRANSACTION_H_ */
