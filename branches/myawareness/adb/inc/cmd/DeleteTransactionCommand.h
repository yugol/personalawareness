#ifndef DELETETRANSACTIONCOMMAND_H_
#define DELETETRANSACTIONCOMMAND_H_

#include <Transaction.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

class DeleteTransactionCommand: public adb::ReversibleDatabaseCommand {
public:
    DeleteTransactionCommand(sqlite3* database, int id);

protected:
    virtual void buildSqlCommand();
    virtual void buildReverseSqlCommand();

private:
    Transaction transaction_;
};

}

#endif /* DELETETRANSACTIONCOMMAND_H_ */
