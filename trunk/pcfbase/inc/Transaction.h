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
    int getSourceId() const;
    int getDestinationId() const;
    int getItemId() const;
    const std::string& getComment() const;

    void setDate(const char* date);
    void setDate(time_t when);
    void setValue(double val);
    void setSourceId(int id);
    void setDestinationId(int id);
    void setItemId(int item);
    void setComment(const char* desc);

    void validate() const;

private:
    Date date_;
    double value_;
    int sourceId_;
    int destinationId_;
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

inline int Transaction::getSourceId() const
{
    return sourceId_;
}

inline int Transaction::getDestinationId() const
{
    return destinationId_;
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
