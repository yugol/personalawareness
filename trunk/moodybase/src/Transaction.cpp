#include <Transaction.h>

Transaction::Transaction()
{
}

Transaction::~Transaction()
{
}

void Transaction::add(Atom* atom)
{
	atoms_.push_back(atom);
}

void Transaction::add(Type* type)
{
	types_.push_back(type);
}
