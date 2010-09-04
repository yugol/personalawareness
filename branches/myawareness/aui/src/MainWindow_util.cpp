#include <wx/combobox.h>
#include <wx/button.h>
#include <wx/choice.h>
#include <wx/datectrl.h>
#include <wx/msgdlg.h>
#include <Transaction.h>
#include <UiUtil.h>
#include <Controller.h>
#include <MainWindow.h>

using namespace adb;

void MainWindow::setSelectionInterval(int choice)
{
    wxDateTime firstDate;
    wxDateTime lastDate;
    int year, month;

    Transaction lastTransaction;
    Controller::instance()->selectLastTransaction(&lastTransaction);
    if (lastTransaction.getId() == 0) {
        lastDate = wxDateTime::Today();
    } else {
        UiUtil::adbDate2wxDate(lastDate, lastTransaction.getDate());
    }

    switch (choice) {
        case SELECTION_INTERVAL_ALL:
            firstDate.SetDay(1);
            firstDate.SetMonth(wxDateTime::Jan);
            firstDate.SetYear(1900);
            break;
        case SELECTION_INTERVAL_TODAY:
            firstDate = wxDateTime::Today();
            lastDate = wxDateTime::Today();
            break;
        case SELECTION_INTERVAL_LASTMONTH:
            firstDate = lastDate;
            firstDate.SetDay(1);
            break;
        case SELECTION_INTERVAL_LASTQUARTER:
            year = lastDate.GetYear();
            month = lastDate.GetMonth() - 2;
            if (month < wxDateTime::Jan) {
                --year;
                month = wxDateTime::Inv_Month - ::abs(month);
            }
            firstDate.SetDay(1);
            firstDate.SetMonth(static_cast<wxDateTime::Month> (month));
            firstDate.SetYear(year);
            break;
        case SELECTION_INTERVAL_LASTYEAR:
            firstDate = lastDate;
            firstDate.SetDay(1);
            firstDate.SetMonth(wxDateTime::Jan);
            break;
        case SELECTION_INTERVAL_PREVYEAR:
            year = lastDate.GetYear() - 1;
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
        if (SELECTION_INTERVAL_LASTQUARTER == data) {
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

