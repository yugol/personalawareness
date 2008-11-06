﻿/*
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
 * Date: 01/09/2008
 * Time: 14:32
 * 
 */
namespace awareness.ui
{
    partial class FormEditAccountTypes
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
        	this.label1 = new System.Windows.Forms.Label();
        	this.typeList = new System.Windows.Forms.ListBox();
        	this.newButton = new System.Windows.Forms.Button();
        	this.updateButton = new System.Windows.Forms.Button();
        	this.deleteButton = new System.Windows.Forms.Button();
        	this.closeButton = new System.Windows.Forms.Button();
        	this.nameBox = new System.Windows.Forms.TextBox();
        	this.nameLabel = new System.Windows.Forms.Label();
        	this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(8, 16);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(81, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Available types:";
        	// 
        	// typeList
        	// 
        	this.typeList.FormattingEnabled = true;
        	this.typeList.Location = new System.Drawing.Point(8, 40);
        	this.typeList.Name = "typeList";
        	this.typeList.Size = new System.Drawing.Size(144, 212);
        	this.typeList.Sorted = true;
        	this.typeList.TabIndex = 1;
        	this.typeList.SelectedIndexChanged += new System.EventHandler(this.TypeListSelectedIndexChanged);
        	// 
        	// newButton
        	// 
        	this.newButton.Location = new System.Drawing.Point(352, 24);
        	this.newButton.Name = "newButton";
        	this.newButton.Size = new System.Drawing.Size(75, 23);
        	this.newButton.TabIndex = 3;
        	this.newButton.Text = "&New";
        	this.newButton.UseVisualStyleBackColor = true;
        	this.newButton.Click += new System.EventHandler(this.NewButtonClick);
        	// 
        	// updateButton
        	// 
        	this.updateButton.Location = new System.Drawing.Point(352, 56);
        	this.updateButton.Name = "updateButton";
        	this.updateButton.Size = new System.Drawing.Size(75, 23);
        	this.updateButton.TabIndex = 4;
        	this.updateButton.Text = "&Update";
        	this.updateButton.UseVisualStyleBackColor = true;
        	this.updateButton.Click += new System.EventHandler(this.UpdateButtonClick);
        	// 
        	// deleteButton
        	// 
        	this.deleteButton.Location = new System.Drawing.Point(352, 88);
        	this.deleteButton.Name = "deleteButton";
        	this.deleteButton.Size = new System.Drawing.Size(75, 23);
        	this.deleteButton.TabIndex = 5;
        	this.deleteButton.Text = "&Delete";
        	this.deleteButton.UseVisualStyleBackColor = true;
        	this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
        	// 
        	// closeButton
        	// 
        	this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.closeButton.Location = new System.Drawing.Point(352, 136);
        	this.closeButton.Name = "closeButton";
        	this.closeButton.Size = new System.Drawing.Size(75, 23);
        	this.closeButton.TabIndex = 6;
        	this.closeButton.Text = "&Close";
        	this.closeButton.UseVisualStyleBackColor = true;
        	// 
        	// nameBox
        	// 
        	this.nameBox.Location = new System.Drawing.Point(168, 56);
        	this.nameBox.Name = "nameBox";
        	this.nameBox.Size = new System.Drawing.Size(160, 20);
        	this.nameBox.TabIndex = 2;
        	this.nameBox.TextChanged += new System.EventHandler(this.NameBoxTextChanged);
        	this.nameBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameBoxValidating);
        	// 
        	// nameLabel
        	// 
        	this.nameLabel.AutoSize = true;
        	this.nameLabel.Location = new System.Drawing.Point(168, 40);
        	this.nameLabel.Name = "nameLabel";
        	this.nameLabel.Size = new System.Drawing.Size(38, 13);
        	this.nameLabel.TabIndex = 8;
        	this.nameLabel.Text = "Name:";
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// FormEditAccountTypes
        	// 
        	this.AcceptButton = this.updateButton;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.closeButton;
        	this.ClientSize = new System.Drawing.Size(434, 262);
        	this.Controls.Add(this.nameBox);
        	this.Controls.Add(this.nameLabel);
        	this.Controls.Add(this.closeButton);
        	this.Controls.Add(this.deleteButton);
        	this.Controls.Add(this.updateButton);
        	this.Controls.Add(this.newButton);
        	this.Controls.Add(this.typeList);
        	this.Controls.Add(this.label1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormEditAccountTypes";
        	this.ShowInTaskbar = false;
        	this.Text = "Account Types";
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.ListBox typeList;
        private System.Windows.Forms.Label label1;
    }
}
