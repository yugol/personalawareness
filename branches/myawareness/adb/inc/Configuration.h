#ifndef CONFIGURATION_H_
#define CONFIGURATION_H_

#include <string>

class Configuration {
public:
    // utilities
    static const int LINE_BUFFER_LENGTH = 10000;
    static const int DEFAULT_ID = 0;
    // defaults
    static const char PROJECT_MARKER[]; // used for database identification
    static const char PROJECT_NAME[];
    static const char PROJECT_VERSION[];
    static const char PROJECT_DATABASE_VERSION[];
    static const char DEFAULT_CURRENCY_SYMBOL[];
    static const bool DEFAULT_PREFIX_CURRENCY;
    static const bool DEFAULT_COMPACT_TRNSACTIONS;
    static const bool DEFAULT_COMPARE_ASCII_ONLY;
    // tables
    static const char TABLE_PREFERENCES[];
    static const char TABLE_ACCOUNTS[];
    static const char TABLE_ITEMS[];
    static const char TABLE_TRANSACTIONS[];
    // indexes
    static const char INDEX_MARKER[];
    // columns
    static const char COLUMN_ID[];
    static const char COLUMN_DELETED[];
    static const char COLUMN_TYPE[];
    static const char COLUMN_NAME[];
    static const char COLUMN_GROUP[];
    static const char COLUMN_BALANCE[];
    static const char COLUMN_COMMENT[];
    static const char COLUMN_TRANSACTION[];
    static const char COLUMN_DATE[];
    static const char COLUMN_VALUE[];
    static const char COLUMN_SOURCE[];
    static const char COLUMN_DESTINATION[];
    static const char COLUMN_ITEM[];
    // preference names
    static const char PREF_PROJECT_MARKER[];
    static const char PREF_DATABASE_VERSION[];
    static const char PREF_CURRENCY_SYMBOL[];
    static const char PREF_PREFIX_CURRENCY[];
    static const char PREF_COMPACT_TRNSACTIONS[];
    static const char PREF_COMPARE_ASCII_ONLY[];

    static Configuration* instance();

    virtual ~Configuration();

    bool existsConfigurationFile() const;
    const std::string& getConfigurationFilePath() const;
    const std::string& getLastDatabasePath() const;
    const std::string& getCurrencySymbol() const;
    bool isPrefixCurrency() const;
    bool isCompactTransactions() const;
    bool isCompareAsciiOnly() const;

    void setLastDatabasePath(const char*);
    void setCurrencySymbol(const char*);
    void setPrefixCurrency(const char*);
    void setCompactTransactions(const char*);
    void setCompareAsciiOnly(const char*);
    void setPrefixCurrency(bool);
    void setCompactTransactions(bool);
    void setCompareAsciiOnly(bool);

private:
    static Configuration* instance_;

    std::string configurationFilePath_;
    std::string lastDatabasePath_;

    std::string currencySymbol_;
    bool prefixCurrency_;
    bool compactTransactions_;
    bool compareAsciiOnly_;

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

inline const std::string& Configuration::getCurrencySymbol() const
{
    return currencySymbol_;
}

inline bool Configuration::isPrefixCurrency() const
{
    return prefixCurrency_;
}

inline bool Configuration::isCompactTransactions() const
{
    return compactTransactions_;
}

inline bool Configuration::isCompareAsciiOnly() const
{
    return compareAsciiOnly_;
}

#endif /* CONFIGURATIO_H_ */
