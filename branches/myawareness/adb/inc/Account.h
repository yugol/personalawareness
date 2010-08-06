#ifndef ACCOUNT_H_
#define ACCOUNT_H_

#include "Record.h"

namespace adb {

class Account: public Record {
public:
    enum Type {
        DEBT = 0, ACCOUNT = 1, CREDIT = 2, ALL
    };

    Account(int id = Configuration::DEFAULT_ID);

    int getType() const;
    const std::string& getName() const;
    const std::string getFullName() const;
    const std::string& getGroup() const;
    double getInitialValue() const;
    const std::string& getDescription() const;

    void setType(Type);
    void setName(const char*);
    void setGroup(const char*);
    void setInitialValue(double);
    void setDescription(const char*);

    virtual void validate() const;
    void print() const;

private:
    int type_;
    std::string name_;
    std::string group_;
    double initialValue_;
    std::string description_;
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

inline double Account::getInitialValue() const
{
    return initialValue_;
}

inline const std::string& Account::getDescription() const
{
    return description_;
}

} // namespace adb

#endif // ACCOUNT_H_
