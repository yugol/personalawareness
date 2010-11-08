#include <Memory.h>

using namespace std;

Memory::Memory() :
    facts_(&types_), transactions_(this)
{
}

Memory::~Memory()
{
}

void Memory::beginTransaction()
{
    transactions_.begin();
}

Type* Memory::createType(const std::string& id)
{
    Type* type = types_.createType(id);
    transactions_.add(type);
    return type;
}

Atom* Memory::createAtom(Type* type)
{
    Atom* atom = facts_.createAtom(type);
    transactions_.add(atom);
    return atom;
}

void Memory::rollbackTransaction()
{
    transactions_.rollback();
}

void Memory::commitTransaction()
{
    transactions_.commit();
}

ostream& Memory::dumpTypesDot(ostream& out)
{
    return types_.dumpDot(out);
}

