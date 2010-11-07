#ifndef ACCOUNT_H_
#define ACCOUNT_H_

#include "Configuration.h"
#include "Record.h"

class Account: public Record {
public:
    enum Type {
        EXPENSES = 0, ACCOUNT = 1, INCOME = 2, ALL
    };

    Account(int id = Configuration::DEFAULT_ID);

    int getType() const;
    const std::string& getName() const;
    std::string getFullName() const;
    std::string getDecoratedName() const;
    const std::string& getGroup() const;
    double getStartBalance() const;
    const std::string& getComment() const;

    void setType(Type);
    void setName(const char*);
    void setGroup(const char*);
    void setStartBalance(double);
    void setComment(const char*);

    virtual void validate() const;
    void print() const;

private:
    int type_;
    std::string name_;
    std::string group_;
    double startBalance_;
    std::string comment_;
};

inline int Account::getType() const
{
    return type_;
}

inline const std::string& Account::getName() const
{
    return name_;
}

inline const std::string& Account::getGroup() const
{
    return group_;
}

inline double Account::getStartBalance() const
{
    return startBalance_;
}

inline const std::string& Account::getComment() const
{
    return comment_;
}

#endif // ACCOUNT_H_
