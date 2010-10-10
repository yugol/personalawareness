#include <Configuration.h>
#include <BaseUtil.h>
#include <Account.h>
#include <SelectionParameters.h>

SelectionParameters::SelectionParameters() :
	itemId_(Configuration::DEFAULT_ID), firstTransactionOnly_(false), lastTransactionOnly_(false), checkUsage_(false), accountType_(Account::ALL), accountId_(Configuration::DEFAULT_ID)
{
}

void SelectionParameters::setItemId(int val)
{
	itemId_ = val;
}

void SelectionParameters::setFirstTransactionOnly(bool val)
{
	firstTransactionOnly_ = val;
}

void SelectionParameters::setLastTransactionOnly(bool val)
{
	lastTransactionOnly_ = val;
}

void SelectionParameters::setCheckUsage(bool val)
{
	checkUsage_ = val;
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

