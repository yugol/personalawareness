#ifndef SELECTITEMS_H_
#define SELECTITEMS_H_

#include "SelectCommand.h"

namespace adb {

    class SelectItems: public SelectCommand {
    public:
        SelectItems(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters);

    protected:
        virtual void buildSqlCommand();
    };

} // namespace adb

#endif /* SELECTITEMS_H_ */
