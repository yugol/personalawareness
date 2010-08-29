#include <cstdlib>
#include <SelectionParameters.h>
#include <cmd/SelectCommand.h>

using namespace std;

namespace adb {

    SelectCommand::SelectCommand(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters) :
        DatabaseCommand(database), selection_(selection), parameters_(parameters)
    {
    }

    static int readId(void *param, int colCount, char **values, char **names)
    {
        vector<int>* sel = reinterpret_cast<vector<int>*> (param);
        sel->push_back(::atoi(values[0]));
        return 0;
    }

    sqlite3_callback SelectCommand::getCallbackFunction()
    {
        return readId;
    }

    void* SelectCommand::getCallbackParameter()
    {
        return selection_;
    }

} // namespace adb
