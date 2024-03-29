#include <iostream>
#include <Exception.h>
#include <BaseUtil.h>
#include <Account.h>

using namespace std;

Account::Account(int id) :
    Record(id), type_(ALL), startBalance_(0)
{
}

void Account::setType(Type type)
{
    type_ = type;
}

void Account::setStartBalance(double value)
{
    startBalance_ = value;
}

void Account::setName(const char *name)
{
    assign(name_, name);
}

void Account::setGroup(const char *group)
{
    assign(group_, group);
}

void Account::setComment(const char *comment)
{
    assign(comment_, comment);
}

void Account::print() const
{
    cout << id_ << " " << type_ << " " << name_ << " " << group_ << " " << startBalance_ << " " << comment_ << endl;
}

string Account::getFullName() const
{
    if (group_.size() <= 0) {
        return name_;
    }
    string fullName(name_);
    fullName.append(" (");
    fullName.append(group_);
    fullName.append(")");
    return fullName;
}

string Account::getDecoratedName() const
{
    string name;
    switch (type_) {
        case INCOME:
            name.append("[+] ");
            name.append(getFullName());
            return name;
        case EXPENSES:
            name.append("[-] ");
            name.append(getFullName());
            return name;
        default:
            return getFullName();
    }
}

void Account::validate() const
{
    if (ALL == type_) {
        THROW(BaseUtil::EMSG_WRONG_VALUE);
    }
    if (0 == name_.size()) {
        THROW(BaseUtil::EMSG_WRONG_NAME);
    }
}

