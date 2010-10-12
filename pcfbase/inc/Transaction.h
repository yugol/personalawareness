#ifndef TRANSACTION_H
#define TRANSACTION_H

#include "Configuration.h"
#include "Date.h"
#include "Record.h"

class Transaction: public Record {
public:
    Transaction(int id = Configuration::DEFAULT_ID);

    const Date& getDate() const;
    double getValue() const;
    int getFromId() const;
    int getToId() const;
    int getItemId() const;
    const std::string& getComment() const;

    void setDate(const char* date);
    void setDate(time_t when);
    void setValue(double val);
    void setFromId(int from);
    void setToId(int to);
    void setItemId(int item);
    void setComment(const char* desc);

    void validate() const;

private:
    Date date_;
    double value_;
    int fromId_;
    int toId_;
    int itemId_;
    std::string comment_;

};

inline const Date& Transaction::getDate() const
{
    return date_;
}

inline double Transaction::getValue() const
{
    return value_;
}

inline int Transaction::getFromId() const
{
    return fromId_;
}

inline int Transaction::getToId() const
{
    return toId_;
}

inline int Transaction::getItemId() const
{
    return itemId_;
}

inline const std::string& Transaction::getComment() const
{
    return comment_;
}

#endif // TRANSACTION_H
