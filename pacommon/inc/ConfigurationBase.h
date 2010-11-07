#ifndef CONFIGURATIONBASE_H_
#define CONFIGURATIONBASE_H_

#include <string>

class ConfigurationBase {
public:
    static const int LINE_BUFFER_LENGTH = 10000;
    static const char CONFIGURATION_FILEEXT[];

    ConfigurationBase();
    virtual ~ConfigurationBase();

    bool supportsConfigurationFile() const;
    const std::string& getConfigurationFileLocation() const;
    bool existsConfigurationFile() const;
    void createConfigurationFile();
    void deleteConfigurationFile();
    void readConfigurationFile();
    void writeConfigurationFile();

protected:
    // Personal Cash Flow
    std::string lastDatabaseLocation_;

private:
    std::string configurationFileLocation_;
};

inline const std::string& ConfigurationBase::getConfigurationFileLocation() const
{
    return configurationFileLocation_;
}

#endif /* CONFIGURATIONBASE_H_ */
