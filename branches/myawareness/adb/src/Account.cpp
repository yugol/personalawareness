#include <iostream>
#include <Account.h>
#include "util.h"

using namespace std;

namespace adb {

Account::Account() :
	id_(-1)
{
}

Account::Account(int type, const char *name, const char *group, double ival, const char *desc) :
	id_(0), type_(type), initialValue_(ival)
{
	setName(name);
	setGroup(group);
	setDescription(desc);
}

Account::Account(int id, int type, const char *name, const char *group, double ival, const char *desc) :
	id_(id), type_(type), initialValue_(ival)
{
	setName(name);
	setGroup(group);
	setDescription(desc);
}

Account::~Account()
{
}

void Account::setId(int id)
{
	id_ = id;
}

void Account::setName(const char *name)
{
	adb::charPtrToString(name_, name);
}

void Account::setGroup(const char *group)
{
	adb::charPtrToString(group_, group);
}

void Account::setDescription(const char *desc)
{
	adb::charPtrToString(description_, desc);
}

void Account::print()
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

} // namespace adb

