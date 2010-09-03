#include <wx/combobox.h>
#include <wx/button.h>
#include <wx/choice.h>
#include <wx/datectrl.h>
#include <wx/msgdlg.h>
#include <Controller.h>
#include <MainWindow.h>

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

void MainWindow::reportMessage(const wxString& message, const wxString& title)
{
    wxMessageBox(message, title, wxOK | wxCENTRE, this);
}

