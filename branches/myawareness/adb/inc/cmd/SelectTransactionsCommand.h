#ifndef SELECTTRANSACTIONSCOMMAND_H_
#define SELECTTRANSACTIONSCOMMAND_H_

#include "SelectCommand.h"

namespace adb {

    class SelectTransactionsCommand: public SelectCommand {
    public:
        SelectTransactionsCommand(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters);

    protected:
        virtual void buildSqlCommand();
    };

} // namespace adb

#endif /* SELECTTRANSACTIONSCOMMAND_H_ */
