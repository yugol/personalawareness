#include <Item.h>
#include <Exception.h>
#include <Configuration.h>
#include <cmd/SelectTransactionsCommand.h>
#include <cmd/GetLastTransactionCommand.h>

using namespace std;

namespace adb {

GetLastTransactionCommand::GetLastTransactionCommand(sqlite3* database, Item* item) :
    DatabaseCommand(database), item_(item), id_(Configuration::DEFAULT_ID)
{
}

void GetLastTransactionCommand::buildSqlCommand()
{
}

void GetLastTransactionCommand::execute()
{
    vector<int> sel;
    SelectionParameters params;
    params.setItemId(item_->getId());
    params.setLastTransactionOnly(true);
    SelectTransactionsCommand selectCmd(database_, &sel, &params);
    selectCmd.execute();
    if (sel.size() > 1) {
        THROW(Exception::WRONG_VALUE_MESSAGE);
    }
    if (sel.size() == 1) {
        id_ = sel[0];
    }
}

} // namespace adb
