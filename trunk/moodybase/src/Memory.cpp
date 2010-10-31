#include <Memory.h>

using namespace std;

Memory::Memory() :
	transactions_(this)
{
}

Memory::~Memory()
{
}

void Memory::beginTransaction()
{
	transactions_.begin();
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
