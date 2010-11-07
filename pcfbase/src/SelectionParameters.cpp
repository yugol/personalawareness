#include <Configuration.h>
#include <BaseUtil.h>
#include <Account.h>
#include <SelectionParameters.h>

SelectionParameters::SelectionParameters() :
	itemId_(Configuration::DEFAULT_ID), firstTransactionOnly_(false), lastTransactionOnly_(false), checkUsage_(false), accountType_(Account::ALL), accountId_(Configuration::DEFAULT_ID)
{
}

void SelectionParameters::setItemId(int value)
{
	itemId_ = value;
}

void SelectionParameters::setFirstTransactionOnly(bool value)
{
	firstTransactionOnly_ = value;
}

void SelectionParameters::setLastTransactionOnly(bool value)
{
	lastTransactionOnly_ = value;
}

void SelectionParameters::setCheckUsage(bool value)
{
	checkUsage_ = value;
}

void SelectionParameters::setAccountType(int type)
{
	accountType_ = type;
}

void SelectionParameters::setFirstDate(time_t when)
{
	firstDate_.setValue(when);
}

void SelectionParameters::setLastDate(time_t when)
{
	lastDate_.setValue(when);
}

void SelectionParameters::setAccountId(int id)
{
	accountId_ = id;
}

void SelectionParameters::setNamePattern(const char* pattern)
{
	BaseUtil::charPtrToString(namePattern_, pattern);
	BaseUtil::trimSpaces(namePattern_);
}

