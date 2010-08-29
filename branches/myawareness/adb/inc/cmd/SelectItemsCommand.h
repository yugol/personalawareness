#ifndef SELECTITEMSCOMMAND_H_
#define SELECTITEMSCOMMAND_H_

#include "SelectCommand.h"

namespace adb {

    class SelectItemsCommand: public SelectCommand {
    public:
        SelectItemsCommand(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters);

    protected:
        virtual void buildSqlCommand();
    };

} // namespace adb

#endif /* SELECTITEMSCOMMAND_H_ */
