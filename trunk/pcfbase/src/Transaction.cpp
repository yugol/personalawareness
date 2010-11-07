#include <Exception.h>
#include <BaseUtil.h>
#include <Transaction.h>

Transaction::Transaction(int id) :
	Record(id), value_(0), sourceId_(0), destinationId_(0), itemId_(0)
{
}

void Transaction::setDate(const char* when)
{
	date_.setValue(when);
}

void Transaction::setDate(time_t when)
{
	date_.setValue(when);
}

void Transaction::setValue(double value)
{
	value_ = value;
}

void Transaction::setSourceId(int id)
{
	sourceId_ = id;
}

void Transaction::setDestinationId(int id)
{
	destinationId_ = id;
}

void Transaction::setItemId(int item)
{
	itemId_ = item;
}

void Transaction::setComment(const char* comment)
{
	assign(comment_, comment);
}

void Transaction::validate() const
{
	if (0 == value_) {
		THROW(BaseUtil::EMSG_WRONG_VALUE);
	}
	if (0 == sourceId_) {
		THROW(BaseUtil::EMSG_WRONG_VALUE);
	}
	if (0 == destinationId_) {
		THROW(BaseUtil::EMSG_WRONG_VALUE);
	}
	if (0 == itemId_) {
		THROW(BaseUtil::EMSG_WRONG_VALUE);
	}
	if (sourceId_ == destinationId_) {
		THROW(BaseUtil::EMSG_WRONG_VALUE);
	}
}

