#ifndef SELECTIONPARAMETERS_H
#define SELECTIONPARAMETERS_H

#include "Date.h"

namespace adb {

    class SelectionParameters {
    public:
        SelectionParameters();

        int getItemId() const;
        bool isLastTransactionOnly() const;
        const Date& getFirstDate() const;
        const Date& getLastDate() const;
        int getAccountId() const;
        const std::string& getNamePattern() const;

        void setItemId(int);
        void setLastTransactionOnly(bool);
        void setFirstDate(time_t when);
        void setLastDate(time_t when);
        void setAccountId(int id);
        void setNamePattern(const char* pattern);

    private:
        int itemId_;
        bool lastTransactionOnly_;

        Date firstDate_;
        Date lastDate_;
        int accountId_;
        std::string namePattern_;
    };

    inline int SelectionParameters::getItemId() const
    {
        return itemId_;
    }

    inline bool SelectionParameters::isLastTransactionOnly() const
    {
        return lastTransactionOnly_;
    }

    inline const Date& SelectionParameters::getFirstDate() const
    {
        return firstDate_;
    }

    inline const Date& SelectionParameters::getLastDate() const
    {
        return lastDate_;
    }

    inline int SelectionParameters::getAccountId() const
    {
        return accountId_;
    }

    inline const std::string& SelectionParameters::getNamePattern() const
    {
        return namePattern_;
    }

} // namespace adb

#endif // SELECTIONPARAMETERS_H
