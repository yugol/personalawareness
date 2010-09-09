#ifndef UPDATEPREFERENCE_H_
#define UPDATEPREFERENCE_H_

#include <ostream>
#include <DatabaseCommand.h>

namespace adb {

    class UpdatePreference: public adb::DatabaseCommand {
    public:
        static void buildSqlCommand(std::ostream& out, const std::string& name, const std::string& value);

        UpdatePreference(sqlite3* database, const char* name, const char* value);
        virtual ~UpdatePreference();

    protected:
        virtual void buildSqlCommand();

    private:
        std::string name_;
        std::string value_;
    };

}

#endif /* UPDATEPREFERENCE_H_ */
