/*
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

/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 30/08/2008
 * Time: 22:07
 *
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class FormMain : Form {
        // TODO: confirm every entry delete
        // TODO: on accountBalanceView double click show transaction manager

        public FormMain(){
            InitializeComponent();
            #if !DEBUG
            buddiCSVToolStripMenuItem.Visible = false;
            #endif
            transactionsControl.SelectPanelExpanded = false;
            transactionsControl.EditPanelExpanded = true;
        }

        void FormMainLoad(object sender, EventArgs e){
            UpdateStatusTime();
            statusTimer.Start();
            new ActionOpenDatabase(this).Run();
        }

        void NewDatabaseToolStripMenuItemClick(object sender, EventArgs e){
            new ActionNewDatabase(this).Run();
        }

        void OpenDatabaseToolStripMenuItemClick(object sender, EventArgs e){
            OpenDatabase();
        }

        void OpenDatabase(){
            string databaseName = ActionOpenDatabase.UiPickDatabaseName();
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

        void ExitToolStripMenuItemClick(object sender, EventArgs e){
            Close();
        }

        internal void DisableEnableActions(){
            bool isDbOperational = !string.IsNullOrEmpty(Configuration.LAST_DATABASE_NAME);
            fileMenuSeparator.Visible = isDbOperational;
            importToolStripMenuItem.Visible = isDbOperational;
            exportToolStripMenuItem.Visible = isDbOperational;
            deleteDatabaseToolStripMenuItem.Enabled = isDbOperational;
            editToolStripMenuItem.Visible = isDbOperational;
            mealsToolStripMenuItem.Visible = isDbOperational;
            mainViewPages.Visible = isDbOperational;
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

        void BuddiExportToolStripMenuItemClick(object sender, EventArgs e){
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Buddi export (*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK){
                try {
                    ImporterBuddy importer = new ImporterBuddy(DbUtil.GetDataContext());
                    importer.Import(ofd.FileName);
                    MessageBox.Show("Operation completed successfully.", "Import Buddi CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DbUtil.ReOpenDataContext();
                }
            }
        }

        void DumpToolStripMenuItemClick(object sender, EventArgs e){
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "SQL Script (*.sql)|*.sql";
            if (sfd.ShowDialog() == DialogResult.OK){
                StreamWriter writer = new StreamWriter(sfd.FileName, false);
                try {
                    DbDumper dd = new DbDumper(DbUtil.GetDataContext());
                    dd.DumpDb(writer);
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
                        DbUtil.RestoreFromSqlDump(ofd.FileName);
                        MessageBox.Show("Operation completed successfully.", "Restore database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } catch (Exception ex) {
                        MessageBox.Show("There was an error when restoring the database.\n" + ex.Message, "Restore database",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        void ManageMealsToolStripMenuItemClick(object sender, EventArgs e){
            new FormManageMeals().ShowDialog();
        }

        void FormMainFormClosed(object sender, FormClosedEventArgs e){
            notesViewer.TextView.UpdateNote();
            DbUtil.CloseDataContext();
        }

        void NewToolButtonClick(object sender, EventArgs e){
            new ActionNewDatabase(this).Run();
        }

        void OpenToolButtonClick(object sender, EventArgs e){
            OpenDatabase();
        }

        void UpdateStatusTime(){
            timeStatusLabel.Text = DateTime.Now.ToString("dddd, d-MMM-yyyy . ( HH:mm )");
        }

        void StatusTimerTick(object sender, EventArgs e){
            UpdateStatusTime();
        }

        void ActionPagesSelecting(object sender, TabControlCancelEventArgs e){
            Debug.WriteLine("ActionPagesSelecting");
            if (e.TabPage.Equals(dayPage)){
                dayActionsReportControl.UpdateActions();
            } else if (e.TabPage.Equals(weekPage)) {
                weekActionsReport.UpdateActions();
            }
        }

        void CalculatorToolButtonClick(object sender, EventArgs e){
            ManagerCalculator.Display();
        }

        void TeaTimerToolButtonClick(object sender, EventArgs e){
            ManagerTeaTimer.Display();
        }

        void RemindersToolButtonClick(object sender, EventArgs e){
            ManagerReminders.Display();
        }
    }
}
