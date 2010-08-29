#include <Exception.h>
#include <Transaction.h>

namespace adb {

    Transaction::Transaction(int id) :
        Record(id), value_(0), fromId_(0), toId_(0), itemId_(0)
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

    void Transaction::setFromId(int fromId)
    {
        fromId_ = fromId;
    }

    void Transaction::setToId(int toId)
    {
        toId_ = toId;
    }

    void Transaction::setItemId(int item)
    {
        itemId_ = item;
    }

    void Transaction::setDescription(const char* description)
    {
        assign(description_, description);
    }

    void Transaction::validate() const
    {
        if (0 == value_) {
            THROW(Exception::WRONG_VALUE_MESSAGE);
        }
        if (0 == fromId_) {
            THROW(Exception::WRONG_VALUE_MESSAGE);
        }
        if (0 == toId_) {
            THROW(Exception::WRONG_VALUE_MESSAGE);
        }
        if (0 == itemId_) {
            THROW(Exception::WRONG_VALUE_MESSAGE);
        }

        // TODO: check if source != destination
    }

} // namespace adb
