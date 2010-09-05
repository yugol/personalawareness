#ifndef INSERTTRANSACTIONCOMMAND_H_
#define INSERTTRANSACTIONCOMMAND_H_

#include <Transaction.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

    class InsertTransactionCommand: public ReversibleDatabaseCommand {
    public:
        static void buildSqlCommand(std::ostream& out, const Transaction& transaction);

        InsertTransactionCommand(sqlite3* database, const Transaction& transaction);

        const Transaction& getTransaction() const;

        virtual void execute();
        virtual void unexecute();

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Transaction transaction_;
    };

    inline const Transaction& InsertTransactionCommand::getTransaction() const
    {
        return transaction_;
    }

}

#endif /* INSERTTRANSACTIONCOMMAND_H_ */
