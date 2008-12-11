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
        	this.actionPages = new System.Windows.Forms.TabControl();
        	this.generalPage = new System.Windows.Forms.TabPage();
        	this.noteGroup = new System.Windows.Forms.GroupBox();
        	this.noteTextView = new Awareness.UI.ControlNoteTextView();
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
        	this.durationCombo = new System.Windows.Forms.ComboBox();
        	this.endDatePicker = new System.Windows.Forms.DateTimePicker();
        	this.startDatePicker = new System.Windows.Forms.DateTimePicker();
        	this.durationLabel = new System.Windows.Forms.Label();
        	this.endLabel = new System.Windows.Forms.Label();
        	this.startLabel = new System.Windows.Forms.Label();
        	this.reminderPage = new System.Windows.Forms.TabPage();
        	this.setupGroup = new System.Windows.Forms.GroupBox();
        	this.usageLabel = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.soundSelector = new Awareness.UI.ControlCommandSelector();
        	this.commandSelector = new Awareness.UI.ControlCommandSelector();
        	this.playSoundCheck = new System.Windows.Forms.CheckBox();
        	this.runCommandCheck = new System.Windows.Forms.CheckBox();
        	this.beforeOccurrenceLabel = new System.Windows.Forms.Label();
        	this.reminderDurationCombo = new System.Windows.Forms.ComboBox();
        	this.showReminderCheck = new System.Windows.Forms.CheckBox();
        	this.aboutPage = new System.Windows.Forms.TabPage();
        	this.timingGroup = new System.Windows.Forms.GroupBox();
        	this.createdBox = new System.Windows.Forms.TextBox();
        	this.modifiedBox = new System.Windows.Forms.TextBox();
        	this.completedBox = new System.Windows.Forms.TextBox();
        	this.completedLabel = new System.Windows.Forms.Label();
        	this.modifiedLabel = new System.Windows.Forms.Label();
        	this.createdLabel = new System.Windows.Forms.Label();
        	this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        	this.actionPages.SuspendLayout();
        	this.generalPage.SuspendLayout();
        	this.noteGroup.SuspendLayout();
        	this.planPage.SuspendLayout();
        	this.recurrenceGroup.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.anotherUpDown)).BeginInit();
        	this.whenGroup.SuspendLayout();
        	this.reminderPage.SuspendLayout();
        	this.setupGroup.SuspendLayout();
        	this.aboutPage.SuspendLayout();
        	this.timingGroup.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// actionPages
        	// 
        	this.actionPages.Controls.Add(this.generalPage);
        	this.actionPages.Controls.Add(this.planPage);
        	this.actionPages.Controls.Add(this.reminderPage);
        	this.actionPages.Controls.Add(this.aboutPage);
        	this.actionPages.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.actionPages.Location = new System.Drawing.Point(0, 0);
        	this.actionPages.Name = "actionPages";
        	this.actionPages.SelectedIndex = 0;
        	this.actionPages.Size = new System.Drawing.Size(501, 428);
        	this.actionPages.TabIndex = 0;
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
        	this.noteGroup.Controls.Add(this.noteTextView);
        	this.noteGroup.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.noteGroup.Location = new System.Drawing.Point(3, 3);
        	this.noteGroup.Name = "noteGroup";
        	this.noteGroup.Size = new System.Drawing.Size(487, 396);
        	this.noteGroup.TabIndex = 1;
        	this.noteGroup.TabStop = false;
        	this.noteGroup.Text = "Note:";
        	// 
        	// noteTextView
        	// 
        	this.noteTextView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.noteTextView.IconVisible = false;
        	this.noteTextView.Location = new System.Drawing.Point(3, 16);
        	this.noteTextView.Name = "noteTextView";
        	this.noteTextView.Node = null;
        	this.noteTextView.Note = null;
        	this.noteTextView.ScrollBars = true;
        	this.noteTextView.Size = new System.Drawing.Size(481, 377);
        	this.noteTextView.TabIndex = 0;
        	this.noteTextView.TextReadOnly = false;
        	this.noteTextView.TitleReadOnly = false;
        	this.noteTextView.TopVisible = false;
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
        	this.whenGroup.Controls.Add(this.setEndCheck);
        	this.whenGroup.Controls.Add(this.repeatCheck);
        	this.whenGroup.Controls.Add(this.planTimeCheck);
        	this.whenGroup.Controls.Add(this.endTimePicker);
        	this.whenGroup.Controls.Add(this.startTimePicker);
        	this.whenGroup.Controls.Add(this.durationCombo);
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
        	// durationCombo
        	// 
        	this.durationCombo.FormattingEnabled = true;
        	this.durationCombo.Location = new System.Drawing.Point(80, 80);
        	this.durationCombo.Name = "durationCombo";
        	this.durationCombo.Size = new System.Drawing.Size(192, 21);
        	this.durationCombo.TabIndex = 7;
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
        	// reminderPage
        	// 
        	this.reminderPage.Controls.Add(this.setupGroup);
        	this.reminderPage.Location = new System.Drawing.Point(4, 22);
        	this.reminderPage.Name = "reminderPage";
        	this.reminderPage.Padding = new System.Windows.Forms.Padding(3);
        	this.reminderPage.Size = new System.Drawing.Size(493, 402);
        	this.reminderPage.TabIndex = 3;
        	this.reminderPage.Text = "Reminder";
        	this.reminderPage.UseVisualStyleBackColor = true;
        	// 
        	// setupGroup
        	// 
        	this.setupGroup.Controls.Add(this.usageLabel);
        	this.setupGroup.Controls.Add(this.label2);
        	this.setupGroup.Controls.Add(this.soundSelector);
        	this.setupGroup.Controls.Add(this.commandSelector);
        	this.setupGroup.Controls.Add(this.playSoundCheck);
        	this.setupGroup.Controls.Add(this.runCommandCheck);
        	this.setupGroup.Controls.Add(this.beforeOccurrenceLabel);
        	this.setupGroup.Controls.Add(this.reminderDurationCombo);
        	this.setupGroup.Controls.Add(this.showReminderCheck);
        	this.setupGroup.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.setupGroup.Location = new System.Drawing.Point(3, 3);
        	this.setupGroup.Name = "setupGroup";
        	this.setupGroup.Size = new System.Drawing.Size(487, 396);
        	this.setupGroup.TabIndex = 0;
        	this.setupGroup.TabStop = false;
        	this.setupGroup.Text = "Setup:";
        	// 
        	// usageLabel
        	// 
        	this.usageLabel.ForeColor = System.Drawing.Color.Red;
        	this.usageLabel.Location = new System.Drawing.Point(16, 288);
        	this.usageLabel.Name = "usageLabel";
        	this.usageLabel.Size = new System.Drawing.Size(296, 48);
        	this.usageLabel.TabIndex = 14;
        	this.usageLabel.Text = "Only the actions with start time planned can have reminders. If you want to attac" +
        	"h a reminder to this action please go to the \'Plan\' tab and check the \'Plan time" +
        	"\' button.";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(16, 224);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(123, 13);
        	this.label2.TabIndex = 13;
        	this.label2.Text = "Remind me of this action";
        	this.label2.Visible = false;
        	// 
        	// soundSelector
        	// 
        	this.soundSelector.Command = "";
        	this.soundSelector.Location = new System.Drawing.Point(40, 168);
        	this.soundSelector.MinimumSize = new System.Drawing.Size(140, 28);
        	this.soundSelector.Name = "soundSelector";
        	this.soundSelector.Size = new System.Drawing.Size(288, 28);
        	this.soundSelector.TabIndex = 5;
        	// 
        	// commandSelector
        	// 
        	this.commandSelector.Command = "";
        	this.commandSelector.Location = new System.Drawing.Point(40, 96);
        	this.commandSelector.MinimumSize = new System.Drawing.Size(140, 28);
        	this.commandSelector.Name = "commandSelector";
        	this.commandSelector.Size = new System.Drawing.Size(288, 28);
        	this.commandSelector.TabIndex = 3;
        	// 
        	// playSoundCheck
        	// 
        	this.playSoundCheck.Location = new System.Drawing.Point(16, 136);
        	this.playSoundCheck.Name = "playSoundCheck";
        	this.playSoundCheck.Size = new System.Drawing.Size(104, 24);
        	this.playSoundCheck.TabIndex = 4;
        	this.playSoundCheck.Text = "&Play sound";
        	this.playSoundCheck.UseVisualStyleBackColor = true;
        	this.playSoundCheck.CheckedChanged += new System.EventHandler(this.PlaySoundCheckCheckedChanged);
        	// 
        	// runCommandCheck
        	// 
        	this.runCommandCheck.Location = new System.Drawing.Point(16, 64);
        	this.runCommandCheck.Name = "runCommandCheck";
        	this.runCommandCheck.Size = new System.Drawing.Size(192, 24);
        	this.runCommandCheck.TabIndex = 2;
        	this.runCommandCheck.Text = "&Run operating system command";
        	this.runCommandCheck.UseVisualStyleBackColor = true;
        	this.runCommandCheck.CheckedChanged += new System.EventHandler(this.RunCommandCheckCheckedChanged);
        	// 
        	// beforeOccurrenceLabel
        	// 
        	this.beforeOccurrenceLabel.AutoSize = true;
        	this.beforeOccurrenceLabel.Location = new System.Drawing.Point(192, 248);
        	this.beforeOccurrenceLabel.Name = "beforeOccurrenceLabel";
        	this.beforeOccurrenceLabel.Size = new System.Drawing.Size(123, 13);
        	this.beforeOccurrenceLabel.TabIndex = 7;
        	this.beforeOccurrenceLabel.Text = "before every occurrence";
        	this.beforeOccurrenceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.beforeOccurrenceLabel.Visible = false;
        	// 
        	// reminderDurationCombo
        	// 
        	this.reminderDurationCombo.FormattingEnabled = true;
        	this.reminderDurationCombo.Location = new System.Drawing.Point(16, 248);
        	this.reminderDurationCombo.Name = "reminderDurationCombo";
        	this.reminderDurationCombo.Size = new System.Drawing.Size(150, 21);
        	this.reminderDurationCombo.TabIndex = 6;
        	this.reminderDurationCombo.Visible = false;
        	this.reminderDurationCombo.Validating += new System.ComponentModel.CancelEventHandler(this.ReminderDurationComboValidating);
        	this.reminderDurationCombo.TextChanged += new System.EventHandler(this.ReminderDurationComboTextChanged);
        	// 
        	// showReminderCheck
        	// 
        	this.showReminderCheck.Location = new System.Drawing.Point(16, 24);
        	this.showReminderCheck.Name = "showReminderCheck";
        	this.showReminderCheck.Size = new System.Drawing.Size(320, 24);
        	this.showReminderCheck.TabIndex = 1;
        	this.showReminderCheck.Text = "&Show reminder dialog";
        	this.showReminderCheck.UseVisualStyleBackColor = true;
        	this.showReminderCheck.CheckedChanged += new System.EventHandler(this.ShowReminderCheckCheckedChanged);
        	// 
        	// aboutPage
        	// 
        	this.aboutPage.Controls.Add(this.timingGroup);
        	this.aboutPage.Location = new System.Drawing.Point(4, 22);
        	this.aboutPage.Name = "aboutPage";
        	this.aboutPage.Padding = new System.Windows.Forms.Padding(3);
        	this.aboutPage.Size = new System.Drawing.Size(493, 402);
        	this.aboutPage.TabIndex = 2;
        	this.aboutPage.Text = "About";
        	this.aboutPage.UseVisualStyleBackColor = true;
        	// 
        	// timingGroup
        	// 
        	this.timingGroup.Controls.Add(this.createdBox);
        	this.timingGroup.Controls.Add(this.modifiedBox);
        	this.timingGroup.Controls.Add(this.completedBox);
        	this.timingGroup.Controls.Add(this.completedLabel);
        	this.timingGroup.Controls.Add(this.modifiedLabel);
        	this.timingGroup.Controls.Add(this.createdLabel);
        	this.timingGroup.Dock = System.Windows.Forms.DockStyle.Top;
        	this.timingGroup.Location = new System.Drawing.Point(3, 3);
        	this.timingGroup.Name = "timingGroup";
        	this.timingGroup.Size = new System.Drawing.Size(487, 133);
        	this.timingGroup.TabIndex = 0;
        	this.timingGroup.TabStop = false;
        	this.timingGroup.Text = "Action timing:";
        	// 
        	// createdBox
        	// 
        	this.createdBox.Location = new System.Drawing.Point(96, 32);
        	this.createdBox.Name = "createdBox";
        	this.createdBox.ReadOnly = true;
        	this.createdBox.Size = new System.Drawing.Size(144, 20);
        	this.createdBox.TabIndex = 5;
        	this.createdBox.Text = "0000/00/00 00:00:00";
        	this.createdBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	// 
        	// modifiedBox
        	// 
        	this.modifiedBox.Location = new System.Drawing.Point(96, 64);
        	this.modifiedBox.Name = "modifiedBox";
        	this.modifiedBox.ReadOnly = true;
        	this.modifiedBox.Size = new System.Drawing.Size(144, 20);
        	this.modifiedBox.TabIndex = 4;
        	this.modifiedBox.Text = "0000/00/00 00:00:00";
        	this.modifiedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	// 
        	// completedBox
        	// 
        	this.completedBox.Location = new System.Drawing.Point(96, 96);
        	this.completedBox.Name = "completedBox";
        	this.completedBox.ReadOnly = true;
        	this.completedBox.Size = new System.Drawing.Size(144, 20);
        	this.completedBox.TabIndex = 3;
        	this.completedBox.Text = "0000/00/00 00:00:00";
        	this.completedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	// 
        	// completedLabel
        	// 
        	this.completedLabel.AutoSize = true;
        	this.completedLabel.Location = new System.Drawing.Point(16, 96);
        	this.completedLabel.Name = "completedLabel";
        	this.completedLabel.Size = new System.Drawing.Size(60, 13);
        	this.completedLabel.TabIndex = 2;
        	this.completedLabel.Text = "Completed:";
        	// 
        	// modifiedLabel
        	// 
        	this.modifiedLabel.AutoSize = true;
        	this.modifiedLabel.Location = new System.Drawing.Point(16, 64);
        	this.modifiedLabel.Name = "modifiedLabel";
        	this.modifiedLabel.Size = new System.Drawing.Size(50, 13);
        	this.modifiedLabel.TabIndex = 1;
        	this.modifiedLabel.Text = "Modified:";
        	// 
        	// createdLabel
        	// 
        	this.createdLabel.AutoSize = true;
        	this.createdLabel.Location = new System.Drawing.Point(16, 32);
        	this.createdLabel.Name = "createdLabel";
        	this.createdLabel.Size = new System.Drawing.Size(47, 13);
        	this.createdLabel.TabIndex = 0;
        	this.createdLabel.Text = "Created:";
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// ControlActionEdit
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.actionPages);
        	this.Name = "ControlActionEdit";
        	this.Size = new System.Drawing.Size(501, 428);
        	this.actionPages.ResumeLayout(false);
        	this.generalPage.ResumeLayout(false);
        	this.noteGroup.ResumeLayout(false);
        	this.planPage.ResumeLayout(false);
        	this.recurrenceGroup.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.anotherUpDown)).EndInit();
        	this.whenGroup.ResumeLayout(false);
        	this.whenGroup.PerformLayout();
        	this.reminderPage.ResumeLayout(false);
        	this.setupGroup.ResumeLayout(false);
        	this.setupGroup.PerformLayout();
        	this.aboutPage.ResumeLayout(false);
        	this.timingGroup.ResumeLayout(false);
        	this.timingGroup.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.Label usageLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox reminderDurationCombo;
        private Awareness.UI.ControlCommandSelector commandSelector;
        private Awareness.UI.ControlCommandSelector soundSelector;
        private System.Windows.Forms.CheckBox showReminderCheck;
        private System.Windows.Forms.Label beforeOccurrenceLabel;
        private System.Windows.Forms.CheckBox runCommandCheck;
        private System.Windows.Forms.CheckBox playSoundCheck;
        private System.Windows.Forms.GroupBox setupGroup;
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
        private System.Windows.Forms.ComboBox durationCombo;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.CheckBox planTimeCheck;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.Label endLabel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.GroupBox whenGroup;
        private System.Windows.Forms.TabPage reminderPage;
        private System.Windows.Forms.Label createdLabel;
        private System.Windows.Forms.Label modifiedLabel;
        private System.Windows.Forms.Label completedLabel;
        private System.Windows.Forms.TextBox completedBox;
        private System.Windows.Forms.TextBox modifiedBox;
        private System.Windows.Forms.TextBox createdBox;
        private System.Windows.Forms.GroupBox timingGroup;
        private Awareness.UI.ControlNoteTextView noteTextView;
        private System.Windows.Forms.GroupBox noteGroup;
        private System.Windows.Forms.TabPage aboutPage;
        private System.Windows.Forms.TabPage planPage;
        private System.Windows.Forms.TabPage generalPage;
        private System.Windows.Forms.TabControl actionPages;
    }
}
