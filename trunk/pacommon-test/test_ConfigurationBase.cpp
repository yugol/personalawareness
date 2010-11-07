#include <cstdio>
#include <ConfigurationBase.h>
#include "_test.h"

TEST(basic, ConfigurationBase)
{
	ConfigurationBase cb;
	CHECK(cb.supportsConfigurationFile());

	bool prevCfgFile = cb.existsConfigurationFile();
	string altCfgFile;
	if (prevCfgFile) {
		altCfgFile = cb.getConfigurationFileLocation();
		altCfgFile.append(1, '~');
		::rename(cb.getConfigurationFileLocation().c_str(), altCfgFile.c_str());
	}
	CHECK(!cb.existsConfigurationFile());

	cb.createConfigurationFile();
	CHECK(cb.existsConfigurationFile());

	cb.deleteConfigurationFile();
	CHECK(!cb.existsConfigurationFile());

	if (prevCfgFile) {
		::rename(altCfgFile.c_str(), cb.getConfigurationFileLocation().c_str());
	}
}
