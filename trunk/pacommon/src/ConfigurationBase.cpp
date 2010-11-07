#include <cstdlib>
#include <sstream>
#include <fstream>
#include <ConfigurationBase.h>

using namespace std;

static const char HOME_ENVIRONMENT_VARIABLE_NAME[] = "HOME";

const char ConfigurationBase::CONFIGURATION_FILEEXT[] = ".awareness.cfg";

ConfigurationBase::ConfigurationBase()
{
    if (supportsConfigurationFile()) {
        ostringstream sout;
        sout << ::getenv(HOME_ENVIRONMENT_VARIABLE_NAME) << "/" << CONFIGURATION_FILEEXT;
        configurationFileLocation_ = sout.rdbuf()->str();
        readConfigurationFile();
    }
}

ConfigurationBase::~ConfigurationBase()
{
}

bool ConfigurationBase::supportsConfigurationFile() const
{
    return (::getenv(HOME_ENVIRONMENT_VARIABLE_NAME) != NULL);
}

bool ConfigurationBase::existsConfigurationFile() const
{
    ifstream fin(configurationFileLocation_.c_str());
    return fin.is_open();
}

void ConfigurationBase::createConfigurationFile()
{
    ofstream fout(configurationFileLocation_.c_str(), ofstream::out | ofstream::trunc);
    fout.close();
}

void ConfigurationBase::deleteConfigurationFile()
{
    ::remove(configurationFileLocation_.c_str());
}

void ConfigurationBase::readConfigurationFile()
{
    if (existsConfigurationFile()) {
        ifstream fin(configurationFileLocation_.c_str());
        char buf[LINE_BUFFER_LENGTH];
        fin.getline(buf, LINE_BUFFER_LENGTH);
        lastDatabaseLocation_ = buf;
        fin.close();
    }
}

void ConfigurationBase::writeConfigurationFile()
{
    if (existsConfigurationFile()) {
        ofstream fout(configurationFileLocation_.c_str(), ofstream::out | ofstream::trunc);
        fout << lastDatabaseLocation_ << endl;
        fout.close();
    }
}
