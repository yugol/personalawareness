#ifndef SELECTACCOUNTSCOMMAND_H_
#define SELECTACCOUNTSCOMMAND_H_

#include "SelectCommand.h"

namespace adb {

class SelectAccountsCommand: public adb::SelectCommand {
public:
	SelectAccountsCommand(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters);

protected:
	virtual void buildSqlCommand();
};

}

#endif /* SELECTACCOUNTSCOMMAND_H_ */
