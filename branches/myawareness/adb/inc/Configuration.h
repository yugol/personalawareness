#ifndef CONFIGURATION_H_
#define CONFIGURATION_H_

#include <string>

namespace adb {

class Configuration {
public:
	static const char PROJECT_NAME[];
	static const char PROJECT_VERSION[];

	static const char ACCOUNTS_TABLE_NAME[];
	static const char ITEMS_TABLE_NAME[];
	static const char TRANSACTIONS_TABLE_NAME[];
	static const char INDEX_SUFFIX[];
	static const char ID_COLUMN_NAME[];
	static const char TYPE_COLUMN_NAME[];
	static const char NAME_COLUMN_NAME[];
	static const char GROUP_COLUMN_NAME[];
	static const char IVAL_COLUMN_NAME[];
	static const char DESC_COLUMN_NAME[];
	static const char LASTR_COLUMN_NAME[];
	static const char DATE_COLUMN_NAME[];
	static const char VAL_COLUMN_NAME[];
	static const char FROM_COLUMN_NAME[];
	static const char TO_COLUMN_NAME[];
	static const char ITEM_COLUMN_NAME[];

	static const int LINE_BUFFER_LENGTH = 5000;


	static Configuration* instance();

	virtual ~Configuration();

	const std::string& getConfigurationFilePath() const;
	bool existsConfigurationFile() const;
	const std::string& getLastDatabasePath() const;
	void setLastDatabasePath(const char* path);

private:
	static Configuration* instance_;

	std::string configurationFilePath_;
	std::string lastDatabasePath_;

	Configuration();
	Configuration(const Configuration&);
	void operator=(const Configuration&);

	void readConfiguration();
	void writeConfiguration();
};

inline const std::string& Configuration::getConfigurationFilePath() const
{
	return configurationFilePath_;
}

inline const std::string& Configuration::getLastDatabasePath() const
{
	return lastDatabasePath_;
}

}

#endif /* CONFIGURATIO_H_ */
