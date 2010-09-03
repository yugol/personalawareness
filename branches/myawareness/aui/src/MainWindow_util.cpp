#include <wx/combobox.h>
#include <wx/htmllbox.h>
#include <wx/button.h>
#include <wx/choice.h>
#include <wx/datectrl.h>
#include <wx/msgdlg.h>
#include <Controller.h>
#include <MainWindow.h>

void MainWindow::checkItem()
{
    int nChars = trItemCombo_->GetValue().Trim(true).Trim(false).size();
    if (nChars > 0) {
        trAcceptButton_->Enable();
    } else {
        trAcceptButton_->Disable();
    }
}

int MainWindow::getItemIndexById(int id)
{
    for (unsigned int i = 0; i < trItemCombo_->GetCount(); ++i) {
        int tmpId = reinterpret_cast<int> (trItemCombo_->GetClientData(i));
        if (tmpId == id) {
            return i;
        }
    }
    return -1;
}

int MainWindow::getSourceIndexById(int id)
{
    for (unsigned int i = 0; i < trSourceChoice_->GetCount(); ++i) {
        int tmpId = reinterpret_cast<int> (trSourceChoice_->GetClientData(i));
        if (tmpId == id) {
            return i;
        }
    }
    return -1;
}

int MainWindow::getDestinationIndexById(int id)
{
    for (unsigned int i = 0; i < trDestinationChoice_->GetCount(); ++i) {
        int tmpId = reinterpret_cast<int> (trDestinationChoice_->GetClientData(i));
        if (tmpId == id) {
            return i;
        }
    }
    return -1;
}

void MainWindow::updateSelectedTransactionId()
{
    int idx = transactionsList_->GetSelection();

    wxString html = transactionsList_->GetString(idx);
    int first = html.Find(wxChar('@')) + 1;
    int last = html.Find(wxChar('@'), true) - 1;
    wxString idString = html.SubString(first, last);

    long id;
    if (!idString.ToLong(&id)) {
        uiReport(wxT("Could not read id.\n(this should not happen)"), wxT("Selecting transaction"));
    }
    selectedTransactionId_ = static_cast<int> (id);
}

void MainWindow::setSelectionInterval(int choice)
{
    wxDateTime firstDate;
    wxDateTime lastDate = wxDateTime::Today();
    int year, month;

    switch (choice) {
        case SELECTION_INTERVAL_ALL:
            firstDate.SetDay(1);
            firstDate.SetMonth(wxDateTime::Jan);
            firstDate.SetYear(1900);
            break;
        case SELECTION_INTERVAL_TODAY:
            firstDate = lastDate;
            break;
        case SELECTION_INTERVAL_THISMONTH:
            firstDate = lastDate;
            firstDate.SetDay(1);
            break;
        case SELECTION_INTERVAL_THISQUARTER:
            year = wxDateTime::GetCurrentYear();
            month = wxDateTime::GetCurrentMonth() - 2;
            if (month < 0) {
                --year;
                month %= wxDateTime::Inv_Month;
            }
            firstDate.SetDay(1);
            firstDate.SetMonth(static_cast<wxDateTime::Month> (month));
            firstDate.SetYear(year);
            break;
        case SELECTION_INTERVAL_THISYEAR:
            firstDate = lastDate;
            firstDate.SetDay(1);
            firstDate.SetMonth(wxDateTime::Jan);
            break;
        case SELECTION_INTERVAL_LASTYEAR:
            year = wxDateTime::GetCurrentYear() - 1;
            firstDate.SetDay(1);
            firstDate.SetMonth(wxDateTime::Jan);
            firstDate.SetYear(year);
            lastDate.SetDay(31);
            lastDate.SetMonth(wxDateTime::Dec);
            lastDate.SetYear(year);
            break;
        default:
            return;
    }

    selFirstDatePicker_->SetValue(firstDate);
    selLastDatePicker_->SetValue(lastDate);
}

void MainWindow::setSelectionStartInterval()
{
    for (unsigned int choice = 0; choice < selIntervalChoice_->GetCount(); ++choice) {
        int data = reinterpret_cast<int> (selIntervalChoice_->GetClientData(choice));
        if (SELECTION_INTERVAL_THISQUARTER == data) {
            selIntervalChoice_->Select(choice);
            setSelectionInterval(choice);
            break;
        }
    }
}

void MainWindow::setSelectionCustomInterval()
{
    for (unsigned int i = 0; i < selIntervalChoice_->GetCount(); ++i) {
        int data = reinterpret_cast<int> (selIntervalChoice_->GetClientData(i));
        if (SELECTION_INTERVAL_CUSTOM == data) {
            selIntervalChoice_->Select(i);
            break;
        }
    }
}

void MainWindow::uiReport(const wxString& message, const wxString& title)
{
    wxMessageBox(message, title, wxOK | wxCENTRE, this);
}

