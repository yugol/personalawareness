/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 11/12/2008
 * Time: 00:42
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


namespace Awareness.ui
{
    partial class FormAbout
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.button1 = new System.Windows.Forms.Button();
        	this.versionLabel = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
        	this.pictureBox1.Location = new System.Drawing.Point(16, 16);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(32, 32);
        	this.pictureBox1.TabIndex = 0;
        	this.pictureBox1.TabStop = false;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label1.Location = new System.Drawing.Point(64, 16);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(121, 13);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "Personal Awareness";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(64, 40);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(156, 13);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "Copyright (C) 2008 Iulian Goriac";
        	// 
        	// button1
        	// 
        	this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.button1.Location = new System.Drawing.Point(160, 72);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(75, 23);
        	this.button1.TabIndex = 3;
        	this.button1.Text = "OK";
        	this.button1.UseVisualStyleBackColor = true;
        	// 
        	// versionLabel
        	// 
        	this.versionLabel.AutoSize = true;
        	this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.versionLabel.Location = new System.Drawing.Point(184, 16);
        	this.versionLabel.Name = "versionLabel";
        	this.versionLabel.Size = new System.Drawing.Size(48, 13);
        	this.versionLabel.TabIndex = 4;
        	this.versionLabel.Text = "version";
        	// 
        	// FormAbout
        	// 
        	this.AcceptButton = this.button1;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(249, 108);
        	this.Controls.Add(this.versionLabel);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.pictureBox1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormAbout";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "About";
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
