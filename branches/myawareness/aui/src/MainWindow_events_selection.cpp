#include <wx/dateevt.h>
#include <wx/datectrl.h>
#include <wx/menu.h>
#include <ReportData.h>
#include <Controller.h>
#include <MainWindow.h>

using namespace adb;

void MainWindow::onSelectionIntervalChoice(wxCommandEvent& event)
{
    int choice = reinterpret_cast<int> (event.GetClientData());
    setSelectionInterval(choice);
    Controller::instance()->refreshTransactions();
}

void MainWindow::onSelectionFirstDateChanged(wxDateEvent& event)
{
    setSelectionCustomInterval();
    if (event.GetDate() > selLastDatePicker_->GetValue()) {
        selFirstDatePicker_->SetValue(selLastDatePicker_->GetValue());
    }
    Controller::instance()->refreshTransactions();
}

void MainWindow::onSelectionLastDateChanged(wxDateEvent& event)
{
    setSelectionCustomInterval();
    if (event.GetDate() < selFirstDatePicker_->GetValue()) {
        selLastDatePicker_->SetValue(selFirstDatePicker_->GetValue());
    }
    Controller::instance()->refreshTransactions();
}

void MainWindow::onSelectionAccountChoice(wxCommandEvent& event)
{
    Controller::instance()->refreshTransactions();
}

void MainWindow::onSelectionPatternText(wxCommandEvent& event)
{
    Controller::instance()->refreshTransactions();
}

void MainWindow::onReports(wxCommandEvent& event)
{
    wxMenu reportsMenu;

    reportsMenu.Append(ID_REPORT_EXPENSES_PIE, wxT("Expenses"));
    reportsMenu.Append(ID_REPORT_EXPENSES_MONTHLY, wxT("Expenses Monthly"));
    reportsMenu.AppendSeparator();
    reportsMenu.Append(ID_REPORT_INCOME_PIE, wxT("Income"));
    reportsMenu.Append(ID_REPORT_INCOME_MONTHLY, wxT("Income Monthly"));

    reportsMenu.Connect(ID_REPORT_EXPENSES_PIE, wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler(MainWindow::onExpensesPie));
    reportsMenu.Connect(ID_REPORT_EXPENSES_MONTHLY, wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler(MainWindow::onExpensesMonthly));
    reportsMenu.Connect(ID_REPORT_INCOME_PIE, wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler(MainWindow::onIncomePie));
    reportsMenu.Connect(ID_REPORT_INCOME_MONTHLY, wxEVT_COMMAND_MENU_SELECTED, wxCommandEventHandler(MainWindow::onIncomeMonthly));

    PopupMenu(&reportsMenu);
}

void MainWindow::onExpensesPie(wxCommandEvent& event)
{
    Controller::instance()->showReport(ReportData::PIE, ReportData::EXPENSES);
}

void MainWindow::onExpensesMonthly(wxCommandEvent& event)
{
    Controller::instance()->showReport(ReportData::MONTHLY, ReportData::EXPENSES);
}

void MainWindow::onIncomePie(wxCommandEvent& event)
{
    Controller::instance()->showReport(ReportData::PIE, ReportData::INCOME);
}

void MainWindow::onIncomeMonthly(wxCommandEvent& event)
{
    Controller::instance()->showReport(ReportData::MONTHLY, ReportData::INCOME);
}
