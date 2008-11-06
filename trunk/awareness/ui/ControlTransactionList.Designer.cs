/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 05/09/2008
 * Time: 12:55
 * 
 */
namespace awareness.ui
{
    partial class ControlTransactionList
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
        	this.transactionList = new System.Windows.Forms.ListView();
        	this.column = new System.Windows.Forms.ColumnHeader();
        	this.SuspendLayout();
        	// 
        	// transactionList
        	// 
        	this.transactionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        	        	        	this.column});
        	this.transactionList.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.transactionList.FullRowSelect = true;
        	this.transactionList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
        	this.transactionList.HideSelection = false;
        	this.transactionList.Location = new System.Drawing.Point(0, 0);
        	this.transactionList.MultiSelect = false;
        	this.transactionList.Name = "transactionList";
        	this.transactionList.OwnerDraw = true;
        	this.transactionList.Size = new System.Drawing.Size(300, 58);
        	this.transactionList.TabIndex = 0;
        	this.transactionList.UseCompatibleStateImageBehavior = false;
        	this.transactionList.View = System.Windows.Forms.View.Details;
        	this.transactionList.Resize += new System.EventHandler(this.TransactionListResize);
        	this.transactionList.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.TransactionListDrawItem);
        	this.transactionList.SelectedIndexChanged += new System.EventHandler(this.TransactionListSelectedIndexChanged);
        	this.transactionList.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.TransactionListDrawSubItem);
        	// 
        	// column
        	// 
        	this.column.Text = "Transactions";
        	this.column.Width = 278;
        	// 
        	// ControlTransactionList
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.transactionList);
        	this.Name = "ControlTransactionList";
        	this.Size = new System.Drawing.Size(300, 58);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ColumnHeader column;
        private System.Windows.Forms.ListView transactionList;
    }
}
