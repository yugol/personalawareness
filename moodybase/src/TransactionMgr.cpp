#include <Transaction.h>
#include <TransactionMgr.h>

TransactionMgr::TransactionMgr(Memory* memory) :
    current_(0), memory_(memory)
{
}

TransactionMgr::~TransactionMgr()
{
    while (!transactions_.empty()) {
        pop();
    }
}

void TransactionMgr::pop()
{
    current_ = transactions_.top();
    delete current_;
    transactions_.pop();

    if (transactions_.empty()) {
        current_ = 0;
    } else {
        current_ = transactions_.top();
    }
}

void TransactionMgr::begin()
{
    current_ = new Transaction();
    transactions_.push(current_);
}

void TransactionMgr::rollback()
{
    if (current_ != 0) {
        pop();
    }
}

void TransactionMgr::commit()
{
    if (current_ != 0) {
        pop();
    }
}

void TransactionMgr::add(Atom* atom)
{
    if (current_ != 0 && atom != 0) {
        current_->add(atom);
    }
}

void TransactionMgr::add(Type* type)
{
    if (current_ != 0 && type != 0) {
        current_->add(type);
    }
}

