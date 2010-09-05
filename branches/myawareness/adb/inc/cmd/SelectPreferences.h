#ifndef SELECTPREFERENCES_H_
#define SELECTPREFERENCES_H_

#include <map>
#include <string>
#include "DatabaseCommand.h"

namespace adb {

    class SelectPreferences: public DatabaseCommand {
    public:
        SelectPreferences(sqlite3* database);
        virtual ~SelectPreferences();

        const std::string& operator[](const std::string& key);
        std::map<const std::string, const std::string>::iterator begin();
        std::map<const std::string, const std::string>::iterator end();

    protected:
        virtual sqlite3_callback getCallbackFunction();
        virtual void* getCallbackParameter();
        virtual void buildSqlCommand();

    private:
        std::map<const std::string, const std::string> preferences_;
    };

    inline const std::string& SelectPreferences::operator[](const std::string& key)
    {
        return preferences_[key];
    }

    inline std::map<const std::string, const std::string>::iterator SelectPreferences::begin()
    {
        return preferences_.begin();
    }
    inline std::map<const std::string, const std::string>::iterator SelectPreferences::end()
    {
        return preferences_.end();
    }
}

#endif /* SELECTPREFERENCES_H_ */
