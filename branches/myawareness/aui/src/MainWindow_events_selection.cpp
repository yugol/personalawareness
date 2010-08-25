#include <MainWindow.h>
#include <Controller.h>

void MainWindow::onSelectionIntervalChoice(wxCommandEvent& event)
{
    int choice = reinterpret_cast<int> (event.GetClientData());

    wxDateTime firstDate;
    wxDateTime lastDate = wxDateTime::Today();
    int year, month;

    switch (choice) {
        case SELECTION_INTERVAL_ALL:
            firstDate.SetDay(1);
            firstDate.SetMonth(wxDateTime::Jan);
            firstDate.SetYear(2000);
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

    controller_->updateTransactions();
}

void MainWindow::onSelectionFirstDateChanged(wxDateEvent& event)
{
    selectCustomInterval();
    if (event.GetDate() > selLastDatePicker_->GetValue()) {
        selFirstDatePicker_->SetValue(selLastDatePicker_->GetValue());
    }
    controller_->updateTransactions();
}

void MainWindow::onSelectionLastDateChanged(wxDateEvent& event)
{
    selectCustomInterval();
    if (event.GetDate() < selFirstDatePicker_->GetValue()) {
        selLastDatePicker_->SetValue(selFirstDatePicker_->GetValue());
    }
    controller_->updateTransactions();
}

void MainWindow::onSelectionAccountChoice(wxCommandEvent& event)
{
    controller_->updateTransactions();
}
