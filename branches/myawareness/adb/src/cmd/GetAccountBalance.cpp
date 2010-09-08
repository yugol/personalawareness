#include <Account.h>
#include <cmd/GetAccountCredit.h>
#include <cmd/GetAccountDebit.h>
#include <cmd/GetAccountBalance.h>

namespace adb {

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
            GetAccountCredit creditCmd(database_, account_);
            creditCmd.execute();

            GetAccountDebit debitCmd(database_, account_);
            debitCmd.execute();

            double credit = creditCmd.getCredit();
            double debit = debitCmd.getDebit();
            double initialValue = account_->getInitialValue();

            balance_ = initialValue + credit - debit;
        }
    }

} // namespac eadb
