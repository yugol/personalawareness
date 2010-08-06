#ifndef UPDATEITEMCOMMAND_H_
#define UPDATEITEMCOMMAND_H_

#include <Item.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

class UpdateItemCommand: public adb::ReversibleDatabaseCommand {
public:
	UpdateItemCommand(sqlite3* database, const Item& item);

protected:
	virtual void buildSqlCommand();
	virtual void buildReverseSqlCommand();

private:
	Item newItem_;
	Item previousItem_;

	void buildUpdateItemSqlCommand(std::string& sql, const Item& item);
};

} // namespace adb

#endif /* UPDATEITEMCOMMAND_H_ */
