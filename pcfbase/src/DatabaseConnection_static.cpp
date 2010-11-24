#include <cstdio>
#include <Configuration.h>
#include <BaseUtil.h>
#include <Exception.h>
#include <SelectionParameters.h>
#include <cmd/SelectPreferences.h>
#include <cmd/SelectTransactions.h>
#include <cmd/UpdatePreference.h>
#include <DatabaseConnection.h>

using namespace std;

DatabaseConnection* DatabaseConnection::instance_ = 0;

bool DatabaseConnection::isOpened()
{
    return 0 != instance_;
}

DatabaseConnection* DatabaseConnection::instance()
{
    if (!isOpened()) {
        openDatabase(Configuration::instance()->getLastDatabaseLocation().c_str());
    }
    return instance_;
}

void DatabaseConnection::openDatabase(const char* location)
{
    DatabaseConnection* tmpInstance = 0;
    try {
        tmpInstance = new DatabaseConnection(location);
        if (isOpened()) {
            if (instance_->getDatabaseLocation() == location) {
                return;
            }
            closeDatabase();
        }
        instance_ = tmpInstance;
        Configuration::instance()->setLastDatabaseLocation(location);
    } catch (const exception& ex) {
        delete tmpInstance;
        RETHROW(ex);
    }
}

void DatabaseConnection::readPreferences(SelectPreferences& prefs)
{
    Configuration::instance()->setCurrencySymbol(prefs[Configuration::PREF_CURRENCY_SYMBOL].c_str());
    Configuration::instance()->setPrefixCurrency(prefs[Configuration::PREF_PREFIX_CURRENCY].c_str());
    Configuration::instance()->setCompactTransactions(
            prefs[Configuration::PREF_COMPACT_TRNSACTIONS].c_str());
    Configuration::instance()->setCompareAsciiOnly(
            prefs[Configuration::PREF_COMPARE_ASCII_ONLY].c_str());
    Configuration::instance()->setHideZeroBalanceAccounts(
            prefs[Configuration::PREF_HIDE_ZERO_BALANCE_ACCOUNTS].c_str());
}

void DatabaseConnection::writePreferences(sqlite3* database)
{
    bool b;
    UpdatePreference(database, Configuration::PREF_CURRENCY_SYMBOL,
            Configuration::instance()->getCurrencySymbol().c_str()).execute();
    b = Configuration::instance()->isPrefixCurrency();
    UpdatePreference(database, Configuration::PREF_PREFIX_CURRENCY, ((b) ? ("1") : ("0"))).execute();
    b = Configuration::instance()->isCompactTransactions();
    UpdatePreference(database, Configuration::PREF_COMPACT_TRNSACTIONS, ((b) ? ("1") : ("0"))).execute();
    b = Configuration::instance()->isCompareAsciiOnly();
    UpdatePreference(database, Configuration::PREF_COMPARE_ASCII_ONLY, ((b) ? ("1") : ("0"))).execute();
    b = Configuration::instance()->isHideZeroBalanceAccounts();
    UpdatePreference(database, Configuration::PREF_HIDE_ZERO_BALANCE_ACCOUNTS,
            ((b) ? ("1") : ("0"))).execute();
}

bool DatabaseConnection::isAccountInUse(sqlite3* database, int accountId)
{
    SelectionParameters parameters;
    parameters.setAccountId(accountId);
    parameters.setCheckUsage(true);
    vector<int> selection;
    SelectTransactions(database, &selection, &parameters).execute();
    return selection.size() > 0;
}

bool DatabaseConnection::isItemInUse(sqlite3* database, int itemId)
{
    SelectionParameters parameters;
    parameters.setItemId(itemId);
    parameters.setCheckUsage(true);
    vector<int> selection;
    SelectTransactions(database, &selection, &parameters).execute();
    return selection.size() > 0;
}

void DatabaseConnection::exportDatabase(ostream& out)
{
    if (!isOpened()) {
        THROW(BaseUtil::EMSG_NO_DATABASE);
    }
    instance_->exportSql(out);
}

void DatabaseConnection::importDatabase(istream& in)
{
    if (!isOpened()) {
        THROW(BaseUtil::EMSG_NO_DATABASE);
    }
    string databaseLocation = instance_->getDatabaseLocation();
    dropDatabase();
    openDatabase(databaseLocation.c_str());
    instance_->importSql(in);
}

void DatabaseConnection::closeDatabase()
{
    if (!isOpened()) {
        THROW(BaseUtil::EMSG_NO_DATABASE);
    }
    delete instance_;
    instance_ = 0;
}

void DatabaseConnection::dropDatabase()
{
    if (!isOpened()) {
        THROW(BaseUtil::EMSG_NO_DATABASE);
    }
    // string databaseLocation = instance_->getDatabaseLocation();
    instance_->cleanDatabase();
    closeDatabase();
    // if (0 != ::remove(databaseLocation.c_str())) {
    //	THROW("error deleting database");
    // }
}

