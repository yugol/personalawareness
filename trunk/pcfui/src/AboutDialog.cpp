#include <Configuration.h>
#include <UiUtil.h>
#include <Controller.h>
#include <AboutDialog.h>

extern const char* RES_LARGE_ICON[];
extern const char* RES_CHANGES;

AboutDialog::AboutDialog(wxWindow* parent) :
	AboutDialogBase(parent)
{
	// SetTitle(wxT("This is..."));

	wxBitmap largeIcon(RES_LARGE_ICON);
	iconBitmap_->SetBitmap(largeIcon);

	wxString projectName;
	UiUtil::appendStdString(projectName, Configuration::PROJECT_NAME);
	projectNameLabel_->SetLabel(projectName);

	wxString version;
	UiUtil::appendStdString(version, Configuration::PROJECT_VERSION);
	versionLabel_->SetLabel(version);

	wxString dbReport;
	Controller::instance()->getDatabaseReport(dbReport);
	databaseText_->SetValue(dbReport);

	wxString changes;
	UiUtil::appendStdString(changes, RES_CHANGES);
	changesText_->SetValue(changes);

	sectionsNotebook_->SetSelection(0);
}

AboutDialog::~AboutDialog()
{
}

void AboutDialog::onClose(wxCommandEvent& event)
{
	Destroy();
}
