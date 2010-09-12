#ifndef REVERSIBLEDATABASECOMMAND_H_
#define REVERSIBLEDATABASECOMMAND_H_

#include <string>
#include "DatabaseCommand.h"

class ReversibleDatabaseCommand: public DatabaseCommand {
public:
    ReversibleDatabaseCommand(sqlite3* database);

    virtual void unexecute();
    virtual std::string getDescription() const = 0;

protected:
    std::string reverseSql_;

    const char* getReverseSqlCommand();
    virtual void buildReverseSqlCommand() = 0;
};

#endif /* REVERSIBLEDATABASECOMMAND_H_ */
