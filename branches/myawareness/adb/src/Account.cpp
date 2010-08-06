#include <iostream>
#include <Exception.h>
#include <Account.h>

using namespace std;

namespace adb {

Account::Account(int id) :
	Record(id), type_(ALL), initialValue_(0)
{
}

void Account::setType(Type type)
{
	type_ = type;
}

void Account::setInitialValue(double initialValue)
{
	initialValue_ = initialValue;
}

void Account::setName(const char *name)
{
	assign(name_, name);
}

void Account::setGroup(const char *group)
{
	assign(group_, group);
}

void Account::setDescription(const char *description)
{
	assign(description_, description);
}

void Account::print() const
{
	cout << id_ << " " << type_ << " " << name_ << " " << group_ << " " << initialValue_ << " " << description_ << endl;
}

const string Account::getFullName() const
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

void Account::validate() const
{
	if (ALL == type_) {
	    THROW(Exception::WRONG_VALUE_MESSAGE);
	}
	if (0 == name_.size()) {
	    THROW(Exception::WRONG_NAME_MESSAGE);
	}
}

} // namespace adb

