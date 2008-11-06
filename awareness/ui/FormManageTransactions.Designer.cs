/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 05/09/2008
 * Time: 13:43
 * 
 */
namespace awareness.ui
{
    partial class FormManageTransactions
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageTransactions));
        	this.selectPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.selectLayoutLabel = new System.Windows.Forms.Label();
        	this.layoutImageList = new System.Windows.Forms.ImageList(this.components);
        	this.timeIntervalSelectorControl = new awareness.ui.ControlTimeIntervalSelector();
        	this.transferLocationSelectionCombo = new System.Windows.Forms.ComboBox();
        	this.reasonSelectionBox = new System.Windows.Forms.TextBox();
        	this.reportsButton = new System.Windows.Forms.Button();
        	this.editPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.editLayoutLabel = new System.Windows.Forms.Label();
        	this.datePicker = new System.Windows.Forms.DateTimePicker();
        	this.reasonCombo = new System.Windows.Forms.ComboBox();
        	this.fromCombo = new System.Windows.Forms.ComboBox();
        	this.toCombo = new System.Windows.Forms.ComboBox();
        	this.arrowLabel = new System.Windows.Forms.Label();
        	this.deleteButton = new System.Windows.Forms.Button();
        	this.recordButton = new System.Windows.Forms.Button();
        	this.updateButton = new System.Windows.Forms.Button();
        	this.memoBox = new System.Windows.Forms.TextBox();
        	this.quantityBox = new System.Windows.Forms.TextBox();
        	this.ammountBox = new System.Windows.Forms.TextBox();
        	this.listPanel = new System.Windows.Forms.Panel();
        	this.transactionsView = new awareness.ui.ControlTransactionList();
        	this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        	this.toolTips = new System.Windows.Forms.ToolTip(this.components);
        	this.reportsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.expensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.pieChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.monthlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.selectPanel.SuspendLayout();
        	this.editPanel.SuspendLayout();
        	this.listPanel.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        	this.reportsMenu.SuspendLayout();
        	this.SuspendLayout();
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
        	this.selectPanel.Size = new System.Drawing.Size(512, 54);
        	this.selectPanel.TabIndex = 0;
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
        	// layoutImageList
        	// 
        	this.layoutImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("layoutImageList.ImageStream")));
        	this.layoutImageList.TransparentColor = System.Drawing.Color.White;
        	this.layoutImageList.Images.SetKeyName(0, "minus.bmp");
        	this.layoutImageList.Images.SetKeyName(1, "plus.bmp");
        	this.layoutImageList.Images.SetKeyName(2, "right_arrow.bmp");
        	// 
        	// timeIntervalSelectorControl
        	// 
        	this.selectPanel.SetColumnSpan(this.timeIntervalSelectorControl, 2);
        	this.timeIntervalSelectorControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.timeIntervalSelectorControl.Location = new System.Drawing.Point(16, 0);
        	this.timeIntervalSelectorControl.Margin = new System.Windows.Forms.Padding(0);
        	this.timeIntervalSelectorControl.Name = "timeIntervalSelectorControl";
        	this.timeIntervalSelectorControl.Size = new System.Drawing.Size(416, 27);
        	this.timeIntervalSelectorControl.TabIndex = 1;
        	// 
        	// transferLocationSelectionCombo
        	// 
        	this.transferLocationSelectionCombo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.transferLocationSelectionCombo.FormattingEnabled = true;
        	this.transferLocationSelectionCombo.Location = new System.Drawing.Point(19, 30);
        	this.transferLocationSelectionCombo.Name = "transferLocationSelectionCombo";
        	this.transferLocationSelectionCombo.Size = new System.Drawing.Size(202, 21);
        	this.transferLocationSelectionCombo.TabIndex = 2;
        	this.transferLocationSelectionCombo.SelectedIndexChanged += new System.EventHandler(this.TransferLocationSelectionComboSelectedIndexChanged);
        	// 
        	// reasonSelectionBox
        	// 
        	this.reasonSelectionBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.reasonSelectionBox.Location = new System.Drawing.Point(227, 30);
        	this.reasonSelectionBox.Name = "reasonSelectionBox";
        	this.reasonSelectionBox.Size = new System.Drawing.Size(202, 20);
        	this.reasonSelectionBox.TabIndex = 3;
        	this.reasonSelectionBox.TextChanged += new System.EventHandler(this.ReasonSelectionBoxTextChanged);
        	// 
        	// reportsButton
        	// 
        	this.reportsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.reportsButton.Location = new System.Drawing.Point(435, 3);
        	this.reportsButton.Name = "reportsButton";
        	this.selectPanel.SetRowSpan(this.reportsButton, 2);
        	this.reportsButton.Size = new System.Drawing.Size(74, 23);
        	this.reportsButton.TabIndex = 4;
        	this.reportsButton.Text = "Re&ports";
        	this.reportsButton.UseVisualStyleBackColor = true;
        	this.reportsButton.Click += new System.EventHandler(this.Button1Click);
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
        	this.editPanel.Controls.Add(this.memoBox, 7, 0);
        	this.editPanel.Controls.Add(this.quantityBox, 6, 1);
        	this.editPanel.Controls.Add(this.ammountBox, 5, 0);
        	this.editPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.editPanel.Location = new System.Drawing.Point(0, 486);
        	this.editPanel.Name = "editPanel";
        	this.editPanel.RowCount = 3;
        	this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
        	this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
        	this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        	this.editPanel.Size = new System.Drawing.Size(512, 84);
        	this.editPanel.TabIndex = 1;
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
        	// datePicker
        	// 
        	this.datePicker.CustomFormat = "yyyy-MM-dd";
        	this.datePicker.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        	this.datePicker.Location = new System.Drawing.Point(19, 3);
        	this.datePicker.Name = "datePicker";
        	this.datePicker.Size = new System.Drawing.Size(90, 20);
        	this.datePicker.TabIndex = 1;
        	this.toolTips.SetToolTip(this.datePicker, "Transaction date");
        	this.datePicker.ValueChanged += new System.EventHandler(this.DataPickerValueChanged);
        	// 
        	// reasonCombo
        	// 
        	this.editPanel.SetColumnSpan(this.reasonCombo, 3);
        	this.reasonCombo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.reasonCombo.FormattingEnabled = true;
        	this.reasonCombo.Location = new System.Drawing.Point(115, 3);
        	this.reasonCombo.Name = "reasonCombo";
        	this.reasonCombo.Size = new System.Drawing.Size(190, 21);
        	this.reasonCombo.TabIndex = 2;
        	this.toolTips.SetToolTip(this.reasonCombo, "Reason");
        	this.reasonCombo.Validating += new System.ComponentModel.CancelEventHandler(this.ReasonComboValidating);
        	this.reasonCombo.TextChanged += new System.EventHandler(this.ReasonComboTextChanged);
        	// 
        	// fromCombo
        	// 
        	this.editPanel.SetColumnSpan(this.fromCombo, 2);
        	this.fromCombo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.fromCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.fromCombo.FormattingEnabled = true;
        	this.fromCombo.Location = new System.Drawing.Point(19, 28);
        	this.fromCombo.Name = "fromCombo";
        	this.fromCombo.Size = new System.Drawing.Size(150, 21);
        	this.fromCombo.TabIndex = 4;
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
        	this.toCombo.Location = new System.Drawing.Point(191, 28);
        	this.toCombo.Name = "toCombo";
        	this.toCombo.Size = new System.Drawing.Size(150, 21);
        	this.toCombo.TabIndex = 5;
        	this.toolTips.SetToolTip(this.toCombo, "Destination (Account / Budget Category)");
        	this.toCombo.Validating += new System.ComponentModel.CancelEventHandler(this.ToComboValidating);
        	this.toCombo.SelectedIndexChanged += new System.EventHandler(this.ToComboSelectedIndexChanged);
        	// 
        	// arrowLabel
        	// 
        	this.arrowLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.arrowLabel.ImageIndex = 2;
        	this.arrowLabel.ImageList = this.layoutImageList;
        	this.arrowLabel.Location = new System.Drawing.Point(175, 25);
        	this.arrowLabel.Name = "arrowLabel";
        	this.arrowLabel.Size = new System.Drawing.Size(10, 25);
        	this.arrowLabel.TabIndex = 7;
        	// 
        	// deleteButton
        	// 
        	this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.deleteButton.Location = new System.Drawing.Point(19, 58);
        	this.deleteButton.Name = "deleteButton";
        	this.deleteButton.Size = new System.Drawing.Size(75, 23);
        	this.deleteButton.TabIndex = 8;
        	this.deleteButton.Text = "&Delete";
        	this.deleteButton.UseVisualStyleBackColor = true;
        	this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
        	// 
        	// recordButton
        	// 
        	this.recordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.editPanel.SetColumnSpan(this.recordButton, 2);
        	this.recordButton.Location = new System.Drawing.Point(266, 58);
        	this.recordButton.Name = "recordButton";
        	this.recordButton.Size = new System.Drawing.Size(75, 23);
        	this.recordButton.TabIndex = 9;
        	this.recordButton.Text = "&Record";
        	this.recordButton.UseVisualStyleBackColor = true;
        	this.recordButton.Click += new System.EventHandler(this.RecordButtonClick);
        	// 
        	// updateButton
        	// 
        	this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.updateButton.Enabled = false;
        	this.updateButton.Location = new System.Drawing.Point(350, 58);
        	this.updateButton.Name = "updateButton";
        	this.updateButton.Size = new System.Drawing.Size(63, 23);
        	this.updateButton.TabIndex = 10;
        	this.updateButton.Text = "&Update";
        	this.updateButton.UseVisualStyleBackColor = true;
        	this.updateButton.Click += new System.EventHandler(this.UpdateButtonClick);
        	// 
        	// memoBox
        	// 
        	this.memoBox.AcceptsReturn = true;
        	this.memoBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.memoBox.Location = new System.Drawing.Point(432, 3);
        	this.memoBox.Margin = new System.Windows.Forms.Padding(16, 3, 0, 5);
        	this.memoBox.Multiline = true;
        	this.memoBox.Name = "memoBox";
        	this.editPanel.SetRowSpan(this.memoBox, 3);
        	this.memoBox.Size = new System.Drawing.Size(80, 76);
        	this.memoBox.TabIndex = 7;
        	this.toolTips.SetToolTip(this.memoBox, "Memo");
        	this.memoBox.TextChanged += new System.EventHandler(this.MemoBoxTextChanged);
        	// 
        	// quantityBox
        	// 
        	this.quantityBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.quantityBox.Location = new System.Drawing.Point(360, 28);
        	this.quantityBox.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
        	this.quantityBox.Name = "quantityBox";
        	this.quantityBox.Size = new System.Drawing.Size(53, 20);
        	this.quantityBox.TabIndex = 6;
        	this.quantityBox.Text = "0";
        	this.toolTips.SetToolTip(this.quantityBox, "Quantity");
        	this.quantityBox.TextChanged += new System.EventHandler(this.QuantityBoxTextChanged);
        	this.quantityBox.Validating += new System.ComponentModel.CancelEventHandler(this.QuantityBoxValidating);
        	// 
        	// ammountBox
        	// 
        	this.editPanel.SetColumnSpan(this.ammountBox, 2);
        	this.ammountBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.ammountBox.Location = new System.Drawing.Point(324, 3);
        	this.ammountBox.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
        	this.ammountBox.Name = "ammountBox";
        	this.ammountBox.Size = new System.Drawing.Size(89, 20);
        	this.ammountBox.TabIndex = 11;
        	this.toolTips.SetToolTip(this.ammountBox, "Transfer ammount");
        	this.ammountBox.TextChanged += new System.EventHandler(this.AmmountBoxTextChanged);
        	this.ammountBox.Validating += new System.ComponentModel.CancelEventHandler(this.AmmountBoxValidating);
        	// 
        	// listPanel
        	// 
        	this.listPanel.Controls.Add(this.transactionsView);
        	this.listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.listPanel.Location = new System.Drawing.Point(0, 54);
        	this.listPanel.Name = "listPanel";
        	this.listPanel.Size = new System.Drawing.Size(512, 432);
        	this.listPanel.TabIndex = 2;
        	// 
        	// transactionsView
        	// 
        	this.transactionsView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.transactionsView.Location = new System.Drawing.Point(0, 0);
        	this.transactionsView.Name = "transactionsView";
        	this.transactionsView.SelectedTransaction = null;
        	this.transactionsView.Size = new System.Drawing.Size(512, 432);
        	this.transactionsView.TabIndex = 0;
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// reportsMenu
        	// 
        	this.reportsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.expensesToolStripMenuItem});
        	this.reportsMenu.Name = "contextMenuStrip1";
        	this.reportsMenu.Size = new System.Drawing.Size(128, 26);
        	this.reportsMenu.Text = "Reports";
        	// 
        	// expensesToolStripMenuItem
        	// 
        	this.expensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.pieChartToolStripMenuItem,
        	        	        	this.monthlyToolStripMenuItem});
        	this.expensesToolStripMenuItem.Name = "expensesToolStripMenuItem";
        	this.expensesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
        	this.expensesToolStripMenuItem.Text = "Expenses";
        	// 
        	// pieChartToolStripMenuItem
        	// 
        	this.pieChartToolStripMenuItem.Name = "pieChartToolStripMenuItem";
        	this.pieChartToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
        	this.pieChartToolStripMenuItem.Text = "Pie chart";
        	this.pieChartToolStripMenuItem.Click += new System.EventHandler(this.PieChartToolStripMenuItemClick);
        	// 
        	// monthlyToolStripMenuItem
        	// 
        	this.monthlyToolStripMenuItem.Name = "monthlyToolStripMenuItem";
        	this.monthlyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
        	this.monthlyToolStripMenuItem.Text = "Monthly";
        	// 
        	// FormManageTransactions
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(512, 570);
        	this.Controls.Add(this.listPanel);
        	this.Controls.Add(this.selectPanel);
        	this.Controls.Add(this.editPanel);
        	this.MinimizeBox = false;
        	this.MinimumSize = new System.Drawing.Size(480, 400);
        	this.Name = "FormManageTransactions";
        	this.Text = "Transactions";
        	this.Shown += new System.EventHandler(this.FormManageTransactionsShown);
        	this.selectPanel.ResumeLayout(false);
        	this.selectPanel.PerformLayout();
        	this.editPanel.ResumeLayout(false);
        	this.editPanel.PerformLayout();
        	this.listPanel.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        	this.reportsMenu.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.TextBox ammountBox;
        private System.Windows.Forms.Button reportsButton;
        private System.Windows.Forms.ToolStripMenuItem monthlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pieChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip reportsMenu;
        private System.Windows.Forms.TextBox reasonSelectionBox;
        private System.Windows.Forms.ComboBox transferLocationSelectionCombo;
        private awareness.ui.ControlTimeIntervalSelector timeIntervalSelectorControl;
        private System.Windows.Forms.TextBox quantityBox;
        private System.Windows.Forms.TextBox memoBox;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Label arrowLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private awareness.ui.ControlTransactionList transactionsView;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ComboBox toCombo;
        private System.Windows.Forms.ComboBox fromCombo;
        private System.Windows.Forms.ComboBox reasonCombo;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Label editLayoutLabel;
        private System.Windows.Forms.TableLayoutPanel editPanel;
        private System.Windows.Forms.ImageList layoutImageList;
        private System.Windows.Forms.Label selectLayoutLabel;
        private System.Windows.Forms.TableLayoutPanel selectPanel;
    }
}
