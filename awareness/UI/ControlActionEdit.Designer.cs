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
 * Date: 28/09/2008
 * Time: 19:23
 * 
 */
namespace Awareness.UI
{
    partial class ControlActionEdit
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
        	this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        	this.generalPage = new System.Windows.Forms.TabPage();
        	this.noteGroup = new System.Windows.Forms.GroupBox();
        	this.noteControl = new Awareness.UI.ControlAddNote();
        	this.planPage = new System.Windows.Forms.TabPage();
        	this.recurrenceGroup = new System.Windows.Forms.GroupBox();
        	this.anotherUpDown = new System.Windows.Forms.NumericUpDown();
        	this.untilRadio = new System.Windows.Forms.RadioButton();
        	this.untilPicker = new System.Windows.Forms.DateTimePicker();
        	this.anotherLabel = new System.Windows.Forms.Label();
        	this.anotherRadio = new System.Windows.Forms.RadioButton();
        	this.indefinitelyRadio = new System.Windows.Forms.RadioButton();
        	this.label1 = new System.Windows.Forms.Label();
        	this.separatorPanel = new System.Windows.Forms.Panel();
        	this.recurrencePatternEditControl = new Awareness.UI.ControlRecurrencePatternEdit();
        	this.whenGroup = new System.Windows.Forms.GroupBox();
        	this.setEndCheck = new System.Windows.Forms.CheckBox();
        	this.repeatCheck = new System.Windows.Forms.CheckBox();
        	this.planTimeCheck = new System.Windows.Forms.CheckBox();
        	this.endTimePicker = new System.Windows.Forms.DateTimePicker();
        	this.startTimePicker = new System.Windows.Forms.DateTimePicker();
        	this.endDatePicker = new System.Windows.Forms.DateTimePicker();
        	this.startDatePicker = new System.Windows.Forms.DateTimePicker();
        	this.durationLabel = new System.Windows.Forms.Label();
        	this.endLabel = new System.Windows.Forms.Label();
        	this.startLabel = new System.Windows.Forms.Label();
        	this.actionPages = new System.Windows.Forms.TabControl();
        	this.durationValueLabel = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        	this.generalPage.SuspendLayout();
        	this.noteGroup.SuspendLayout();
        	this.planPage.SuspendLayout();
        	this.recurrenceGroup.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.anotherUpDown)).BeginInit();
        	this.whenGroup.SuspendLayout();
        	this.actionPages.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// generalPage
        	// 
        	this.generalPage.Controls.Add(this.noteGroup);
        	this.generalPage.Location = new System.Drawing.Point(4, 22);
        	this.generalPage.Name = "generalPage";
        	this.generalPage.Padding = new System.Windows.Forms.Padding(3);
        	this.generalPage.Size = new System.Drawing.Size(493, 402);
        	this.generalPage.TabIndex = 0;
        	this.generalPage.Text = "General";
        	this.generalPage.UseVisualStyleBackColor = true;
        	// 
        	// noteGroup
        	// 
        	this.noteGroup.Controls.Add(this.noteControl);
        	this.noteGroup.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.noteGroup.Location = new System.Drawing.Point(3, 3);
        	this.noteGroup.Name = "noteGroup";
        	this.noteGroup.Size = new System.Drawing.Size(487, 396);
        	this.noteGroup.TabIndex = 1;
        	this.noteGroup.TabStop = false;
        	this.noteGroup.Text = "Note:";
        	// 
        	// noteControl
        	// 
        	this.noteControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.noteControl.Location = new System.Drawing.Point(3, 16);
        	this.noteControl.Name = "noteControl";
        	this.noteControl.Note = null;
        	this.noteControl.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
        	this.noteControl.Size = new System.Drawing.Size(481, 377);
        	this.noteControl.TabIndex = 2;
        	// 
        	// planPage
        	// 
        	this.planPage.Controls.Add(this.recurrenceGroup);
        	this.planPage.Controls.Add(this.whenGroup);
        	this.planPage.Location = new System.Drawing.Point(4, 22);
        	this.planPage.Name = "planPage";
        	this.planPage.Padding = new System.Windows.Forms.Padding(3);
        	this.planPage.Size = new System.Drawing.Size(493, 402);
        	this.planPage.TabIndex = 1;
        	this.planPage.Text = "Plan";
        	this.planPage.UseVisualStyleBackColor = true;
        	// 
        	// recurrenceGroup
        	// 
        	this.recurrenceGroup.Controls.Add(this.anotherUpDown);
        	this.recurrenceGroup.Controls.Add(this.untilRadio);
        	this.recurrenceGroup.Controls.Add(this.untilPicker);
        	this.recurrenceGroup.Controls.Add(this.anotherLabel);
        	this.recurrenceGroup.Controls.Add(this.anotherRadio);
        	this.recurrenceGroup.Controls.Add(this.indefinitelyRadio);
        	this.recurrenceGroup.Controls.Add(this.label1);
        	this.recurrenceGroup.Controls.Add(this.separatorPanel);
        	this.recurrenceGroup.Controls.Add(this.recurrencePatternEditControl);
        	this.recurrenceGroup.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.recurrenceGroup.Location = new System.Drawing.Point(3, 120);
        	this.recurrenceGroup.Name = "recurrenceGroup";
        	this.recurrenceGroup.Size = new System.Drawing.Size(487, 279);
        	this.recurrenceGroup.TabIndex = 1;
        	this.recurrenceGroup.TabStop = false;
        	this.recurrenceGroup.Text = "Recurrence:";
        	// 
        	// anotherUpDown
        	// 
        	this.anotherUpDown.Location = new System.Drawing.Point(168, 208);
        	this.anotherUpDown.Maximum = new decimal(new int[] {
        	        	        	9999,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.anotherUpDown.Minimum = new decimal(new int[] {
        	        	        	1,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.anotherUpDown.Name = "anotherUpDown";
        	this.anotherUpDown.Size = new System.Drawing.Size(56, 20);
        	this.anotherUpDown.TabIndex = 11;
        	this.anotherUpDown.Value = new decimal(new int[] {
        	        	        	1,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.anotherUpDown.ValueChanged += new System.EventHandler(this.AnotherUpDownValueChanged);
        	// 
        	// untilRadio
        	// 
        	this.untilRadio.Location = new System.Drawing.Point(96, 240);
        	this.untilRadio.Name = "untilRadio";
        	this.untilRadio.Size = new System.Drawing.Size(16, 24);
        	this.untilRadio.TabIndex = 12;
        	this.untilRadio.TabStop = true;
        	this.untilRadio.Text = "&Until";
        	this.untilRadio.UseVisualStyleBackColor = true;
        	this.untilRadio.CheckedChanged += new System.EventHandler(this.UntilRadioCheckedChanged);
        	// 
        	// untilPicker
        	// 
        	this.untilPicker.CustomFormat = "dd/MM/yyyy   HH:mm";
        	this.untilPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.untilPicker.Location = new System.Drawing.Point(120, 240);
        	this.untilPicker.Name = "untilPicker";
        	this.untilPicker.Size = new System.Drawing.Size(136, 20);
        	this.untilPicker.TabIndex = 13;
        	this.untilPicker.ValueChanged += new System.EventHandler(this.UntilPickerValueChanged);
        	// 
        	// anotherLabel
        	// 
        	this.anotherLabel.Location = new System.Drawing.Point(232, 208);
        	this.anotherLabel.Name = "anotherLabel";
        	this.anotherLabel.Size = new System.Drawing.Size(144, 23);
        	this.anotherLabel.TabIndex = 7;
        	this.anotherLabel.Text = "ocurrence(s) are completed";
        	this.anotherLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// anotherRadio
        	// 
        	this.anotherRadio.Location = new System.Drawing.Point(96, 208);
        	this.anotherRadio.Name = "anotherRadio";
        	this.anotherRadio.Size = new System.Drawing.Size(72, 24);
        	this.anotherRadio.TabIndex = 10;
        	this.anotherRadio.Text = "&Another";
        	this.anotherRadio.UseVisualStyleBackColor = true;
        	this.anotherRadio.CheckedChanged += new System.EventHandler(this.AnotherRadioCheckedChanged);
        	// 
        	// indefinitelyRadio
        	// 
        	this.indefinitelyRadio.Location = new System.Drawing.Point(96, 176);
        	this.indefinitelyRadio.Name = "indefinitelyRadio";
        	this.indefinitelyRadio.Size = new System.Drawing.Size(104, 24);
        	this.indefinitelyRadio.TabIndex = 9;
        	this.indefinitelyRadio.Text = "Inde&finitely";
        	this.indefinitelyRadio.UseVisualStyleBackColor = true;
        	this.indefinitelyRadio.CheckedChanged += new System.EventHandler(this.IndefinitelyRadioCheckedChanged);
        	// 
        	// label1
        	// 
        	this.label1.Location = new System.Drawing.Point(16, 176);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(48, 23);
        	this.label1.TabIndex = 2;
        	this.label1.Text = "Until:";
        	// 
        	// separatorPanel
        	// 
        	this.separatorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.separatorPanel.Location = new System.Drawing.Point(8, 160);
        	this.separatorPanel.Name = "separatorPanel";
        	this.separatorPanel.Size = new System.Drawing.Size(432, 4);
        	this.separatorPanel.TabIndex = 1;
        	// 
        	// recurrencePatternEditControl
        	// 
        	this.recurrencePatternEditControl.Location = new System.Drawing.Point(8, 16);
        	this.recurrencePatternEditControl.MinimumSize = new System.Drawing.Size(0, 140);
        	this.recurrencePatternEditControl.Name = "recurrencePatternEditControl";
        	this.recurrencePatternEditControl.Size = new System.Drawing.Size(456, 140);
        	this.recurrencePatternEditControl.TabIndex = 0;
        	// 
        	// whenGroup
        	// 
        	this.whenGroup.Controls.Add(this.durationValueLabel);
        	this.whenGroup.Controls.Add(this.setEndCheck);
        	this.whenGroup.Controls.Add(this.repeatCheck);
        	this.whenGroup.Controls.Add(this.planTimeCheck);
        	this.whenGroup.Controls.Add(this.endTimePicker);
        	this.whenGroup.Controls.Add(this.startTimePicker);
        	this.whenGroup.Controls.Add(this.endDatePicker);
        	this.whenGroup.Controls.Add(this.startDatePicker);
        	this.whenGroup.Controls.Add(this.durationLabel);
        	this.whenGroup.Controls.Add(this.endLabel);
        	this.whenGroup.Controls.Add(this.startLabel);
        	this.whenGroup.Dock = System.Windows.Forms.DockStyle.Top;
        	this.whenGroup.Location = new System.Drawing.Point(3, 3);
        	this.whenGroup.Name = "whenGroup";
        	this.whenGroup.Size = new System.Drawing.Size(487, 117);
        	this.whenGroup.TabIndex = 0;
        	this.whenGroup.TabStop = false;
        	this.whenGroup.Text = "When:";
        	// 
        	// setEndCheck
        	// 
        	this.setEndCheck.Location = new System.Drawing.Point(288, 48);
        	this.setEndCheck.Name = "setEndCheck";
        	this.setEndCheck.Size = new System.Drawing.Size(104, 24);
        	this.setEndCheck.TabIndex = 6;
        	this.setEndCheck.Text = "Set &end";
        	this.setEndCheck.UseVisualStyleBackColor = true;
        	this.setEndCheck.CheckedChanged += new System.EventHandler(this.SetEndCheckCheckedChanged);
        	// 
        	// repeatCheck
        	// 
        	this.repeatCheck.Location = new System.Drawing.Point(288, 80);
        	this.repeatCheck.Name = "repeatCheck";
        	this.repeatCheck.Size = new System.Drawing.Size(120, 24);
        	this.repeatCheck.TabIndex = 8;
        	this.repeatCheck.Text = "&Repeat";
        	this.repeatCheck.UseVisualStyleBackColor = true;
        	this.repeatCheck.CheckedChanged += new System.EventHandler(this.RepeatCheckCheckedChanged);
        	// 
        	// planTimeCheck
        	// 
        	this.planTimeCheck.Location = new System.Drawing.Point(288, 24);
        	this.planTimeCheck.Name = "planTimeCheck";
        	this.planTimeCheck.Size = new System.Drawing.Size(104, 24);
        	this.planTimeCheck.TabIndex = 3;
        	this.planTimeCheck.Text = "&Plan time";
        	this.planTimeCheck.UseVisualStyleBackColor = true;
        	this.planTimeCheck.CheckedChanged += new System.EventHandler(this.PlanTimeCheckCheckedChanged);
        	// 
        	// endTimePicker
        	// 
        	this.endTimePicker.CustomFormat = "HH:mm";
        	this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.endTimePicker.Location = new System.Drawing.Point(200, 48);
        	this.endTimePicker.Name = "endTimePicker";
        	this.endTimePicker.ShowUpDown = true;
        	this.endTimePicker.Size = new System.Drawing.Size(72, 20);
        	this.endTimePicker.TabIndex = 5;
        	this.endTimePicker.ValueChanged += new System.EventHandler(this.EndTimePickerValueChanged);
        	// 
        	// startTimePicker
        	// 
        	this.startTimePicker.CustomFormat = "HH:mm";
        	this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.startTimePicker.Location = new System.Drawing.Point(200, 24);
        	this.startTimePicker.Name = "startTimePicker";
        	this.startTimePicker.ShowUpDown = true;
        	this.startTimePicker.Size = new System.Drawing.Size(72, 20);
        	this.startTimePicker.TabIndex = 2;
        	this.startTimePicker.ValueChanged += new System.EventHandler(this.StartTimePickerValueChanged);
        	// 
        	// endDatePicker
        	// 
        	this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        	this.endDatePicker.Location = new System.Drawing.Point(80, 48);
        	this.endDatePicker.Name = "endDatePicker";
        	this.endDatePicker.Size = new System.Drawing.Size(104, 20);
        	this.endDatePicker.TabIndex = 4;
        	this.endDatePicker.ValueChanged += new System.EventHandler(this.EndDatePickerValueChanged);
        	// 
        	// startDatePicker
        	// 
        	this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        	this.startDatePicker.Location = new System.Drawing.Point(80, 24);
        	this.startDatePicker.Name = "startDatePicker";
        	this.startDatePicker.Size = new System.Drawing.Size(104, 20);
        	this.startDatePicker.TabIndex = 1;
        	this.startDatePicker.ValueChanged += new System.EventHandler(this.StartDatePickerValueChanged);
        	// 
        	// durationLabel
        	// 
        	this.durationLabel.AutoSize = true;
        	this.durationLabel.Location = new System.Drawing.Point(16, 80);
        	this.durationLabel.Name = "durationLabel";
        	this.durationLabel.Size = new System.Drawing.Size(50, 13);
        	this.durationLabel.TabIndex = 2;
        	this.durationLabel.Text = "Duration:";
        	// 
        	// endLabel
        	// 
        	this.endLabel.AutoSize = true;
        	this.endLabel.Location = new System.Drawing.Point(16, 48);
        	this.endLabel.Name = "endLabel";
        	this.endLabel.Size = new System.Drawing.Size(29, 13);
        	this.endLabel.TabIndex = 1;
        	this.endLabel.Text = "End:";
        	// 
        	// startLabel
        	// 
        	this.startLabel.AutoSize = true;
        	this.startLabel.Location = new System.Drawing.Point(16, 24);
        	this.startLabel.Name = "startLabel";
        	this.startLabel.Size = new System.Drawing.Size(32, 13);
        	this.startLabel.TabIndex = 0;
        	this.startLabel.Text = "Start:";
        	// 
        	// actionPages
        	// 
        	this.actionPages.Controls.Add(this.planPage);
        	this.actionPages.Controls.Add(this.generalPage);
        	this.actionPages.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.actionPages.Location = new System.Drawing.Point(0, 0);
        	this.actionPages.Name = "actionPages";
        	this.actionPages.SelectedIndex = 0;
        	this.actionPages.Size = new System.Drawing.Size(501, 428);
        	this.actionPages.TabIndex = 0;
        	// 
        	// durationValueLabel
        	// 
        	this.durationValueLabel.AutoSize = true;
        	this.durationValueLabel.Location = new System.Drawing.Point(80, 80);
        	this.durationValueLabel.Name = "durationValueLabel";
        	this.durationValueLabel.Size = new System.Drawing.Size(27, 13);
        	this.durationValueLabel.TabIndex = 9;
        	this.durationValueLabel.Text = "N/A";
        	// 
        	// ControlActionEdit
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.actionPages);
        	this.Name = "ControlActionEdit";
        	this.Size = new System.Drawing.Size(501, 428);
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        	this.generalPage.ResumeLayout(false);
        	this.noteGroup.ResumeLayout(false);
        	this.planPage.ResumeLayout(false);
        	this.recurrenceGroup.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.anotherUpDown)).EndInit();
        	this.whenGroup.ResumeLayout(false);
        	this.whenGroup.PerformLayout();
        	this.actionPages.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.Label durationValueLabel;
        private Awareness.UI.ControlAddNote noteControl;
        private System.Windows.Forms.NumericUpDown anotherUpDown;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RadioButton untilRadio;
        private System.Windows.Forms.Label anotherLabel;
        private System.Windows.Forms.DateTimePicker untilPicker;
        private System.Windows.Forms.RadioButton indefinitelyRadio;
        private System.Windows.Forms.RadioButton anotherRadio;
        private System.Windows.Forms.Panel separatorPanel;
        private System.Windows.Forms.Label label1;
        private Awareness.UI.ControlRecurrencePatternEdit recurrencePatternEditControl;
        private System.Windows.Forms.CheckBox setEndCheck;
        private System.Windows.Forms.CheckBox repeatCheck;
        private System.Windows.Forms.GroupBox recurrenceGroup;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.CheckBox planTimeCheck;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.GroupBox whenGroup;
        private System.Windows.Forms.GroupBox noteGroup;
        private System.Windows.Forms.TabPage planPage;
        private System.Windows.Forms.TabPage generalPage;
        private System.Windows.Forms.TabControl actionPages;
    }
}
