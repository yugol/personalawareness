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
 * Date: 12/09/2008
 * Time: 12:35
 * 
 */
namespace awareness.ui
{
    partial class ControlTimeIntervalSelector
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
        	this.fillPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.intervalCombo = new System.Windows.Forms.ComboBox();
        	this.firstPicker = new System.Windows.Forms.DateTimePicker();
        	this.lastPicker = new System.Windows.Forms.DateTimePicker();
        	this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        	this.fillPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// fillPanel
        	// 
        	this.fillPanel.ColumnCount = 3;
        	this.fillPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
        	this.fillPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        	this.fillPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        	this.fillPanel.Controls.Add(this.intervalCombo, 0, 0);
        	this.fillPanel.Controls.Add(this.firstPicker, 1, 0);
        	this.fillPanel.Controls.Add(this.lastPicker, 2, 0);
        	this.fillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.fillPanel.Location = new System.Drawing.Point(0, 0);
        	this.fillPanel.Name = "fillPanel";
        	this.fillPanel.RowCount = 1;
        	this.fillPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.fillPanel.Size = new System.Drawing.Size(360, 27);
        	this.fillPanel.TabIndex = 0;
        	// 
        	// intervalCombo
        	// 
        	this.intervalCombo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.intervalCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.intervalCombo.FormattingEnabled = true;
        	this.intervalCombo.Location = new System.Drawing.Point(3, 3);
        	this.intervalCombo.Name = "intervalCombo";
        	this.intervalCombo.Size = new System.Drawing.Size(138, 21);
        	this.intervalCombo.TabIndex = 0;
        	this.toolTip.SetToolTip(this.intervalCombo, "Choose pre-defined time interval");
        	this.intervalCombo.SelectedIndexChanged += new System.EventHandler(this.IntervalComboSelectedIndexChanged);
        	// 
        	// firstPicker
        	// 
        	this.firstPicker.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.firstPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        	this.firstPicker.Location = new System.Drawing.Point(147, 3);
        	this.firstPicker.Name = "firstPicker";
        	this.firstPicker.Size = new System.Drawing.Size(102, 20);
        	this.firstPicker.TabIndex = 1;
        	this.toolTip.SetToolTip(this.firstPicker, "From date");
        	this.firstPicker.ValueChanged += new System.EventHandler(this.FirstPickerValueChanged);
        	// 
        	// lastPicker
        	// 
        	this.lastPicker.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.lastPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        	this.lastPicker.Location = new System.Drawing.Point(255, 3);
        	this.lastPicker.Name = "lastPicker";
        	this.lastPicker.Size = new System.Drawing.Size(102, 20);
        	this.lastPicker.TabIndex = 2;
        	this.toolTip.SetToolTip(this.lastPicker, "To date");
        	this.lastPicker.ValueChanged += new System.EventHandler(this.LastPickerValueChanged);
        	// 
        	// ControlTimeIntervalSelector
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.fillPanel);
        	this.Name = "ControlTimeIntervalSelector";
        	this.Size = new System.Drawing.Size(360, 27);
        	this.fillPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DateTimePicker lastPicker;
        private System.Windows.Forms.DateTimePicker firstPicker;
        private System.Windows.Forms.ComboBox intervalCombo;
        private System.Windows.Forms.TableLayoutPanel fillPanel;
    }
}
