#ifndef SELECTACCOUNTS_H_
#define SELECTACCOUNTS_H_

#include <SelectCommand.h>

class SelectAccounts: public SelectCommand {
public:
    SelectAccounts(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters);

protected:
    virtual void buildSqlCommand();
};

#endif /* SELECTACCOUNTS_H_ */
