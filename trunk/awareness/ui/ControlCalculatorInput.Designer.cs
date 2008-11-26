/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 26/11/2008
 * Time: 13:21
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
    partial class ControlCalculatorInput
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCalculatorInput));
        	this.valueBox = new System.Windows.Forms.TextBox();
        	this.calculatorButton = new System.Windows.Forms.Button();
        	this.imageList = new System.Windows.Forms.ImageList(this.components);
        	this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        	this.SuspendLayout();
        	// 
        	// valueBox
        	// 
        	this.valueBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.valueBox.Location = new System.Drawing.Point(0, 0);
        	this.valueBox.MaxLength = 20;
        	this.valueBox.Name = "valueBox";
        	this.valueBox.Size = new System.Drawing.Size(60, 20);
        	this.valueBox.TabIndex = 0;
        	this.valueBox.TextChanged += new System.EventHandler(this.ValueBoxTextChanged);
        	// 
        	// calculatorButton
        	// 
        	this.calculatorButton.Dock = System.Windows.Forms.DockStyle.Right;
        	this.calculatorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.calculatorButton.ImageIndex = 0;
        	this.calculatorButton.ImageList = this.imageList;
        	this.calculatorButton.Location = new System.Drawing.Point(60, 0);
        	this.calculatorButton.Name = "calculatorButton";
        	this.calculatorButton.Size = new System.Drawing.Size(20, 20);
        	this.calculatorButton.TabIndex = 1;
        	this.calculatorButton.UseVisualStyleBackColor = true;
        	this.calculatorButton.Click += new System.EventHandler(this.CalculatorButtonClick);
        	// 
        	// imageList
        	// 
        	this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
        	this.imageList.TransparentColor = System.Drawing.Color.Magenta;
        	this.imageList.Images.SetKeyName(0, "calculator.bmp");
        	// 
        	// ControlCalculatorInput
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.valueBox);
        	this.Controls.Add(this.calculatorButton);
        	this.MaximumSize = new System.Drawing.Size(1000, 20);
        	this.MinimumSize = new System.Drawing.Size(60, 20);
        	this.Name = "ControlCalculatorInput";
        	this.Size = new System.Drawing.Size(80, 20);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button calculatorButton;
        private System.Windows.Forms.TextBox valueBox;
    }
}
