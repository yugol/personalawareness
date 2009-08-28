/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 24/11/2008
 * Time: 21:48
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


namespace Awareness.UI
{
    partial class FormReminders
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
        	System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("0000-00-00 00:00");
        	this.occurencesView = new System.Windows.Forms.ListView();
        	this.startColumn = new System.Windows.Forms.ColumnHeader();
        	this.nameColumn = new System.Windows.Forms.ColumnHeader();
        	this.dueColumn = new System.Windows.Forms.ColumnHeader();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.bottomPanel = new System.Windows.Forms.Panel();
        	this.completeButton = new System.Windows.Forms.Button();
        	this.centerPanel = new System.Windows.Forms.Panel();
        	this.groupBox1.SuspendLayout();
        	this.bottomPanel.SuspendLayout();
        	this.centerPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// occurencesView
        	// 
        	this.occurencesView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        	        	        	this.startColumn,
        	        	        	this.nameColumn,
        	        	        	this.dueColumn});
        	this.occurencesView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.occurencesView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.occurencesView.FullRowSelect = true;
        	this.occurencesView.HideSelection = false;
        	this.occurencesView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
        	        	        	listViewItem1});
        	this.occurencesView.Location = new System.Drawing.Point(3, 23);
        	this.occurencesView.MultiSelect = false;
        	this.occurencesView.Name = "occurencesView";
        	this.occurencesView.Size = new System.Drawing.Size(523, 238);
        	this.occurencesView.TabIndex = 0;
        	this.occurencesView.UseCompatibleStateImageBehavior = false;
        	this.occurencesView.View = System.Windows.Forms.View.Details;
        	this.occurencesView.SelectedIndexChanged += new System.EventHandler(this.OccurencesViewSelectedIndexChanged);
        	// 
        	// startColumn
        	// 
        	this.startColumn.Text = "Start time";
        	this.startColumn.Width = 100;
        	// 
        	// nameColumn
        	// 
        	this.nameColumn.Text = "Name";
        	this.nameColumn.Width = 304;
        	// 
        	// dueColumn
        	// 
        	this.dueColumn.Text = "Due in";
        	this.dueColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.dueColumn.Width = 90;
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.occurencesView);
        	this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.groupBox1.Location = new System.Drawing.Point(8, 8);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
        	this.groupBox1.Size = new System.Drawing.Size(529, 264);
        	this.groupBox1.TabIndex = 1;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Action occurrences:";
        	// 
        	// bottomPanel
        	// 
        	this.bottomPanel.Controls.Add(this.completeButton);
        	this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.bottomPanel.Location = new System.Drawing.Point(0, 280);
        	this.bottomPanel.Name = "bottomPanel";
        	this.bottomPanel.Padding = new System.Windows.Forms.Padding(8);
        	this.bottomPanel.Size = new System.Drawing.Size(545, 41);
        	this.bottomPanel.TabIndex = 2;
        	// 
        	// completeButton
        	// 
        	this.completeButton.Dock = System.Windows.Forms.DockStyle.Right;
        	this.completeButton.Location = new System.Drawing.Point(462, 8);
        	this.completeButton.Name = "completeButton";
        	this.completeButton.Size = new System.Drawing.Size(75, 25);
        	this.completeButton.TabIndex = 0;
        	this.completeButton.Text = "Complete";
        	this.completeButton.UseVisualStyleBackColor = true;
        	// 
        	// centerPanel
        	// 
        	this.centerPanel.Controls.Add(this.groupBox1);
        	this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.centerPanel.Location = new System.Drawing.Point(0, 0);
        	this.centerPanel.Name = "centerPanel";
        	this.centerPanel.Padding = new System.Windows.Forms.Padding(8);
        	this.centerPanel.Size = new System.Drawing.Size(545, 280);
        	this.centerPanel.TabIndex = 3;
        	// 
        	// FormReminders
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(545, 321);
        	this.Controls.Add(this.centerPanel);
        	this.Controls.Add(this.bottomPanel);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        	this.Name = "FormReminders";
        	this.ShowInTaskbar = false;
        	this.Text = "Reminders";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRemindersFormClosing);
        	this.groupBox1.ResumeLayout(false);
        	this.bottomPanel.ResumeLayout(false);
        	this.centerPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ColumnHeader startColumn;
        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.Button completeButton;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader dueColumn;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ListView occurencesView;
    }
}
