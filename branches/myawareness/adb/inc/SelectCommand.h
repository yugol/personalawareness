#ifndef SELECTCOMMAND_H_
#define SELECTCOMMAND_H_

#include <vector>
#include "DatabaseCommand.h"

class SelectionParameters;

class SelectCommand: public DatabaseCommand {
public:
    SelectCommand(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters);

protected:
    std::vector<int>* selection_;
    const SelectionParameters* parameters_;

    virtual sqlite3_callback getCallbackFunction();
    virtual void* getCallbackParameter();
};

#endif /* SELECTCOMMAND_H_ */
