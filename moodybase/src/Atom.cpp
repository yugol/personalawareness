#include <Atom.h>

Atom::Atom(Type* type) :
    type_(type), args_(0)
{
}

Atom::~Atom()
{
}
