#ifndef UPDATETRANSACTIONCOMMAND_H_
#define UPDATETRANSACTIONCOMMAND_H_

#include <Transaction.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

    class UpdateTransactionCommand: public ReversibleDatabaseCommand {
    public:
        UpdateTransactionCommand(sqlite3* database, const Transaction& transaction);

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Transaction newTransaction_;
        Transaction previousTransaction_;

        void buildUpdateTransactionCommand(std::string& sql, const Transaction& transaction);
    };

} // namespace adb

#endif /* UPDATETRANSACTIONCOMMAND_H_ */
