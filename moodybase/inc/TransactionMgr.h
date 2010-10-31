#ifndef TRANSACTIONMGR_H_
#define TRANSACTIONMGR_H_

#include <stack>

class Atom;
class Type;
class Memory;
class Transaction;

class TransactionMgr {
public:
    TransactionMgr(Memory* memory);
    ~TransactionMgr();

    void begin();
    void rollback();
    void commit();

    void add(Atom*);
    void add(Type*);

private:
    Transaction* current_;
    std::stack<Transaction*> transactions_;
    Memory* memory_;

    void pop();
};

#endif /* TRANSACTIONMGR_H_ */
