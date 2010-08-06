#include <Configuration.h>
#include <SelectionParameters.h>

namespace adb {

SelectionParameters::SelectionParameters() :
    itemId_(Configuration::DEFAULT_ID), lastTrnsactionOnly_(false)
{
}

void SelectionParameters::setItemId(int val)
{
    itemId_ = val;
}

void SelectionParameters::setLastTransactionOnly(bool val)
{
    lastTrnsactionOnly_ = val;
}

} // namespace adb
