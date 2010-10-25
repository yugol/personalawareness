#include <sstream>
#include <Configuration.h>
#include <BaseUtil.h>
#include <cmd/GetTransaction.h>
#include <cmd/UpdateTransaction.h>

using namespace std;

UpdateTransaction::UpdateTransaction(sqlite3* database, const Transaction& transaction) :
	ReversibleDatabaseCommand(database), newTransaction_(transaction)
{
	newTransaction_.validate();
	previousTransaction_.setId(newTransaction_.getId());
	GetTransaction(database_, &previousTransaction_).execute();
}

void UpdateTransaction::buildUpdateTransactionCommand(string& sql, const Transaction& transaction)
{
	ostringstream sout;

	sout << "UPDATE [" << Configuration::TABLE_TRANSACTIONS << "] ";
	sout << "SET ";
	sout << "[" << Configuration::COLUMN_DATE << "] = '" << transaction.getDate() << "', ";
	sout << "[" << Configuration::COLUMN_VALUE << "] = " << transaction.getValue() << ", ";
	sout << "[" << Configuration::COLUMN_SOURCE << "] = " << transaction.getFromId() << ", ";
	sout << "[" << Configuration::COLUMN_DESTINATION << "] = " << transaction.getToId() << ", ";
	sout << "[" << Configuration::COLUMN_ITEM << "] = " << transaction.getItemId() << ", ";
	sout << "[" << Configuration::COLUMN_COMMENT << "] = " << BaseUtil::toDbParameter(transaction.getComment()) << " ";
	sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << transaction.getId() << ";" << endl;

	sql = sout.rdbuf()->str();
}

void UpdateTransaction::buildSqlCommand()
{
	buildUpdateTransactionCommand(sql_, newTransaction_);
}

void UpdateTransaction::buildReverseSqlCommand()
{
	buildUpdateTransactionCommand(reverseSql_, previousTransaction_);
}

string UpdateTransaction::getDescription() const
{
	return "update transaction";
}
