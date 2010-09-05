#include <fstream>
#include <iostream>
#include <Configuration.h>
#include "_test.h"

TEST ( File, Configuration )
{
	try {

		const string& path = Configuration::instance()->getConfigurationFilePath();
		int pos = path.find(Configuration::PROJECT_NAME);
		CHECK( pos >= 0 );

		const string& tmpDatabasePath = Configuration::instance()->getLastDatabasePath();

		string expectedDatabasePath("test database path");
		Configuration::instance()->setLastDatabasePath(expectedDatabasePath.c_str());
		ifstream cfgFile(path.c_str());
		CHECK( cfgFile.is_open() );

		const string& actualDatabasePath = Configuration::instance()->getLastDatabasePath();
		CHECK( expectedDatabasePath == actualDatabasePath );

		Configuration::instance()->setLastDatabasePath(tmpDatabasePath.c_str());

	} catch (const exception& ex) {
		cerr << ex.what() << endl;
	}
}
