#include <cstdlib>
#include <sstream>
#include <fstream>
#include <ConfigurationBase.h>

using namespace std;

#ifdef WIN32
static const char HOME_PATH[] = "HOMEPATH";
static const char PATH_SEP[] = "\\";
#else
static const char HOME_PATH[] = "HOME";
static const char PATH_SEP[] = "/";
#endif

const char ConfigurationBase::CONFIGURATION_FILEEXT[] = ".awareness.cfg";

ConfigurationBase::ConfigurationBase()
{
    ostringstream sout;
    
#ifdef WIN32
	const char* homeDrive = ::getenv("HOMEDRIVE");
	const char* homePath = ::getenv("HOMEPATH");
	if (homeDrive && homePath) {
		sout << homeDrive << homePath << "\\" << CONFIGURATION_FILEEXT;
	}
#else
	const char* homePath = ::getenv("HOME");
	if (homeDrive && homePath) {
		sout << homePath << "/" << CONFIGURATION_FILEEXT;
	}
#endif

    configurationFileLocation_ = sout.rdbuf()->str();
	if (supportsConfigurationFile()) {
	    readConfigurationFile();
	}
}

ConfigurationBase::~ConfigurationBase()
{
}

bool ConfigurationBase::supportsConfigurationFile() const
{
	return (configurationFileLocation_.size() > 0);
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
