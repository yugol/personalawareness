#ifndef SELECTTRANSACTIONS_H_
#define SELECTTRANSACTIONS_H_

#include <SelectCommand.h>

class SelectTransactions: public SelectCommand {
public:
    SelectTransactions(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters);

protected:
    virtual void buildSqlCommand();
};

#endif /* SELECTTRANSACTIONS_H_ */
