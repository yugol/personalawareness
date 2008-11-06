/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 31/08/2008
 * Time: 18:09
 * 
 */
namespace awareness.ui
{
    partial class FormEditBudgetCategories
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
        	this.label1 = new System.Windows.Forms.Label();
        	this.categoriesList = new System.Windows.Forms.ListBox();
        	this.newButton = new System.Windows.Forms.Button();
        	this.updateButton = new System.Windows.Forms.Button();
        	this.deleteButton = new System.Windows.Forms.Button();
        	this.closeButton = new System.Windows.Forms.Button();
        	this.nameLabel = new System.Windows.Forms.Label();
        	this.nameBox = new System.Windows.Forms.TextBox();
        	this.incomeButton = new System.Windows.Forms.RadioButton();
        	this.expenseButton = new System.Windows.Forms.RadioButton();
        	this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(8, 16);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(105, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Available categories:";
        	// 
        	// categoriesList
        	// 
        	this.categoriesList.FormattingEnabled = true;
        	this.categoriesList.Location = new System.Drawing.Point(8, 40);
        	this.categoriesList.Name = "categoriesList";
        	this.categoriesList.Size = new System.Drawing.Size(144, 212);
        	this.categoriesList.Sorted = true;
        	this.categoriesList.TabIndex = 1;
        	this.categoriesList.SelectedIndexChanged += new System.EventHandler(this.CategoriesListSelectedIndexChanged);
        	// 
        	// newButton
        	// 
        	this.newButton.Location = new System.Drawing.Point(352, 24);
        	this.newButton.Name = "newButton";
        	this.newButton.Size = new System.Drawing.Size(75, 23);
        	this.newButton.TabIndex = 5;
        	this.newButton.Text = "&New";
        	this.newButton.UseVisualStyleBackColor = true;
        	this.newButton.Click += new System.EventHandler(this.NewButtonClick);
        	// 
        	// updateButton
        	// 
        	this.updateButton.Enabled = false;
        	this.updateButton.Location = new System.Drawing.Point(352, 56);
        	this.updateButton.Name = "updateButton";
        	this.updateButton.Size = new System.Drawing.Size(75, 23);
        	this.updateButton.TabIndex = 6;
        	this.updateButton.Text = "&Update";
        	this.updateButton.UseVisualStyleBackColor = true;
        	this.updateButton.Click += new System.EventHandler(this.UpdateButtonClick);
        	// 
        	// deleteButton
        	// 
        	this.deleteButton.Enabled = false;
        	this.deleteButton.Location = new System.Drawing.Point(352, 88);
        	this.deleteButton.Name = "deleteButton";
        	this.deleteButton.Size = new System.Drawing.Size(75, 23);
        	this.deleteButton.TabIndex = 7;
        	this.deleteButton.Text = "&Delete";
        	this.deleteButton.UseVisualStyleBackColor = true;
        	this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
        	// 
        	// closeButton
        	// 
        	this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.closeButton.Location = new System.Drawing.Point(352, 136);
        	this.closeButton.Name = "closeButton";
        	this.closeButton.Size = new System.Drawing.Size(75, 23);
        	this.closeButton.TabIndex = 8;
        	this.closeButton.Text = "&Close";
        	this.closeButton.UseVisualStyleBackColor = true;
        	// 
        	// nameLabel
        	// 
        	this.nameLabel.AutoSize = true;
        	this.nameLabel.Location = new System.Drawing.Point(168, 40);
        	this.nameLabel.Name = "nameLabel";
        	this.nameLabel.Size = new System.Drawing.Size(38, 13);
        	this.nameLabel.TabIndex = 6;
        	this.nameLabel.Text = "Name:";
        	// 
        	// nameBox
        	// 
        	this.nameBox.Location = new System.Drawing.Point(168, 56);
        	this.nameBox.Name = "nameBox";
        	this.nameBox.Size = new System.Drawing.Size(160, 20);
        	this.nameBox.TabIndex = 2;
        	this.nameBox.TextChanged += new System.EventHandler(this.NameBoxTextChanged);
        	this.nameBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameBoxValidating);
        	// 
        	// incomeButton
        	// 
        	this.incomeButton.Location = new System.Drawing.Point(168, 96);
        	this.incomeButton.Name = "incomeButton";
        	this.incomeButton.Size = new System.Drawing.Size(104, 24);
        	this.incomeButton.TabIndex = 3;
        	this.incomeButton.TabStop = true;
        	this.incomeButton.Text = "&Income";
        	this.incomeButton.UseVisualStyleBackColor = true;
        	this.incomeButton.CheckedChanged += new System.EventHandler(this.IncomeButtonCheckedChanged);
        	// 
        	// expenseButton
        	// 
        	this.expenseButton.Location = new System.Drawing.Point(168, 120);
        	this.expenseButton.Name = "expenseButton";
        	this.expenseButton.Size = new System.Drawing.Size(104, 24);
        	this.expenseButton.TabIndex = 4;
        	this.expenseButton.TabStop = true;
        	this.expenseButton.Text = "&Expense";
        	this.expenseButton.UseVisualStyleBackColor = true;
        	this.expenseButton.CheckedChanged += new System.EventHandler(this.ExpenseButtonCheckedChanged);
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// FormEditBudgetCategories
        	// 
        	this.AcceptButton = this.updateButton;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.closeButton;
        	this.ClientSize = new System.Drawing.Size(434, 262);
        	this.Controls.Add(this.expenseButton);
        	this.Controls.Add(this.incomeButton);
        	this.Controls.Add(this.nameBox);
        	this.Controls.Add(this.nameLabel);
        	this.Controls.Add(this.closeButton);
        	this.Controls.Add(this.deleteButton);
        	this.Controls.Add(this.updateButton);
        	this.Controls.Add(this.newButton);
        	this.Controls.Add(this.categoriesList);
        	this.Controls.Add(this.label1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormEditBudgetCategories";
        	this.ShowInTaskbar = false;
        	this.Text = "Budget Categories";
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.RadioButton expenseButton;
        private System.Windows.Forms.RadioButton incomeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.ListBox categoriesList;
        private System.Windows.Forms.Label label1;
    }
}
