#ifndef REVERSIBLEDATABASECOMMAND_H_
#define REVERSIBLEDATABASECOMMAND_H_

#include "DatabaseCommand.h"

namespace adb {

    class ReversibleDatabaseCommand: public DatabaseCommand {
    public:
        ReversibleDatabaseCommand(sqlite3* database);

        virtual void unexecute();

    protected:
        std::string reverseSql_;

        const char* getReverseSqlCommand();
        virtual void buildReverseSqlCommand() = 0;
    };

} // namespace adb

#endif /* REVERSIBLEDATABASECOMMAND_H_ */