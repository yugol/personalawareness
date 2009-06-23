/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 30/08/2008
 * Time: 22:07
 *
 *
 * Copyright (c) 2008 Iulian GORIAC
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness.UI
{
    public partial class FormMain : Form {
		
        public FormMain(){
            InitializeComponent();

            #if !DEBUG
            buddiCSVToolStripMenuItem.Visible = false;
            #endif

            transactionsControl.SelectPanelExpanded = false;
            transactionsControl.EditPanelExpanded = true;

            actionPages.Dock = DockStyle.Fill;
            notesViewer.Dock = DockStyle.Fill;
            mealPanel.Dock = DockStyle.Fill;
            financialPages.Dock = DockStyle.Fill;

            financesControl.AccountDoubleClick += new AccountDoubleClickHandler(ShowAllTransactionsForAccount);
        }
		
		internal void SetTitle(string title) {
			Text = title;
			trayIcon.Text = title;
		}
		
        internal void DisableEnableActions(){
            bool isDbOperational = !string.IsNullOrEmpty(Configuration.LAST_DATABASE_NAME);
            fileMenuSeparator.Visible = isDbOperational;
            importToolStripMenuItem.Visible = isDbOperational;
            exportToolStripMenuItem.Visible = isDbOperational;
            deleteDatabaseToolStripMenuItem.Enabled = isDbOperational;
            editToolStripMenuItem.Visible = isDbOperational;
            mealsToolStripMenuItem.Visible = isDbOperational;

            actionsToolButton.Visible = isDbOperational;
            notesToolButton.Visible = isDbOperational;
            mealsToolButton.Visible = isDbOperational;
            financesToolButton.Visible = isDbOperational;

            remindersToolButton.Visible = isDbOperational;
            todoToolButton.Visible = isDbOperational;
            
            remindersToolStripMenuItem.Visible = isDbOperational;
            todoListToolStripMenuItem.Visible = isDbOperational;

            ResetPanelsView();
        }

        void UpdateStatusTime(){
            timeStatusLabel.Text = DateTime.Now.ToString(Configuration.SATUS_DATE_TIME_FORMAT);
        }

        void StatusTimerTick(object sender, EventArgs e){
            UpdateStatusTime();
        }

		void ShowAllTransactionsForAccount(DalAccount account) {
            financialPages.SelectedTab = transactionsPage;
            transactionsControl.ShowAllTransactionsForAccount(account);
        }

		#region FormManagement
				
		// const int WM_QUERYENDSESSION = 0x11;
        // bool endSessionPending = false;
		FormWindowState savedWindowState;
		
		/*
        protected override void WndProc(ref Message m) {
        	if (m.Msg == WM_QUERYENDSESSION) {
                endSessionPending = true;
        	}
            base.WndProc(ref m);
        }
		*/      

        void FormMainLoad(object sender, EventArgs e){
            UpdateStatusTime();
            statusTimer.Start();
            new ActionOpenDatabase(this).Run();
            ResetPanelsView();
            trayIcon.Visible = true;
        }
		
        void FormMainResize(object sender, EventArgs e)
        {
        	switch (WindowState) {
        		case FormWindowState.Maximized:
        			savedWindowState = FormWindowState.Maximized;
        			break;
        		case FormWindowState.Normal:
        			savedWindowState = FormWindowState.Normal;
        			break;
        		case FormWindowState.Minimized:
        			MinimizeToTray();
        			break;
        	}
        }

        void TrayIconDoubleClick(object sender, EventArgs e)
        {
        	RestoreFromTray();
        }

        void TrayIconMouseDown(object sender, MouseEventArgs e)
        {
        	if (e.Button == MouseButtons.Left) {
        		RestoreFromTray();
        	}
        }
        
        private void MinimizeToTray()
        {
            WindowState = FormWindowState.Minimized;
            Visible = false;
            ShowInTaskbar = false;
        }

        private void RestoreFromTray()
        {
            ShowInTaskbar = true;
            Visible = true;
            WindowState = savedWindowState;
        }

        /*
        void FormMainFormClosing(object sender, FormClosingEventArgs e) {
        	if ((!endSessionPending) &&
        		(MessageBox.Show("Are you sure you want to quit Persoanl Awareness?",
        	                    "Personal Awareness", 
        	                    MessageBoxButtons.YesNo, 
        	                    MessageBoxIcon.Question, 
        	                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)) {
        		e.Cancel = true;
        	}
        }
        */

		void FormMainFormClosed(object sender, FormClosedEventArgs e){
            DBUtil.CloseDataContext();
        }
		
		#endregion

        #region Panels
        
        void ResetPanelsView() {
            actionPages.Visible = false;
            notesViewer.Visible = false;
            mealPanel.Visible = false;
            financialPages.Visible = false;

//            financesControl.IsDisplayed = false;
//            transactionsControl.IsDisplayed = false;
//            mealsDailyReportControl.IsDisplayed = false;
//            availableFoodsControl.IsDisplayed = false;
//            dayActionsReportControl.IsDisplayed = false;
//            weekActionsReport.IsDisplayed = false;

            actionsToolButton.Checked = false;
            notesToolButton.Checked = false;
            mealsToolButton.Checked = false;
            financesToolButton.Checked = false;
        }

        public void SelectActionsView() {
            if (!actionsToolButton.Checked){
                ResetPanelsView();
                UpdateActionsPages();
                actionPages.Visible = true;
                actionsToolButton.Checked = true;
            }
        }

        public void SelectNotesView() {
            if (!notesToolButton.Checked){
                ResetPanelsView();
                notesViewer.Visible = true;
                notesToolButton.Checked = true;
            }
        }

        public void SelectMealsView() {
            if (!mealsToolButton.Checked){
                ResetPanelsView();
                UpdateMealPages();
                mealPanel.Visible = true;
                mealsToolButton.Checked = true;
            }
        }

        public void SelectFinancesView() {
            if (!financesToolButton.Checked){
                ResetPanelsView();
                UpdateFinancialPages();
                financialPages.Visible = true;
                financesToolButton.Checked = true;
            }
        }

        void ActionPagesSelecting(object sender, TabControlCancelEventArgs e){
            UpdateActionsPages();
        }

        void MealPagesSelected(object sender, TabControlEventArgs e){
            UpdateMealPages();
        }

        void FinancialPagesSelected(object sender, TabControlEventArgs e){
            UpdateFinancialPages();
        }

        void UpdateActionsPages() {
            dayActionsReportControl.IsDisplayed = false;
            weekActionsReport.IsDisplayed = false;
            if (actionPages.SelectedTab.Equals(dayPage)){
                dayActionsReportControl.IsDisplayed = true;
            } else if (actionPages.SelectedTab.Equals(weekPage)) {
                weekActionsReport.IsDisplayed = true;
            }
        }

        void UpdateMealPages() {
            mealsDailyReportControl.IsDisplayed = false;
            availableFoodsControl.IsDisplayed = false;
            if (mealPages.SelectedTab.Equals(dailyPage)){
                mealsDailyReportControl.IsDisplayed = true;
            } else if (mealPages.SelectedTab.Equals(availableFoodsPage)) {
                availableFoodsControl.IsDisplayed = true;
            }
        }

        void UpdateFinancialPages() {
            financesControl.IsDisplayed = false;
            transactionsControl.IsDisplayed = false;
            if (financialPages.SelectedTab.Equals(accountsPage)){
                financesControl.IsDisplayed = true;
            } else if (financialPages.SelectedTab.Equals(transactionsPage)){
                transactionsControl.IsDisplayed = true;
            }
        }

        #endregion

        #region MainMenu
        
		void NewDatabaseToolStripMenuItemClick(object sender, EventArgs e){
            new ActionNewDatabase(this).Run();
        }

        void OpenDatabaseToolStripMenuItemClick(object sender, EventArgs e){
            OpenDatabase();
        }

        void OpenDatabase(){
            string databaseName = ActionOpenDatabase.UIPickDatabaseName();
            if (!string.IsNullOrEmpty(databaseName)) {
                new ActionOpenDatabase(this, databaseName).Run();
            }
        }

        void DeleteDatabaseToolStripMenuItemClick(object sender, EventArgs e){
            if (MessageBox.Show("Are you sure you want to delete database\n'" + Configuration.LAST_DATABASE_NAME + "'?",
                                "Delete database",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK){
                new ActionDeleteDatabase(this).Run();
            }
        }

        void BuddiExportToolStripMenuItemClick(object sender, EventArgs e){
#if DEBUG
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Buddi export (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK){
                try {
                    ImporterBuddy importer = new ImporterBuddy(DBUtil.GetDataContext());
                    importer.Import(ofd.FileName);
                    MessageBox.Show("Operation completed successfully.", "Import Buddi CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DBUtil.ReOpenDataContext();
                }
            }
#endif
        }

        void DumpToolStripMenuItemClick(object sender, EventArgs e){
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "SQL Script (*.sql)|*.sql";
            if (sfd.ShowDialog() == DialogResult.OK){
                StreamWriter writer = new StreamWriter(sfd.FileName, false);
                try {
                    Dumper dd = new Dumper(DBUtil.GetDataContext());
                    dd.DumpAll(writer);
                    MessageBox.Show("Operation completed successfully.", "Dump database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex) {
                    MessageBox.Show("There was an error when dumping the database.\n" + ex.Message, "Dump database",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (writer != null){
                        writer.Close();
                    }
                }
            }
        }

        void DumpToolStripMenuItem1Click(object sender, EventArgs e){
            if (MessageBox.Show("This operation will COMPLETELY ERASE the current database!\nAre you sure you want to continue?",
                                "Restore database",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.OK){
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "SQL Script (*.sql)|*.sql";
                if (ofd.ShowDialog() == DialogResult.OK){
                    try {
                        DBUtil.RestoreFromSqlDump(ofd.FileName);
                        MessageBox.Show("Operation completed successfully.", "Restore database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show("There was an error when restoring the database.\n" + ex.Message, "Restore database",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void ExitToolStripMenuItemClick(object sender, EventArgs e){
            Close();
        }
        
        void BudgetCategoriesToolStripMenuItemClick(object sender, EventArgs e){
            new FormEditBudgetCategories().ShowDialog();
        }

        void AccoutTypesToolStripMenuItemClick(object sender, EventArgs e){
            new FormEditAccountTypes().ShowDialog();
        }

        void AccountsToolStripMenuItemClick(object sender, EventArgs e){
            try {
                new FormEditAccounts().ShowDialog();
            } catch (ApplicationException) {
                MessageBox.Show("No account types defined!\nYou can edit account types by going to Edit -> Account Types...", "Cannot edit accounts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void TransferreasonsToolStripMenuItemClick(object sender, EventArgs e){
            new FormEditTransactionReasons().ShowDialog();
        }

        void PreferencesToolStripMenuItemClick(object sender, EventArgs e) {
            FormEditProperties dialog = new FormEditProperties();
            dialog.ShowDialog();
        }

        void ManageMealsToolStripMenuItemClick(object sender, EventArgs e){
            new FormManageMeals().ShowDialog();
        }

        void AboutToolStripMenuItemClick(object sender, EventArgs e){
            new FormAbout().ShowDialog();
        }

        #endregion
        
        #region ToolBar
        
        void NewToolButtonClick(object sender, EventArgs e){
            new ActionNewDatabase(this).Run();
        }

        void OpenToolButtonClick(object sender, EventArgs e){
            OpenDatabase();
        }
        
        void ActionsToolButtonClick(object sender, EventArgs e){
            SelectActionsView();
        }

        void NotesToolButtonClick(object sender, EventArgs e){
            SelectNotesView();
        }

        void MealsToolButtonClick(object sender, EventArgs e){
            SelectMealsView();
        }

        void FinancesToolButtonClick(object sender, EventArgs e){
            SelectFinancesView();
        }
        
        

        void CalculatorToolButtonClick(object sender, EventArgs e){
            ManagerCalculator.Display();
        }

        void TeaTimerToolButtonClick(object sender, EventArgs e){
            ManagerTeaTimer.Display();
        }

        void RemindersToolButtonClick(object sender, EventArgs e){
            ManagerReminders.Instance.Display();
        }

        void CalendarToolButtonClick(object sender, EventArgs e){
            ManagerCalendar.Display();
        }

        void TodoToolButtonClick(object sender, EventArgs e){
            ManagerTodo.Display();
        }

        #endregion        
        
        #region Tools
        
        void CalculatorToolStripMenuItemClick(object sender, EventArgs e) {
        	ManagerCalculator.Display();
        }
        
        void TeaTimerToolStripMenuItemClick(object sender, EventArgs e) {
        	ManagerTeaTimer.Display();
        }
        
        void RemindersToolStripMenuItemClick(object sender, EventArgs e) {
        	ManagerReminders.Instance.Display();
        }
        
        void CalendarToolStripMenuItemClick(object sender, EventArgs e) {
        	ManagerCalendar.Display();
        }
        
        void TodoListToolStripMenuItemClick(object sender, EventArgs e) {
        	ManagerTodo.Display();
        }

        #endregion
                
    }
}
