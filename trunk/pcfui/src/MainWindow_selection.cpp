#include <Transaction.h>
#include <ReportData.h>
#include <Controller.h>
#include <UiUtil.h>
#include <MainWindow.h>

void MainWindow::populateSelectionIntervals()
{
	selIntervalChoice_->Append(wxT("(All)"), reinterpret_cast<void*> (SELECTION_INTERVAL_ALL));
	selIntervalChoice_->Append(wxT("(One) day"), reinterpret_cast<void*> (SELECTION_INTERVAL_ONEDAY));
	selIntervalChoice_->Append(wxT("Last day"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTDAY));
	selIntervalChoice_->Append(wxT("Last month"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTMONTH));
	selIntervalChoice_->Append(wxT("Last quarter"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTQUARTER));
	selIntervalChoice_->Append(wxT("Last year"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTYEAR));
	selIntervalChoice_->Append(wxT("(Custom)"), reinterpret_cast<void*> (SELECTION_INTERVAL_CUSTOM));
}

void MainWindow::setSelectionInterval(int intervalId)
{
	Transaction firstTransaction, lastTransaction;
	wxDateTime firstDate, lastDate;

	Controller::instance()->selectLastTransaction(&lastTransaction);
	if (lastTransaction.getId() == 0) {
		lastDate = wxDateTime::Today();
	} else {
		UiUtil::adbDate2wxDate(lastDate, lastTransaction.getDate());
	}

	switch (intervalId) {
		case SELECTION_INTERVAL_ALL:
			Controller::instance()->selectFirstTransaction(&firstTransaction);
			if (firstTransaction.getId() == 0) {
				firstDate = wxDateTime::Today();
			} else {
				UiUtil::adbDate2wxDate(firstDate, firstTransaction.getDate());
			}
			break;
		case SELECTION_INTERVAL_ONEDAY:
			firstDate = selLastDatePicker_->GetValue();
			lastDate = firstDate;
			break;
		case SELECTION_INTERVAL_LASTDAY:
			firstDate = lastDate;
			break;
		case SELECTION_INTERVAL_LASTMONTH:
			firstDate = lastDate;
			firstDate.Subtract(wxDateSpan(0, 1));
			break;
		case SELECTION_INTERVAL_LASTQUARTER:
			firstDate = lastDate;
			firstDate.Subtract(wxDateSpan(0, 3));
			break;
		case SELECTION_INTERVAL_LASTYEAR:
			firstDate = lastDate;
			firstDate.Subtract(wxDateSpan(1));
			break;
		default:
			firstDate = selFirstDatePicker_->GetValue();
			lastDate = selLastDatePicker_->GetValue();
	}

	selFirstDatePicker_->SetValue(firstDate);
	selLastDatePicker_->SetValue(lastDate);
}

void MainWindow::setSelectionDefaultInterval()
{
	for (unsigned int choice = 0; choice < selIntervalChoice_->GetCount(); ++choice) {
		int intervalId = reinterpret_cast<int> (selIntervalChoice_->GetClientData(choice));
		if (SELECTION_INTERVAL_LASTMONTH == intervalId) {
			selIntervalChoice_->Select(choice);
			setSelectionInterval(intervalId);
			break;
		}
	}
}

void MainWindow::setSelectionCustomInterval()
{
	for (unsigned int choice = 0; choice < selIntervalChoice_->GetCount(); ++choice) {
		int intervalId = reinterpret_cast<int> (selIntervalChoice_->GetClientData(choice));
		if (SELECTION_INTERVAL_CUSTOM == intervalId) {
			selIntervalChoice_->Select(choice);
			break;
		}
	}
}

void MainWindow::refreshSelectionInterval()
{
	int intervalId = reinterpret_cast<int> (selIntervalChoice_->GetClientData(selIntervalChoice_->GetSelection()));
	setSelectionInterval(intervalId);
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
