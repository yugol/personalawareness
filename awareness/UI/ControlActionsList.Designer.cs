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
 * Date: 03/10/2008
 * Time: 19:52
 * 
 */
namespace Awareness.ui
{
    partial class ControlActionsList
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
        	this.titleLabel = new System.Windows.Forms.Label();
        	this.actionsView = new System.Windows.Forms.ListView();
        	this.whatColumn = new System.Windows.Forms.ColumnHeader();
        	this.startColumn = new System.Windows.Forms.ColumnHeader();
        	this.endColumn = new System.Windows.Forms.ColumnHeader();
        	this.SuspendLayout();
        	// 
        	// titleLabel
        	// 
        	this.titleLabel.BackColor = System.Drawing.SystemColors.Control;
        	this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
        	this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.titleLabel.Location = new System.Drawing.Point(0, 0);
        	this.titleLabel.Name = "titleLabel";
        	this.titleLabel.Size = new System.Drawing.Size(348, 16);
        	this.titleLabel.TabIndex = 0;
        	this.titleLabel.Text = "When";
        	this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// actionsView
        	// 
        	this.actionsView.AllowColumnReorder = true;
        	this.actionsView.CheckBoxes = true;
        	this.actionsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        	        	        	this.whatColumn,
        	        	        	this.startColumn,
        	        	        	this.endColumn});
        	this.actionsView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.actionsView.FullRowSelect = true;
        	this.actionsView.HideSelection = false;
        	this.actionsView.LabelEdit = true;
        	this.actionsView.Location = new System.Drawing.Point(0, 16);
        	this.actionsView.MultiSelect = false;
        	this.actionsView.Name = "actionsView";
        	this.actionsView.ShowItemToolTips = true;
        	this.actionsView.Size = new System.Drawing.Size(348, 230);
        	this.actionsView.TabIndex = 1;
        	this.actionsView.UseCompatibleStateImageBehavior = false;
        	this.actionsView.View = System.Windows.Forms.View.Details;
        	this.actionsView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ActionsViewItemChecked);
        	this.actionsView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.ActionsViewAfterLabelEdit);
        	this.actionsView.SizeChanged += new System.EventHandler(this.ActionsViewSizeChanged);
        	this.actionsView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ActionsViewMouseUp);
        	this.actionsView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ActionsViewKeyDown);
        	// 
        	// whatColumn
        	// 
        	this.whatColumn.Text = "What";
        	// 
        	// startColumn
        	// 
        	this.startColumn.Text = "Start";
        	this.startColumn.Width = 45;
        	// 
        	// endColumn
        	// 
        	this.endColumn.Text = "End";
        	this.endColumn.Width = 45;
        	// 
        	// ControlActionsList
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.actionsView);
        	this.Controls.Add(this.titleLabel);
        	this.Name = "ControlActionsList";
        	this.Size = new System.Drawing.Size(348, 246);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ListView actionsView;
        private System.Windows.Forms.ColumnHeader whatColumn;
        private System.Windows.Forms.ColumnHeader endColumn;
        private System.Windows.Forms.ColumnHeader startColumn;
        private System.Windows.Forms.Label titleLabel;
    }
}
