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


namespace Awareness.UI
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
        	this.components = new System.ComponentModel.Container();
        	this.optionTabs = new System.Windows.Forms.TabControl();
        	this.financialPage = new System.Windows.Forms.TabPage();
        	this.currencyGroup = new System.Windows.Forms.GroupBox();
        	this.placementCheck = new System.Windows.Forms.CheckBox();
        	this.symbolBox = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.mainPanel = new System.Windows.Forms.Panel();
        	this.bottomPanel = new System.Windows.Forms.Panel();
        	this.okButton = new System.Windows.Forms.Button();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.cancelButton = new System.Windows.Forms.Button();
        	this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        	this.optionTabs.SuspendLayout();
        	this.financialPage.SuspendLayout();
        	this.currencyGroup.SuspendLayout();
        	this.mainPanel.SuspendLayout();
        	this.bottomPanel.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// optionTabs
        	// 
        	this.optionTabs.Controls.Add(this.financialPage);
        	this.optionTabs.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.optionTabs.Location = new System.Drawing.Point(8, 8);
        	this.optionTabs.Name = "optionTabs";
        	this.optionTabs.SelectedIndex = 0;
        	this.optionTabs.Size = new System.Drawing.Size(415, 222);
        	this.optionTabs.TabIndex = 0;
        	// 
        	// financialPage
        	// 
        	this.financialPage.Controls.Add(this.currencyGroup);
        	this.financialPage.Location = new System.Drawing.Point(4, 22);
        	this.financialPage.Name = "financialPage";
        	this.financialPage.Padding = new System.Windows.Forms.Padding(8);
        	this.financialPage.Size = new System.Drawing.Size(407, 196);
        	this.financialPage.TabIndex = 0;
        	this.financialPage.Text = "Financial";
        	this.financialPage.UseVisualStyleBackColor = true;
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
        	// placementCheck
        	// 
        	this.placementCheck.Location = new System.Drawing.Point(24, 56);
        	this.placementCheck.Name = "placementCheck";
        	this.placementCheck.Size = new System.Drawing.Size(160, 24);
        	this.placementCheck.TabIndex = 2;
        	this.placementCheck.Text = "Place symbol after value";
        	this.placementCheck.UseVisualStyleBackColor = true;
        	// 
        	// symbolBox
        	// 
        	this.symbolBox.Location = new System.Drawing.Point(64, 24);
        	this.symbolBox.MaxLength = 10;
        	this.symbolBox.Name = "symbolBox";
        	this.symbolBox.Size = new System.Drawing.Size(96, 20);
        	this.symbolBox.TabIndex = 1;
        	this.symbolBox.Validating += new System.ComponentModel.CancelEventHandler(this.SymbolBoxValidating);
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
        	// mainPanel
        	// 
        	this.mainPanel.Controls.Add(this.optionTabs);
        	this.mainPanel.Controls.Add(this.bottomPanel);
        	this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mainPanel.Location = new System.Drawing.Point(0, 0);
        	this.mainPanel.Name = "mainPanel";
        	this.mainPanel.Padding = new System.Windows.Forms.Padding(8);
        	this.mainPanel.Size = new System.Drawing.Size(431, 270);
        	this.mainPanel.TabIndex = 1;
        	// 
        	// bottomPanel
        	// 
        	this.bottomPanel.Controls.Add(this.okButton);
        	this.bottomPanel.Controls.Add(this.panel1);
        	this.bottomPanel.Controls.Add(this.cancelButton);
        	this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.bottomPanel.Location = new System.Drawing.Point(8, 230);
        	this.bottomPanel.Name = "bottomPanel";
        	this.bottomPanel.Padding = new System.Windows.Forms.Padding(0, 8, 2, 0);
        	this.bottomPanel.Size = new System.Drawing.Size(415, 32);
        	this.bottomPanel.TabIndex = 1;
        	// 
        	// okButton
        	// 
        	this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.okButton.Dock = System.Windows.Forms.DockStyle.Right;
        	this.okButton.Location = new System.Drawing.Point(255, 8);
        	this.okButton.Name = "okButton";
        	this.okButton.Size = new System.Drawing.Size(75, 24);
        	this.okButton.TabIndex = 2;
        	this.okButton.Text = "OK";
        	this.okButton.UseVisualStyleBackColor = true;
        	this.okButton.Click += new System.EventHandler(this.OkButtonClick);
        	// 
        	// panel1
        	// 
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
        	this.panel1.Location = new System.Drawing.Point(330, 8);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(8, 24);
        	this.panel1.TabIndex = 1;
        	// 
        	// cancelButton
        	// 
        	this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
        	this.cancelButton.Location = new System.Drawing.Point(338, 8);
        	this.cancelButton.Name = "cancelButton";
        	this.cancelButton.Size = new System.Drawing.Size(75, 24);
        	this.cancelButton.TabIndex = 0;
        	this.cancelButton.Text = "Cancel";
        	this.cancelButton.UseVisualStyleBackColor = true;
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// FormEditProperties
        	// 
        	this.AcceptButton = this.okButton;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.cancelButton;
        	this.ClientSize = new System.Drawing.Size(431, 270);
        	this.Controls.Add(this.mainPanel);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormEditProperties";
        	this.ShowInTaskbar = false;
        	this.Text = "Preferences";
        	this.optionTabs.ResumeLayout(false);
        	this.financialPage.ResumeLayout(false);
        	this.currencyGroup.ResumeLayout(false);
        	this.currencyGroup.PerformLayout();
        	this.mainPanel.ResumeLayout(false);
        	this.bottomPanel.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.TabPage financialPage;
        private System.Windows.Forms.TabControl optionTabs;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox symbolBox;
        private System.Windows.Forms.CheckBox placementCheck;
        private System.Windows.Forms.GroupBox currencyGroup;
    }
}
