/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 24/11/2008
 * Time: 09:55
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
    partial class FormTeaTimer
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
        	this.components = new System.ComponentModel.Container();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.label5 = new System.Windows.Forms.Label();
        	this.actionButton = new System.Windows.Forms.Button();
        	this.resetButton = new System.Windows.Forms.Button();
        	this.hoursBox = new System.Windows.Forms.NumericUpDown();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.minutesBox = new System.Windows.Forms.NumericUpDown();
        	this.label7 = new System.Windows.Forms.Label();
        	this.secondsBox = new System.Windows.Forms.NumericUpDown();
        	this.timer1 = new System.Windows.Forms.Timer(this.components);
        	((System.ComponentModel.ISupportInitialize)(this.hoursBox)).BeginInit();
        	this.groupBox1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.minutesBox)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.secondsBox)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// label2
        	// 
        	this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label2.Location = new System.Drawing.Point(16, 72);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(60, 16);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "hour(s)";
        	this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
        	// 
        	// label3
        	// 
        	this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label3.Location = new System.Drawing.Point(96, 72);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(60, 16);
        	this.label3.TabIndex = 3;
        	this.label3.Text = "minute(s)";
        	this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
        	// 
        	// label4
        	// 
        	this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label4.Location = new System.Drawing.Point(176, 72);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(60, 16);
        	this.label4.TabIndex = 4;
        	this.label4.Text = "second(s)";
        	this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
        	// 
        	// label5
        	// 
        	this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label5.Location = new System.Drawing.Point(72, 32);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(24, 42);
        	this.label5.TabIndex = 7;
        	this.label5.Text = ":";
        	this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        	// 
        	// actionButton
        	// 
        	this.actionButton.Location = new System.Drawing.Point(8, 112);
        	this.actionButton.Name = "actionButton";
        	this.actionButton.Size = new System.Drawing.Size(192, 40);
        	this.actionButton.TabIndex = 9;
        	this.actionButton.Text = "Action";
        	this.actionButton.UseVisualStyleBackColor = true;
        	this.actionButton.Click += new System.EventHandler(this.ActionButtonClick);
        	// 
        	// resetButton
        	// 
        	this.resetButton.Location = new System.Drawing.Point(208, 112);
        	this.resetButton.Name = "resetButton";
        	this.resetButton.Size = new System.Drawing.Size(48, 40);
        	this.resetButton.TabIndex = 10;
        	this.resetButton.Text = "Reset";
        	this.resetButton.UseVisualStyleBackColor = true;
        	this.resetButton.Click += new System.EventHandler(this.ResetButtonClick);
        	// 
        	// hoursBox
        	// 
        	this.hoursBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.hoursBox.Location = new System.Drawing.Point(16, 32);
        	this.hoursBox.Maximum = new decimal(new int[] {
        	        	        	99,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.hoursBox.Name = "hoursBox";
        	this.hoursBox.Size = new System.Drawing.Size(56, 38);
        	this.hoursBox.TabIndex = 11;
        	this.hoursBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.hoursBox.Value = new decimal(new int[] {
        	        	        	99,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.secondsBox);
        	this.groupBox1.Controls.Add(this.label7);
        	this.groupBox1.Controls.Add(this.minutesBox);
        	this.groupBox1.Controls.Add(this.hoursBox);
        	this.groupBox1.Controls.Add(this.label5);
        	this.groupBox1.Controls.Add(this.label2);
        	this.groupBox1.Controls.Add(this.label4);
        	this.groupBox1.Controls.Add(this.label3);
        	this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.groupBox1.Location = new System.Drawing.Point(8, 8);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(248, 96);
        	this.groupBox1.TabIndex = 12;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Notify me in:";
        	// 
        	// minutesBox
        	// 
        	this.minutesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.minutesBox.Location = new System.Drawing.Point(96, 32);
        	this.minutesBox.Maximum = new decimal(new int[] {
        	        	        	59,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.minutesBox.Name = "minutesBox";
        	this.minutesBox.Size = new System.Drawing.Size(56, 38);
        	this.minutesBox.TabIndex = 12;
        	this.minutesBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.minutesBox.Value = new decimal(new int[] {
        	        	        	59,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	// 
        	// label7
        	// 
        	this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label7.Location = new System.Drawing.Point(152, 32);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(24, 42);
        	this.label7.TabIndex = 13;
        	this.label7.Text = ":";
        	this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        	// 
        	// secondsBox
        	// 
        	this.secondsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.secondsBox.Location = new System.Drawing.Point(176, 32);
        	this.secondsBox.Maximum = new decimal(new int[] {
        	        	        	59,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	this.secondsBox.Name = "secondsBox";
        	this.secondsBox.Size = new System.Drawing.Size(56, 38);
        	this.secondsBox.TabIndex = 14;
        	this.secondsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.secondsBox.Value = new decimal(new int[] {
        	        	        	59,
        	        	        	0,
        	        	        	0,
        	        	        	0});
        	// 
        	// FormTeaTimer
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(265, 161);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.resetButton);
        	this.Controls.Add(this.actionButton);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        	this.Name = "FormTeaTimer";
        	this.ShowInTaskbar = false;
        	this.Text = "Tea Timer";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTeaTimerFormClosing);
        	((System.ComponentModel.ISupportInitialize)(this.hoursBox)).EndInit();
        	this.groupBox1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.minutesBox)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.secondsBox)).EndInit();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown hoursBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown secondsBox;
        private System.Windows.Forms.NumericUpDown minutesBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
