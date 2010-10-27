#include <Configuration.h>
#include <UiUtil.h>
#include <PreferencesDialog.h>

using namespace std;

PreferencesDialog::PreferencesDialog(wxWindow* parent) :
	PreferencesDialogBase(parent)
{
}

PreferencesDialog::~PreferencesDialog()
{
}

void PreferencesDialog::onInitDialog(wxInitDialogEvent& event)
{
	wxString symbol;
	UiUtil::appendStdString(symbol, Configuration::instance()->getCurrencySymbol());

	if (!Configuration::instance()->supportsConfigurationFile()) {
		propertiesNotebook_->RemovePage(0);
	}

	openLastDatabaseCheckBox_->SetValue(Configuration::instance()->existsConfigurationFile());
	compactTransactionsViewCheckBox_->SetValue(Configuration::instance()->isCompactTransactions());
	currencySymbolText_->SetValue(symbol);
	currencyPositionCheckBox_->SetValue(Configuration::instance()->isPrefixCurrency());
	treatNonAsciiCharsIdenticallyCheckBox_->SetValue(Configuration::instance()->isCompareAsciiOnly());
	hideZeroBalanceAccountsCheckBox_->SetValue(Configuration::instance()->isHideZeroBalanceAccounts());

	propertiesNotebook_->ChangeSelection(0);
}

void PreferencesDialog::updatePreferences()
{
	string symbol;
	UiUtil::appendWxString(symbol, UiUtil::makeProperName(currencySymbolText_->GetValue()));

	if (Configuration::instance()->supportsConfigurationFile()) {
		if (openLastDatabaseCheckBox_->GetValue()) {
			Configuration::instance()->createConfigurationFile();
			Configuration::instance()->writeConfigurationFile();
		} else {
			Configuration::instance()->deleteConfigurationFile();
		}
	}
	Configuration::instance()->setCompactTransactions(compactTransactionsViewCheckBox_->GetValue());
	Configuration::instance()->setCurrencySymbol(symbol.c_str());
	Configuration::instance()->setPrefixCurrency(currencyPositionCheckBox_->GetValue());
	Configuration::instance()->setCompareAsciiOnly(treatNonAsciiCharsIdenticallyCheckBox_->GetValue());
	Configuration::instance()->setHideZeroBalanceAccounts(hideZeroBalanceAccountsCheckBox_->GetValue());
}

