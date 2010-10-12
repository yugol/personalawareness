#ifndef UPDATETRANSACTION_H_
#define UPDATETRANSACTION_H_

#include <Transaction.h>
#include <ReversibleDatabaseCommand.h>

class UpdateTransaction: public ReversibleDatabaseCommand {
public:
    UpdateTransaction(sqlite3* database, const Transaction& transaction);

    virtual std::string getDescription() const;

protected:
    virtual void buildSqlCommand();
    virtual void buildReverseSqlCommand();

private:
    Transaction newTransaction_;
    Transaction previousTransaction_;

    void buildUpdateTransactionCommand(std::string& sql, const Transaction& transaction);
};

#endif /* UPDATETRANSACTION_H_ */
