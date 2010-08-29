#ifndef ITEM_H
#define ITEM_H

#include "Configuration.h"
#include "Record.h"

namespace adb {

    class Item: public Record {
    public:
        Item(int id = Configuration::DEFAULT_ID);

        const std::string& getName() const;
        int getLastTransactionId() const;

        void setName(const char*);
        void setLastTransactionId(int);

        void validate() const;

    private:
        std::string name_;
        int lastTransactionId_;
    };

    inline const std::string& Item::getName() const
    {
        return name_;
    }

    inline int Item::getLastTransactionId() const
    {
        return lastTransactionId_;
    }

} // namespace adb

#endif // ITEM_H
