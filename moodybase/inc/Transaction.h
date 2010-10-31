#ifndef TRANSACTION_H_
#define TRANSACTION_H_

#include <vector>

class Atom;
class Type;

class Transaction {
public:
    Transaction();
    ~Transaction();

    void add(Atom*);
    void add(Type*);

private:
    std::vector<Atom*> atoms_;
    std::vector<Type*> types_;
};

#endif /* TRANSACTION_H_ */
