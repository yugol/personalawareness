/*
 * To add a new preference to the database:
 * - export the old database as SQL
 * - add the preference support in Configuration class
 *   - add Configuration::PREF_ variable
 *   - add Configuration::DEFAULT_ variable
 *   - add Configuration::_ attribute
 *   - add getter and setter member functions
 * - update CreateDatabase::buildSqlCommand function to insert the new preference
 * - update DatabaseConnection::readPreferences function to read the new preference from the database
 * - update DatabaseConnection::writePreferences function to write the new preference to database
 * - update Configuration::PROJECT_DATABASE_VERSION
 * - create a new database
 * - import database from SQL script
 */

#include <Configuration.h>
#include <Exception.h>
#include <BaseUtil.h>

using namespace std;

Configuration* Configuration::instance_ = 0;

// defaults
const char Configuration::PROJECT_MARKER[] =
        "5A08548C-B8C3-11DF-8AC9-BD12E0D72085-PERSONALAWARENESS";
const char Configuration::PROJECT_NAME[] = "Personal Cash Flow";
const char Configuration::PROJECT_VERSION[] = "1.0.0 alpha";
const char Configuration::PROJECT_DATABASE_VERSION[] = "1.0.0";
const char Configuration::DEFAULT_CURRENCY_SYMBOL[] = "'";
const bool Configuration::DEFAULT_PREFIX_CURRENCY = false;
const bool Configuration::DEFAULT_COMPACT_TRNSACTIONS = false;
const bool Configuration::DEFAULT_COMPARE_ASCII_ONLY = false;
const bool Configuration::DEFAULT_HIDE_ZERO_BALANCE_ACCOUNTS = false;

// tables
const char Configuration::TABLE_PREFERENCES[] = "preferences";
const char Configuration::TABLE_ACCOUNTS[] = "accounts";
const char Configuration::TABLE_ITEMS[] = "items";
const char Configuration::TABLE_TRANSACTIONS[] = "transactions";
// indexes
const char Configuration::INDEX_MARKER[] = "_index";
// columns
const char Configuration::COLUMN_ID[] = "id";
const char Configuration::COLUMN_DELETED[] = "del";
const char Configuration::COLUMN_TYPE[] = "type";
const char Configuration::COLUMN_NAME[] = "name";
const char Configuration::COLUMN_GROUP[] = "group";
const char Configuration::COLUMN_BALANCE[] = "ival";
const char Configuration::COLUMN_COMMENT[] = "desc";
const char Configuration::COLUMN_DATE[] = "date";
const char Configuration::COLUMN_VALUE[] = "val";
const char Configuration::COLUMN_SOURCE[] = "from";
const char Configuration::COLUMN_DESTINATION[] = "to";
const char Configuration::COLUMN_ITEM[] = "item";
// preference names
const char Configuration::PREF_PROJECT_MARKER[] = "PROJECT_MARKER";
const char Configuration::PREF_DATABASE_VERSION[] = "DATABASE_VERSION";
const char Configuration::PREF_CURRENCY_SYMBOL[] = "CURRENCY_SYMBOL";
const char Configuration::PREF_PREFIX_CURRENCY[] = "PREFIX_CURRENCY";
const char Configuration::PREF_COMPACT_TRNSACTIONS[] = "COMPACT_TRNSACTIONS";
const char Configuration::PREF_COMPARE_ASCII_ONLY[] = "COMPARE_ASCII_ONLY";
const char Configuration::PREF_HIDE_ZERO_BALANCE_ACCOUNTS[] = "PREF_HIDE_ZERO_BALANCE_ACCOUNTS";

Configuration* Configuration::instance()
{
    if (0 == instance_) {
        instance_ = new Configuration();
    }
    return instance_;
}

Configuration::Configuration() :
    currencySymbol_(DEFAULT_CURRENCY_SYMBOL), prefixCurrency_(DEFAULT_PREFIX_CURRENCY),
            compactTransactions_(DEFAULT_COMPACT_TRNSACTIONS), compareAsciiOnly_(
                    DEFAULT_COMPARE_ASCII_ONLY), hideZeroBalanceAccounts_(
                    DEFAULT_HIDE_ZERO_BALANCE_ACCOUNTS)
{
}

Configuration::~Configuration()
{
}

void Configuration::setLastDatabaseLocation(const char* location)
{
    BaseUtil::charPtrToString(lastDatabaseLocation_, location);
    BaseUtil::trimSpaces( lastDatabaseLocation_);
    writeConfigurationFile();
}

void Configuration::setCurrencySymbol(const char* symbol)
{
    BaseUtil::charPtrToString(currencySymbol_, symbol);
    BaseUtil::trimSpaces(currencySymbol_);
}

void Configuration::setPrefixCurrency(const char* cstr)
{
    prefixCurrency_ = BaseUtil::toBool(cstr);
}

void Configuration::setCompactTransactions(const char* cstr)
{
    compactTransactions_ = BaseUtil::toBool(cstr);
}

void Configuration::setCompareAsciiOnly(const char* cstr)
{
    compareAsciiOnly_ = BaseUtil::toBool(cstr);
}

void Configuration::setPrefixCurrency(bool value)
{
    prefixCurrency_ = value;
}

void Configuration::setCompactTransactions(bool value)
{
    compactTransactions_ = value;
}

void Configuration::setCompareAsciiOnly(bool value)
{
    compareAsciiOnly_ = value;
}

void Configuration::setHideZeroBalanceAccounts(bool value)
{
    hideZeroBalanceAccounts_ = value;
}

