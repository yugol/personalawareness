#include <OptimizationReport.h>
#include <OptimizationDialog.h>

OptimizationDialog::OptimizationDialog(wxWindow* parent, OptimizationReport* report) :
    OptimizationDialogBase(parent), report_(report)
{
    if (report_->isRemoveUnusedItems()) {
        message_->SetLabel(wxT("Please select the actions to be performed:"));
        unusedItemsCheckBox_->SetValue(true);
    } else {
        message_->SetLabel(wxT("The database is already optimized."));
        unusedItemsCheckBox_->Enable(false);
        buttons_Cancel->Show(false);
    }
}

OptimizationDialog::~OptimizationDialog()
{
}

void OptimizationDialog::onClose(wxCloseEvent& event)
{
    report_->setRemoveUnusedItems(unusedItemsCheckBox_->GetValue());
}
