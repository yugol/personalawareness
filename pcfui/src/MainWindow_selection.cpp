#include <Transaction.h>
#include <ReportData.h>
#include <Controller.h>
#include <UiUtil.h>
#include <MainWindow.h>

void MainWindow::populateSelectionIntervals()
{
	selIntervalChoice_->Append(wxT("All"), reinterpret_cast<void*> (SELECTION_INTERVAL_ALL));
	selIntervalChoice_->Append(wxT("One day"), reinterpret_cast<void*> (SELECTION_INTERVAL_ONEDAY));
	selIntervalChoice_->Append(wxT("Last day"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTDAY));
	selIntervalChoice_->Append(wxT("Last month"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTMONTH));
	selIntervalChoice_->Append(wxT("Last quarter"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTQUARTER));
	selIntervalChoice_->Append(wxT("Last year"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTYEAR));
	selIntervalChoice_->Append(wxT("- Custom -"), reinterpret_cast<void*> (SELECTION_INTERVAL_CUSTOM));
}

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
		case SELECTION_INTERVAL_LASTDAY:
			firstDate = lastDate;
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
		case SELECTION_INTERVAL_ONEDAY:
			firstDate = selFirstDatePicker_->GetValue();
			lastDate = firstDate;
			break;
		default:
			firstDate = selFirstDatePicker_->GetValue();
			lastDate = selLastDatePicker_->GetValue();
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
	for (unsigned int choice = 0; choice < selIntervalChoice_->GetCount(); ++choice) {
		int data = reinterpret_cast<int> (selIntervalChoice_->GetClientData(choice));
		if (SELECTION_INTERVAL_CUSTOM == data) {
			selIntervalChoice_->Select(choice);
			break;
		}
	}
}

void MainWindow::onSelectionIntervalChoice(wxCommandEvent& event)
{
	int choice = reinterpret_cast<int> (event.GetClientData());
	setSelectionInterval(choice);
	Controller::instance()->refreshTransactions();
}

void MainWindow::onSelectionFirstDateChanged(wxDateEvent& event)
{
	int choice = reinterpret_cast<int> (selIntervalChoice_->GetClientData(selIntervalChoice_->GetSelection()));
	if (choice == SELECTION_INTERVAL_ONEDAY) {
		selLastDatePicker_->SetValue(selFirstDatePicker_->GetValue());
	} else {
		setSelectionCustomInterval();
		if (event.GetDate() > selLastDatePicker_->GetValue()) {
			selFirstDatePicker_->SetValue(selLastDatePicker_->GetValue());
		}
	}
	Controller::instance()->refreshTransactions();
}

void MainWindow::onSelectionLastDateChanged(wxDateEvent& event)
{
	int choice = reinterpret_cast<int> (selIntervalChoice_->GetClientData(selIntervalChoice_->GetSelection()));
	if (choice == SELECTION_INTERVAL_ONEDAY) {
		selFirstDatePicker_->SetValue(selLastDatePicker_->GetValue());
	} else {
		setSelectionCustomInterval();
		if (event.GetDate() < selFirstDatePicker_->GetValue()) {
			selLastDatePicker_->SetValue(selFirstDatePicker_->GetValue());
		}
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
