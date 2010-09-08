#ifndef SELECTACCOUNTS_H_
#define SELECTACCOUNTS_H_

#include "SelectCommand.h"

namespace adb {

    class SelectAccounts: public SelectCommand {
    public:
        SelectAccounts(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters);

    protected:
        virtual void buildSqlCommand();
    };

} // namespace adb

#endif /* SELECTACCOUNTS_H_ */
