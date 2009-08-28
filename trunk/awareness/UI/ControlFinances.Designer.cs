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
 * Date: 11/09/2008
 * Time: 11:28
 * 
 */
namespace Awareness.UI
{
    partial class ControlFinances
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
        	this.netWorthNameLabel = new System.Windows.Forms.Label();
        	this.bottomPanel = new System.Windows.Forms.FlowLayoutPanel();
        	this.netWorthValueLabel = new System.Windows.Forms.Label();
        	this.accountsBalanceView = new System.Windows.Forms.ListView();
        	this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
        	this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
        	this.bottomPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// netWorthNameLabel
        	// 
        	this.netWorthNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.netWorthNameLabel.AutoSize = true;
        	this.netWorthNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.netWorthNameLabel.Location = new System.Drawing.Point(389, 7);
        	this.netWorthNameLabel.Name = "netWorthNameLabel";
        	this.netWorthNameLabel.Size = new System.Drawing.Size(66, 13);
        	this.netWorthNameLabel.TabIndex = 0;
        	this.netWorthNameLabel.Text = "Net worth:";
        	this.netWorthNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// bottomPanel
        	// 
        	this.bottomPanel.BackColor = System.Drawing.SystemColors.Control;
        	this.bottomPanel.Controls.Add(this.netWorthValueLabel);
        	this.bottomPanel.Controls.Add(this.netWorthNameLabel);
        	this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.bottomPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        	this.bottomPanel.Location = new System.Drawing.Point(0, 367);
        	this.bottomPanel.Name = "bottomPanel";
        	this.bottomPanel.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
        	this.bottomPanel.Size = new System.Drawing.Size(559, 26);
        	this.bottomPanel.TabIndex = 4;
        	// 
        	// netWorthValueLabel
        	// 
        	this.netWorthValueLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
        	this.netWorthValueLabel.AutoSize = true;
        	this.netWorthValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.netWorthValueLabel.Location = new System.Drawing.Point(461, 7);
        	this.netWorthValueLabel.Name = "netWorthValueLabel";
        	this.netWorthValueLabel.Size = new System.Drawing.Size(95, 13);
        	this.netWorthValueLabel.TabIndex = 1;
        	this.netWorthValueLabel.Text = "00,000.00 RON";
        	this.netWorthValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// accountsBalanceView
        	// 
        	this.accountsBalanceView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        	        	        	this.columnHeader1,
        	        	        	this.columnHeader2});
        	this.accountsBalanceView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.accountsBalanceView.FullRowSelect = true;
        	this.accountsBalanceView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        	this.accountsBalanceView.Location = new System.Drawing.Point(0, 0);
        	this.accountsBalanceView.MultiSelect = false;
        	this.accountsBalanceView.Name = "accountsBalanceView";
        	this.accountsBalanceView.Size = new System.Drawing.Size(559, 367);
        	this.accountsBalanceView.TabIndex = 5;
        	this.accountsBalanceView.UseCompatibleStateImageBehavior = false;
        	this.accountsBalanceView.View = System.Windows.Forms.View.Details;
        	this.accountsBalanceView.DoubleClick += new System.EventHandler(this.AccountsBalanceViewDoubleClick);
        	// 
        	// columnHeader1
        	// 
        	this.columnHeader1.Text = "Account";
        	this.columnHeader1.Width = 200;
        	// 
        	// columnHeader2
        	// 
        	this.columnHeader2.Text = "Balance";
        	this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.columnHeader2.Width = 100;
        	// 
        	// ControlFinances
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.accountsBalanceView);
        	this.Controls.Add(this.bottomPanel);
        	this.Name = "ControlFinances";
        	this.Size = new System.Drawing.Size(559, 393);
        	this.bottomPanel.ResumeLayout(false);
        	this.bottomPanel.PerformLayout();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView accountsBalanceView;
        private System.Windows.Forms.Label netWorthValueLabel;
        private System.Windows.Forms.FlowLayoutPanel bottomPanel;
        private System.Windows.Forms.Label netWorthNameLabel;
    }
}
