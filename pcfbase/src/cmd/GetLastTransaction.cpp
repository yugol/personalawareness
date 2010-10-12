#include <Item.h>
#include <Exception.h>
#include <Configuration.h>
#include <BaseUtil.h>
#include <SelectionParameters.h>
#include <cmd/SelectTransactions.h>
#include <cmd/GetLastTransaction.h>

using namespace std;

GetLastTransaction::GetLastTransaction(sqlite3* database, Item* item) :
    DatabaseCommand(database), item_(item), id_(Configuration::DEFAULT_ID)
{
}

void GetLastTransaction::buildSqlCommand()
{
}

void GetLastTransaction::execute()
{
    vector<int> sel;
    SelectionParameters params;
    params.setItemId(item_->getId());
    params.setLastTransactionOnly(true);
    SelectTransactions selectCmd(database_, &sel, &params);
    selectCmd.execute();
    if (sel.size() > 1) {
        THROW(BaseUtil::EMSG_WRONG_VALUE);
    }
    if (sel.size() == 1) {
        id_ = sel[0];
    }
}

