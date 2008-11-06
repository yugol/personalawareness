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
 * Time: 22:59
 * 
 */
namespace awareness.ui
{
    partial class ControlWeekActionsReport
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
        	this.datePicker = new awareness.ui.ControlJumperDatePicker();
        	this.reportPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.saturdayActions = new awareness.ui.ControlActionsList();
        	this.fridayActions = new awareness.ui.ControlActionsList();
        	this.thursdayActions = new awareness.ui.ControlActionsList();
        	this.mondayActions = new awareness.ui.ControlActionsList();
        	this.tuesdayActions = new awareness.ui.ControlActionsList();
        	this.wednesdayActions = new awareness.ui.ControlActionsList();
        	this.sundayActions = new awareness.ui.ControlActionsList();
        	this.reportPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// datePicker
        	// 
        	this.datePicker.Dock = System.Windows.Forms.DockStyle.Top;
        	this.datePicker.JumpSize = awareness.ui.JumpSize.Week;
        	this.datePicker.Location = new System.Drawing.Point(0, 0);
        	this.datePicker.MinimumSize = new System.Drawing.Size(244, 20);
        	this.datePicker.Name = "datePicker";
        	this.datePicker.Size = new System.Drawing.Size(669, 20);
        	this.datePicker.TabIndex = 0;
        	this.datePicker.Value = new System.DateTime(2008, 10, 3, 23, 0, 5, 214);
        	// 
        	// reportPanel
        	// 
        	this.reportPanel.ColumnCount = 2;
        	this.reportPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.reportPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.reportPanel.Controls.Add(this.saturdayActions, 1, 2);
        	this.reportPanel.Controls.Add(this.fridayActions, 1, 1);
        	this.reportPanel.Controls.Add(this.thursdayActions, 1, 0);
        	this.reportPanel.Controls.Add(this.mondayActions, 0, 0);
        	this.reportPanel.Controls.Add(this.tuesdayActions, 0, 1);
        	this.reportPanel.Controls.Add(this.wednesdayActions, 0, 2);
        	this.reportPanel.Controls.Add(this.sundayActions, 1, 3);
        	this.reportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.reportPanel.Location = new System.Drawing.Point(0, 20);
        	this.reportPanel.Name = "reportPanel";
        	this.reportPanel.RowCount = 4;
        	this.reportPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
        	this.reportPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
        	this.reportPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
        	this.reportPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17F));
        	this.reportPanel.Size = new System.Drawing.Size(669, 530);
        	this.reportPanel.TabIndex = 1;
        	// 
        	// saturdayActions
        	// 
        	this.saturdayActions.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.saturdayActions.HeadersVisible = false;
        	this.saturdayActions.Location = new System.Drawing.Point(335, 350);
        	this.saturdayActions.Margin = new System.Windows.Forms.Padding(1, 2, 0, 0);
        	this.saturdayActions.Name = "saturdayActions";
        	this.saturdayActions.Size = new System.Drawing.Size(334, 88);
        	this.saturdayActions.TabIndex = 5;
        	this.saturdayActions.TimeInterval = null;
        	this.saturdayActions.Title = "When";
        	this.saturdayActions.TitleFormat = awareness.ui.TitleFormats.DAY_OF_WEEK;
        	// 
        	// fridayActions
        	// 
        	this.fridayActions.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.fridayActions.HeadersVisible = false;
        	this.fridayActions.Location = new System.Drawing.Point(335, 176);
        	this.fridayActions.Margin = new System.Windows.Forms.Padding(1, 2, 0, 0);
        	this.fridayActions.Name = "fridayActions";
        	this.fridayActions.Size = new System.Drawing.Size(334, 172);
        	this.fridayActions.TabIndex = 4;
        	this.fridayActions.TimeInterval = null;
        	this.fridayActions.Title = "When";
        	this.fridayActions.TitleFormat = awareness.ui.TitleFormats.DAY_OF_WEEK;
        	// 
        	// thursdayActions
        	// 
        	this.thursdayActions.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.thursdayActions.HeadersVisible = false;
        	this.thursdayActions.Location = new System.Drawing.Point(335, 2);
        	this.thursdayActions.Margin = new System.Windows.Forms.Padding(1, 2, 0, 0);
        	this.thursdayActions.Name = "thursdayActions";
        	this.thursdayActions.Size = new System.Drawing.Size(334, 172);
        	this.thursdayActions.TabIndex = 3;
        	this.thursdayActions.TimeInterval = null;
        	this.thursdayActions.Title = "When";
        	this.thursdayActions.TitleFormat = awareness.ui.TitleFormats.DAY_OF_WEEK;
        	// 
        	// mondayActions
        	// 
        	this.mondayActions.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mondayActions.HeadersVisible = false;
        	this.mondayActions.Location = new System.Drawing.Point(0, 2);
        	this.mondayActions.Margin = new System.Windows.Forms.Padding(0, 2, 1, 0);
        	this.mondayActions.Name = "mondayActions";
        	this.mondayActions.Size = new System.Drawing.Size(333, 172);
        	this.mondayActions.TabIndex = 0;
        	this.mondayActions.TimeInterval = null;
        	this.mondayActions.Title = "When";
        	this.mondayActions.TitleFormat = awareness.ui.TitleFormats.DAY_OF_WEEK;
        	// 
        	// tuesdayActions
        	// 
        	this.tuesdayActions.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tuesdayActions.HeadersVisible = false;
        	this.tuesdayActions.Location = new System.Drawing.Point(0, 176);
        	this.tuesdayActions.Margin = new System.Windows.Forms.Padding(0, 2, 1, 0);
        	this.tuesdayActions.Name = "tuesdayActions";
        	this.tuesdayActions.Size = new System.Drawing.Size(333, 172);
        	this.tuesdayActions.TabIndex = 1;
        	this.tuesdayActions.TimeInterval = null;
        	this.tuesdayActions.Title = "When";
        	this.tuesdayActions.TitleFormat = awareness.ui.TitleFormats.DAY_OF_WEEK;
        	// 
        	// wednesdayActions
        	// 
        	this.wednesdayActions.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.wednesdayActions.HeadersVisible = false;
        	this.wednesdayActions.Location = new System.Drawing.Point(0, 350);
        	this.wednesdayActions.Margin = new System.Windows.Forms.Padding(0, 2, 1, 0);
        	this.wednesdayActions.Name = "wednesdayActions";
        	this.reportPanel.SetRowSpan(this.wednesdayActions, 2);
        	this.wednesdayActions.Size = new System.Drawing.Size(333, 180);
        	this.wednesdayActions.TabIndex = 2;
        	this.wednesdayActions.TimeInterval = null;
        	this.wednesdayActions.Title = "When";
        	this.wednesdayActions.TitleFormat = awareness.ui.TitleFormats.DAY_OF_WEEK;
        	// 
        	// sundayActions
        	// 
        	this.sundayActions.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.sundayActions.HeadersVisible = false;
        	this.sundayActions.Location = new System.Drawing.Point(335, 440);
        	this.sundayActions.Margin = new System.Windows.Forms.Padding(1, 2, 0, 0);
        	this.sundayActions.Name = "sundayActions";
        	this.sundayActions.Size = new System.Drawing.Size(334, 90);
        	this.sundayActions.TabIndex = 6;
        	this.sundayActions.TimeInterval = null;
        	this.sundayActions.Title = "When";
        	this.sundayActions.TitleFormat = awareness.ui.TitleFormats.DAY_OF_WEEK;
        	// 
        	// ControlWeekActionsReport
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.reportPanel);
        	this.Controls.Add(this.datePicker);
        	this.Name = "ControlWeekActionsReport";
        	this.Size = new System.Drawing.Size(669, 550);
        	this.Load += new System.EventHandler(this.ControlWeekActionsReportLoad);
        	this.reportPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private awareness.ui.ControlActionsList sundayActions;
        private awareness.ui.ControlActionsList wednesdayActions;
        private awareness.ui.ControlActionsList tuesdayActions;
        private awareness.ui.ControlActionsList mondayActions;
        private awareness.ui.ControlActionsList thursdayActions;
        private awareness.ui.ControlActionsList fridayActions;
        private awareness.ui.ControlActionsList saturdayActions;
        private System.Windows.Forms.TableLayoutPanel reportPanel;
        private awareness.ui.ControlJumperDatePicker datePicker;
    }
}
