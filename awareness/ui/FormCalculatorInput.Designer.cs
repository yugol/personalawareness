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
 * Date: 26/10/2008
 * Time: 20:19
 * 
 */
namespace Awareness.UI
{
    partial class FormCalculatorInput
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
        	this.outputLabel = new System.Windows.Forms.Label();
        	this.buttonDivide = new System.Windows.Forms.Button();
        	this.buttonMultiply = new System.Windows.Forms.Button();
        	this.buttonMinus = new System.Windows.Forms.Button();
        	this.buttonPlus = new System.Windows.Forms.Button();
        	this.buttonEquals = new System.Windows.Forms.Button();
        	this.buttonClearEverything = new System.Windows.Forms.Button();
        	this.buttonCancel = new System.Windows.Forms.Button();
        	this.buttonOk = new System.Windows.Forms.Button();
        	this.buttonDot = new System.Windows.Forms.Button();
        	this.buttonSign = new System.Windows.Forms.Button();
        	this.button0 = new System.Windows.Forms.Button();
        	this.button9 = new System.Windows.Forms.Button();
        	this.button8 = new System.Windows.Forms.Button();
        	this.button7 = new System.Windows.Forms.Button();
        	this.button6 = new System.Windows.Forms.Button();
        	this.button5 = new System.Windows.Forms.Button();
        	this.button4 = new System.Windows.Forms.Button();
        	this.button3 = new System.Windows.Forms.Button();
        	this.button2 = new System.Windows.Forms.Button();
        	this.button1 = new System.Windows.Forms.Button();
        	this.calculatorPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.calculatorPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// outputLabel
        	// 
        	this.outputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.calculatorPanel.SetColumnSpan(this.outputLabel, 5);
        	this.outputLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.outputLabel.Location = new System.Drawing.Point(8, 9);
        	this.outputLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        	this.outputLabel.Name = "outputLabel";
        	this.outputLabel.Size = new System.Drawing.Size(196, 23);
        	this.outputLabel.TabIndex = 42;
        	this.outputLabel.Text = "12345678901234567890";
        	this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// buttonDivide
        	// 
        	this.buttonDivide.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.buttonDivide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.buttonDivide.ForeColor = System.Drawing.Color.Red;
        	this.buttonDivide.Location = new System.Drawing.Point(116, 132);
        	this.buttonDivide.Name = "buttonDivide";
        	this.buttonDivide.Size = new System.Drawing.Size(30, 25);
        	this.buttonDivide.TabIndex = 41;
        	this.buttonDivide.Text = "/";
        	this.buttonDivide.UseVisualStyleBackColor = true;
        	this.buttonDivide.Click += new System.EventHandler(this.ButtonDivideClick);
        	// 
        	// buttonMultiply
        	// 
        	this.buttonMultiply.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.buttonMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.buttonMultiply.ForeColor = System.Drawing.Color.Red;
        	this.buttonMultiply.Location = new System.Drawing.Point(116, 101);
        	this.buttonMultiply.Name = "buttonMultiply";
        	this.buttonMultiply.Size = new System.Drawing.Size(30, 25);
        	this.buttonMultiply.TabIndex = 40;
        	this.buttonMultiply.Text = "*";
        	this.buttonMultiply.UseVisualStyleBackColor = true;
        	this.buttonMultiply.Click += new System.EventHandler(this.ButtonMultiplyClick);
        	// 
        	// buttonMinus
        	// 
        	this.buttonMinus.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.buttonMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.buttonMinus.ForeColor = System.Drawing.Color.Red;
        	this.buttonMinus.Location = new System.Drawing.Point(116, 70);
        	this.buttonMinus.Name = "buttonMinus";
        	this.buttonMinus.Size = new System.Drawing.Size(30, 25);
        	this.buttonMinus.TabIndex = 39;
        	this.buttonMinus.Text = "-";
        	this.buttonMinus.UseVisualStyleBackColor = true;
        	this.buttonMinus.Click += new System.EventHandler(this.ButtonMinusClick);
        	// 
        	// buttonPlus
        	// 
        	this.buttonPlus.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.buttonPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.buttonPlus.ForeColor = System.Drawing.Color.Red;
        	this.buttonPlus.Location = new System.Drawing.Point(116, 39);
        	this.buttonPlus.Name = "buttonPlus";
        	this.buttonPlus.Size = new System.Drawing.Size(30, 25);
        	this.buttonPlus.TabIndex = 38;
        	this.buttonPlus.Text = "+";
        	this.buttonPlus.UseVisualStyleBackColor = true;
        	this.buttonPlus.Click += new System.EventHandler(this.ButtonPlusClick);
        	// 
        	// buttonEquals
        	// 
        	this.buttonEquals.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.buttonEquals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.buttonEquals.Location = new System.Drawing.Point(152, 132);
        	this.buttonEquals.Name = "buttonEquals";
        	this.buttonEquals.Size = new System.Drawing.Size(52, 25);
        	this.buttonEquals.TabIndex = 37;
        	this.buttonEquals.Text = "=";
        	this.buttonEquals.UseVisualStyleBackColor = true;
        	this.buttonEquals.Click += new System.EventHandler(this.ButtonEqualsClick);
        	// 
        	// buttonClearEverything
        	// 
        	this.buttonClearEverything.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.buttonClearEverything.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.buttonClearEverything.Location = new System.Drawing.Point(152, 101);
        	this.buttonClearEverything.Name = "buttonClearEverything";
        	this.buttonClearEverything.Size = new System.Drawing.Size(52, 25);
        	this.buttonClearEverything.TabIndex = 36;
        	this.buttonClearEverything.Text = "CE";
        	this.buttonClearEverything.UseVisualStyleBackColor = true;
        	this.buttonClearEverything.Click += new System.EventHandler(this.ButtonClearEverythingClick);
        	// 
        	// buttonCancel
        	// 
        	this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.buttonCancel.Location = new System.Drawing.Point(152, 70);
        	this.buttonCancel.Name = "buttonCancel";
        	this.buttonCancel.Size = new System.Drawing.Size(52, 25);
        	this.buttonCancel.TabIndex = 35;
        	this.buttonCancel.Text = "Cancel";
        	this.buttonCancel.UseVisualStyleBackColor = true;
        	// 
        	// buttonOk
        	// 
        	this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.buttonOk.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.buttonOk.Location = new System.Drawing.Point(152, 39);
        	this.buttonOk.Name = "buttonOk";
        	this.buttonOk.Size = new System.Drawing.Size(52, 25);
        	this.buttonOk.TabIndex = 34;
        	this.buttonOk.Text = "OK";
        	this.buttonOk.UseVisualStyleBackColor = true;
        	// 
        	// buttonDot
        	// 
        	this.buttonDot.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.buttonDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.buttonDot.ForeColor = System.Drawing.Color.Blue;
        	this.buttonDot.Location = new System.Drawing.Point(80, 132);
        	this.buttonDot.Name = "buttonDot";
        	this.buttonDot.Size = new System.Drawing.Size(30, 25);
        	this.buttonDot.TabIndex = 33;
        	this.buttonDot.Text = ".";
        	this.buttonDot.UseVisualStyleBackColor = true;
        	this.buttonDot.Click += new System.EventHandler(this.ButtonDotClick);
        	// 
        	// buttonSign
        	// 
        	this.buttonSign.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.buttonSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.buttonSign.ForeColor = System.Drawing.Color.Blue;
        	this.buttonSign.Location = new System.Drawing.Point(44, 132);
        	this.buttonSign.Name = "buttonSign";
        	this.buttonSign.Size = new System.Drawing.Size(30, 25);
        	this.buttonSign.TabIndex = 32;
        	this.buttonSign.Text = "-|+";
        	this.buttonSign.UseVisualStyleBackColor = true;
        	this.buttonSign.Click += new System.EventHandler(this.ButtonSignClick);
        	// 
        	// button0
        	// 
        	this.button0.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button0.ForeColor = System.Drawing.Color.Blue;
        	this.button0.Location = new System.Drawing.Point(8, 132);
        	this.button0.Name = "button0";
        	this.button0.Size = new System.Drawing.Size(30, 25);
        	this.button0.TabIndex = 31;
        	this.button0.Text = "0";
        	this.button0.UseVisualStyleBackColor = true;
        	this.button0.Click += new System.EventHandler(this.Button0Click);
        	// 
        	// button9
        	// 
        	this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button9.ForeColor = System.Drawing.Color.Blue;
        	this.button9.Location = new System.Drawing.Point(80, 101);
        	this.button9.Name = "button9";
        	this.button9.Size = new System.Drawing.Size(30, 25);
        	this.button9.TabIndex = 30;
        	this.button9.Text = "9";
        	this.button9.UseVisualStyleBackColor = true;
        	this.button9.Click += new System.EventHandler(this.Button9Click);
        	// 
        	// button8
        	// 
        	this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button8.ForeColor = System.Drawing.Color.Blue;
        	this.button8.Location = new System.Drawing.Point(44, 101);
        	this.button8.Name = "button8";
        	this.button8.Size = new System.Drawing.Size(30, 25);
        	this.button8.TabIndex = 29;
        	this.button8.Text = "8";
        	this.button8.UseVisualStyleBackColor = true;
        	this.button8.Click += new System.EventHandler(this.Button8Click);
        	// 
        	// button7
        	// 
        	this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button7.ForeColor = System.Drawing.Color.Blue;
        	this.button7.Location = new System.Drawing.Point(8, 101);
        	this.button7.Name = "button7";
        	this.button7.Size = new System.Drawing.Size(30, 25);
        	this.button7.TabIndex = 28;
        	this.button7.Text = "7";
        	this.button7.UseVisualStyleBackColor = true;
        	this.button7.Click += new System.EventHandler(this.Button7Click);
        	// 
        	// button6
        	// 
        	this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button6.ForeColor = System.Drawing.Color.Blue;
        	this.button6.Location = new System.Drawing.Point(80, 70);
        	this.button6.Name = "button6";
        	this.button6.Size = new System.Drawing.Size(30, 25);
        	this.button6.TabIndex = 27;
        	this.button6.Text = "6";
        	this.button6.UseVisualStyleBackColor = true;
        	this.button6.Click += new System.EventHandler(this.Button6Click);
        	// 
        	// button5
        	// 
        	this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button5.ForeColor = System.Drawing.Color.Blue;
        	this.button5.Location = new System.Drawing.Point(44, 70);
        	this.button5.Name = "button5";
        	this.button5.Size = new System.Drawing.Size(30, 25);
        	this.button5.TabIndex = 26;
        	this.button5.Text = "5";
        	this.button5.UseVisualStyleBackColor = true;
        	this.button5.Click += new System.EventHandler(this.Button5Click);
        	// 
        	// button4
        	// 
        	this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button4.ForeColor = System.Drawing.Color.Blue;
        	this.button4.Location = new System.Drawing.Point(8, 70);
        	this.button4.Name = "button4";
        	this.button4.Size = new System.Drawing.Size(30, 25);
        	this.button4.TabIndex = 25;
        	this.button4.Text = "4";
        	this.button4.UseVisualStyleBackColor = true;
        	this.button4.Click += new System.EventHandler(this.Button4Click);
        	// 
        	// button3
        	// 
        	this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button3.ForeColor = System.Drawing.Color.Blue;
        	this.button3.Location = new System.Drawing.Point(80, 39);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(30, 25);
        	this.button3.TabIndex = 24;
        	this.button3.Text = "3";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Click += new System.EventHandler(this.Button3Click);
        	// 
        	// button2
        	// 
        	this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button2.ForeColor = System.Drawing.Color.Blue;
        	this.button2.Location = new System.Drawing.Point(44, 39);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(30, 25);
        	this.button2.TabIndex = 23;
        	this.button2.Text = "2";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.Button2Click);
        	// 
        	// button1
        	// 
        	this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.button1.ForeColor = System.Drawing.Color.Blue;
        	this.button1.Location = new System.Drawing.Point(8, 39);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(30, 25);
        	this.button1.TabIndex = 22;
        	this.button1.Text = "1";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.Button1Click);
        	// 
        	// calculatorPanel
        	// 
        	this.calculatorPanel.ColumnCount = 5;
        	this.calculatorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
        	this.calculatorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
        	this.calculatorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
        	this.calculatorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
        	this.calculatorPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
        	this.calculatorPanel.Controls.Add(this.button1, 0, 1);
        	this.calculatorPanel.Controls.Add(this.button2, 1, 1);
        	this.calculatorPanel.Controls.Add(this.buttonEquals, 4, 4);
        	this.calculatorPanel.Controls.Add(this.buttonDivide, 3, 4);
        	this.calculatorPanel.Controls.Add(this.button3, 2, 1);
        	this.calculatorPanel.Controls.Add(this.buttonMultiply, 3, 3);
        	this.calculatorPanel.Controls.Add(this.buttonDot, 2, 4);
        	this.calculatorPanel.Controls.Add(this.buttonClearEverything, 4, 3);
        	this.calculatorPanel.Controls.Add(this.buttonSign, 1, 4);
        	this.calculatorPanel.Controls.Add(this.buttonPlus, 3, 1);
        	this.calculatorPanel.Controls.Add(this.button0, 0, 4);
        	this.calculatorPanel.Controls.Add(this.buttonMinus, 3, 2);
        	this.calculatorPanel.Controls.Add(this.buttonOk, 4, 1);
        	this.calculatorPanel.Controls.Add(this.buttonCancel, 4, 2);
        	this.calculatorPanel.Controls.Add(this.button4, 0, 2);
        	this.calculatorPanel.Controls.Add(this.button5, 1, 2);
        	this.calculatorPanel.Controls.Add(this.button9, 2, 3);
        	this.calculatorPanel.Controls.Add(this.button6, 2, 2);
        	this.calculatorPanel.Controls.Add(this.button8, 1, 3);
        	this.calculatorPanel.Controls.Add(this.button7, 0, 3);
        	this.calculatorPanel.Controls.Add(this.outputLabel, 0, 0);
        	this.calculatorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.calculatorPanel.Location = new System.Drawing.Point(0, 0);
        	this.calculatorPanel.Name = "calculatorPanel";
        	this.calculatorPanel.Padding = new System.Windows.Forms.Padding(5);
        	this.calculatorPanel.RowCount = 5;
        	this.calculatorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        	this.calculatorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        	this.calculatorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        	this.calculatorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        	this.calculatorPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
        	this.calculatorPanel.Size = new System.Drawing.Size(212, 165);
        	this.calculatorPanel.TabIndex = 43;
        	// 
        	// FormCalculatorInput
        	// 
        	this.AcceptButton = this.buttonOk;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.buttonCancel;
        	this.ClientSize = new System.Drawing.Size(212, 165);
        	this.Controls.Add(this.calculatorPanel);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        	this.Name = "FormCalculatorInput";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Calculator";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCalculatorInputFormClosing);
        	this.calculatorPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private Awareness.CalculatorLogic calc = new CalculatorLogic();
        private System.Windows.Forms.TableLayoutPanel calculatorPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button buttonSign;
        private System.Windows.Forms.Button buttonDot;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonClearEverything;
        private System.Windows.Forms.Button buttonEquals;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonMultiply;
        private System.Windows.Forms.Button buttonDivide;
        private System.Windows.Forms.Label outputLabel;
    }
}
