#ifndef SELECTITEMS_H_
#define SELECTITEMS_H_

#include <SelectCommand.h>

class SelectItems: public SelectCommand {
public:
    SelectItems(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters);

protected:
    virtual void buildSqlCommand();
};

#endif /* SELECTITEMS_H_ */
