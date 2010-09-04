#include <Configuration.h>
#include <UiUtil.h>
#include <PreferencesDialog.h>

using namespace adb;
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
    UiUtil::appendStdString(symbol, Configuration::instance()->CURRENCY_SYMBOL);

    compactTransactionsViewCkBox_->SetValue(Configuration::instance()->COMPACT_TRNSACTION_VIEW);
    currencySymbolText_->SetValue(symbol);
    currencyPositionCheckBox_->SetValue(Configuration::instance()->PREFIX_CURRENCY);
    treatNonAsciiCharsIdenticallyCheckBox_->SetValue(Configuration::instance()->SAME_NONASCII_CHARS);

    propertiesNotebook_->ChangeSelection(0);
}

void PreferencesDialog::updatePreferences()
{
    Configuration::instance()->CURRENCY_SYMBOL.clear();

    Configuration::instance()->COMPACT_TRNSACTION_VIEW = compactTransactionsViewCkBox_->GetValue();
    UiUtil::appendWxString(Configuration::instance()->CURRENCY_SYMBOL, UiUtil::makeProperName(currencySymbolText_->GetValue()));
    Configuration::instance()->PREFIX_CURRENCY = currencyPositionCheckBox_->GetValue();
    Configuration::instance()->SAME_NONASCII_CHARS = treatNonAsciiCharsIdenticallyCheckBox_->GetValue();
}

