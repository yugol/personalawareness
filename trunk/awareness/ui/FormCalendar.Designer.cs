/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/12/2008
 * Time: 21:11
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


namespace awareness.ui
{
    partial class FormCalendar
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
        	this.matrixPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.datePicker = new awareness.ui.ControlJumperDatePicker();
        	this.leftCalendar = new awareness.ui.ControlCalendar();
        	this.middleCalendar = new awareness.ui.ControlCalendar();
        	this.rightCalendar = new awareness.ui.ControlCalendar();
        	this.matrixPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// matrixPanel
        	// 
        	this.matrixPanel.ColumnCount = 3;
        	this.matrixPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        	this.matrixPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        	this.matrixPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
        	this.matrixPanel.Controls.Add(this.datePicker, 0, 0);
        	this.matrixPanel.Controls.Add(this.leftCalendar, 0, 1);
        	this.matrixPanel.Controls.Add(this.middleCalendar, 1, 1);
        	this.matrixPanel.Controls.Add(this.rightCalendar, 2, 1);
        	this.matrixPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.matrixPanel.Location = new System.Drawing.Point(0, 0);
        	this.matrixPanel.Name = "matrixPanel";
        	this.matrixPanel.RowCount = 2;
        	this.matrixPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
        	this.matrixPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.matrixPanel.Size = new System.Drawing.Size(484, 154);
        	this.matrixPanel.TabIndex = 0;
        	// 
        	// datePicker
        	// 
        	this.matrixPanel.SetColumnSpan(this.datePicker, 3);
        	this.datePicker.Dock = System.Windows.Forms.DockStyle.Right;
        	this.datePicker.JumpSize = awareness.ui.EJumpSize.Month;
        	this.datePicker.Location = new System.Drawing.Point(177, 3);
        	this.datePicker.MinimumSize = new System.Drawing.Size(304, 20);
        	this.datePicker.Name = "datePicker";
        	this.datePicker.Size = new System.Drawing.Size(304, 20);
        	this.datePicker.TabIndex = 0;
        	this.datePicker.Value = new System.DateTime(2008, 12, 3, 21, 15, 22, 453);
        	this.datePicker.ValueChanged += new System.EventHandler(this.DatePickerValueChanged);
        	// 
        	// leftCalendar
        	// 
        	this.leftCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.leftCalendar.Location = new System.Drawing.Point(3, 28);
        	this.leftCalendar.MinimumSize = new System.Drawing.Size(150, 116);
        	this.leftCalendar.Name = "leftCalendar";
        	this.leftCalendar.Size = new System.Drawing.Size(155, 123);
        	this.leftCalendar.TabIndex = 1;
        	// 
        	// middleCalendar
        	// 
        	this.middleCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.middleCalendar.Location = new System.Drawing.Point(164, 28);
        	this.middleCalendar.MinimumSize = new System.Drawing.Size(150, 116);
        	this.middleCalendar.Name = "middleCalendar";
        	this.middleCalendar.Size = new System.Drawing.Size(155, 123);
        	this.middleCalendar.TabIndex = 2;
        	// 
        	// rightCalendar
        	// 
        	this.rightCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.rightCalendar.Location = new System.Drawing.Point(325, 28);
        	this.rightCalendar.MinimumSize = new System.Drawing.Size(150, 116);
        	this.rightCalendar.Name = "rightCalendar";
        	this.rightCalendar.Size = new System.Drawing.Size(156, 123);
        	this.rightCalendar.TabIndex = 3;
        	// 
        	// FormCalendar
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(484, 154);
        	this.Controls.Add(this.matrixPanel);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        	this.MinimumSize = new System.Drawing.Size(492, 180);
        	this.Name = "FormCalendar";
        	this.ShowInTaskbar = false;
        	this.Text = "Calendar";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCalendarFormClosing);
        	this.matrixPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private awareness.ui.ControlCalendar rightCalendar;
        private awareness.ui.ControlCalendar middleCalendar;
        private awareness.ui.ControlCalendar leftCalendar;
        private awareness.ui.ControlJumperDatePicker datePicker;
        private System.Windows.Forms.TableLayoutPanel matrixPanel;
    }
}
