#include <Account.h>
#include <cmd/GetAccountCreditCommand.h>
#include <cmd/GetAccountDebitCommand.h>
#include <cmd/GetAccountBalanceCommand.h>

namespace adb {

    GetAccountBalanceCommand::GetAccountBalanceCommand(sqlite3* database, Account* account) :
        DatabaseCommand(database), account_(account), balance_(0)
    {
    }

    void GetAccountBalanceCommand::buildSqlCommand()
    {
    }

    void GetAccountBalanceCommand::execute()
    {
        if (account_->getType() == Account::ACCOUNT) {
            GetAccountCreditCommand creditCmd(database_, account_);
            creditCmd.execute();

            GetAccountDebitCommand debitCmd(database_, account_);
            debitCmd.execute();

            double credit = creditCmd.getCredit();
            double debit = debitCmd.getDebit();
            double initialValue = account_->getInitialValue();

            balance_ = initialValue + credit - debit;
        }
    }

} // namespac eadb
