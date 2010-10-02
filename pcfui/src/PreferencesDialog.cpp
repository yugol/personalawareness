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

	compactTransactionsViewCkBox_->SetValue(Configuration::instance()->isCompactTransactions());
	currencySymbolText_->SetValue(symbol);
	currencyPositionCheckBox_->SetValue(Configuration::instance()->isPrefixCurrency());
	treatNonAsciiCharsIdenticallyCheckBox_->SetValue(Configuration::instance()->isCompareAsciiOnly());
	hideZeroBalanceAccounts_->SetValue(Configuration::instance()->isHideZeroBalanceAccounts());

	propertiesNotebook_->ChangeSelection(0);
}

void PreferencesDialog::updatePreferences()
{
	string symbol;
	UiUtil::appendWxString(symbol, UiUtil::makeProperName(currencySymbolText_->GetValue()));

	Configuration::instance()->setCompactTransactions(compactTransactionsViewCkBox_->GetValue());
	Configuration::instance()->setCurrencySymbol(symbol.c_str());
	Configuration::instance()->setPrefixCurrency(currencyPositionCheckBox_->GetValue());
	Configuration::instance()->setCompareAsciiOnly(treatNonAsciiCharsIdenticallyCheckBox_->GetValue());
	Configuration::instance()->setHideZeroBalanceAccounts(hideZeroBalanceAccounts_->GetValue());
}

