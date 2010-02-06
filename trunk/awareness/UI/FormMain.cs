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
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness.UI
{
    public partial class FormMain : Form
    {
        string genericTitle = "Personal Awareness";

        public FormMain()
        {
            InitializeComponent();

            trayIcon.Visible = true;

            transactionsControl.SelectPanelExpanded = false;
            transactionsControl.EditPanelExpanded = true;

            actionPages.Dock = DockStyle.Fill;
            notesViewer.Dock = DockStyle.Fill;
            mealPanel.Dock = DockStyle.Fill;
            financialPages.Dock = DockStyle.Fill;

            financesControl.AccountDoubleClick += new AccountDoubleClickHandler(ShowAllTransactionsForAccount);

            Controller.StorageOpened += new DataChangedHandler(StorageOpened);
            Controller.StorageClosing += new DataChangedHandler(StorageClosing);
        }

        void ExitApplication()
        {
            Close();
        }

        void StorageOpened()
        {
            Debug.WriteLine("FormMain.StorageOpened |-");

            SetTitle(genericTitle + " - " + Controller.Storage.Nick);
            SetDataOperatonsVisible(true);
            SelectActionsView();
            toDoNote.Note = Controller.Storage.GetTodoNote();

            Debug.WriteLine("FormMain.StorageOpened -|");
        }

        void StorageClosing()
        {
            toDoNote.UpdateNote();
            ResetView();
        }

        void ResetView()
        {
            SetTitle(genericTitle);
            SetDataOperatonsVisible(false);
            ResetPanelsView();
        }

        void SetDataOperatonsVisible(bool b)
        {
            editToolStripMenuItem.Visible = b;
            mealsToolStripMenuItem.Visible = b;

            actionsToolButton.Visible = b;
            notesToolButton.Visible = b;
            mealsToolButton.Visible = b;
            financesToolButton.Visible = b;
            remindersToolStripMenuItem.Visible = b;
        }

        internal void SetTitle(string title)
        {
            Text = title;
            trayIcon.Text = title;
        }

        internal void DisableEnableActions()
        {
            bool isDbOperational = !string.IsNullOrEmpty(Configuration.LastStorageId);
            editToolStripMenuItem.Visible = isDbOperational;
            mealsToolStripMenuItem.Visible = isDbOperational;

            actionsToolButton.Visible = isDbOperational;
            notesToolButton.Visible = isDbOperational;
            mealsToolButton.Visible = isDbOperational;
            financesToolButton.Visible = isDbOperational;
            remindersToolStripMenuItem.Visible = isDbOperational;

            ResetPanelsView();
        }

        void UpdateStatusTime()
        {
            timeStatusLabel.Text = DateTime.Now.ToString(Configuration.SATUS_DATE_TIME_FORMAT);
        }

        void StatusTimerTick(object sender, EventArgs e)
        {
            UpdateStatusTime();
        }

        void ShowAllTransactionsForAccount(DalAccount account)
        {
            financialPages.SelectedTab = transactionsPage;
            transactionsControl.ShowAllTransactionsForAccount(account);
        }

        #region FormManagement

        [DllImport("User32.dll")]
        public static extern Int32 SetForegroundWindow(int hWnd);

        void FormMainLoad(object sender, EventArgs e)
        {
            ResetView();
            UpdateStatusTime();
            statusTimer.Start();

            if (!string.IsNullOrEmpty(Configuration.LastStorageId)) {
                Controller.OpenStorage(Configuration.LastStorageId);
            }
        }

        void FormMainFormClosing(object sender, FormClosingEventArgs e)
        {
            Controller.CloseStorage();
        }

        FormWindowState savedWindowState;

        void FormMainResize(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized) {
                savedWindowState = WindowState;
            } else {
                Visible = false;
            }
        }

        void TrayIconMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                Visible = true;
                WindowState = savedWindowState;
                SetForegroundWindow(Handle.ToInt32());
            }
        }

        #endregion

        #region Panels

        void ResetPanelsView()
        {
            actionPages.Visible = false;
            notesViewer.Visible = false;
            mealPanel.Visible = false;
            financialPages.Visible = false;

            actionsToolButton.Checked = false;
            notesToolButton.Checked = false;
            mealsToolButton.Checked = false;
            financesToolButton.Checked = false;
        }

        public void SelectActionsView()
        {
            if (!actionsToolButton.Checked) {
                ResetPanelsView();
                UpdateActionsPages();
                actionPages.Visible = true;
                actionsToolButton.Checked = true;
            }
        }

        public void SelectNotesView()
        {
            if (!notesToolButton.Checked) {
                ResetPanelsView();
                notesViewer.Visible = true;
                notesToolButton.Checked = true;
            }
        }

        public void SelectMealsView()
        {
            if (!mealsToolButton.Checked) {
                ResetPanelsView();
                UpdateMealPages();
                mealPanel.Visible = true;
                mealsToolButton.Checked = true;
            }
        }

        public void SelectFinancesView()
        {
            if (!financesToolButton.Checked) {
                ResetPanelsView();
                UpdateFinancialPages();
                financialPages.Visible = true;
                financesToolButton.Checked = true;
            }
        }

        void ActionPagesSelecting(object sender, TabControlCancelEventArgs e)
        {
            UpdateActionsPages();
        }

        void MealPagesSelected(object sender, TabControlEventArgs e)
        {
            UpdateMealPages();
        }

        void FinancialPagesSelected(object sender, TabControlEventArgs e)
        {
            UpdateFinancialPages();
        }

        void UpdateActionsPages()
        {
            dayActionsReportControl.IsDisplayed = false;
            weekActionsReport.IsDisplayed = false;
            controlActionsOverview.IsDisplayed = false;
            if (actionPages.SelectedTab.Equals(dayPage)) {
                dayActionsReportControl.IsDisplayed = true;
            } else if (actionPages.SelectedTab.Equals(weekPage)) {
                weekActionsReport.IsDisplayed = true;
            } else if (actionPages.SelectedTab.Equals(overviewPage)) {
                controlActionsOverview.IsDisplayed = true;
            }
        }

        void UpdateMealPages()
        {
            mealsDailyReportControl.IsDisplayed = false;
            availableFoodsControl.IsDisplayed = false;
            if (mealPages.SelectedTab.Equals(dailyPage)) {
                mealsDailyReportControl.IsDisplayed = true;
            } else if (mealPages.SelectedTab.Equals(availableFoodsPage)) {
                availableFoodsControl.IsDisplayed = true;
            }
        }

        void UpdateFinancialPages()
        {
            financesControl.IsDisplayed = false;
            transactionsControl.IsDisplayed = false;
            if (financialPages.SelectedTab.Equals(accountsPage)) {
                financesControl.IsDisplayed = true;
            } else if (financialPages.SelectedTab.Equals(transactionsPage)) {
                transactionsControl.IsDisplayed = true;
            }
        }

        #endregion

        #region MainMenu

        void OpenStorgeToolStripMenuItemClick(object sender, EventArgs e)
        {
            OpenStorage();
        }

        void DumpToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "SQL Script (*.sql)|*.sql";
            if (sfd.ShowDialog() == DialogResult.OK) {
                try {
                    Controller.DumpSql(sfd.FileName);
                    MessageBox.Show("Operation completed successfully.",
                                    "Dump database",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                } catch (Exception ex) {
                    MessageBox.Show("There was an error when dumping the database.\n" + ex.Message,
                                    "Dump database",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                }
            }
        }

        void DumpToolStripMenuItem1Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This operation will COMPLETELY ERASE the current database!\n" +
                                "Are you sure you want to continue?",
                                "Restore database",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "SQL Script (*.sql)|*.sql";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    try {
                        Controller.RestoreFromSqlDump(ofd.FileName);
                        MessageBox.Show("Operation completed successfully.",
                                        "Restore database",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show("There was an error when restoring the database.\n" + ex.Message,
                                        "Restore database",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            ExitApplication();
        }

        void BudgetCategoriesToolStripMenuItemClick(object sender, EventArgs e)
        {
            new FormEditBudgetCategories().ShowDialog();
        }

        void AccoutTypesToolStripMenuItemClick(object sender, EventArgs e)
        {
            new FormEditAccountTypes().ShowDialog();
        }

        void AccountsToolStripMenuItemClick(object sender, EventArgs e)
        {
            try {
                new FormEditAccounts().ShowDialog();
            } catch (ApplicationException) {
                MessageBox.Show("No account types defined!\n" +
                                "You can edit account types by going to Edit -> Account Types...",
                                "Cannot edit accounts",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        void TransferreasonsToolStripMenuItemClick(object sender, EventArgs e)
        {
            new FormEditTransactionReasons().ShowDialog();
        }

        void PreferencesToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormEditProperties dialog = new FormEditProperties();
            dialog.ShowDialog();
        }

        void ManageMealsToolStripMenuItemClick(object sender, EventArgs e)
        {
            new FormManageMeals().ShowDialog();
        }

        void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog();
        }

        #endregion

        #region ToolBar

        void OpenToolButtonClick(object sender, EventArgs e)
        {
            OpenStorage();
        }

        void ActionsToolButtonClick(object sender, EventArgs e)
        {
            SelectActionsView();
        }

        void NotesToolButtonClick(object sender, EventArgs e)
        {
            SelectNotesView();
        }

        void MealsToolButtonClick(object sender, EventArgs e)
        {
            SelectMealsView();
        }

        void FinancesToolButtonClick(object sender, EventArgs e)
        {
            SelectFinancesView();
        }



        void CalculatorToolButtonClick(object sender, EventArgs e)
        {
            ManagerCalculator.Display();
        }

        void TeaTimerToolButtonClick(object sender, EventArgs e)
        {
            ManagerTeaTimer.Display();
        }

        void RemindersToolButtonClick(object sender, EventArgs e)
        {
            ManagerReminders.Instance.Display();
        }

        void CalendarToolButtonClick(object sender, EventArgs e)
        {
            ManagerCalendar.Display();
        }

        #endregion

        #region Tools

        void CalculatorToolStripMenuItemClick(object sender, EventArgs e)
        {
            ManagerCalculator.Display();
        }

        void TeaTimerToolStripMenuItemClick(object sender, EventArgs e)
        {
            ManagerTeaTimer.Display();
        }

        void RemindersToolStripMenuItemClick(object sender, EventArgs e)
        {
            ManagerReminders.Instance.Display();
        }

        void CalendarToolStripMenuItemClick(object sender, EventArgs e)
        {
            ManagerCalendar.Display();
        }

        void ExitToolStripMenuItem1Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        #endregion

        void OpenStorage()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Choose storage";
            fd.CheckFileExists = false;
            fd.Filter = Configuration.DataFilter;
            fd.InitialDirectory = Configuration.DataFolder;
            fd.ShowDialog();
            Controller.OpenStorage(fd.FileName);
        }

    }
}
