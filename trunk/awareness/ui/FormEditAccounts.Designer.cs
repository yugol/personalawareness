/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 01/09/2008
 * Time: 16:58
 * 
 */
namespace awareness.ui
{
    partial class FormEditAccounts
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
        	this.newButton = new System.Windows.Forms.Button();
        	this.updateButton = new System.Windows.Forms.Button();
        	this.deleteButton = new System.Windows.Forms.Button();
        	this.closeButton = new System.Windows.Forms.Button();
        	this.nameBox = new System.Windows.Forms.TextBox();
        	this.nameLabel = new System.Windows.Forms.Label();
        	this.typeCombo = new System.Windows.Forms.ComboBox();
        	this.startingBalanceBox = new System.Windows.Forms.TextBox();
        	this.startingBalanceLabel = new System.Windows.Forms.Label();
        	this.typeLabel = new System.Windows.Forms.Label();
        	this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        	this.accountsView = new System.Windows.Forms.TreeView();
        	this.label1 = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// newButton
        	// 
        	this.newButton.Location = new System.Drawing.Point(424, 16);
        	this.newButton.Name = "newButton";
        	this.newButton.Size = new System.Drawing.Size(75, 23);
        	this.newButton.TabIndex = 5;
        	this.newButton.Text = "&New";
        	this.newButton.UseVisualStyleBackColor = true;
        	this.newButton.Click += new System.EventHandler(this.NewButtonClick);
        	// 
        	// updateButton
        	// 
        	this.updateButton.Location = new System.Drawing.Point(424, 48);
        	this.updateButton.Name = "updateButton";
        	this.updateButton.Size = new System.Drawing.Size(75, 23);
        	this.updateButton.TabIndex = 6;
        	this.updateButton.Text = "&Update";
        	this.updateButton.UseVisualStyleBackColor = true;
        	this.updateButton.Click += new System.EventHandler(this.UpdateButtonClick);
        	// 
        	// deleteButton
        	// 
        	this.deleteButton.Location = new System.Drawing.Point(424, 80);
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
        	this.closeButton.Location = new System.Drawing.Point(424, 128);
        	this.closeButton.Name = "closeButton";
        	this.closeButton.Size = new System.Drawing.Size(75, 23);
        	this.closeButton.TabIndex = 8;
        	this.closeButton.Text = "&Close";
        	this.closeButton.UseVisualStyleBackColor = true;
        	// 
        	// nameBox
        	// 
        	this.nameBox.Location = new System.Drawing.Point(224, 32);
        	this.nameBox.Name = "nameBox";
        	this.nameBox.Size = new System.Drawing.Size(176, 20);
        	this.nameBox.TabIndex = 2;
        	this.nameBox.TextChanged += new System.EventHandler(this.NameBoxTextChanged);
        	this.nameBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameBoxValidating);
        	// 
        	// nameLabel
        	// 
        	this.nameLabel.AutoSize = true;
        	this.nameLabel.Location = new System.Drawing.Point(224, 16);
        	this.nameLabel.Name = "nameLabel";
        	this.nameLabel.Size = new System.Drawing.Size(38, 13);
        	this.nameLabel.TabIndex = 8;
        	this.nameLabel.Text = "Name:";
        	// 
        	// typeCombo
        	// 
        	this.typeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.typeCombo.FormattingEnabled = true;
        	this.typeCombo.Location = new System.Drawing.Point(224, 88);
        	this.typeCombo.Name = "typeCombo";
        	this.typeCombo.Size = new System.Drawing.Size(176, 21);
        	this.typeCombo.TabIndex = 3;
        	this.typeCombo.SelectedIndexChanged += new System.EventHandler(this.TypeComboSelectedIndexChanged);
        	// 
        	// startingBalanceBox
        	// 
        	this.startingBalanceBox.Location = new System.Drawing.Point(224, 144);
        	this.startingBalanceBox.Name = "startingBalanceBox";
        	this.startingBalanceBox.Size = new System.Drawing.Size(176, 20);
        	this.startingBalanceBox.TabIndex = 4;
        	this.startingBalanceBox.TextChanged += new System.EventHandler(this.StartingBalanceBoxTextChanged);
        	this.startingBalanceBox.Validating += new System.ComponentModel.CancelEventHandler(this.StartingBalanceBoxValidating);
        	// 
        	// startingBalanceLabel
        	// 
        	this.startingBalanceLabel.AutoSize = true;
        	this.startingBalanceLabel.Location = new System.Drawing.Point(224, 128);
        	this.startingBalanceLabel.Name = "startingBalanceLabel";
        	this.startingBalanceLabel.Size = new System.Drawing.Size(88, 13);
        	this.startingBalanceLabel.TabIndex = 11;
        	this.startingBalanceLabel.Text = "Starting Balance:";
        	// 
        	// typeLabel
        	// 
        	this.typeLabel.AutoSize = true;
        	this.typeLabel.Location = new System.Drawing.Point(224, 72);
        	this.typeLabel.Name = "typeLabel";
        	this.typeLabel.Size = new System.Drawing.Size(34, 13);
        	this.typeLabel.TabIndex = 10;
        	this.typeLabel.Text = "Type:";
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// accountsView
        	// 
        	this.accountsView.HideSelection = false;
        	this.accountsView.Location = new System.Drawing.Point(8, 32);
        	this.accountsView.Name = "accountsView";
        	this.accountsView.Size = new System.Drawing.Size(200, 248);
        	this.accountsView.TabIndex = 12;
        	this.accountsView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AccountsViewAfterSelect);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(8, 8);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(100, 13);
        	this.label1.TabIndex = 13;
        	this.label1.Text = "Available accounts:";
        	// 
        	// FormEditAccounts
        	// 
        	this.AcceptButton = this.updateButton;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.closeButton;
        	this.ClientSize = new System.Drawing.Size(506, 292);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.accountsView);
        	this.Controls.Add(this.typeCombo);
        	this.Controls.Add(this.startingBalanceBox);
        	this.Controls.Add(this.startingBalanceLabel);
        	this.Controls.Add(this.typeLabel);
        	this.Controls.Add(this.nameBox);
        	this.Controls.Add(this.nameLabel);
        	this.Controls.Add(this.closeButton);
        	this.Controls.Add(this.deleteButton);
        	this.Controls.Add(this.updateButton);
        	this.Controls.Add(this.newButton);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormEditAccounts";
        	this.ShowInTaskbar = false;
        	this.Text = "Accounts";
        	this.Load += new System.EventHandler(this.FormEditAccountsLoad);
        	this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEditAccountsFormClosed);
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView accountsView;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label startingBalanceLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox startingBalanceBox;
        private System.Windows.Forms.ComboBox typeCombo;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button newButton;
    }
}
