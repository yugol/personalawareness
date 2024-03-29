#ifndef CONFIGURATION_H_
#define CONFIGURATION_H_

#include <ConfigurationBase.h>

class Configuration: public ConfigurationBase {
public:
	// utilities
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
	static const bool DEFAULT_HIDE_ZERO_BALANCE_ACCOUNTS;
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
	static const char PREF_HIDE_ZERO_BALANCE_ACCOUNTS[];

	static Configuration* instance();

	virtual ~Configuration();

	const std::string& getLastDatabaseLocation() const;
	const std::string& getCurrencySymbol() const;
	bool isPrefixCurrency() const;
	bool isCompactTransactions() const;
	bool isCompareAsciiOnly() const;
	bool isHideZeroBalanceAccounts() const;

	void setLastDatabaseLocation(const char*);
	void setCurrencySymbol(const char*);
	void setPrefixCurrency(const char*);
	void setCompactTransactions(const char*);
	void setCompareAsciiOnly(const char*);
	void setHideZeroBalanceAccounts(const char* cstr);
	void setPrefixCurrency(bool);
	void setCompactTransactions(bool);
	void setCompareAsciiOnly(bool);
	void setHideZeroBalanceAccounts(bool);

private:
	static Configuration* instance_;

	std::string currencySymbol_;
	bool prefixCurrency_;
	bool compactTransactions_;
	bool compareAsciiOnly_;
	bool hideZeroBalanceAccounts_;

	Configuration();
	Configuration(const Configuration&);
	void operator=(const Configuration&);
};

inline const std::string& Configuration::getLastDatabaseLocation() const
{
	return lastDatabaseLocation_;
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

inline bool Configuration::isHideZeroBalanceAccounts() const
{
	return hideZeroBalanceAccounts_;
}

#endif /* CONFIGURATIO_H_ */
