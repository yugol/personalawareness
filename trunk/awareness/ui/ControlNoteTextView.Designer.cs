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
 * Date: 25/09/2008
 * Time: 14:45
 * 
 */
namespace Awareness.UI
{
    partial class ControlNoteTextView
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
        	this.topPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.iconsPicture = new System.Windows.Forms.PictureBox();
        	this.titleBox = new System.Windows.Forms.TextBox();
        	this.creationTimeBox = new System.Windows.Forms.TextBox();
        	this.textBox = new System.Windows.Forms.TextBox();
        	this.topPanel.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.iconsPicture)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// topPanel
        	// 
        	this.topPanel.ColumnCount = 3;
        	this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
        	this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
        	this.topPanel.Controls.Add(this.iconsPicture, 0, 0);
        	this.topPanel.Controls.Add(this.titleBox, 1, 0);
        	this.topPanel.Controls.Add(this.creationTimeBox, 2, 0);
        	this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
        	this.topPanel.Location = new System.Drawing.Point(0, 0);
        	this.topPanel.Name = "topPanel";
        	this.topPanel.RowCount = 1;
        	this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.topPanel.Size = new System.Drawing.Size(548, 25);
        	this.topPanel.TabIndex = 0;
        	// 
        	// iconsPicture
        	// 
        	this.iconsPicture.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.iconsPicture.Location = new System.Drawing.Point(3, 0);
        	this.iconsPicture.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
        	this.iconsPicture.Name = "iconsPicture";
        	this.iconsPicture.Size = new System.Drawing.Size(20, 22);
        	this.iconsPicture.TabIndex = 0;
        	this.iconsPicture.TabStop = false;
        	// 
        	// titleBox
        	// 
        	this.titleBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.titleBox.Location = new System.Drawing.Point(29, 0);
        	this.titleBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
        	this.titleBox.Name = "titleBox";
        	this.titleBox.Size = new System.Drawing.Size(386, 20);
        	this.titleBox.TabIndex = 1;
        	this.titleBox.TextChanged += new System.EventHandler(this.TitleBoxTextChanged);
        	this.titleBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TitleBoxKeyDown);
        	this.titleBox.Leave += new System.EventHandler(this.TitleBoxLeave);
        	this.titleBox.Enter += new System.EventHandler(this.TitleBoxEnter);
        	// 
        	// creationTimeBox
        	// 
        	this.creationTimeBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.creationTimeBox.Location = new System.Drawing.Point(421, 0);
        	this.creationTimeBox.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
        	this.creationTimeBox.Name = "creationTimeBox";
        	this.creationTimeBox.ReadOnly = true;
        	this.creationTimeBox.Size = new System.Drawing.Size(127, 20);
        	this.creationTimeBox.TabIndex = 2;
        	this.creationTimeBox.Text = "0000-00-00 00:00:00";
        	this.creationTimeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	// 
        	// textBox
        	// 
        	this.textBox.AcceptsReturn = true;
        	this.textBox.AcceptsTab = true;
        	this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.textBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.textBox.Location = new System.Drawing.Point(0, 25);
        	this.textBox.Multiline = true;
        	this.textBox.Name = "textBox";
        	this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        	this.textBox.Size = new System.Drawing.Size(548, 223);
        	this.textBox.TabIndex = 2;
        	this.textBox.WordWrap = false;
        	this.textBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
        	this.textBox.Leave += new System.EventHandler(this.TextBoxLeave);
        	// 
        	// ControlNoteTextView
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.textBox);
        	this.Controls.Add(this.topPanel);
        	this.Name = "ControlNoteTextView";
        	this.Size = new System.Drawing.Size(548, 248);
        	this.topPanel.ResumeLayout(false);
        	this.topPanel.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.iconsPicture)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.TextBox creationTimeBox;
        private System.Windows.Forms.PictureBox iconsPicture;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.TableLayoutPanel topPanel;
    }
}
