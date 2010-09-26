#include <cstdio>
#include <Configuration.h>
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
        openDatabase(Configuration::instance()->getLastDatabasePath().c_str());
    }
    return instance_;
}

void DatabaseConnection::openDatabase(const char* databasePath)
{
    DatabaseConnection* tmpInstance = 0;
    try {
        tmpInstance = new DatabaseConnection(databasePath);
        if (isOpened()) {
            if (instance_->getDatabaseLocation() == databasePath) {
                return;
            }
            closeDatabase();
        }
        instance_ = tmpInstance;
        Configuration::instance()->setLastDatabasePath(databasePath);
    } catch (const exception& ex) {
        delete tmpInstance;
        RETHROW(ex);
    }
}

void DatabaseConnection::readPreferences(SelectPreferences& prefs)
{
    Configuration::instance()->setCurrencySymbol(prefs[Configuration::PREF_CURRENCY_SYMBOL].c_str());
    Configuration::instance()->setPrefixCurrency(prefs[Configuration::PREF_PREFIX_CURRENCY].c_str());
    Configuration::instance()->setCompactTransactions(prefs[Configuration::PREF_COMPACT_TRNSACTIONS].c_str());
    Configuration::instance()->setCompareAsciiOnly(prefs[Configuration::PREF_COMPARE_ASCII_ONLY].c_str());
}

void DatabaseConnection::writePreferences(sqlite3* database)
{
    bool b;
    UpdatePreference(database, Configuration::PREF_CURRENCY_SYMBOL, Configuration::instance()->getCurrencySymbol().c_str()).execute();
    b = Configuration::instance()->isPrefixCurrency();
    UpdatePreference(database, Configuration::PREF_PREFIX_CURRENCY, ((b) ? ("1") : ("0"))).execute();
    b = Configuration::instance()->isCompactTransactions();
    UpdatePreference(database, Configuration::PREF_COMPACT_TRNSACTIONS, ((b) ? ("1") : ("0"))).execute();
    b = Configuration::instance()->isCompareAsciiOnly();
    UpdatePreference(database, Configuration::PREF_COMPARE_ASCII_ONLY, ((b) ? ("1") : ("0"))).execute();
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
        THROW(Exception::NO_DATABASE_MESSAGE);
    }
    instance_->dumpSql(out);
}

void DatabaseConnection::importDatabase(istream& in)
{
    if (!isOpened()) {
        THROW(Exception::NO_DATABASE_MESSAGE);
    }
    string databasePath = instance_->getDatabaseLocation();
    deleteDatabase();
    openDatabase(databasePath.c_str());
    instance_->loadSql(in);
}

void DatabaseConnection::closeDatabase()
{
    if (!isOpened()) {
        THROW(Exception::NO_DATABASE_MESSAGE);
    }
    delete instance_;
    instance_ = 0;
}

void DatabaseConnection::deleteDatabase()
{
    if (!isOpened()) {
        THROW(Exception::NO_DATABASE_MESSAGE);
    }
    string databasePath = instance_->getDatabaseLocation();
    closeDatabase();
    if (0 != ::remove(databasePath.c_str())) {
        THROW("error deleting database");
    }
}

