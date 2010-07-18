#ifndef CONFIGURATION_H_
#define CONFIGURATION_H_

#include <string>

namespace adb {

class Configuration {
public:
	static const char PROJECT_NAME[];
	static const char PROJECT_VERSION[];
	static const int LINE_BUFFER_LENGTH = 5000;

	static Configuration* instance();

	virtual ~Configuration();

	const std::string& getConfigurationFilePath() const;
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
