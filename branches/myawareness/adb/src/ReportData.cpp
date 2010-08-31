#include <algorithm>
#include <Transaction.h>
#include <DatabaseConnection.h>
#include <ReportData.h>

using namespace std;

namespace adb {

    ReportData::ReportData(int chart, int direction, const SelectionParameters& parameters) :
        chart_(chart), direction_(direction), parameters_(parameters)
    {
    }

    ReportData::~ReportData()
    {
    }

    void ReportData::acquire()
    {
        data_.clear();

        switch (direction_) {
            case INCOME:
                parameters_.setAccountType(Account::CREDIT);
                break;
            case EXPENSES:
                parameters_.setAccountType(Account::DEBT);
                break;
            default:
                parameters_.setAccountType(Account::ACCOUNT);
        }

        vector<int> sel;
        DatabaseConnection::instance()->selectTransactions(&sel, &parameters_);

        switch (chart_) {
            case PIE:
                fetchPieData(sel);
                break;
            case MONTHLY:
                fetchMonthlyData(sel);
                break;
        }
    }

    void ReportData::fetchPieData(const vector<int>& sel)
    {
        if (sel.size() <= 0) {
            return;
        }

        vector<int> accIds;
        DatabaseConnection::instance()->selectAccounts(&accIds, 0);
        int maxId = *max_element(accIds.begin(), accIds.end());

        data_.resize(maxId + 1, 0);

        vector<int>::const_iterator it;
        for (it = sel.begin(); it != sel.end(); ++it) {
            Transaction t(*it);
            DatabaseConnection::instance()->getTransaction(&t);
            int accountId = t.getFromId();
            if (direction_ == EXPENSES) {
                accountId = t.getToId();
            }
            data_[accountId] += t.getValue();
        }
    }

    void ReportData::fetchMonthlyData(const vector<int>& sel)
    {
        if (sel.size() <= 0) {
            return;
        }

        Transaction first(sel[0]);
        DatabaseConnection::instance()->getTransaction(&first);

        Transaction last(sel[sel.size() - 1]);
        DatabaseConnection::instance()->getTransaction(&last);

        data_.resize(Date::monthDifference(first.getDate(), last.getDate()) + 1, 0);

        vector<int>::const_iterator it;
        for (it = sel.begin(); it != sel.end(); ++it) {
            Transaction t(*it);
            DatabaseConnection::instance()->getTransaction(&t);
            data_[Date::monthDifference(first.getDate(), t.getDate())] += t.getValue();
        }
    }

} // namespac adb
