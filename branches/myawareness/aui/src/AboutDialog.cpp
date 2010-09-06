#include <Configuration.h>
#include <UiUtil.h>
#include <AboutDialog.h>

using namespace adb;

AboutDialog::AboutDialog(wxWindow* parent) :
    AboutDialogBase(parent)
{
}

AboutDialog::~AboutDialog()
{
}

void AboutDialog::onInitDialog(wxInitDialogEvent& event)
{
    wxString title;
    UiUtil::appendStdString(title, Configuration::PROJECT_NAME);
    title.Prepend(wxT("About "));
    SetTitle(title);

    wxBitmap acorn64(acorn64xpm);
    iconBitmap_->SetBitmap(acorn64);

    wxString version;
    UiUtil::appendStdString(version, Configuration::PROJECT_VERSION);
    versionLabel_->SetLabel(version);
}

void AboutDialog::onClose(wxCommandEvent& event)
{
    Destroy();
}
