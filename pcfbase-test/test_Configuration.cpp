#include <fstream>
#include <iostream>
#include <Configuration.h>
#include "_test.h"

TEST ( File, Configuration )
{
	CHECK( Configuration::instance()->supportsConfigurationFile() );

	bool prevCfgFile = Configuration::instance()->existsConfigurationFile();
	string prevDatabaseLocation;
	if (prevCfgFile) {
		prevDatabaseLocation = Configuration::instance()->getLastDatabaseLocation();
	} else {
		Configuration::instance()->createConfigurationFile();
	}

	string expectedDatabaseLocation("test database location");
	Configuration::instance()->setLastDatabaseLocation(expectedDatabaseLocation.c_str());
	Configuration::instance()->readConfigurationFile();
	string actualDatabaseLocation = Configuration::instance()->getLastDatabaseLocation();
	CHECK( expectedDatabaseLocation == actualDatabaseLocation );

	if (prevCfgFile) {
		Configuration::instance()->setLastDatabaseLocation(prevDatabaseLocation.c_str());
	} else {
		Configuration::instance()->deleteConfigurationFile();
	}
}
