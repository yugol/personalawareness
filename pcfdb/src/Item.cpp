#include <Exception.h>
#include <Item.h>

Item::Item(int id) :
    Record(id), lastTransactionId_(Configuration::DEFAULT_ID)
{
}

void Item::setName(const char* name)
{
    assign(name_, name);
}

void Item::setLastTransactionId(int lastTransactionId)
{
    lastTransactionId_ = lastTransactionId;
}

void Item::validate() const
{
    if (0 == name_.size()) {
        THROW(Exception::EMSG_WRONG_NAME);
    }
}

