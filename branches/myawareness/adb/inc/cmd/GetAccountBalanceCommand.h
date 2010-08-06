#ifndef GETACCOUNTBALANCECOMMAND_H_
#define GETACCOUNTBALANCECOMMAND_H_

#include "DatabaseCommand.h"

namespace adb {

class Account;

class GetAccountBalanceCommand: public adb::DatabaseCommand {
public:
	GetAccountBalanceCommand(sqlite3* database, Account* account);

	virtual void execute();

	double getBalance() const;

protected:
	virtual void buildSqlCommand();

private:
	Account* account_;
	double balance_;
};

inline double GetAccountBalanceCommand::getBalance() const
{
	return balance_;
}

}

#endif /* GETACCOUNTBALANCECOMMAND_H_ */
