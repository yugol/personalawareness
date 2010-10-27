#include <fstream>
#include <iostream>
#include <Configuration.h>
#include "_test.h"

TEST ( File, Configuration )
{
	CHECK( Configuration::instance()->supportsConfigurationFile() );

	bool prevCfgFile = Configuration::instance()->existsConfigurationFile();
	string prevLastDatabasePath;
	if (prevCfgFile) {
		prevLastDatabasePath = Configuration::instance()->getLastDatabasePath();
	} else {
		Configuration::instance()->createConfigurationFile();
	}

	string expectedDatabasePath("test database path");
	Configuration::instance()->setLastDatabasePath(expectedDatabasePath.c_str());
	Configuration::instance()->readConfigurationFile();
	string actualDatabasePath = Configuration::instance()->getLastDatabasePath();
	CHECK( expectedDatabasePath == actualDatabasePath );

	if (prevCfgFile) {
		Configuration::instance()->setLastDatabasePath(prevLastDatabasePath.c_str());
	} else {
		Configuration::instance()->deleteConfigurationFile();
	}
}
