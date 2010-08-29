#include <Exception.h>
#include <Item.h>

namespace adb {

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
            THROW(Exception::WRONG_NAME_MESSAGE);
        }
    }

} // namespace adb
