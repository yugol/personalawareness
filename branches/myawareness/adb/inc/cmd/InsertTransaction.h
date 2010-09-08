#ifndef INSERTTRANSACTION_H_
#define INSERTTRANSACTION_H_

#include <Transaction.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

    class InsertTransaction: public ReversibleDatabaseCommand {
    public:
        static void buildSqlCommand(std::ostream& out, const Transaction& transaction);

        InsertTransaction(sqlite3* database, const Transaction& transaction);

        const Transaction& getTransaction() const;

        virtual void execute();
        virtual void unexecute();

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Transaction transaction_;
    };

    inline const Transaction& InsertTransaction::getTransaction() const
    {
        return transaction_;
    }

}

#endif /* INSERTTRANSACTION_H_ */
