#include <Transaction.h>
#include "util.h"

namespace adb {

Transaction::Transaction() :
	id_(-1)
{
}

Transaction::Transaction(int id) :
	id_(id)
{
}

Transaction::Transaction(const char *date, double val, int from, int to, int item, const char *desc) :
	id_(0), date_(date), value_(val), from_(from), to_(to), item_(item)
{
	charPtrToString(this->description_, desc);
}

Transaction::~Transaction()
{
	//dtor
}

void Transaction::setDescription(const char *desc)
{
	charPtrToString(this->description_, desc);
}

} // namespace adb
