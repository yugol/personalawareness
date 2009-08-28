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
 * Date: 02/11/2008
 * Time: 19:30
 * 
 */
namespace Awareness.UI
{
    partial class ControlTransactions
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the control.
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlTransactions));
        	this.editLayoutLabel = new System.Windows.Forms.Label();
        	this.layoutImageList = new System.Windows.Forms.ImageList(this.components);
        	this.transactionsView = new Awareness.UI.ControlTransactionList();
        	this.datePicker = new System.Windows.Forms.DateTimePicker();
        	this.listPanel = new System.Windows.Forms.Panel();
        	this.fromCombo = new System.Windows.Forms.ComboBox();
        	this.toCombo = new System.Windows.Forms.ComboBox();
        	this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        	this.expensesPieChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.expensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.expensesYearlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.expensesMonthlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.expensesWeeklyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.expensesDailyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.reportsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.incomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.incomePieChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.incomeYearlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.incomeMonthlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.incomeWeeklyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.incomeDailyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolTips = new System.Windows.Forms.ToolTip(this.components);
        	this.reasonCombo = new System.Windows.Forms.ComboBox();
        	this.ammountBox = new System.Windows.Forms.TextBox();
        	this.quantityInput = new Awareness.UI.ControlCalculatorInput();
        	this.transferLocationSelectionCombo = new System.Windows.Forms.ComboBox();
        	this.reasonSelectionBox = new System.Windows.Forms.TextBox();
        	this.arrowLabel = new System.Windows.Forms.Label();
        	this.editPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.deleteButton = new System.Windows.Forms.Button();
        	this.recordButton = new System.Windows.Forms.Button();
        	this.updateButton = new System.Windows.Forms.Button();
        	this.noteControl = new Awareness.UI.ControlAddNote();
        	this.selectLayoutLabel = new System.Windows.Forms.Label();
        	this.selectPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.timeIntervalSelectorControl = new Awareness.UI.ControlTimeIntervalSelector();
        	this.reportsButton = new System.Windows.Forms.Button();
        	this.listPanel.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        	this.reportsMenu.SuspendLayout();
        	this.editPanel.SuspendLayout();
        	this.selectPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// editLayoutLabel
        	// 
        	this.editLayoutLabel.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.editLayoutLabel.ImageIndex = 0;
        	this.editLayoutLabel.ImageList = this.layoutImageList;
        	this.editLayoutLabel.Location = new System.Drawing.Point(0, 2);
        	this.editLayoutLabel.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
        	this.editLayoutLabel.Name = "editLayoutLabel";
        	this.editLayoutLabel.Size = new System.Drawing.Size(9, 9);
        	this.editLayoutLabel.TabIndex = 1;
        	this.editLayoutLabel.Click += new System.EventHandler(this.EditLayoutLabelClick);
        	// 
        	// layoutImageList
        	// 
        	this.layoutImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("layoutImageList.ImageStream")));
        	this.layoutImageList.TransparentColor = System.Drawing.Color.White;
        	this.layoutImageList.Images.SetKeyName(0, "minus.bmp");
        	this.layoutImageList.Images.SetKeyName(1, "plus.bmp");
        	this.layoutImageList.Images.SetKeyName(2, "right_arrow.bmp");
        	// 
        	// transactionsView
        	// 
        	this.transactionsView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.transactionsView.Location = new System.Drawing.Point(0, 0);
        	this.transactionsView.Name = "transactionsView";
        	this.transactionsView.SelectedTransaction = null;
        	this.transactionsView.Size = new System.Drawing.Size(732, 388);
        	this.transactionsView.TabIndex = 0;
        	// 
        	// datePicker
        	// 
        	this.datePicker.CustomFormat = "yyyy-MM-dd";
        	this.datePicker.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        	this.datePicker.Location = new System.Drawing.Point(19, 3);
        	this.datePicker.Name = "datePicker";
        	this.datePicker.Size = new System.Drawing.Size(134, 20);
        	this.datePicker.TabIndex = 5;
        	this.toolTips.SetToolTip(this.datePicker, "Transaction date");
        	this.datePicker.ValueChanged += new System.EventHandler(this.DatePickerValueChanged);
        	// 
        	// listPanel
        	// 
        	this.listPanel.Controls.Add(this.transactionsView);
        	this.listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.listPanel.Location = new System.Drawing.Point(0, 54);
        	this.listPanel.Name = "listPanel";
        	this.listPanel.Size = new System.Drawing.Size(732, 388);
        	this.listPanel.TabIndex = 5;
        	// 
        	// fromCombo
        	// 
        	this.editPanel.SetColumnSpan(this.fromCombo, 2);
        	this.fromCombo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.fromCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.fromCombo.FormattingEnabled = true;
        	this.fromCombo.Location = new System.Drawing.Point(19, 28);
        	this.fromCombo.Name = "fromCombo";
        	this.fromCombo.Size = new System.Drawing.Size(221, 21);
        	this.fromCombo.TabIndex = 8;
        	this.toolTips.SetToolTip(this.fromCombo, "Source (Account / Budget Category)");
        	this.fromCombo.Validating += new System.ComponentModel.CancelEventHandler(this.FromComboValidating);
        	this.fromCombo.SelectedIndexChanged += new System.EventHandler(this.FromComboSelectedIndexChanged);
        	// 
        	// toCombo
        	// 
        	this.editPanel.SetColumnSpan(this.toCombo, 2);
        	this.toCombo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.toCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.toCombo.FormattingEnabled = true;
        	this.toCombo.Location = new System.Drawing.Point(262, 28);
        	this.toCombo.Name = "toCombo";
        	this.toCombo.Size = new System.Drawing.Size(221, 21);
        	this.toCombo.TabIndex = 9;
        	this.toolTips.SetToolTip(this.toCombo, "Destination (Account / Budget Category)");
        	this.toCombo.Validating += new System.ComponentModel.CancelEventHandler(this.ToComboValidating);
        	this.toCombo.SelectedIndexChanged += new System.EventHandler(this.ToComboSelectedIndexChanged);
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// expensesPieChartToolStripMenuItem
        	// 
        	this.expensesPieChartToolStripMenuItem.Name = "expensesPieChartToolStripMenuItem";
        	this.expensesPieChartToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
        	this.expensesPieChartToolStripMenuItem.Text = "Pie chart";
        	this.expensesPieChartToolStripMenuItem.Click += new System.EventHandler(this.ExpensesPieChartToolStripMenuItemClick);
        	// 
        	// expensesToolStripMenuItem
        	// 
        	this.expensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.expensesPieChartToolStripMenuItem,
        	        	        	this.expensesYearlyToolStripMenuItem,
        	        	        	this.expensesMonthlyToolStripMenuItem,
        	        	        	this.expensesWeeklyToolStripMenuItem,
        	        	        	this.expensesDailyToolStripMenuItem});
        	this.expensesToolStripMenuItem.Name = "expensesToolStripMenuItem";
        	this.expensesToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
        	this.expensesToolStripMenuItem.Text = "Expenses";
        	// 
        	// expensesYearlyToolStripMenuItem
        	// 
        	this.expensesYearlyToolStripMenuItem.Name = "expensesYearlyToolStripMenuItem";
        	this.expensesYearlyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
        	this.expensesYearlyToolStripMenuItem.Text = "Yearly";
        	this.expensesYearlyToolStripMenuItem.Click += new System.EventHandler(this.ExpensesYearlyToolStripMenuItemClick);
        	// 
        	// expensesMonthlyToolStripMenuItem
        	// 
        	this.expensesMonthlyToolStripMenuItem.Name = "expensesMonthlyToolStripMenuItem";
        	this.expensesMonthlyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
        	this.expensesMonthlyToolStripMenuItem.Text = "Monthly";
        	this.expensesMonthlyToolStripMenuItem.Click += new System.EventHandler(this.ExpensesMonthlyToolStripMenuItemClick);
        	// 
        	// expensesWeeklyToolStripMenuItem
        	// 
        	this.expensesWeeklyToolStripMenuItem.Name = "expensesWeeklyToolStripMenuItem";
        	this.expensesWeeklyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
        	this.expensesWeeklyToolStripMenuItem.Text = "Weekly";
        	this.expensesWeeklyToolStripMenuItem.Click += new System.EventHandler(this.ExpensesWeeklyToolStripMenuItemClick);
        	// 
        	// expensesDailyToolStripMenuItem
        	// 
        	this.expensesDailyToolStripMenuItem.Name = "expensesDailyToolStripMenuItem";
        	this.expensesDailyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
        	this.expensesDailyToolStripMenuItem.Text = "Daily";
        	this.expensesDailyToolStripMenuItem.Click += new System.EventHandler(this.ExpensesDailyToolStripMenuItemClick);
        	// 
        	// reportsMenu
        	// 
        	this.reportsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.expensesToolStripMenuItem,
        	        	        	this.incomeToolStripMenuItem});
        	this.reportsMenu.Name = "contextMenuStrip1";
        	this.reportsMenu.Size = new System.Drawing.Size(124, 48);
        	this.reportsMenu.Text = "Reports";
        	// 
        	// incomeToolStripMenuItem
        	// 
        	this.incomeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.incomePieChartToolStripMenuItem,
        	        	        	this.incomeYearlyToolStripMenuItem,
        	        	        	this.incomeMonthlyToolStripMenuItem,
        	        	        	this.incomeWeeklyToolStripMenuItem,
        	        	        	this.incomeDailyToolStripMenuItem});
        	this.incomeToolStripMenuItem.Name = "incomeToolStripMenuItem";
        	this.incomeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
        	this.incomeToolStripMenuItem.Text = "Income";
        	// 
        	// incomePieChartToolStripMenuItem
        	// 
        	this.incomePieChartToolStripMenuItem.Name = "incomePieChartToolStripMenuItem";
        	this.incomePieChartToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
        	this.incomePieChartToolStripMenuItem.Text = "Pie Chart";
        	this.incomePieChartToolStripMenuItem.Click += new System.EventHandler(this.IncomePieChartToolStripMenuItemClick);
        	// 
        	// incomeYearlyToolStripMenuItem
        	// 
        	this.incomeYearlyToolStripMenuItem.Name = "incomeYearlyToolStripMenuItem";
        	this.incomeYearlyToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
        	this.incomeYearlyToolStripMenuItem.Text = "Yearly";
        	this.incomeYearlyToolStripMenuItem.Click += new System.EventHandler(this.IncomeYearlyToolStripMenuItemClick);
        	// 
        	// incomeMonthlyToolStripMenuItem
        	// 
        	this.incomeMonthlyToolStripMenuItem.Name = "incomeMonthlyToolStripMenuItem";
        	this.incomeMonthlyToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
        	this.incomeMonthlyToolStripMenuItem.Text = "Monthly";
        	this.incomeMonthlyToolStripMenuItem.Click += new System.EventHandler(this.IncomeMonthlyToolStripMenuItemClick);
        	// 
        	// incomeWeeklyToolStripMenuItem
        	// 
        	this.incomeWeeklyToolStripMenuItem.Name = "incomeWeeklyToolStripMenuItem";
        	this.incomeWeeklyToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
        	this.incomeWeeklyToolStripMenuItem.Text = "Weekly";
        	this.incomeWeeklyToolStripMenuItem.Click += new System.EventHandler(this.IncomeWeeklyToolStripMenuItemClick);
        	// 
        	// incomeDailyToolStripMenuItem
        	// 
        	this.incomeDailyToolStripMenuItem.Name = "incomeDailyToolStripMenuItem";
        	this.incomeDailyToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
        	this.incomeDailyToolStripMenuItem.Text = "Daily";
        	this.incomeDailyToolStripMenuItem.Click += new System.EventHandler(this.IncomeDailyToolStripMenuItemClick);
        	// 
        	// reasonCombo
        	// 
        	this.editPanel.SetColumnSpan(this.reasonCombo, 3);
        	this.reasonCombo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.reasonCombo.FormattingEnabled = true;
        	this.reasonCombo.Location = new System.Drawing.Point(159, 3);
        	this.reasonCombo.Name = "reasonCombo";
        	this.reasonCombo.Size = new System.Drawing.Size(272, 21);
        	this.reasonCombo.TabIndex = 6;
        	this.toolTips.SetToolTip(this.reasonCombo, "Reason");
        	this.reasonCombo.Validating += new System.ComponentModel.CancelEventHandler(this.ReasonComboValidating);
        	this.reasonCombo.SelectedIndexChanged += new System.EventHandler(this.ReasonComboSelectedIndexChanged);
        	this.reasonCombo.TextChanged += new System.EventHandler(this.ReasonComboTextChanged);
        	// 
        	// ammountBox
        	// 
        	this.editPanel.SetColumnSpan(this.ammountBox, 2);
        	this.ammountBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.ammountBox.Location = new System.Drawing.Point(450, 3);
        	this.ammountBox.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
        	this.ammountBox.Name = "ammountBox";
        	this.ammountBox.Size = new System.Drawing.Size(138, 20);
        	this.ammountBox.TabIndex = 7;
        	this.toolTips.SetToolTip(this.ammountBox, "Transfer ammount");
        	this.ammountBox.TextChanged += new System.EventHandler(this.AmmountBoxTextChanged);
        	this.ammountBox.Validating += new System.ComponentModel.CancelEventHandler(this.AmmountBoxValidating);
        	// 
        	// quantityInput
        	// 
        	this.quantityInput.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.quantityInput.Location = new System.Drawing.Point(502, 28);
        	this.quantityInput.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
        	this.quantityInput.MaximumSize = new System.Drawing.Size(1000, 20);
        	this.quantityInput.MinimumSize = new System.Drawing.Size(60, 20);
        	this.quantityInput.Name = "quantityInput";
        	this.quantityInput.Size = new System.Drawing.Size(86, 20);
        	this.quantityInput.TabIndex = 10;
        	this.toolTips.SetToolTip(this.quantityInput, "Quantity (value will be rounded)");
        	this.quantityInput.Value = 0;
        	this.quantityInput.ValueChanged += new System.EventHandler(this.QuantityInputValueChanged);
        	this.quantityInput.Validating += new System.ComponentModel.CancelEventHandler(this.QuantityInputValidating);
        	// 
        	// transferLocationSelectionCombo
        	// 
        	this.transferLocationSelectionCombo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.transferLocationSelectionCombo.FormattingEnabled = true;
        	this.transferLocationSelectionCombo.Location = new System.Drawing.Point(19, 30);
        	this.transferLocationSelectionCombo.Name = "transferLocationSelectionCombo";
        	this.transferLocationSelectionCombo.Size = new System.Drawing.Size(312, 21);
        	this.transferLocationSelectionCombo.TabIndex = 2;
        	this.toolTips.SetToolTip(this.transferLocationSelectionCombo, "Select transactions by location");
        	this.transferLocationSelectionCombo.SelectedIndexChanged += new System.EventHandler(this.TransferLocationSelectionComboSelectedIndexChanged);
        	// 
        	// reasonSelectionBox
        	// 
        	this.reasonSelectionBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.reasonSelectionBox.Location = new System.Drawing.Point(337, 30);
        	this.reasonSelectionBox.Name = "reasonSelectionBox";
        	this.reasonSelectionBox.Size = new System.Drawing.Size(312, 20);
        	this.reasonSelectionBox.TabIndex = 3;
        	this.toolTips.SetToolTip(this.reasonSelectionBox, "Select by name pattern");
        	this.reasonSelectionBox.TextChanged += new System.EventHandler(this.ReasonSelectionBoxTextChanged);
        	// 
        	// arrowLabel
        	// 
        	this.arrowLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.arrowLabel.ImageIndex = 2;
        	this.arrowLabel.ImageList = this.layoutImageList;
        	this.arrowLabel.Location = new System.Drawing.Point(246, 25);
        	this.arrowLabel.Name = "arrowLabel";
        	this.arrowLabel.Size = new System.Drawing.Size(10, 25);
        	this.arrowLabel.TabIndex = 7;
        	// 
        	// editPanel
        	// 
        	this.editPanel.ColumnCount = 8;
        	this.editPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
        	this.editPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        	this.editPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
        	this.editPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
        	this.editPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        	this.editPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
        	this.editPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
        	this.editPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        	this.editPanel.Controls.Add(this.editLayoutLabel, 0, 0);
        	this.editPanel.Controls.Add(this.datePicker, 1, 0);
        	this.editPanel.Controls.Add(this.reasonCombo, 2, 0);
        	this.editPanel.Controls.Add(this.fromCombo, 1, 1);
        	this.editPanel.Controls.Add(this.toCombo, 4, 1);
        	this.editPanel.Controls.Add(this.arrowLabel, 3, 1);
        	this.editPanel.Controls.Add(this.deleteButton, 1, 2);
        	this.editPanel.Controls.Add(this.recordButton, 4, 2);
        	this.editPanel.Controls.Add(this.updateButton, 6, 2);
        	this.editPanel.Controls.Add(this.ammountBox, 5, 0);
        	this.editPanel.Controls.Add(this.noteControl, 7, 0);
        	this.editPanel.Controls.Add(this.quantityInput, 6, 1);
        	this.editPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.editPanel.Location = new System.Drawing.Point(0, 442);
        	this.editPanel.Name = "editPanel";
        	this.editPanel.RowCount = 3;
        	this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
        	this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
        	this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        	this.editPanel.Size = new System.Drawing.Size(732, 84);
        	this.editPanel.TabIndex = 4;
        	// 
        	// deleteButton
        	// 
        	this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.deleteButton.Location = new System.Drawing.Point(19, 58);
        	this.deleteButton.Name = "deleteButton";
        	this.deleteButton.Size = new System.Drawing.Size(75, 23);
        	this.deleteButton.TabIndex = 14;
        	this.deleteButton.Text = "&Delete";
        	this.deleteButton.UseVisualStyleBackColor = true;
        	this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
        	// 
        	// recordButton
        	// 
        	this.recordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.editPanel.SetColumnSpan(this.recordButton, 2);
        	this.recordButton.Location = new System.Drawing.Point(408, 58);
        	this.recordButton.Name = "recordButton";
        	this.recordButton.Size = new System.Drawing.Size(75, 23);
        	this.recordButton.TabIndex = 12;
        	this.recordButton.Text = "&Record";
        	this.recordButton.UseVisualStyleBackColor = true;
        	this.recordButton.Click += new System.EventHandler(this.RecordButtonClick);
        	// 
        	// updateButton
        	// 
        	this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.updateButton.Enabled = false;
        	this.updateButton.Location = new System.Drawing.Point(525, 58);
        	this.updateButton.Name = "updateButton";
        	this.updateButton.Size = new System.Drawing.Size(63, 23);
        	this.updateButton.TabIndex = 13;
        	this.updateButton.Text = "&Update";
        	this.updateButton.UseVisualStyleBackColor = true;
        	this.updateButton.Click += new System.EventHandler(this.UpdateButtonClick);
        	// 
        	// noteControl
        	// 
        	this.noteControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.noteControl.Location = new System.Drawing.Point(607, 3);
        	this.noteControl.Margin = new System.Windows.Forms.Padding(16, 3, 0, 3);
        	this.noteControl.Name = "noteControl";
        	this.noteControl.Note = null;
        	this.editPanel.SetRowSpan(this.noteControl, 3);
        	this.noteControl.Size = new System.Drawing.Size(125, 78);
        	this.noteControl.TabIndex = 11;
        	this.noteControl.NoteTextChanged += new Awareness.UI.NoteHandler(this.NoteControlNoteTextChanged);
        	this.noteControl.NoteRemoved += new Awareness.UI.NoteHandler(this.NoteControlNoteRemoved);
        	this.noteControl.NoteAdded += new Awareness.UI.NoteHandler(this.NoteControlNoteAdded);
        	// 
        	// selectLayoutLabel
        	// 
        	this.selectLayoutLabel.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.selectLayoutLabel.ImageIndex = 0;
        	this.selectLayoutLabel.ImageList = this.layoutImageList;
        	this.selectLayoutLabel.Location = new System.Drawing.Point(0, 2);
        	this.selectLayoutLabel.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
        	this.selectLayoutLabel.Name = "selectLayoutLabel";
        	this.selectLayoutLabel.Size = new System.Drawing.Size(9, 9);
        	this.selectLayoutLabel.TabIndex = 0;
        	this.selectLayoutLabel.Click += new System.EventHandler(this.SelectLayoutLabelClick);
        	// 
        	// selectPanel
        	// 
        	this.selectPanel.ColumnCount = 4;
        	this.selectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
        	this.selectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.selectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.selectPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
        	this.selectPanel.Controls.Add(this.selectLayoutLabel, 0, 0);
        	this.selectPanel.Controls.Add(this.timeIntervalSelectorControl, 1, 0);
        	this.selectPanel.Controls.Add(this.transferLocationSelectionCombo, 1, 1);
        	this.selectPanel.Controls.Add(this.reasonSelectionBox, 2, 1);
        	this.selectPanel.Controls.Add(this.reportsButton, 3, 0);
        	this.selectPanel.Dock = System.Windows.Forms.DockStyle.Top;
        	this.selectPanel.Location = new System.Drawing.Point(0, 0);
        	this.selectPanel.Name = "selectPanel";
        	this.selectPanel.RowCount = 2;
        	this.selectPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
        	this.selectPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
        	this.selectPanel.Size = new System.Drawing.Size(732, 54);
        	this.selectPanel.TabIndex = 3;
        	// 
        	// timeIntervalSelectorControl
        	// 
        	this.selectPanel.SetColumnSpan(this.timeIntervalSelectorControl, 2);
        	this.timeIntervalSelectorControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.timeIntervalSelectorControl.Location = new System.Drawing.Point(16, 0);
        	this.timeIntervalSelectorControl.Margin = new System.Windows.Forms.Padding(0);
        	this.timeIntervalSelectorControl.Name = "timeIntervalSelectorControl";
        	this.timeIntervalSelectorControl.Size = new System.Drawing.Size(636, 27);
        	this.timeIntervalSelectorControl.TabIndex = 1;
        	// 
        	// reportsButton
        	// 
        	this.reportsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.reportsButton.Location = new System.Drawing.Point(655, 3);
        	this.reportsButton.Name = "reportsButton";
        	this.selectPanel.SetRowSpan(this.reportsButton, 2);
        	this.reportsButton.Size = new System.Drawing.Size(74, 23);
        	this.reportsButton.TabIndex = 4;
        	this.reportsButton.Text = "Re&ports";
        	this.reportsButton.UseVisualStyleBackColor = true;
        	this.reportsButton.Click += new System.EventHandler(this.ReportsButtonClick);
        	// 
        	// ControlTransactions
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.listPanel);
        	this.Controls.Add(this.editPanel);
        	this.Controls.Add(this.selectPanel);
        	this.Name = "ControlTransactions";
        	this.Size = new System.Drawing.Size(732, 526);
        	this.listPanel.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        	this.reportsMenu.ResumeLayout(false);
        	this.editPanel.ResumeLayout(false);
        	this.editPanel.PerformLayout();
        	this.selectPanel.ResumeLayout(false);
        	this.selectPanel.PerformLayout();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolStripMenuItem expensesPieChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesMonthlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesYearlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesWeeklyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesDailyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incomePieChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incomeYearlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incomeMonthlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incomeWeeklyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incomeDailyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incomeToolStripMenuItem;
        private Awareness.UI.ControlCalculatorInput quantityInput;
        private Awareness.UI.ControlAddNote noteControl;
        private System.Windows.Forms.ContextMenuStrip reportsMenu;
        private System.Windows.Forms.ToolStripMenuItem expensesToolStripMenuItem;
        private System.Windows.Forms.Button reportsButton;
        private System.Windows.Forms.TextBox reasonSelectionBox;
        private System.Windows.Forms.ComboBox transferLocationSelectionCombo;
        private Awareness.UI.ControlTimeIntervalSelector timeIntervalSelectorControl;
        private System.Windows.Forms.Label selectLayoutLabel;
        private System.Windows.Forms.TableLayoutPanel selectPanel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox ammountBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label arrowLabel;
        private System.Windows.Forms.ComboBox toCombo;
        private System.Windows.Forms.ComboBox reasonCombo;
        private System.Windows.Forms.TableLayoutPanel editPanel;
        private System.Windows.Forms.ComboBox fromCombo;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.DateTimePicker datePicker;
        private Awareness.UI.ControlTransactionList transactionsView;
        private System.Windows.Forms.ImageList layoutImageList;
        private System.Windows.Forms.Label editLayoutLabel;
    }
}
