#ifndef SELECTIONPARAMETERS_H
#define SELECTIONPARAMETERS_H

#include "Date.h"

class SelectionParameters {
public:
    SelectionParameters();

    int getItemId() const;
    bool isLastTransactionOnly() const;
    bool isCheckUsage() const;
    int getAccountType() const;
    const Date& getFirstDate() const;
    const Date& getLastDate() const;
    int getAccountId() const;
    const std::string& getNamePattern() const;
    bool hasNamePattern() const;

    void setItemId(int);
    void setLastTransactionOnly(bool);
    void setCheckUsage(bool);
    void setAccountType(int type);
    void setFirstDate(time_t);
    void setLastDate(time_t);
    void setAccountId(int);
    void setNamePattern(const char*);

private:
    int itemId_;
    bool lastTransactionOnly_;
    bool checkUsage_;

    int accountType_;

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

inline bool SelectionParameters::isCheckUsage() const
{
    return checkUsage_;
}

inline int SelectionParameters::getAccountType() const
{
    return accountType_;
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

inline bool SelectionParameters::hasNamePattern() const
{
    return namePattern_.size() > 0;
}

#endif // SELECTIONPARAMETERS_H
