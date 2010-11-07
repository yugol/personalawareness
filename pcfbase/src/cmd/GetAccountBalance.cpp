#include <Account.h>
#include <cmd/GetAccountIncome.h>
#include <cmd/GetAccountExpenses.h>
#include <cmd/GetAccountBalance.h>

GetAccountBalance::GetAccountBalance(sqlite3* database, const Account* account) :
    DatabaseCommand(database), account_(account), balance_(0)
{
}

void GetAccountBalance::buildSqlCommand()
{
}

void GetAccountBalance::execute()
{
    if (account_->getType() == Account::ACCOUNT) {
        GetAccountIncome incomeCmd(database_, account_);
        incomeCmd.execute();

        GetAccountExpenses expensesCmd(database_, account_);
        expensesCmd.execute();

        double income = incomeCmd.getBalance();
        double expenses = expensesCmd.getBalance();
        double startBalance = account_->getStartBalance();

        balance_ = startBalance + income - expenses;
    }
}

