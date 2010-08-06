#ifndef DELETEACCOUNTCOMMAND_H_
#define DELETEACCOUNTCOMMAND_H_

#include <Account.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

class DeleteAccountCommand: public adb::ReversibleDatabaseCommand {
public:
	DeleteAccountCommand(sqlite3* database, int id);

protected:
	virtual void buildSqlCommand();
	virtual void buildReverseSqlCommand();

private:
	Account account_;
};

} // namespace adb

#endif /* DELETEACCOUNTCOMMAND_H_ */
