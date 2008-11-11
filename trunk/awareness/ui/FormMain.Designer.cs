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
namespace awareness.ui
{
    partial class FormMain
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        	this.mainMenu = new System.Windows.Forms.MenuStrip();
        	this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.newDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.deleteDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.fileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
        	this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.dumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.dumpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.buddiCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
        	this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.accoutTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.productCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
        	this.transferreasonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
        	this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.manageReminderSoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.mealsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.manageMealsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.statusBar = new System.Windows.Forms.StatusStrip();
        	this.timeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.mainViewPages = new System.Windows.Forms.TabControl();
        	this.actionsPage = new System.Windows.Forms.TabPage();
        	this.actionPages = new System.Windows.Forms.TabControl();
        	this.overviewPage = new System.Windows.Forms.TabPage();
        	this.controlActionsOverview = new awareness.ui.ControlActionsOverview();
        	this.dayPage = new System.Windows.Forms.TabPage();
        	this.dayActionsReportControl = new awareness.ui.ControlDayActionsReport();
        	this.weekPage = new System.Windows.Forms.TabPage();
        	this.weekActionsReport = new awareness.ui.ControlWeekActionsReport();
        	this.notesPage = new System.Windows.Forms.TabPage();
        	this.notesViewer = new awareness.ui.ControlNotesViewer();
        	this.mealsPage = new System.Windows.Forms.TabPage();
        	this.mealPages = new System.Windows.Forms.TabControl();
        	this.dailyPage = new System.Windows.Forms.TabPage();
        	this.mealsDailyReportControl = new awareness.ui.ControlMealsDailyReport();
        	this.availableFoodsPage = new System.Windows.Forms.TabPage();
        	this.availableFoodsControl = new awareness.ui.ControlAvailableFoods();
        	this.financesPage = new System.Windows.Forms.TabPage();
        	this.financialPages = new System.Windows.Forms.TabControl();
        	this.accountsPage = new System.Windows.Forms.TabPage();
        	this.financesControl = new awareness.ui.ControlFinances();
        	this.transactionsPage = new System.Windows.Forms.TabPage();
        	this.transactionsControl = new awareness.ui.ControlTransactions();
        	this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
        	this.defaultToolStrip = new System.Windows.Forms.ToolStrip();
        	this.newToolButton = new System.Windows.Forms.ToolStripButton();
        	this.openToolButton = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.actionsToolButton = new System.Windows.Forms.ToolStripButton();
        	this.notesToolButton = new System.Windows.Forms.ToolStripButton();
        	this.mealsToolButton = new System.Windows.Forms.ToolStripButton();
        	this.financesToolButton = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.calculatorToolButton = new System.Windows.Forms.ToolStripButton();
        	this.statusTimer = new System.Windows.Forms.Timer(this.components);
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.controlActionsOverview1 = new awareness.ui.ControlActionsOverview();
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.controlDayActionsReport1 = new awareness.ui.ControlDayActionsReport();
        	this.tabPage3 = new System.Windows.Forms.TabPage();
        	this.controlWeekActionsReport1 = new awareness.ui.ControlWeekActionsReport();
        	this.mainMenu.SuspendLayout();
        	this.statusBar.SuspendLayout();
        	this.mainViewPages.SuspendLayout();
        	this.actionsPage.SuspendLayout();
        	this.actionPages.SuspendLayout();
        	this.overviewPage.SuspendLayout();
        	this.dayPage.SuspendLayout();
        	this.weekPage.SuspendLayout();
        	this.notesPage.SuspendLayout();
        	this.mealsPage.SuspendLayout();
        	this.mealPages.SuspendLayout();
        	this.dailyPage.SuspendLayout();
        	this.availableFoodsPage.SuspendLayout();
        	this.financesPage.SuspendLayout();
        	this.financialPages.SuspendLayout();
        	this.accountsPage.SuspendLayout();
        	this.transactionsPage.SuspendLayout();
        	this.toolStripContainer.ContentPanel.SuspendLayout();
        	this.toolStripContainer.TopToolStripPanel.SuspendLayout();
        	this.toolStripContainer.SuspendLayout();
        	this.defaultToolStrip.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.tabPage2.SuspendLayout();
        	this.tabPage3.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mainMenu
        	// 
        	this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.fileToolStripMenuItem,
        	        	        	this.editToolStripMenuItem,
        	        	        	this.actionsToolStripMenuItem,
        	        	        	this.mealsToolStripMenuItem,
        	        	        	this.helpToolStripMenuItem});
        	this.mainMenu.Location = new System.Drawing.Point(0, 0);
        	this.mainMenu.Name = "mainMenu";
        	this.mainMenu.Size = new System.Drawing.Size(792, 24);
        	this.mainMenu.TabIndex = 0;
        	this.mainMenu.Text = "MainMenu";
        	// 
        	// fileToolStripMenuItem
        	// 
        	this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.newDatabaseToolStripMenuItem,
        	        	        	this.openDatabaseToolStripMenuItem,
        	        	        	this.deleteDatabaseToolStripMenuItem,
        	        	        	this.fileMenuSeparator,
        	        	        	this.exportToolStripMenuItem,
        	        	        	this.importToolStripMenuItem,
        	        	        	this.toolStripMenuItem2,
        	        	        	this.exitToolStripMenuItem});
        	this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        	this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
        	this.fileToolStripMenuItem.Text = "&File";
        	// 
        	// newDatabaseToolStripMenuItem
        	// 
        	this.newDatabaseToolStripMenuItem.Name = "newDatabaseToolStripMenuItem";
        	this.newDatabaseToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
        	this.newDatabaseToolStripMenuItem.Text = "&New Database...";
        	this.newDatabaseToolStripMenuItem.Click += new System.EventHandler(this.NewDatabaseToolStripMenuItemClick);
        	// 
        	// openDatabaseToolStripMenuItem
        	// 
        	this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
        	this.openDatabaseToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
        	this.openDatabaseToolStripMenuItem.Text = "&Open Database...";
        	this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.OpenDatabaseToolStripMenuItemClick);
        	// 
        	// deleteDatabaseToolStripMenuItem
        	// 
        	this.deleteDatabaseToolStripMenuItem.Name = "deleteDatabaseToolStripMenuItem";
        	this.deleteDatabaseToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
        	this.deleteDatabaseToolStripMenuItem.Text = "&Delete Database";
        	this.deleteDatabaseToolStripMenuItem.Click += new System.EventHandler(this.DeleteDatabaseToolStripMenuItemClick);
        	// 
        	// fileMenuSeparator
        	// 
        	this.fileMenuSeparator.Name = "fileMenuSeparator";
        	this.fileMenuSeparator.Size = new System.Drawing.Size(163, 6);
        	// 
        	// exportToolStripMenuItem
        	// 
        	this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.dumpToolStripMenuItem});
        	this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
        	this.exportToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
        	this.exportToolStripMenuItem.Text = "&Export";
        	// 
        	// dumpToolStripMenuItem
        	// 
        	this.dumpToolStripMenuItem.Name = "dumpToolStripMenuItem";
        	this.dumpToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
        	this.dumpToolStripMenuItem.Text = "SQL &Dump...";
        	this.dumpToolStripMenuItem.Click += new System.EventHandler(this.DumpToolStripMenuItemClick);
        	// 
        	// importToolStripMenuItem
        	// 
        	this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.dumpToolStripMenuItem1,
        	        	        	this.buddiCSVToolStripMenuItem});
        	this.importToolStripMenuItem.Name = "importToolStripMenuItem";
        	this.importToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
        	this.importToolStripMenuItem.Text = "&Import";
        	// 
        	// dumpToolStripMenuItem1
        	// 
        	this.dumpToolStripMenuItem1.Name = "dumpToolStripMenuItem1";
        	this.dumpToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
        	this.dumpToolStripMenuItem1.Text = "SQL &Dump...";
        	this.dumpToolStripMenuItem1.Click += new System.EventHandler(this.DumpToolStripMenuItem1Click);
        	// 
        	// buddiCSVToolStripMenuItem
        	// 
        	this.buddiCSVToolStripMenuItem.Name = "buddiCSVToolStripMenuItem";
        	this.buddiCSVToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
        	this.buddiCSVToolStripMenuItem.Text = "&Buddi CSV...";
        	this.buddiCSVToolStripMenuItem.Click += new System.EventHandler(this.BuddiExportToolStripMenuItemClick);
        	// 
        	// toolStripMenuItem2
        	// 
        	this.toolStripMenuItem2.Name = "toolStripMenuItem2";
        	this.toolStripMenuItem2.Size = new System.Drawing.Size(163, 6);
        	// 
        	// exitToolStripMenuItem
        	// 
        	this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        	this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
        	this.exitToolStripMenuItem.Text = "E&xit";
        	this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
        	// 
        	// editToolStripMenuItem
        	// 
        	this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.accountsToolStripMenuItem,
        	        	        	this.accoutTypesToolStripMenuItem,
        	        	        	this.productCategoriesToolStripMenuItem,
        	        	        	this.toolStripMenuItem4,
        	        	        	this.transferreasonsToolStripMenuItem,
        	        	        	this.toolStripMenuItem7,
        	        	        	this.preferencesToolStripMenuItem});
        	this.editToolStripMenuItem.Name = "editToolStripMenuItem";
        	this.editToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
        	this.editToolStripMenuItem.Text = "&Edit";
        	// 
        	// accountsToolStripMenuItem
        	// 
        	this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
        	this.accountsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        	this.accountsToolStripMenuItem.Text = "&Accounts...";
        	this.accountsToolStripMenuItem.Click += new System.EventHandler(this.AccountsToolStripMenuItemClick);
        	// 
        	// accoutTypesToolStripMenuItem
        	// 
        	this.accoutTypesToolStripMenuItem.Name = "accoutTypesToolStripMenuItem";
        	this.accoutTypesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        	this.accoutTypesToolStripMenuItem.Text = "Accout &Types...";
        	this.accoutTypesToolStripMenuItem.Click += new System.EventHandler(this.AccoutTypesToolStripMenuItemClick);
        	// 
        	// productCategoriesToolStripMenuItem
        	// 
        	this.productCategoriesToolStripMenuItem.Name = "productCategoriesToolStripMenuItem";
        	this.productCategoriesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        	this.productCategoriesToolStripMenuItem.Text = "&Budget Categories...";
        	this.productCategoriesToolStripMenuItem.Click += new System.EventHandler(this.BudgetCategoriesToolStripMenuItemClick);
        	// 
        	// toolStripMenuItem4
        	// 
        	this.toolStripMenuItem4.Name = "toolStripMenuItem4";
        	this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 6);
        	// 
        	// transferreasonsToolStripMenuItem
        	// 
        	this.transferreasonsToolStripMenuItem.Name = "transferreasonsToolStripMenuItem";
        	this.transferreasonsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        	this.transferreasonsToolStripMenuItem.Text = "Transfer &Reasons...";
        	this.transferreasonsToolStripMenuItem.Click += new System.EventHandler(this.TransferreasonsToolStripMenuItemClick);
        	// 
        	// toolStripMenuItem7
        	// 
        	this.toolStripMenuItem7.Name = "toolStripMenuItem7";
        	this.toolStripMenuItem7.Size = new System.Drawing.Size(180, 6);
        	// 
        	// preferencesToolStripMenuItem
        	// 
        	this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
        	this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
        	this.preferencesToolStripMenuItem.Text = "Pre&ferences...";
        	// 
        	// actionsToolStripMenuItem
        	// 
        	this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.manageReminderSoundsToolStripMenuItem});
        	this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
        	this.actionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
        	this.actionsToolStripMenuItem.Text = "&Actions";
        	// 
        	// manageReminderSoundsToolStripMenuItem
        	// 
        	this.manageReminderSoundsToolStripMenuItem.Name = "manageReminderSoundsToolStripMenuItem";
        	this.manageReminderSoundsToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
        	this.manageReminderSoundsToolStripMenuItem.Text = "&Manage Reminder Sounds...";
        	// 
        	// mealsToolStripMenuItem
        	// 
        	this.mealsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.manageMealsToolStripMenuItem});
        	this.mealsToolStripMenuItem.Name = "mealsToolStripMenuItem";
        	this.mealsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
        	this.mealsToolStripMenuItem.Text = "&Meals";
        	// 
        	// manageMealsToolStripMenuItem
        	// 
        	this.manageMealsToolStripMenuItem.Name = "manageMealsToolStripMenuItem";
        	this.manageMealsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
        	this.manageMealsToolStripMenuItem.Text = "&Manage Meals...";
        	this.manageMealsToolStripMenuItem.Click += new System.EventHandler(this.ManageMealsToolStripMenuItemClick);
        	// 
        	// helpToolStripMenuItem
        	// 
        	this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        	this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        	this.helpToolStripMenuItem.Text = "&Help";
        	// 
        	// statusBar
        	// 
        	this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.timeStatusLabel});
        	this.statusBar.Location = new System.Drawing.Point(0, 548);
        	this.statusBar.Name = "statusBar";
        	this.statusBar.Size = new System.Drawing.Size(792, 22);
        	this.statusBar.Stretch = false;
        	this.statusBar.TabIndex = 1;
        	// 
        	// timeStatusLabel
        	// 
        	this.timeStatusLabel.MergeIndex = 0;
        	this.timeStatusLabel.Name = "timeStatusLabel";
        	this.timeStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
        	this.timeStatusLabel.Size = new System.Drawing.Size(777, 17);
        	this.timeStatusLabel.Spring = true;
        	this.timeStatusLabel.Text = "Current time";
        	this.timeStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// mainViewPages
        	// 
        	this.mainViewPages.Controls.Add(this.actionsPage);
        	this.mainViewPages.Controls.Add(this.notesPage);
        	this.mainViewPages.Controls.Add(this.mealsPage);
        	this.mainViewPages.Controls.Add(this.financesPage);
        	this.mainViewPages.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mainViewPages.Location = new System.Drawing.Point(0, 0);
        	this.mainViewPages.Name = "mainViewPages";
        	this.mainViewPages.SelectedIndex = 0;
        	this.mainViewPages.Size = new System.Drawing.Size(792, 499);
        	this.mainViewPages.TabIndex = 2;
        	// 
        	// actionsPage
        	// 
        	this.actionsPage.BackColor = System.Drawing.SystemColors.Control;
        	this.actionsPage.Controls.Add(this.actionPages);
        	this.actionsPage.Location = new System.Drawing.Point(4, 23);
        	this.actionsPage.Name = "actionsPage";
        	this.actionsPage.Padding = new System.Windows.Forms.Padding(1);
        	this.actionsPage.Size = new System.Drawing.Size(784, 472);
        	this.actionsPage.TabIndex = 5;
        	this.actionsPage.Text = "Actions";
        	// 
        	// actionPages
        	// 
        	this.actionPages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
        	this.actionPages.Controls.Add(this.overviewPage);
        	this.actionPages.Controls.Add(this.dayPage);
        	this.actionPages.Controls.Add(this.weekPage);
        	this.actionPages.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.actionPages.Location = new System.Drawing.Point(1, 1);
        	this.actionPages.Name = "actionPages";
        	this.actionPages.SelectedIndex = 0;
        	this.actionPages.Size = new System.Drawing.Size(782, 470);
        	this.actionPages.TabIndex = 0;
        	this.actionPages.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.ActionPagesSelecting);
        	// 
        	// overviewPage
        	// 
        	this.overviewPage.Controls.Add(this.controlActionsOverview);
        	this.overviewPage.Location = new System.Drawing.Point(4, 25);
        	this.overviewPage.Name = "overviewPage";
        	this.overviewPage.Padding = new System.Windows.Forms.Padding(3);
        	this.overviewPage.Size = new System.Drawing.Size(774, 441);
        	this.overviewPage.TabIndex = 0;
        	this.overviewPage.Text = "Overview";
        	this.overviewPage.UseVisualStyleBackColor = true;
        	// 
        	// controlActionsOverview
        	// 
        	this.controlActionsOverview.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.controlActionsOverview.Location = new System.Drawing.Point(3, 3);
        	this.controlActionsOverview.Name = "controlActionsOverview";
        	this.controlActionsOverview.Size = new System.Drawing.Size(768, 435);
        	this.controlActionsOverview.TabIndex = 0;
        	// 
        	// dayPage
        	// 
        	this.dayPage.Controls.Add(this.dayActionsReportControl);
        	this.dayPage.Location = new System.Drawing.Point(4, 25);
        	this.dayPage.Name = "dayPage";
        	this.dayPage.Padding = new System.Windows.Forms.Padding(3);
        	this.dayPage.Size = new System.Drawing.Size(774, 441);
        	this.dayPage.TabIndex = 1;
        	this.dayPage.Text = "Day";
        	this.dayPage.UseVisualStyleBackColor = true;
        	// 
        	// dayActionsReportControl
        	// 
        	this.dayActionsReportControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dayActionsReportControl.Location = new System.Drawing.Point(3, 3);
        	this.dayActionsReportControl.Name = "dayActionsReportControl";
        	this.dayActionsReportControl.Size = new System.Drawing.Size(768, 435);
        	this.dayActionsReportControl.TabIndex = 0;
        	// 
        	// weekPage
        	// 
        	this.weekPage.Controls.Add(this.weekActionsReport);
        	this.weekPage.Location = new System.Drawing.Point(4, 25);
        	this.weekPage.Name = "weekPage";
        	this.weekPage.Padding = new System.Windows.Forms.Padding(3);
        	this.weekPage.Size = new System.Drawing.Size(774, 441);
        	this.weekPage.TabIndex = 2;
        	this.weekPage.Text = "Week";
        	this.weekPage.UseVisualStyleBackColor = true;
        	// 
        	// weekActionsReport
        	// 
        	this.weekActionsReport.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.weekActionsReport.Location = new System.Drawing.Point(3, 3);
        	this.weekActionsReport.Name = "weekActionsReport";
        	this.weekActionsReport.Size = new System.Drawing.Size(768, 435);
        	this.weekActionsReport.TabIndex = 0;
        	// 
        	// notesPage
        	// 
        	this.notesPage.BackColor = System.Drawing.SystemColors.Control;
        	this.notesPage.Controls.Add(this.notesViewer);
        	this.notesPage.Location = new System.Drawing.Point(4, 23);
        	this.notesPage.Name = "notesPage";
        	this.notesPage.Size = new System.Drawing.Size(784, 472);
        	this.notesPage.TabIndex = 4;
        	this.notesPage.Text = "Notes";
        	// 
        	// notesViewer
        	// 
        	this.notesViewer.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.notesViewer.Location = new System.Drawing.Point(0, 0);
        	this.notesViewer.Name = "notesViewer";
        	this.notesViewer.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
        	this.notesViewer.Size = new System.Drawing.Size(784, 472);
        	this.notesViewer.TabIndex = 0;
        	// 
        	// mealsPage
        	// 
        	this.mealsPage.BackColor = System.Drawing.SystemColors.Control;
        	this.mealsPage.Controls.Add(this.mealPages);
        	this.mealsPage.Location = new System.Drawing.Point(4, 23);
        	this.mealsPage.Name = "mealsPage";
        	this.mealsPage.Padding = new System.Windows.Forms.Padding(3, 1, 1, 1);
        	this.mealsPage.Size = new System.Drawing.Size(784, 472);
        	this.mealsPage.TabIndex = 3;
        	this.mealsPage.Text = "Meals";
        	// 
        	// mealPages
        	// 
        	this.mealPages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
        	this.mealPages.Controls.Add(this.dailyPage);
        	this.mealPages.Controls.Add(this.availableFoodsPage);
        	this.mealPages.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mealPages.Location = new System.Drawing.Point(3, 1);
        	this.mealPages.Multiline = true;
        	this.mealPages.Name = "mealPages";
        	this.mealPages.RightToLeft = System.Windows.Forms.RightToLeft.No;
        	this.mealPages.SelectedIndex = 0;
        	this.mealPages.Size = new System.Drawing.Size(780, 470);
        	this.mealPages.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
        	this.mealPages.TabIndex = 0;
        	// 
        	// dailyPage
        	// 
        	this.dailyPage.Controls.Add(this.mealsDailyReportControl);
        	this.dailyPage.Location = new System.Drawing.Point(4, 25);
        	this.dailyPage.Name = "dailyPage";
        	this.dailyPage.Padding = new System.Windows.Forms.Padding(1, 0, 3, 3);
        	this.dailyPage.Size = new System.Drawing.Size(772, 441);
        	this.dailyPage.TabIndex = 1;
        	this.dailyPage.Text = "Daily Report";
        	this.dailyPage.UseVisualStyleBackColor = true;
        	// 
        	// mealsDailyReportControl
        	// 
        	this.mealsDailyReportControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mealsDailyReportControl.Location = new System.Drawing.Point(1, 0);
        	this.mealsDailyReportControl.Name = "mealsDailyReportControl";
        	this.mealsDailyReportControl.Size = new System.Drawing.Size(768, 438);
        	this.mealsDailyReportControl.TabIndex = 0;
        	// 
        	// availableFoodsPage
        	// 
        	this.availableFoodsPage.Controls.Add(this.availableFoodsControl);
        	this.availableFoodsPage.Location = new System.Drawing.Point(4, 49);
        	this.availableFoodsPage.Name = "availableFoodsPage";
        	this.availableFoodsPage.Padding = new System.Windows.Forms.Padding(1, 3, 3, 3);
        	this.availableFoodsPage.Size = new System.Drawing.Size(180, 18);
        	this.availableFoodsPage.TabIndex = 0;
        	this.availableFoodsPage.Text = "Available Foods";
        	this.availableFoodsPage.UseVisualStyleBackColor = true;
        	// 
        	// availableFoodsControl
        	// 
        	this.availableFoodsControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.availableFoodsControl.Location = new System.Drawing.Point(1, 3);
        	this.availableFoodsControl.Name = "availableFoodsControl";
        	this.availableFoodsControl.Size = new System.Drawing.Size(176, 12);
        	this.availableFoodsControl.TabIndex = 0;
        	// 
        	// financesPage
        	// 
        	this.financesPage.BackColor = System.Drawing.SystemColors.Control;
        	this.financesPage.Controls.Add(this.financialPages);
        	this.financesPage.Location = new System.Drawing.Point(4, 23);
        	this.financesPage.Margin = new System.Windows.Forms.Padding(0);
        	this.financesPage.Name = "financesPage";
        	this.financesPage.Padding = new System.Windows.Forms.Padding(1);
        	this.financesPage.Size = new System.Drawing.Size(784, 472);
        	this.financesPage.TabIndex = 2;
        	this.financesPage.Text = "Finances";
        	// 
        	// financialPages
        	// 
        	this.financialPages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
        	this.financialPages.Controls.Add(this.accountsPage);
        	this.financialPages.Controls.Add(this.transactionsPage);
        	this.financialPages.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.financialPages.Location = new System.Drawing.Point(1, 1);
        	this.financialPages.Name = "financialPages";
        	this.financialPages.SelectedIndex = 0;
        	this.financialPages.Size = new System.Drawing.Size(782, 470);
        	this.financialPages.TabIndex = 1;
        	// 
        	// accountsPage
        	// 
        	this.accountsPage.Controls.Add(this.financesControl);
        	this.accountsPage.Location = new System.Drawing.Point(4, 25);
        	this.accountsPage.Name = "accountsPage";
        	this.accountsPage.Padding = new System.Windows.Forms.Padding(3);
        	this.accountsPage.Size = new System.Drawing.Size(774, 441);
        	this.accountsPage.TabIndex = 0;
        	this.accountsPage.Text = "Accounts";
        	this.accountsPage.UseVisualStyleBackColor = true;
        	// 
        	// financesControl
        	// 
        	this.financesControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.financesControl.Location = new System.Drawing.Point(3, 3);
        	this.financesControl.Margin = new System.Windows.Forms.Padding(0);
        	this.financesControl.Name = "financesControl";
        	this.financesControl.Size = new System.Drawing.Size(768, 435);
        	this.financesControl.TabIndex = 0;
        	// 
        	// transactionsPage
        	// 
        	this.transactionsPage.Controls.Add(this.transactionsControl);
        	this.transactionsPage.Location = new System.Drawing.Point(4, 25);
        	this.transactionsPage.Name = "transactionsPage";
        	this.transactionsPage.Padding = new System.Windows.Forms.Padding(3);
        	this.transactionsPage.Size = new System.Drawing.Size(182, 42);
        	this.transactionsPage.TabIndex = 1;
        	this.transactionsPage.Text = "Transactions";
        	this.transactionsPage.UseVisualStyleBackColor = true;
        	// 
        	// transactionsControl
        	// 
        	this.transactionsControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.transactionsControl.EditPanelExpanded = true;
        	this.transactionsControl.Location = new System.Drawing.Point(3, 3);
        	this.transactionsControl.Name = "transactionsControl";
        	this.transactionsControl.SelectPanelExpanded = true;
        	this.transactionsControl.Size = new System.Drawing.Size(176, 36);
        	this.transactionsControl.TabIndex = 0;
        	// 
        	// toolStripContainer
        	// 
        	// 
        	// toolStripContainer.ContentPanel
        	// 
        	this.toolStripContainer.ContentPanel.Controls.Add(this.mainViewPages);
        	this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(792, 499);
        	this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.toolStripContainer.Location = new System.Drawing.Point(0, 24);
        	this.toolStripContainer.Name = "toolStripContainer";
        	this.toolStripContainer.Size = new System.Drawing.Size(792, 524);
        	this.toolStripContainer.TabIndex = 3;
        	this.toolStripContainer.Text = "toolStripContainer1";
        	// 
        	// toolStripContainer.TopToolStripPanel
        	// 
        	this.toolStripContainer.TopToolStripPanel.Controls.Add(this.defaultToolStrip);
        	// 
        	// defaultToolStrip
        	// 
        	this.defaultToolStrip.Dock = System.Windows.Forms.DockStyle.None;
        	this.defaultToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.defaultToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.newToolButton,
        	        	        	this.openToolButton,
        	        	        	this.toolStripSeparator1,
        	        	        	this.actionsToolButton,
        	        	        	this.notesToolButton,
        	        	        	this.mealsToolButton,
        	        	        	this.financesToolButton,
        	        	        	this.toolStripSeparator2,
        	        	        	this.calculatorToolButton});
        	this.defaultToolStrip.Location = new System.Drawing.Point(3, 0);
        	this.defaultToolStrip.Name = "defaultToolStrip";
        	this.defaultToolStrip.Size = new System.Drawing.Size(176, 25);
        	this.defaultToolStrip.TabIndex = 0;
        	// 
        	// newToolButton
        	// 
        	this.newToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.newToolButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolButton.Image")));
        	this.newToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.newToolButton.Name = "newToolButton";
        	this.newToolButton.Size = new System.Drawing.Size(23, 22);
        	this.newToolButton.Text = "New Database";
        	this.newToolButton.ToolTipText = "New database";
        	this.newToolButton.Click += new System.EventHandler(this.NewToolButtonClick);
        	// 
        	// openToolButton
        	// 
        	this.openToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.openToolButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolButton.Image")));
        	this.openToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.openToolButton.Name = "openToolButton";
        	this.openToolButton.Size = new System.Drawing.Size(23, 22);
        	this.openToolButton.Text = "Open Database";
        	this.openToolButton.ToolTipText = "Open database";
        	this.openToolButton.Click += new System.EventHandler(this.OpenToolButtonClick);
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
        	// 
        	// actionsToolButton
        	// 
        	this.actionsToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.actionsToolButton.Image = ((System.Drawing.Image)(resources.GetObject("actionsToolButton.Image")));
        	this.actionsToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.actionsToolButton.Name = "actionsToolButton";
        	this.actionsToolButton.Size = new System.Drawing.Size(23, 22);
        	this.actionsToolButton.Text = "Actions";
        	// 
        	// notesToolButton
        	// 
        	this.notesToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.notesToolButton.Image = ((System.Drawing.Image)(resources.GetObject("notesToolButton.Image")));
        	this.notesToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.notesToolButton.Name = "notesToolButton";
        	this.notesToolButton.Size = new System.Drawing.Size(23, 22);
        	this.notesToolButton.Text = "Notes";
        	// 
        	// mealsToolButton
        	// 
        	this.mealsToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.mealsToolButton.Image = ((System.Drawing.Image)(resources.GetObject("mealsToolButton.Image")));
        	this.mealsToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.mealsToolButton.Name = "mealsToolButton";
        	this.mealsToolButton.Size = new System.Drawing.Size(23, 22);
        	this.mealsToolButton.Text = "Meals";
        	// 
        	// financesToolButton
        	// 
        	this.financesToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.financesToolButton.Image = ((System.Drawing.Image)(resources.GetObject("financesToolButton.Image")));
        	this.financesToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.financesToolButton.Name = "financesToolButton";
        	this.financesToolButton.Size = new System.Drawing.Size(23, 22);
        	this.financesToolButton.Text = "Finances";
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
        	// 
        	// calculatorToolButton
        	// 
        	this.calculatorToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.calculatorToolButton.Image = ((System.Drawing.Image)(resources.GetObject("calculatorToolButton.Image")));
        	this.calculatorToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.calculatorToolButton.Name = "calculatorToolButton";
        	this.calculatorToolButton.Size = new System.Drawing.Size(23, 22);
        	this.calculatorToolButton.Text = "Calculator";
        	this.calculatorToolButton.Click += new System.EventHandler(this.CalculatorToolButtonClick);
        	// 
        	// statusTimer
        	// 
        	this.statusTimer.Interval = 1000;
        	this.statusTimer.Tick += new System.EventHandler(this.StatusTimerTick);
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.controlActionsOverview1);
        	this.tabPage1.Location = new System.Drawing.Point(4, 25);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage1.Size = new System.Drawing.Size(776, 444);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "Overview";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// controlActionsOverview1
        	// 
        	this.controlActionsOverview1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.controlActionsOverview1.Location = new System.Drawing.Point(3, 3);
        	this.controlActionsOverview1.Name = "controlActionsOverview1";
        	this.controlActionsOverview1.Size = new System.Drawing.Size(770, 438);
        	this.controlActionsOverview1.TabIndex = 0;
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.controlDayActionsReport1);
        	this.tabPage2.Location = new System.Drawing.Point(4, 25);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage2.Size = new System.Drawing.Size(776, 444);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "Day";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// controlDayActionsReport1
        	// 
        	this.controlDayActionsReport1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.controlDayActionsReport1.Location = new System.Drawing.Point(3, 3);
        	this.controlDayActionsReport1.Name = "controlDayActionsReport1";
        	this.controlDayActionsReport1.Size = new System.Drawing.Size(770, 438);
        	this.controlDayActionsReport1.TabIndex = 0;
        	// 
        	// tabPage3
        	// 
        	this.tabPage3.Controls.Add(this.controlWeekActionsReport1);
        	this.tabPage3.Location = new System.Drawing.Point(4, 25);
        	this.tabPage3.Name = "tabPage3";
        	this.tabPage3.Size = new System.Drawing.Size(776, 444);
        	this.tabPage3.TabIndex = 2;
        	this.tabPage3.Text = "Week";
        	this.tabPage3.UseVisualStyleBackColor = true;
        	// 
        	// controlWeekActionsReport1
        	// 
        	this.controlWeekActionsReport1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.controlWeekActionsReport1.Location = new System.Drawing.Point(0, 0);
        	this.controlWeekActionsReport1.Name = "controlWeekActionsReport1";
        	this.controlWeekActionsReport1.Size = new System.Drawing.Size(776, 444);
        	this.controlWeekActionsReport1.TabIndex = 0;
        	// 
        	// FormMain
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(792, 570);
        	this.Controls.Add(this.toolStripContainer);
        	this.Controls.Add(this.statusBar);
        	this.Controls.Add(this.mainMenu);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MainMenuStrip = this.mainMenu;
        	this.Name = "FormMain";
        	this.Text = "Awareness";
        	this.Load += new System.EventHandler(this.FormMainLoad);
        	this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainFormClosed);
        	this.mainMenu.ResumeLayout(false);
        	this.mainMenu.PerformLayout();
        	this.statusBar.ResumeLayout(false);
        	this.statusBar.PerformLayout();
        	this.mainViewPages.ResumeLayout(false);
        	this.actionsPage.ResumeLayout(false);
        	this.actionPages.ResumeLayout(false);
        	this.overviewPage.ResumeLayout(false);
        	this.dayPage.ResumeLayout(false);
        	this.weekPage.ResumeLayout(false);
        	this.notesPage.ResumeLayout(false);
        	this.mealsPage.ResumeLayout(false);
        	this.mealPages.ResumeLayout(false);
        	this.dailyPage.ResumeLayout(false);
        	this.availableFoodsPage.ResumeLayout(false);
        	this.financesPage.ResumeLayout(false);
        	this.financialPages.ResumeLayout(false);
        	this.accountsPage.ResumeLayout(false);
        	this.transactionsPage.ResumeLayout(false);
        	this.toolStripContainer.ContentPanel.ResumeLayout(false);
        	this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
        	this.toolStripContainer.TopToolStripPanel.PerformLayout();
        	this.toolStripContainer.ResumeLayout(false);
        	this.toolStripContainer.PerformLayout();
        	this.defaultToolStrip.ResumeLayout(false);
        	this.defaultToolStrip.PerformLayout();
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage2.ResumeLayout(false);
        	this.tabPage3.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private awareness.ui.ControlTransactions transactionsControl;
        private System.Windows.Forms.TabPage transactionsPage;
        private System.Windows.Forms.TabPage accountsPage;
        private System.Windows.Forms.TabControl financialPages;
        private System.Windows.Forms.ToolStripButton calculatorToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton financesToolButton;
        private System.Windows.Forms.ToolStripButton mealsToolButton;
        private System.Windows.Forms.ToolStripButton notesToolButton;
        private System.Windows.Forms.ToolStripButton actionsToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton newToolButton;
        private System.Windows.Forms.ToolStripButton openToolButton;
        private System.Windows.Forms.ToolStripMenuItem manageReminderSoundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private awareness.ui.ControlWeekActionsReport controlWeekActionsReport1;
        private System.Windows.Forms.TabPage tabPage3;
        private awareness.ui.ControlDayActionsReport controlDayActionsReport1;
        private System.Windows.Forms.TabPage tabPage2;
        private awareness.ui.ControlActionsOverview controlActionsOverview1;
        private System.Windows.Forms.TabPage tabPage1;
        private awareness.ui.ControlWeekActionsReport weekActionsReport;
        private System.Windows.Forms.TabPage weekPage;
        private awareness.ui.ControlDayActionsReport dayActionsReportControl;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.ToolStripStatusLabel timeStatusLabel;
        private awareness.ui.ControlActionsOverview controlActionsOverview;
        private System.Windows.Forms.ToolStrip defaultToolStrip;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.TabPage dayPage;
        private System.Windows.Forms.TabPage overviewPage;
        private System.Windows.Forms.TabControl actionPages;
        private System.Windows.Forms.TabPage actionsPage;
        private System.Windows.Forms.TabControl mealPages;
        private awareness.ui.ControlNotesViewer notesViewer;
        private System.Windows.Forms.TabPage notesPage;
        private awareness.ui.ControlMealsDailyReport mealsDailyReportControl;
        private awareness.ui.ControlFinances financesControl;
        private awareness.ui.ControlAvailableFoods availableFoodsControl;
        private System.Windows.Forms.TabPage dailyPage;
        private System.Windows.Forms.TabPage availableFoodsPage;
        private System.Windows.Forms.TabPage mealsPage;
        private System.Windows.Forms.TabPage financesPage;
        private System.Windows.Forms.ToolStripMenuItem manageMealsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem dumpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buddiCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferreasonsToolStripMenuItem;
        private System.Windows.Forms.TabControl mainViewPages;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accoutTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDatabaseToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mealsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenu;
    }
}
