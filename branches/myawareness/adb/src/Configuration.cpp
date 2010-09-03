#include <cstdlib>
#include <sstream>
#include <fstream>
#include <Configuration.h>
#include <Exception.h>

using namespace std;

namespace adb {

    const char Configuration::PROJECT_NAME[] = "myawareness";
    const char Configuration::PROJECT_VERSION[] = "0.1";

    const char Configuration::ACCOUNTS_TABLE_NAME[] = "accounts";
    const char Configuration::ITEMS_TABLE_NAME[] = "items";
    const char Configuration::TRANSACTIONS_TABLE_NAME[] = "transactions";
    const char Configuration::INDEX_SUFFIX[] = "_index";
    const char Configuration::ID_COLUMN_NAME[] = "id";
    const char Configuration::DEL_COLUMN_NAME[] = "del";
    const char Configuration::TYPE_COLUMN_NAME[] = "type";
    const char Configuration::NAME_COLUMN_NAME[] = "name";
    const char Configuration::GROUP_COLUMN_NAME[] = "group";
    const char Configuration::IVAL_COLUMN_NAME[] = "ival";
    const char Configuration::DESC_COLUMN_NAME[] = "desc";
    const char Configuration::LASTR_COLUMN_NAME[] = "lastr";
    const char Configuration::DATE_COLUMN_NAME[] = "date";
    const char Configuration::VAL_COLUMN_NAME[] = "val";
    const char Configuration::FROM_COLUMN_NAME[] = "from";
    const char Configuration::TO_COLUMN_NAME[] = "to";
    const char Configuration::ITEM_COLUMN_NAME[] = "item";

    static const char HOME_ENVIRONMENT_VARIABLE_NAME[] = "HOME";

    Configuration* Configuration::instance_ = 0;

    Configuration* Configuration::instance()
    {
        if (0 == instance_) {
            instance_ = new Configuration();
        }
        return instance_;
    }

    Configuration::Configuration() :
        CURRENCY_SYMBOL("CU"), PREFIX_CURRENCY(false)
    {
        const char* homeFolder = ::getenv(HOME_ENVIRONMENT_VARIABLE_NAME);
        if (NULL == homeFolder) {
            THROW("HOME environment variable not found");
        } else {
            ostringstream sout;
            sout << homeFolder << "/." << PROJECT_NAME;
            configurationFilePath_ = sout.rdbuf()->str();
            readConfiguration();
        }
    }

    Configuration::~Configuration()
    {
    }

    bool Configuration::existsConfigurationFile() const
    {
        ifstream fin(configurationFilePath_.c_str());
        return fin.is_open();
    }

    void Configuration::setLastDatabasePath(const char* path)
    {
        lastDatabasePath_ = path;
        writeConfiguration();

        // this is for testing purpose (ensuring the configuration was actually written)
        lastDatabasePath_ = "";
        readConfiguration();
    }

    void Configuration::readConfiguration()
    {
        ifstream fin(configurationFilePath_.c_str());
        char buf[LINE_BUFFER_LENGTH];
        fin.getline(buf, LINE_BUFFER_LENGTH);
        lastDatabasePath_ = buf;
        fin.close();
    }

    void Configuration::writeConfiguration()
    {
        ofstream fout(configurationFilePath_.c_str(), ofstream::out | ofstream::trunc);
        fout << lastDatabasePath_ << endl;
        fout.close();
    }

} // namespac eadb
