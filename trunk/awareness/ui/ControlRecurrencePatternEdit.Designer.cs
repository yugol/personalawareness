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
 * Date: 02/10/2008
 * Time: 11:48
 * 
 */
namespace Awareness.ui
{
    partial class ControlRecurrencePatternEdit
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
        	this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
        	this.stepPanel = new System.Windows.Forms.Panel();
        	this.yearlyRadio = new System.Windows.Forms.RadioButton();
        	this.monthlyRadio = new System.Windows.Forms.RadioButton();
        	this.weeklyRadio = new System.Windows.Forms.RadioButton();
        	this.dailyRadio = new System.Windows.Forms.RadioButton();
        	this.intradayRadio = new System.Windows.Forms.RadioButton();
        	this.separatorPanel = new System.Windows.Forms.Panel();
        	this.intradayPanel = new System.Windows.Forms.Panel();
        	this.intradayLabel = new System.Windows.Forms.Label();
        	this.intradayFrequencyCombo = new System.Windows.Forms.ComboBox();
        	this.dailyPanel = new System.Windows.Forms.Panel();
        	this.weekdaysFrequencyRadio = new System.Windows.Forms.RadioButton();
        	this.dailyFrequencyBox = new System.Windows.Forms.TextBox();
        	this.dailyFrequencyLabel = new System.Windows.Forms.Label();
        	this.dailyFrequencyRadio = new System.Windows.Forms.RadioButton();
        	this.weeklyPanel = new System.Windows.Forms.Panel();
        	this.sundayCheck = new System.Windows.Forms.CheckBox();
        	this.saturdayCheck = new System.Windows.Forms.CheckBox();
        	this.fridayCheck = new System.Windows.Forms.CheckBox();
        	this.thursdayCheck = new System.Windows.Forms.CheckBox();
        	this.wednesdayCheck = new System.Windows.Forms.CheckBox();
        	this.tuesdayCheck = new System.Windows.Forms.CheckBox();
        	this.mondayCheck = new System.Windows.Forms.CheckBox();
        	this.weelkyFrequencyRightLabel = new System.Windows.Forms.Label();
        	this.weelkyFrequencyLeftLabel = new System.Windows.Forms.Label();
        	this.weeklyFrequencyBox = new System.Windows.Forms.TextBox();
        	this.monthlyPanel = new System.Windows.Forms.Panel();
        	this.monthlyWhenCombo = new System.Windows.Forms.ComboBox();
        	this.monthlyFrequencyRightLabel = new System.Windows.Forms.Label();
        	this.monthlyFrequencyBox = new System.Windows.Forms.TextBox();
        	this.monthlyFrequencyMiddleLabel = new System.Windows.Forms.Label();
        	this.monthlyFrequencyLeftLabel = new System.Windows.Forms.Label();
        	this.yearlyPanel = new System.Windows.Forms.Panel();
        	this.yearlyWhenCombo = new System.Windows.Forms.ComboBox();
        	this.yearlyFrequencyCombo = new System.Windows.Forms.ComboBox();
        	this.yearlyFrequencyLabel = new System.Windows.Forms.Label();
        	this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        	this.flowPanel.SuspendLayout();
        	this.stepPanel.SuspendLayout();
        	this.intradayPanel.SuspendLayout();
        	this.dailyPanel.SuspendLayout();
        	this.weeklyPanel.SuspendLayout();
        	this.monthlyPanel.SuspendLayout();
        	this.yearlyPanel.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// flowPanel
        	// 
        	this.flowPanel.Controls.Add(this.stepPanel);
        	this.flowPanel.Controls.Add(this.separatorPanel);
        	this.flowPanel.Controls.Add(this.intradayPanel);
        	this.flowPanel.Controls.Add(this.dailyPanel);
        	this.flowPanel.Controls.Add(this.weeklyPanel);
        	this.flowPanel.Controls.Add(this.monthlyPanel);
        	this.flowPanel.Controls.Add(this.yearlyPanel);
        	this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.flowPanel.Location = new System.Drawing.Point(0, 0);
        	this.flowPanel.Name = "flowPanel";
        	this.flowPanel.Size = new System.Drawing.Size(730, 461);
        	this.flowPanel.TabIndex = 0;
        	// 
        	// stepPanel
        	// 
        	this.stepPanel.Controls.Add(this.yearlyRadio);
        	this.stepPanel.Controls.Add(this.monthlyRadio);
        	this.stepPanel.Controls.Add(this.weeklyRadio);
        	this.stepPanel.Controls.Add(this.dailyRadio);
        	this.stepPanel.Controls.Add(this.intradayRadio);
        	this.stepPanel.Location = new System.Drawing.Point(3, 3);
        	this.stepPanel.Name = "stepPanel";
        	this.stepPanel.Size = new System.Drawing.Size(85, 133);
        	this.stepPanel.TabIndex = 0;
        	// 
        	// yearlyRadio
        	// 
        	this.yearlyRadio.Location = new System.Drawing.Point(8, 104);
        	this.yearlyRadio.Name = "yearlyRadio";
        	this.yearlyRadio.Size = new System.Drawing.Size(72, 24);
        	this.yearlyRadio.TabIndex = 4;
        	this.yearlyRadio.Text = "&Yearly";
        	this.yearlyRadio.UseVisualStyleBackColor = true;
        	this.yearlyRadio.CheckedChanged += new System.EventHandler(this.YearlyRadioCheckedChanged);
        	// 
        	// monthlyRadio
        	// 
        	this.monthlyRadio.Location = new System.Drawing.Point(8, 80);
        	this.monthlyRadio.Name = "monthlyRadio";
        	this.monthlyRadio.Size = new System.Drawing.Size(72, 24);
        	this.monthlyRadio.TabIndex = 3;
        	this.monthlyRadio.Text = "&Monthly";
        	this.monthlyRadio.UseVisualStyleBackColor = true;
        	this.monthlyRadio.CheckedChanged += new System.EventHandler(this.MonthlyRadioCheckedChanged);
        	// 
        	// weeklyRadio
        	// 
        	this.weeklyRadio.Location = new System.Drawing.Point(8, 56);
        	this.weeklyRadio.Name = "weeklyRadio";
        	this.weeklyRadio.Size = new System.Drawing.Size(72, 24);
        	this.weeklyRadio.TabIndex = 2;
        	this.weeklyRadio.Text = "&Weekly";
        	this.weeklyRadio.UseVisualStyleBackColor = true;
        	this.weeklyRadio.CheckedChanged += new System.EventHandler(this.WeeklyRadioCheckedChanged);
        	// 
        	// dailyRadio
        	// 
        	this.dailyRadio.Location = new System.Drawing.Point(8, 32);
        	this.dailyRadio.Name = "dailyRadio";
        	this.dailyRadio.Size = new System.Drawing.Size(72, 24);
        	this.dailyRadio.TabIndex = 1;
        	this.dailyRadio.Text = "&Daily";
        	this.dailyRadio.UseVisualStyleBackColor = true;
        	this.dailyRadio.CheckedChanged += new System.EventHandler(this.DailyRadioCheckedChanged);
        	// 
        	// intradayRadio
        	// 
        	this.intradayRadio.Location = new System.Drawing.Point(8, 8);
        	this.intradayRadio.Name = "intradayRadio";
        	this.intradayRadio.Size = new System.Drawing.Size(72, 24);
        	this.intradayRadio.TabIndex = 0;
        	this.intradayRadio.Text = "&Intraday";
        	this.intradayRadio.UseVisualStyleBackColor = true;
        	this.intradayRadio.CheckedChanged += new System.EventHandler(this.IntradayRadioCheckedChanged);
        	// 
        	// separatorPanel
        	// 
        	this.separatorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.separatorPanel.Location = new System.Drawing.Point(91, 13);
        	this.separatorPanel.Margin = new System.Windows.Forms.Padding(0, 13, 0, 0);
        	this.separatorPanel.Name = "separatorPanel";
        	this.separatorPanel.Size = new System.Drawing.Size(4, 115);
        	this.separatorPanel.TabIndex = 1;
        	// 
        	// intradayPanel
        	// 
        	this.intradayPanel.Controls.Add(this.intradayLabel);
        	this.intradayPanel.Controls.Add(this.intradayFrequencyCombo);
        	this.intradayPanel.Location = new System.Drawing.Point(98, 3);
        	this.intradayPanel.Name = "intradayPanel";
        	this.intradayPanel.Size = new System.Drawing.Size(350, 133);
        	this.intradayPanel.TabIndex = 2;
        	// 
        	// intradayLabel
        	// 
        	this.intradayLabel.Location = new System.Drawing.Point(16, 24);
        	this.intradayLabel.Name = "intradayLabel";
        	this.intradayLabel.Size = new System.Drawing.Size(88, 23);
        	this.intradayLabel.TabIndex = 7;
        	this.intradayLabel.Text = "Repeat every";
        	this.intradayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// intradayFrequencyCombo
        	// 
        	this.intradayFrequencyCombo.DropDownHeight = 150;
        	this.intradayFrequencyCombo.FormattingEnabled = true;
        	this.intradayFrequencyCombo.IntegralHeight = false;
        	this.intradayFrequencyCombo.Items.AddRange(new object[] {
        	        	        	"10 min",
        	        	        	"15 min",
        	        	        	"20 min",
        	        	        	"30 min",
        	        	        	"1 hour 0 min",
        	        	        	"1 hour 30 min",
        	        	        	"2 hours 0 min",
        	        	        	"4 hours 0 min",
        	        	        	"6 hours 0 min"});
        	this.intradayFrequencyCombo.Location = new System.Drawing.Point(104, 24);
        	this.intradayFrequencyCombo.Name = "intradayFrequencyCombo";
        	this.intradayFrequencyCombo.Size = new System.Drawing.Size(121, 21);
        	this.intradayFrequencyCombo.TabIndex = 1;
        	this.intradayFrequencyCombo.Validating += new System.ComponentModel.CancelEventHandler(this.IntradayFrequencyComboValidating);
        	this.intradayFrequencyCombo.Validated += new System.EventHandler(this.IntradayFrequencyComboValidated);
        	// 
        	// dailyPanel
        	// 
        	this.dailyPanel.Controls.Add(this.weekdaysFrequencyRadio);
        	this.dailyPanel.Controls.Add(this.dailyFrequencyBox);
        	this.dailyPanel.Controls.Add(this.dailyFrequencyLabel);
        	this.dailyPanel.Controls.Add(this.dailyFrequencyRadio);
        	this.dailyPanel.Location = new System.Drawing.Point(3, 142);
        	this.dailyPanel.Name = "dailyPanel";
        	this.dailyPanel.Size = new System.Drawing.Size(350, 133);
        	this.dailyPanel.TabIndex = 3;
        	// 
        	// weekdaysFrequencyRadio
        	// 
        	this.weekdaysFrequencyRadio.Location = new System.Drawing.Point(16, 64);
        	this.weekdaysFrequencyRadio.Name = "weekdaysFrequencyRadio";
        	this.weekdaysFrequencyRadio.Size = new System.Drawing.Size(200, 24);
        	this.weekdaysFrequencyRadio.TabIndex = 3;
        	this.weekdaysFrequencyRadio.Text = "Repeat every weekday";
        	this.weekdaysFrequencyRadio.UseVisualStyleBackColor = true;
        	this.weekdaysFrequencyRadio.CheckedChanged += new System.EventHandler(this.WeekdaysFrequencyRadioCheckedChanged);
        	// 
        	// dailyFrequencyBox
        	// 
        	this.dailyFrequencyBox.Location = new System.Drawing.Point(120, 24);
        	this.dailyFrequencyBox.MaxLength = 4;
        	this.dailyFrequencyBox.Name = "dailyFrequencyBox";
        	this.dailyFrequencyBox.Size = new System.Drawing.Size(32, 20);
        	this.dailyFrequencyBox.TabIndex = 2;
        	this.dailyFrequencyBox.Text = "1";
        	this.dailyFrequencyBox.Validated += new System.EventHandler(this.DailyFrequencyBoxValidated);
        	this.dailyFrequencyBox.Validating += new System.ComponentModel.CancelEventHandler(this.DailyFrequencyBoxValidating);
        	// 
        	// dailyFrequencyLabel
        	// 
        	this.dailyFrequencyLabel.Location = new System.Drawing.Point(168, 24);
        	this.dailyFrequencyLabel.Name = "dailyFrequencyLabel";
        	this.dailyFrequencyLabel.Size = new System.Drawing.Size(48, 24);
        	this.dailyFrequencyLabel.TabIndex = 1;
        	this.dailyFrequencyLabel.Text = "day(s)";
        	this.dailyFrequencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// dailyFrequencyRadio
        	// 
        	this.dailyFrequencyRadio.Location = new System.Drawing.Point(16, 24);
        	this.dailyFrequencyRadio.Name = "dailyFrequencyRadio";
        	this.dailyFrequencyRadio.Size = new System.Drawing.Size(96, 24);
        	this.dailyFrequencyRadio.TabIndex = 0;
        	this.dailyFrequencyRadio.Text = "Repeat every";
        	this.dailyFrequencyRadio.UseVisualStyleBackColor = true;
        	this.dailyFrequencyRadio.CheckedChanged += new System.EventHandler(this.DailyFrequencyRadioCheckedChanged);
        	// 
        	// weeklyPanel
        	// 
        	this.weeklyPanel.Controls.Add(this.sundayCheck);
        	this.weeklyPanel.Controls.Add(this.saturdayCheck);
        	this.weeklyPanel.Controls.Add(this.fridayCheck);
        	this.weeklyPanel.Controls.Add(this.thursdayCheck);
        	this.weeklyPanel.Controls.Add(this.wednesdayCheck);
        	this.weeklyPanel.Controls.Add(this.tuesdayCheck);
        	this.weeklyPanel.Controls.Add(this.mondayCheck);
        	this.weeklyPanel.Controls.Add(this.weelkyFrequencyRightLabel);
        	this.weeklyPanel.Controls.Add(this.weelkyFrequencyLeftLabel);
        	this.weeklyPanel.Controls.Add(this.weeklyFrequencyBox);
        	this.weeklyPanel.Location = new System.Drawing.Point(359, 142);
        	this.weeklyPanel.Name = "weeklyPanel";
        	this.weeklyPanel.Size = new System.Drawing.Size(350, 133);
        	this.weeklyPanel.TabIndex = 4;
        	// 
        	// sundayCheck
        	// 
        	this.sundayCheck.Location = new System.Drawing.Point(256, 80);
        	this.sundayCheck.Name = "sundayCheck";
        	this.sundayCheck.Size = new System.Drawing.Size(72, 24);
        	this.sundayCheck.TabIndex = 14;
        	this.sundayCheck.Text = "S&unday";
        	this.sundayCheck.UseVisualStyleBackColor = true;
        	this.sundayCheck.CheckedChanged += new System.EventHandler(this.SundayCheckCheckedChanged);
        	// 
        	// saturdayCheck
        	// 
        	this.saturdayCheck.Location = new System.Drawing.Point(256, 56);
        	this.saturdayCheck.Name = "saturdayCheck";
        	this.saturdayCheck.Size = new System.Drawing.Size(72, 24);
        	this.saturdayCheck.TabIndex = 13;
        	this.saturdayCheck.Text = "&Saturday";
        	this.saturdayCheck.UseVisualStyleBackColor = true;
        	this.saturdayCheck.CheckedChanged += new System.EventHandler(this.SaturdayCheckCheckedChanged);
        	// 
        	// fridayCheck
        	// 
        	this.fridayCheck.Location = new System.Drawing.Point(96, 80);
        	this.fridayCheck.Name = "fridayCheck";
        	this.fridayCheck.Size = new System.Drawing.Size(72, 24);
        	this.fridayCheck.TabIndex = 12;
        	this.fridayCheck.Text = "&Friday";
        	this.fridayCheck.UseVisualStyleBackColor = true;
        	this.fridayCheck.CheckedChanged += new System.EventHandler(this.FridayCheckCheckedChanged);
        	// 
        	// thursdayCheck
        	// 
        	this.thursdayCheck.Location = new System.Drawing.Point(24, 80);
        	this.thursdayCheck.Name = "thursdayCheck";
        	this.thursdayCheck.Size = new System.Drawing.Size(72, 24);
        	this.thursdayCheck.TabIndex = 11;
        	this.thursdayCheck.Text = "T&hursday";
        	this.thursdayCheck.UseVisualStyleBackColor = true;
        	this.thursdayCheck.CheckedChanged += new System.EventHandler(this.ThursdayCheckCheckedChanged);
        	// 
        	// wednesdayCheck
        	// 
        	this.wednesdayCheck.Location = new System.Drawing.Point(168, 56);
        	this.wednesdayCheck.Name = "wednesdayCheck";
        	this.wednesdayCheck.Size = new System.Drawing.Size(88, 24);
        	this.wednesdayCheck.TabIndex = 10;
        	this.wednesdayCheck.Text = "Wed&nesday";
        	this.wednesdayCheck.UseVisualStyleBackColor = true;
        	this.wednesdayCheck.CheckedChanged += new System.EventHandler(this.WednesdayCheckCheckedChanged);
        	// 
        	// tuesdayCheck
        	// 
        	this.tuesdayCheck.Location = new System.Drawing.Point(96, 56);
        	this.tuesdayCheck.Name = "tuesdayCheck";
        	this.tuesdayCheck.Size = new System.Drawing.Size(72, 24);
        	this.tuesdayCheck.TabIndex = 9;
        	this.tuesdayCheck.Text = "&Tuesday";
        	this.tuesdayCheck.UseVisualStyleBackColor = true;
        	this.tuesdayCheck.CheckedChanged += new System.EventHandler(this.TuesdayCheckCheckedChanged);
        	// 
        	// mondayCheck
        	// 
        	this.mondayCheck.Location = new System.Drawing.Point(24, 56);
        	this.mondayCheck.Name = "mondayCheck";
        	this.mondayCheck.Size = new System.Drawing.Size(72, 24);
        	this.mondayCheck.TabIndex = 8;
        	this.mondayCheck.Text = "M&onday";
        	this.mondayCheck.UseVisualStyleBackColor = true;
        	this.mondayCheck.CheckedChanged += new System.EventHandler(this.MondayCheckCheckedChanged);
        	// 
        	// weelkyFrequencyRightLabel
        	// 
        	this.weelkyFrequencyRightLabel.Location = new System.Drawing.Point(152, 24);
        	this.weelkyFrequencyRightLabel.Name = "weelkyFrequencyRightLabel";
        	this.weelkyFrequencyRightLabel.Size = new System.Drawing.Size(72, 23);
        	this.weelkyFrequencyRightLabel.TabIndex = 7;
        	this.weelkyFrequencyRightLabel.Text = "week(s) on:";
        	this.weelkyFrequencyRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// weelkyFrequencyLeftLabel
        	// 
        	this.weelkyFrequencyLeftLabel.Location = new System.Drawing.Point(16, 24);
        	this.weelkyFrequencyLeftLabel.Name = "weelkyFrequencyLeftLabel";
        	this.weelkyFrequencyLeftLabel.Size = new System.Drawing.Size(88, 23);
        	this.weelkyFrequencyLeftLabel.TabIndex = 6;
        	this.weelkyFrequencyLeftLabel.Text = "Repeat every";
        	this.weelkyFrequencyLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// weeklyFrequencyBox
        	// 
        	this.weeklyFrequencyBox.Location = new System.Drawing.Point(104, 24);
        	this.weeklyFrequencyBox.MaxLength = 3;
        	this.weeklyFrequencyBox.Name = "weeklyFrequencyBox";
        	this.weeklyFrequencyBox.Size = new System.Drawing.Size(32, 20);
        	this.weeklyFrequencyBox.TabIndex = 5;
        	this.weeklyFrequencyBox.Text = "1";
        	this.weeklyFrequencyBox.Validated += new System.EventHandler(this.WeeklyFrequencyBoxValidated);
        	this.weeklyFrequencyBox.Validating += new System.ComponentModel.CancelEventHandler(this.WeeklyFrequencyBoxValidating);
        	// 
        	// monthlyPanel
        	// 
        	this.monthlyPanel.Controls.Add(this.monthlyWhenCombo);
        	this.monthlyPanel.Controls.Add(this.monthlyFrequencyRightLabel);
        	this.monthlyPanel.Controls.Add(this.monthlyFrequencyBox);
        	this.monthlyPanel.Controls.Add(this.monthlyFrequencyMiddleLabel);
        	this.monthlyPanel.Controls.Add(this.monthlyFrequencyLeftLabel);
        	this.monthlyPanel.Location = new System.Drawing.Point(3, 281);
        	this.monthlyPanel.Name = "monthlyPanel";
        	this.monthlyPanel.Size = new System.Drawing.Size(350, 133);
        	this.monthlyPanel.TabIndex = 5;
        	// 
        	// monthlyWhenCombo
        	// 
        	this.monthlyWhenCombo.DropDownHeight = 198;
        	this.monthlyWhenCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.monthlyWhenCombo.FormattingEnabled = true;
        	this.monthlyWhenCombo.IntegralHeight = false;
        	this.monthlyWhenCombo.Items.AddRange(new object[] {
        	        	        	"1 st",
        	        	        	"2 nd",
        	        	        	"3 rd",
        	        	        	"4 th",
        	        	        	"5 th",
        	        	        	"6 th",
        	        	        	"7 th",
        	        	        	"8 th",
        	        	        	"9 th",
        	        	        	"10 th",
        	        	        	"11 th",
        	        	        	"12 th",
        	        	        	"13 th",
        	        	        	"14 th",
        	        	        	"15 th",
        	        	        	"16 th",
        	        	        	"17 th",
        	        	        	"18 th",
        	        	        	"19 th",
        	        	        	"20 th",
        	        	        	"21 th",
        	        	        	"22 th",
        	        	        	"23 th",
        	        	        	"24 th",
        	        	        	"25 th",
        	        	        	"26 th",
        	        	        	"27 th",
        	        	        	"28 th",
        	        	        	"29 th",
        	        	        	"30 th",
        	        	        	"31 th"});
        	this.monthlyWhenCombo.Location = new System.Drawing.Point(104, 24);
        	this.monthlyWhenCombo.Name = "monthlyWhenCombo";
        	this.monthlyWhenCombo.Size = new System.Drawing.Size(56, 21);
        	this.monthlyWhenCombo.TabIndex = 12;
        	this.monthlyWhenCombo.SelectedIndexChanged += new System.EventHandler(this.MonthlyWhenComboSelectedIndexChanged);
        	// 
        	// monthlyFrequencyRightLabel
        	// 
        	this.monthlyFrequencyRightLabel.Location = new System.Drawing.Point(272, 24);
        	this.monthlyFrequencyRightLabel.Name = "monthlyFrequencyRightLabel";
        	this.monthlyFrequencyRightLabel.Size = new System.Drawing.Size(48, 23);
        	this.monthlyFrequencyRightLabel.TabIndex = 11;
        	this.monthlyFrequencyRightLabel.Text = "month(s)";
        	this.monthlyFrequencyRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// monthlyFrequencyBox
        	// 
        	this.monthlyFrequencyBox.Location = new System.Drawing.Point(224, 24);
        	this.monthlyFrequencyBox.MaxLength = 2;
        	this.monthlyFrequencyBox.Name = "monthlyFrequencyBox";
        	this.monthlyFrequencyBox.Size = new System.Drawing.Size(32, 20);
        	this.monthlyFrequencyBox.TabIndex = 10;
        	this.monthlyFrequencyBox.Text = "1";
        	this.monthlyFrequencyBox.Validated += new System.EventHandler(this.MonthlyFrequencyBoxValidated);
        	this.monthlyFrequencyBox.Validating += new System.ComponentModel.CancelEventHandler(this.MonthlyFrequencyBoxValidating);
        	// 
        	// monthlyFrequencyMiddleLabel
        	// 
        	this.monthlyFrequencyMiddleLabel.Location = new System.Drawing.Point(168, 24);
        	this.monthlyFrequencyMiddleLabel.Name = "monthlyFrequencyMiddleLabel";
        	this.monthlyFrequencyMiddleLabel.Size = new System.Drawing.Size(48, 23);
        	this.monthlyFrequencyMiddleLabel.TabIndex = 9;
        	this.monthlyFrequencyMiddleLabel.Text = "of every";
        	this.monthlyFrequencyMiddleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// monthlyFrequencyLeftLabel
        	// 
        	this.monthlyFrequencyLeftLabel.Location = new System.Drawing.Point(16, 24);
        	this.monthlyFrequencyLeftLabel.Name = "monthlyFrequencyLeftLabel";
        	this.monthlyFrequencyLeftLabel.Size = new System.Drawing.Size(88, 23);
        	this.monthlyFrequencyLeftLabel.TabIndex = 7;
        	this.monthlyFrequencyLeftLabel.Text = "Repeat on the";
        	this.monthlyFrequencyLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// yearlyPanel
        	// 
        	this.yearlyPanel.Controls.Add(this.yearlyWhenCombo);
        	this.yearlyPanel.Controls.Add(this.yearlyFrequencyCombo);
        	this.yearlyPanel.Controls.Add(this.yearlyFrequencyLabel);
        	this.yearlyPanel.Location = new System.Drawing.Point(359, 281);
        	this.yearlyPanel.Name = "yearlyPanel";
        	this.yearlyPanel.Size = new System.Drawing.Size(350, 133);
        	this.yearlyPanel.TabIndex = 6;
        	// 
        	// yearlyWhenCombo
        	// 
        	this.yearlyWhenCombo.DropDownHeight = 198;
        	this.yearlyWhenCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.yearlyWhenCombo.FormattingEnabled = true;
        	this.yearlyWhenCombo.IntegralHeight = false;
        	this.yearlyWhenCombo.Items.AddRange(new object[] {
        	        	        	"1 st",
        	        	        	"2 nd",
        	        	        	"3 rd",
        	        	        	"4 th",
        	        	        	"5 th",
        	        	        	"6 th",
        	        	        	"7 th",
        	        	        	"8 th",
        	        	        	"9 th",
        	        	        	"10 th",
        	        	        	"11 th",
        	        	        	"12 th",
        	        	        	"13 th",
        	        	        	"14 th",
        	        	        	"15 th",
        	        	        	"16 th",
        	        	        	"17 th",
        	        	        	"18 th",
        	        	        	"19 th",
        	        	        	"20 th",
        	        	        	"21 th",
        	        	        	"22 th",
        	        	        	"23 th",
        	        	        	"24 th",
        	        	        	"25 th",
        	        	        	"26 th",
        	        	        	"27 th",
        	        	        	"28 th",
        	        	        	"29 th",
        	        	        	"30 th",
        	        	        	"31 th"});
        	this.yearlyWhenCombo.Location = new System.Drawing.Point(224, 24);
        	this.yearlyWhenCombo.Name = "yearlyWhenCombo";
        	this.yearlyWhenCombo.Size = new System.Drawing.Size(56, 21);
        	this.yearlyWhenCombo.TabIndex = 13;
        	this.yearlyWhenCombo.SelectedIndexChanged += new System.EventHandler(this.YearlyWhenComboSelectedIndexChanged);
        	// 
        	// yearlyFrequencyCombo
        	// 
        	this.yearlyFrequencyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.yearlyFrequencyCombo.FormattingEnabled = true;
        	this.yearlyFrequencyCombo.Items.AddRange(new object[] {
        	        	        	"January",
        	        	        	"February",
        	        	        	"March",
        	        	        	"April",
        	        	        	"May",
        	        	        	"June",
        	        	        	"July",
        	        	        	"August",
        	        	        	"September",
        	        	        	"October",
        	        	        	"November",
        	        	        	"December"});
        	this.yearlyFrequencyCombo.Location = new System.Drawing.Point(96, 24);
        	this.yearlyFrequencyCombo.Name = "yearlyFrequencyCombo";
        	this.yearlyFrequencyCombo.Size = new System.Drawing.Size(121, 21);
        	this.yearlyFrequencyCombo.TabIndex = 9;
        	this.yearlyFrequencyCombo.SelectedIndexChanged += new System.EventHandler(this.YearlyFrequencyComboSelectedIndexChanged);
        	// 
        	// yearlyFrequencyLabel
        	// 
        	this.yearlyFrequencyLabel.Location = new System.Drawing.Point(16, 24);
        	this.yearlyFrequencyLabel.Name = "yearlyFrequencyLabel";
        	this.yearlyFrequencyLabel.Size = new System.Drawing.Size(80, 23);
        	this.yearlyFrequencyLabel.TabIndex = 8;
        	this.yearlyFrequencyLabel.Text = "Repeat every";
        	this.yearlyFrequencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// ControlRecurrencePatternEdit
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.flowPanel);
        	this.MinimumSize = new System.Drawing.Size(452, 130);
        	this.Name = "ControlRecurrencePatternEdit";
        	this.Size = new System.Drawing.Size(730, 461);
        	this.flowPanel.ResumeLayout(false);
        	this.stepPanel.ResumeLayout(false);
        	this.intradayPanel.ResumeLayout(false);
        	this.dailyPanel.ResumeLayout(false);
        	this.dailyPanel.PerformLayout();
        	this.weeklyPanel.ResumeLayout(false);
        	this.weeklyPanel.PerformLayout();
        	this.monthlyPanel.ResumeLayout(false);
        	this.monthlyPanel.PerformLayout();
        	this.yearlyPanel.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ComboBox yearlyWhenCombo;
        private System.Windows.Forms.ComboBox monthlyWhenCombo;
        private System.Windows.Forms.TextBox weeklyFrequencyBox;
        private System.Windows.Forms.ComboBox intradayFrequencyCombo;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox monthlyFrequencyBox;
        private System.Windows.Forms.Label yearlyFrequencyLabel;
        private System.Windows.Forms.ComboBox yearlyFrequencyCombo;
        private System.Windows.Forms.Label monthlyFrequencyMiddleLabel;
        private System.Windows.Forms.Label monthlyFrequencyRightLabel;
        private System.Windows.Forms.Label monthlyFrequencyLeftLabel;
        private System.Windows.Forms.Label weelkyFrequencyLeftLabel;
        private System.Windows.Forms.Label weelkyFrequencyRightLabel;
        private System.Windows.Forms.CheckBox mondayCheck;
        private System.Windows.Forms.CheckBox tuesdayCheck;
        private System.Windows.Forms.CheckBox wednesdayCheck;
        private System.Windows.Forms.CheckBox thursdayCheck;
        private System.Windows.Forms.CheckBox fridayCheck;
        private System.Windows.Forms.CheckBox saturdayCheck;
        private System.Windows.Forms.CheckBox sundayCheck;
        private System.Windows.Forms.RadioButton dailyFrequencyRadio;
        private System.Windows.Forms.Label dailyFrequencyLabel;
        private System.Windows.Forms.TextBox dailyFrequencyBox;
        private System.Windows.Forms.RadioButton weekdaysFrequencyRadio;
        private System.Windows.Forms.Panel yearlyPanel;
        private System.Windows.Forms.Panel monthlyPanel;
        private System.Windows.Forms.Panel weeklyPanel;
        private System.Windows.Forms.Panel dailyPanel;
        private System.Windows.Forms.Label intradayLabel;
        private System.Windows.Forms.Panel intradayPanel;
        private System.Windows.Forms.Panel separatorPanel;
        private System.Windows.Forms.RadioButton intradayRadio;
        private System.Windows.Forms.RadioButton dailyRadio;
        private System.Windows.Forms.RadioButton weeklyRadio;
        private System.Windows.Forms.RadioButton monthlyRadio;
        private System.Windows.Forms.RadioButton yearlyRadio;
        private System.Windows.Forms.Panel stepPanel;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
    }
}
