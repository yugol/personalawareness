#include <Configuration.h>
#include <Account.h>
#include <SelectionParameters.h>

namespace adb {

    SelectionParameters::SelectionParameters() :
        itemId_(Configuration::DEFAULT_ID), lastTransactionOnly_(false), accountType_(Account::ALL), accountId_(Configuration::DEFAULT_ID)
    {
    }

    void SelectionParameters::setItemId(int val)
    {
        itemId_ = val;
    }

    void SelectionParameters::setLastTransactionOnly(bool val)
    {
        lastTransactionOnly_ = val;
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
        namePattern_ = pattern;
    }

} // namespace adb
