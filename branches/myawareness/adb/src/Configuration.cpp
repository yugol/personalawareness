#include <cstdlib>
#include <sstream>
#include <fstream>
#include <Configuration.h>
#include <Exception.h>

using namespace std;

namespace adb {

const char Configuration::PROJECT_NAME[] = "myawareness";
const char Configuration::PROJECT_VERSION[] = "0.1";

static const char HOME_ENVIRONMENT_VARIABLE_NAME[] = "HOME";

Configuration* Configuration::instance_ = 0;

Configuration* Configuration::instance()
{
	if (0 == instance_) {
		instance_ = new Configuration();
	}
	return instance_;
}

Configuration::Configuration()
{
	const char* homeFolder = ::getenv(HOME_ENVIRONMENT_VARIABLE_NAME);
	if (NULL == homeFolder) {
		throw Exception("HOME environment variable not found");
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

}
