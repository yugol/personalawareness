/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 04/12/2008
 * Time: 00:33
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
    partial class FormEditProperties
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
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.optionsPage = new System.Windows.Forms.TabPage();
        	this.mainPanel = new System.Windows.Forms.Panel();
        	this.currencyGroup = new System.Windows.Forms.GroupBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.symbolBox = new System.Windows.Forms.TextBox();
        	this.placementCheck = new System.Windows.Forms.CheckBox();
        	this.tabControl1.SuspendLayout();
        	this.optionsPage.SuspendLayout();
        	this.mainPanel.SuspendLayout();
        	this.currencyGroup.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Controls.Add(this.optionsPage);
        	this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControl1.Location = new System.Drawing.Point(8, 8);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(415, 237);
        	this.tabControl1.TabIndex = 0;
        	// 
        	// optionsPage
        	// 
        	this.optionsPage.Controls.Add(this.currencyGroup);
        	this.optionsPage.Location = new System.Drawing.Point(4, 22);
        	this.optionsPage.Name = "optionsPage";
        	this.optionsPage.Padding = new System.Windows.Forms.Padding(8);
        	this.optionsPage.Size = new System.Drawing.Size(407, 211);
        	this.optionsPage.TabIndex = 0;
        	this.optionsPage.Text = "Options";
        	this.optionsPage.UseVisualStyleBackColor = true;
        	// 
        	// mainPanel
        	// 
        	this.mainPanel.Controls.Add(this.tabControl1);
        	this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mainPanel.Location = new System.Drawing.Point(0, 0);
        	this.mainPanel.Name = "mainPanel";
        	this.mainPanel.Padding = new System.Windows.Forms.Padding(8);
        	this.mainPanel.Size = new System.Drawing.Size(431, 253);
        	this.mainPanel.TabIndex = 1;
        	// 
        	// currencyGroup
        	// 
        	this.currencyGroup.Controls.Add(this.placementCheck);
        	this.currencyGroup.Controls.Add(this.symbolBox);
        	this.currencyGroup.Controls.Add(this.label1);
        	this.currencyGroup.Dock = System.Windows.Forms.DockStyle.Top;
        	this.currencyGroup.Location = new System.Drawing.Point(8, 8);
        	this.currencyGroup.Name = "currencyGroup";
        	this.currencyGroup.Size = new System.Drawing.Size(391, 96);
        	this.currencyGroup.TabIndex = 0;
        	this.currencyGroup.TabStop = false;
        	this.currencyGroup.Text = "Currency";
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(16, 24);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(44, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Symbol:";
        	// 
        	// symbolBox
        	// 
        	this.symbolBox.Location = new System.Drawing.Point(64, 24);
        	this.symbolBox.MaxLength = 10;
        	this.symbolBox.Name = "symbolBox";
        	this.symbolBox.Size = new System.Drawing.Size(96, 20);
        	this.symbolBox.TabIndex = 1;
        	// 
        	// placementCheck
        	// 
        	this.placementCheck.Location = new System.Drawing.Point(24, 56);
        	this.placementCheck.Name = "placementCheck";
        	this.placementCheck.Size = new System.Drawing.Size(160, 24);
        	this.placementCheck.TabIndex = 2;
        	this.placementCheck.Text = "Place symbol after value";
        	this.placementCheck.UseVisualStyleBackColor = true;
        	// 
        	// FormEditProperties
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(431, 253);
        	this.Controls.Add(this.mainPanel);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormEditProperties";
        	this.ShowInTaskbar = false;
        	this.Text = "Preferences";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditPropertiesFormClosing);
        	this.tabControl1.ResumeLayout(false);
        	this.optionsPage.ResumeLayout(false);
        	this.mainPanel.ResumeLayout(false);
        	this.currencyGroup.ResumeLayout(false);
        	this.currencyGroup.PerformLayout();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox symbolBox;
        private System.Windows.Forms.CheckBox placementCheck;
        private System.Windows.Forms.GroupBox currencyGroup;
        private System.Windows.Forms.TabPage optionsPage;
        private System.Windows.Forms.TabControl tabControl1;
    }
}
