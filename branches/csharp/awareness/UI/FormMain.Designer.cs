﻿/*
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
namespace Awareness.UI
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
        	this.openStorgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.dumpDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
        	this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.accoutTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.productCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.mealsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
        	this.transferreasonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
        	this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.statusBar = new System.Windows.Forms.StatusStrip();
        	this.timeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.mealPages = new System.Windows.Forms.TabControl();
        	this.dailyPage = new System.Windows.Forms.TabPage();
        	this.mealsDailyReportControl = new Awareness.UI.ControlMealsDailyReport();
        	this.availableFoodsPage = new System.Windows.Forms.TabPage();
        	this.availableFoodsControl = new Awareness.UI.ControlAvailableFoods();
        	this.financialPages = new System.Windows.Forms.TabControl();
        	this.accountsPage = new System.Windows.Forms.TabPage();
        	this.financesControl = new Awareness.UI.ControlFinances();
        	this.transactionsPage = new System.Windows.Forms.TabPage();
        	this.transactionsControl = new Awareness.UI.ControlTransactions();
        	this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
        	this.centralPark = new System.Windows.Forms.Panel();
        	this.mealPanel = new System.Windows.Forms.Panel();
        	this.actionPages = new System.Windows.Forms.TabControl();
        	this.dayPage = new System.Windows.Forms.TabPage();
        	this.actionPagesDaySplitContainer = new System.Windows.Forms.SplitContainer();
        	this.dayActionsReportControl = new Awareness.UI.ControlDayActionsReport();
        	this.toDoNote = new Awareness.UI.ControlNoteTextView();
        	this.weekPage = new System.Windows.Forms.TabPage();
        	this.weekActionsReport = new Awareness.UI.ControlWeekActionsReport();
        	this.defaultToolStrip = new System.Windows.Forms.ToolStrip();
        	this.openToolButton = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.actionsToolButton = new System.Windows.Forms.ToolStripButton();
        	this.mealsToolButton = new System.Windows.Forms.ToolStripButton();
        	this.financesToolButton = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.calculatorToolButton = new System.Windows.Forms.ToolStripButton();
        	this.calendarToolButton = new System.Windows.Forms.ToolStripButton();
        	this.statusTimer = new System.Windows.Forms.Timer(this.components);
        	this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
        	this.toolsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.calculatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.calendarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
        	this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.mainMenu.SuspendLayout();
        	this.statusBar.SuspendLayout();
        	this.mealPages.SuspendLayout();
        	this.dailyPage.SuspendLayout();
        	this.availableFoodsPage.SuspendLayout();
        	this.financialPages.SuspendLayout();
        	this.accountsPage.SuspendLayout();
        	this.transactionsPage.SuspendLayout();
        	this.toolStripContainer.ContentPanel.SuspendLayout();
        	this.toolStripContainer.TopToolStripPanel.SuspendLayout();
        	this.toolStripContainer.SuspendLayout();
        	this.centralPark.SuspendLayout();
        	this.mealPanel.SuspendLayout();
        	this.actionPages.SuspendLayout();
        	this.dayPage.SuspendLayout();
        	this.actionPagesDaySplitContainer.Panel1.SuspendLayout();
        	this.actionPagesDaySplitContainer.Panel2.SuspendLayout();
        	this.actionPagesDaySplitContainer.SuspendLayout();
        	this.weekPage.SuspendLayout();
        	this.defaultToolStrip.SuspendLayout();
        	this.toolsMenuStrip.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// mainMenu
        	// 
        	this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.fileToolStripMenuItem,
        	        	        	this.editToolStripMenuItem,
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
        	        	        	this.openStorgeToolStripMenuItem,
        	        	        	this.dumpDatabaseToolStripMenuItem,
        	        	        	this.toolStripMenuItem2,
        	        	        	this.exitToolStripMenuItem});
        	this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        	this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        	this.fileToolStripMenuItem.Text = "&File";
        	// 
        	// openStorgeToolStripMenuItem
        	// 
        	this.openStorgeToolStripMenuItem.Name = "openStorgeToolStripMenuItem";
        	this.openStorgeToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
        	this.openStorgeToolStripMenuItem.Text = "&Open Storge ...";
        	this.openStorgeToolStripMenuItem.Click += new System.EventHandler(this.OpenStorgeToolStripMenuItemClick);
        	// 
        	// dumpDatabaseToolStripMenuItem
        	// 
        	this.dumpDatabaseToolStripMenuItem.Name = "dumpDatabaseToolStripMenuItem";
        	this.dumpDatabaseToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
        	this.dumpDatabaseToolStripMenuItem.Text = "&Dump Database ...";
        	this.dumpDatabaseToolStripMenuItem.Visible = false;
        	this.dumpDatabaseToolStripMenuItem.Click += new System.EventHandler(this.DumpDatabaseToolStripMenuItemClick);
        	// 
        	// toolStripMenuItem2
        	// 
        	this.toolStripMenuItem2.Name = "toolStripMenuItem2";
        	this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 6);
        	// 
        	// exitToolStripMenuItem
        	// 
        	this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        	this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
        	this.exitToolStripMenuItem.Text = "E&xit";
        	this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
        	// 
        	// editToolStripMenuItem
        	// 
        	this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.accountsToolStripMenuItem,
        	        	        	this.accoutTypesToolStripMenuItem,
        	        	        	this.productCategoriesToolStripMenuItem,
        	        	        	this.mealsToolStripMenuItem,
        	        	        	this.toolStripMenuItem4,
        	        	        	this.transferreasonsToolStripMenuItem,
        	        	        	this.toolStripMenuItem7,
        	        	        	this.preferencesToolStripMenuItem});
        	this.editToolStripMenuItem.Name = "editToolStripMenuItem";
        	this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
        	this.editToolStripMenuItem.Text = "&Edit";
        	// 
        	// accountsToolStripMenuItem
        	// 
        	this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
        	this.accountsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        	this.accountsToolStripMenuItem.Text = "&Accounts...";
        	this.accountsToolStripMenuItem.Click += new System.EventHandler(this.AccountsToolStripMenuItemClick);
        	// 
        	// accoutTypesToolStripMenuItem
        	// 
        	this.accoutTypesToolStripMenuItem.Name = "accoutTypesToolStripMenuItem";
        	this.accoutTypesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        	this.accoutTypesToolStripMenuItem.Text = "Accout &Types...";
        	this.accoutTypesToolStripMenuItem.Click += new System.EventHandler(this.AccoutTypesToolStripMenuItemClick);
        	// 
        	// productCategoriesToolStripMenuItem
        	// 
        	this.productCategoriesToolStripMenuItem.Name = "productCategoriesToolStripMenuItem";
        	this.productCategoriesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        	this.productCategoriesToolStripMenuItem.Text = "&Budget Categories...";
        	this.productCategoriesToolStripMenuItem.Click += new System.EventHandler(this.BudgetCategoriesToolStripMenuItemClick);
        	// 
        	// mealsToolStripMenuItem
        	// 
        	this.mealsToolStripMenuItem.Name = "mealsToolStripMenuItem";
        	this.mealsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        	this.mealsToolStripMenuItem.Text = "&Meals...";
        	this.mealsToolStripMenuItem.Click += new System.EventHandler(this.MealsToolStripMenuItem1Click);
        	// 
        	// toolStripMenuItem4
        	// 
        	this.toolStripMenuItem4.Name = "toolStripMenuItem4";
        	this.toolStripMenuItem4.Size = new System.Drawing.Size(177, 6);
        	// 
        	// transferreasonsToolStripMenuItem
        	// 
        	this.transferreasonsToolStripMenuItem.Name = "transferreasonsToolStripMenuItem";
        	this.transferreasonsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        	this.transferreasonsToolStripMenuItem.Text = "Transfer &Reasons...";
        	this.transferreasonsToolStripMenuItem.Click += new System.EventHandler(this.TransferreasonsToolStripMenuItemClick);
        	// 
        	// toolStripMenuItem7
        	// 
        	this.toolStripMenuItem7.Name = "toolStripMenuItem7";
        	this.toolStripMenuItem7.Size = new System.Drawing.Size(177, 6);
        	// 
        	// preferencesToolStripMenuItem
        	// 
        	this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
        	this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
        	this.preferencesToolStripMenuItem.Text = "Pre&ferences...";
        	this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.PreferencesToolStripMenuItemClick);
        	// 
        	// helpToolStripMenuItem
        	// 
        	this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.aboutToolStripMenuItem});
        	this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        	this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        	this.helpToolStripMenuItem.Text = "&Help";
        	// 
        	// aboutToolStripMenuItem
        	// 
        	this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        	this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
        	this.aboutToolStripMenuItem.Text = "&About";
        	this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
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
        	// mealPages
        	// 
        	this.mealPages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
        	this.mealPages.Controls.Add(this.dailyPage);
        	this.mealPages.Controls.Add(this.availableFoodsPage);
        	this.mealPages.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mealPages.Location = new System.Drawing.Point(2, 0);
        	this.mealPages.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
        	this.mealPages.Multiline = true;
        	this.mealPages.Name = "mealPages";
        	this.mealPages.RightToLeft = System.Windows.Forms.RightToLeft.No;
        	this.mealPages.SelectedIndex = 0;
        	this.mealPages.Size = new System.Drawing.Size(294, 208);
        	this.mealPages.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
        	this.mealPages.TabIndex = 0;
        	this.mealPages.Selected += new System.Windows.Forms.TabControlEventHandler(this.MealPagesSelected);
        	// 
        	// dailyPage
        	// 
        	this.dailyPage.Controls.Add(this.mealsDailyReportControl);
        	this.dailyPage.Location = new System.Drawing.Point(4, 25);
        	this.dailyPage.Name = "dailyPage";
        	this.dailyPage.Padding = new System.Windows.Forms.Padding(1, 0, 3, 3);
        	this.dailyPage.Size = new System.Drawing.Size(286, 179);
        	this.dailyPage.TabIndex = 1;
        	this.dailyPage.Text = "Daily Report";
        	this.dailyPage.UseVisualStyleBackColor = true;
        	// 
        	// mealsDailyReportControl
        	// 
        	this.mealsDailyReportControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mealsDailyReportControl.IsDisplayed = false;
        	this.mealsDailyReportControl.Location = new System.Drawing.Point(1, 0);
        	this.mealsDailyReportControl.Name = "mealsDailyReportControl";
        	this.mealsDailyReportControl.Size = new System.Drawing.Size(282, 176);
        	this.mealsDailyReportControl.TabIndex = 0;
        	// 
        	// availableFoodsPage
        	// 
        	this.availableFoodsPage.Controls.Add(this.availableFoodsControl);
        	this.availableFoodsPage.Location = new System.Drawing.Point(4, 25);
        	this.availableFoodsPage.Name = "availableFoodsPage";
        	this.availableFoodsPage.Padding = new System.Windows.Forms.Padding(1, 3, 3, 3);
        	this.availableFoodsPage.Size = new System.Drawing.Size(286, 179);
        	this.availableFoodsPage.TabIndex = 0;
        	this.availableFoodsPage.Text = "Available Foods";
        	this.availableFoodsPage.UseVisualStyleBackColor = true;
        	// 
        	// availableFoodsControl
        	// 
        	this.availableFoodsControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.availableFoodsControl.IsDisplayed = false;
        	this.availableFoodsControl.Location = new System.Drawing.Point(1, 3);
        	this.availableFoodsControl.Name = "availableFoodsControl";
        	this.availableFoodsControl.Size = new System.Drawing.Size(282, 173);
        	this.availableFoodsControl.TabIndex = 0;
        	// 
        	// financialPages
        	// 
        	this.financialPages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
        	this.financialPages.Controls.Add(this.accountsPage);
        	this.financialPages.Controls.Add(this.transactionsPage);
        	this.financialPages.Location = new System.Drawing.Point(16, 280);
        	this.financialPages.Name = "financialPages";
        	this.financialPages.SelectedIndex = 0;
        	this.financialPages.Size = new System.Drawing.Size(336, 198);
        	this.financialPages.TabIndex = 1;
        	this.financialPages.Selected += new System.Windows.Forms.TabControlEventHandler(this.FinancialPagesSelected);
        	// 
        	// accountsPage
        	// 
        	this.accountsPage.Controls.Add(this.financesControl);
        	this.accountsPage.Location = new System.Drawing.Point(4, 25);
        	this.accountsPage.Name = "accountsPage";
        	this.accountsPage.Padding = new System.Windows.Forms.Padding(3);
        	this.accountsPage.Size = new System.Drawing.Size(328, 169);
        	this.accountsPage.TabIndex = 0;
        	this.accountsPage.Text = "Accounts";
        	this.accountsPage.UseVisualStyleBackColor = true;
        	// 
        	// financesControl
        	// 
        	this.financesControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.financesControl.IsDisplayed = false;
        	this.financesControl.Location = new System.Drawing.Point(3, 3);
        	this.financesControl.Margin = new System.Windows.Forms.Padding(0);
        	this.financesControl.Name = "financesControl";
        	this.financesControl.Size = new System.Drawing.Size(322, 163);
        	this.financesControl.TabIndex = 0;
        	// 
        	// transactionsPage
        	// 
        	this.transactionsPage.Controls.Add(this.transactionsControl);
        	this.transactionsPage.Location = new System.Drawing.Point(4, 25);
        	this.transactionsPage.Name = "transactionsPage";
        	this.transactionsPage.Padding = new System.Windows.Forms.Padding(3);
        	this.transactionsPage.Size = new System.Drawing.Size(328, 169);
        	this.transactionsPage.TabIndex = 1;
        	this.transactionsPage.Text = "Transactions";
        	this.transactionsPage.UseVisualStyleBackColor = true;
        	// 
        	// transactionsControl
        	// 
        	this.transactionsControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.transactionsControl.EditPanelExpanded = true;
        	this.transactionsControl.IsDisplayed = false;
        	this.transactionsControl.Location = new System.Drawing.Point(3, 3);
        	this.transactionsControl.Name = "transactionsControl";
        	this.transactionsControl.SelectPanelExpanded = true;
        	this.transactionsControl.Size = new System.Drawing.Size(322, 163);
        	this.transactionsControl.TabIndex = 0;
        	// 
        	// toolStripContainer
        	// 
        	// 
        	// toolStripContainer.ContentPanel
        	// 
        	this.toolStripContainer.ContentPanel.Controls.Add(this.centralPark);
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
        	// centralPark
        	// 
        	this.centralPark.Controls.Add(this.mealPanel);
        	this.centralPark.Controls.Add(this.financialPages);
        	this.centralPark.Controls.Add(this.actionPages);
        	this.centralPark.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.centralPark.Location = new System.Drawing.Point(0, 0);
        	this.centralPark.Name = "centralPark";
        	this.centralPark.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
        	this.centralPark.Size = new System.Drawing.Size(792, 499);
        	this.centralPark.TabIndex = 2;
        	// 
        	// mealPanel
        	// 
        	this.mealPanel.Controls.Add(this.mealPages);
        	this.mealPanel.Location = new System.Drawing.Point(424, 40);
        	this.mealPanel.Name = "mealPanel";
        	this.mealPanel.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
        	this.mealPanel.Size = new System.Drawing.Size(296, 208);
        	this.mealPanel.TabIndex = 2;
        	// 
        	// actionPages
        	// 
        	this.actionPages.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
        	this.actionPages.Controls.Add(this.dayPage);
        	this.actionPages.Controls.Add(this.weekPage);
        	this.actionPages.Location = new System.Drawing.Point(24, 24);
        	this.actionPages.Name = "actionPages";
        	this.actionPages.SelectedIndex = 0;
        	this.actionPages.Size = new System.Drawing.Size(384, 208);
        	this.actionPages.TabIndex = 0;
        	this.actionPages.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.ActionPagesSelecting);
        	// 
        	// dayPage
        	// 
        	this.dayPage.Controls.Add(this.actionPagesDaySplitContainer);
        	this.dayPage.Location = new System.Drawing.Point(4, 25);
        	this.dayPage.Name = "dayPage";
        	this.dayPage.Padding = new System.Windows.Forms.Padding(3);
        	this.dayPage.Size = new System.Drawing.Size(376, 179);
        	this.dayPage.TabIndex = 1;
        	this.dayPage.Text = "Day";
        	this.dayPage.UseVisualStyleBackColor = true;
        	// 
        	// actionPagesDaySplitContainer
        	// 
        	this.actionPagesDaySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.actionPagesDaySplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        	this.actionPagesDaySplitContainer.Location = new System.Drawing.Point(3, 3);
        	this.actionPagesDaySplitContainer.Name = "actionPagesDaySplitContainer";
        	// 
        	// actionPagesDaySplitContainer.Panel1
        	// 
        	this.actionPagesDaySplitContainer.Panel1.Controls.Add(this.dayActionsReportControl);
        	// 
        	// actionPagesDaySplitContainer.Panel2
        	// 
        	this.actionPagesDaySplitContainer.Panel2.Controls.Add(this.toDoNote);
        	this.actionPagesDaySplitContainer.Size = new System.Drawing.Size(370, 173);
        	this.actionPagesDaySplitContainer.SplitterDistance = 85;
        	this.actionPagesDaySplitContainer.TabIndex = 1;
        	// 
        	// dayActionsReportControl
        	// 
        	this.dayActionsReportControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dayActionsReportControl.IsDisplayed = false;
        	this.dayActionsReportControl.Location = new System.Drawing.Point(0, 0);
        	this.dayActionsReportControl.Name = "dayActionsReportControl";
        	this.dayActionsReportControl.Size = new System.Drawing.Size(85, 173);
        	this.dayActionsReportControl.TabIndex = 0;
        	// 
        	// toDoNote
        	// 
        	this.toDoNote.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.toDoNote.IconVisible = false;
        	this.toDoNote.Location = new System.Drawing.Point(0, 0);
        	this.toDoNote.Name = "toDoNote";
        	this.toDoNote.Node = null;
        	this.toDoNote.Note = null;
        	this.toDoNote.ScrollBars = true;
        	this.toDoNote.Size = new System.Drawing.Size(281, 173);
        	this.toDoNote.TabIndex = 0;
        	this.toDoNote.TextReadOnly = false;
        	this.toDoNote.TitleReadOnly = false;
        	this.toDoNote.TopVisible = false;
        	// 
        	// weekPage
        	// 
        	this.weekPage.Controls.Add(this.weekActionsReport);
        	this.weekPage.Location = new System.Drawing.Point(4, 25);
        	this.weekPage.Name = "weekPage";
        	this.weekPage.Padding = new System.Windows.Forms.Padding(3);
        	this.weekPage.Size = new System.Drawing.Size(376, 179);
        	this.weekPage.TabIndex = 2;
        	this.weekPage.Text = "Week";
        	this.weekPage.UseVisualStyleBackColor = true;
        	// 
        	// weekActionsReport
        	// 
        	this.weekActionsReport.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.weekActionsReport.IsDisplayed = false;
        	this.weekActionsReport.Location = new System.Drawing.Point(3, 3);
        	this.weekActionsReport.Name = "weekActionsReport";
        	this.weekActionsReport.Size = new System.Drawing.Size(370, 173);
        	this.weekActionsReport.TabIndex = 0;
        	// 
        	// defaultToolStrip
        	// 
        	this.defaultToolStrip.Dock = System.Windows.Forms.DockStyle.None;
        	this.defaultToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.defaultToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.openToolButton,
        	        	        	this.toolStripSeparator2,
        	        	        	this.actionsToolButton,
        	        	        	this.mealsToolButton,
        	        	        	this.financesToolButton,
        	        	        	this.toolStripSeparator1,
        	        	        	this.calculatorToolButton,
        	        	        	this.calendarToolButton});
        	this.defaultToolStrip.Location = new System.Drawing.Point(3, 0);
        	this.defaultToolStrip.Name = "defaultToolStrip";
        	this.defaultToolStrip.Size = new System.Drawing.Size(153, 25);
        	this.defaultToolStrip.TabIndex = 0;
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
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
        	// 
        	// actionsToolButton
        	// 
        	this.actionsToolButton.Checked = true;
        	this.actionsToolButton.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.actionsToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.actionsToolButton.Image = ((System.Drawing.Image)(resources.GetObject("actionsToolButton.Image")));
        	this.actionsToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.actionsToolButton.Name = "actionsToolButton";
        	this.actionsToolButton.Size = new System.Drawing.Size(23, 22);
        	this.actionsToolButton.Text = "Diary";
        	this.actionsToolButton.Click += new System.EventHandler(this.ActionsToolButtonClick);
        	// 
        	// mealsToolButton
        	// 
        	this.mealsToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.mealsToolButton.Image = ((System.Drawing.Image)(resources.GetObject("mealsToolButton.Image")));
        	this.mealsToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.mealsToolButton.Name = "mealsToolButton";
        	this.mealsToolButton.Size = new System.Drawing.Size(23, 22);
        	this.mealsToolButton.Text = "Meals";
        	this.mealsToolButton.Click += new System.EventHandler(this.MealsToolButtonClick);
        	// 
        	// financesToolButton
        	// 
        	this.financesToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.financesToolButton.Image = ((System.Drawing.Image)(resources.GetObject("financesToolButton.Image")));
        	this.financesToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.financesToolButton.Name = "financesToolButton";
        	this.financesToolButton.Size = new System.Drawing.Size(23, 22);
        	this.financesToolButton.Text = "Finances";
        	this.financesToolButton.Click += new System.EventHandler(this.FinancesToolButtonClick);
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
        	// calendarToolButton
        	// 
        	this.calendarToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.calendarToolButton.Image = ((System.Drawing.Image)(resources.GetObject("calendarToolButton.Image")));
        	this.calendarToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.calendarToolButton.Name = "calendarToolButton";
        	this.calendarToolButton.Size = new System.Drawing.Size(23, 22);
        	this.calendarToolButton.Text = "Calendar";
        	this.calendarToolButton.Click += new System.EventHandler(this.CalendarToolButtonClick);
        	// 
        	// statusTimer
        	// 
        	this.statusTimer.Interval = 1000;
        	this.statusTimer.Tick += new System.EventHandler(this.StatusTimerTick);
        	// 
        	// trayIcon
        	// 
        	this.trayIcon.ContextMenuStrip = this.toolsMenuStrip;
        	this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
        	this.trayIcon.Visible = true;
        	this.trayIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrayIconMouseDown);
        	// 
        	// toolsMenuStrip
        	// 
        	this.toolsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.calculatorToolStripMenuItem,
        	        	        	this.calendarToolStripMenuItem,
        	        	        	this.toolStripMenuItem1,
        	        	        	this.exitToolStripMenuItem1});
        	this.toolsMenuStrip.Name = "toolsMenuStrip";
        	this.toolsMenuStrip.Size = new System.Drawing.Size(129, 76);
        	// 
        	// calculatorToolStripMenuItem
        	// 
        	this.calculatorToolStripMenuItem.Name = "calculatorToolStripMenuItem";
        	this.calculatorToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
        	this.calculatorToolStripMenuItem.Text = "C&alculator";
        	this.calculatorToolStripMenuItem.Click += new System.EventHandler(this.CalculatorToolStripMenuItemClick);
        	// 
        	// calendarToolStripMenuItem
        	// 
        	this.calendarToolStripMenuItem.Name = "calendarToolStripMenuItem";
        	this.calendarToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
        	this.calendarToolStripMenuItem.Text = "&Calendar";
        	this.calendarToolStripMenuItem.Click += new System.EventHandler(this.CalendarToolStripMenuItemClick);
        	// 
        	// toolStripMenuItem1
        	// 
        	this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        	this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 6);
        	// 
        	// exitToolStripMenuItem1
        	// 
        	this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
        	this.exitToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
        	this.exitToolStripMenuItem1.Text = "E&xit";
        	this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1Click);
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
        	this.ShowInTaskbar = false;
        	this.Text = "Awareness";
        	this.Load += new System.EventHandler(this.FormMainLoad);
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainFormClosing);
        	this.Resize += new System.EventHandler(this.FormMainResize);
        	this.mainMenu.ResumeLayout(false);
        	this.mainMenu.PerformLayout();
        	this.statusBar.ResumeLayout(false);
        	this.statusBar.PerformLayout();
        	this.mealPages.ResumeLayout(false);
        	this.dailyPage.ResumeLayout(false);
        	this.availableFoodsPage.ResumeLayout(false);
        	this.financialPages.ResumeLayout(false);
        	this.accountsPage.ResumeLayout(false);
        	this.transactionsPage.ResumeLayout(false);
        	this.toolStripContainer.ContentPanel.ResumeLayout(false);
        	this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
        	this.toolStripContainer.TopToolStripPanel.PerformLayout();
        	this.toolStripContainer.ResumeLayout(false);
        	this.toolStripContainer.PerformLayout();
        	this.centralPark.ResumeLayout(false);
        	this.mealPanel.ResumeLayout(false);
        	this.actionPages.ResumeLayout(false);
        	this.dayPage.ResumeLayout(false);
        	this.actionPagesDaySplitContainer.Panel1.ResumeLayout(false);
        	this.actionPagesDaySplitContainer.Panel2.ResumeLayout(false);
        	this.actionPagesDaySplitContainer.ResumeLayout(false);
        	this.weekPage.ResumeLayout(false);
        	this.defaultToolStrip.ResumeLayout(false);
        	this.defaultToolStrip.PerformLayout();
        	this.toolsMenuStrip.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripMenuItem dumpDatabaseToolStripMenuItem;
        private Awareness.UI.ControlNoteTextView toDoNote;
        private System.Windows.Forms.SplitContainer actionPagesDaySplitContainer;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openStorgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calendarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip toolsMenuStrip;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel mealPanel;
        private System.Windows.Forms.Panel centralPark;
        private System.Windows.Forms.ToolStripButton financesToolButton;
        private System.Windows.Forms.ToolStripButton mealsToolButton;
        private System.Windows.Forms.ToolStripButton actionsToolButton;
        private System.Windows.Forms.ToolStripButton calendarToolButton;
        private Awareness.UI.ControlTransactions transactionsControl;
        private System.Windows.Forms.TabPage transactionsPage;
        private System.Windows.Forms.TabPage accountsPage;
        private System.Windows.Forms.TabControl financialPages;
        private System.Windows.Forms.ToolStripButton calculatorToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton openToolButton;
        private Awareness.UI.ControlWeekActionsReport weekActionsReport;
        private System.Windows.Forms.TabPage weekPage;
        private Awareness.UI.ControlDayActionsReport dayActionsReportControl;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.ToolStripStatusLabel timeStatusLabel;
        private System.Windows.Forms.ToolStrip defaultToolStrip;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.TabPage dayPage;
        private System.Windows.Forms.TabControl actionPages;
        private System.Windows.Forms.TabControl mealPages;
        private Awareness.UI.ControlMealsDailyReport mealsDailyReportControl;
        private Awareness.UI.ControlFinances financesControl;
        private Awareness.UI.ControlAvailableFoods availableFoodsControl;
        private System.Windows.Forms.TabPage dailyPage;
        private System.Windows.Forms.TabPage availableFoodsPage;
        private System.Windows.Forms.ToolStripMenuItem transferreasonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem accountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accoutTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mealsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenu;
    }
}