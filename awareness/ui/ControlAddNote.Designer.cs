/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 19/11/2008
 * Time: 08:21
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
    partial class ControlAddNote
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlAddNote));
        	this.addNoteButton = new System.Windows.Forms.Button();
        	this.topPanel = new System.Windows.Forms.Panel();
        	this.centerBottomPanel = new System.Windows.Forms.Panel();
        	this.enlargeBox = new System.Windows.Forms.PictureBox();
        	this.separatorPanel = new System.Windows.Forms.Panel();
        	this.deleteBox = new System.Windows.Forms.PictureBox();
        	this.noteControl = new Awareness.UI.ControlNoteTextView();
        	this.centerPanel = new System.Windows.Forms.Panel();
        	this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        	this.topPanel.SuspendLayout();
        	this.centerBottomPanel.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.enlargeBox)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.deleteBox)).BeginInit();
        	this.centerPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// addNoteButton
        	// 
        	this.addNoteButton.Dock = System.Windows.Forms.DockStyle.Right;
        	this.addNoteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.addNoteButton.Location = new System.Drawing.Point(396, 0);
        	this.addNoteButton.Name = "addNoteButton";
        	this.addNoteButton.Size = new System.Drawing.Size(75, 24);
        	this.addNoteButton.TabIndex = 0;
        	this.addNoteButton.Text = "Add note";
        	this.addNoteButton.UseVisualStyleBackColor = true;
        	this.addNoteButton.Click += new System.EventHandler(this.AddNoteButtonClick);
        	// 
        	// topPanel
        	// 
        	this.topPanel.Controls.Add(this.addNoteButton);
        	this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
        	this.topPanel.Location = new System.Drawing.Point(0, 0);
        	this.topPanel.Name = "topPanel";
        	this.topPanel.Size = new System.Drawing.Size(471, 24);
        	this.topPanel.TabIndex = 2;
        	// 
        	// centerBottomPanel
        	// 
        	this.centerBottomPanel.Controls.Add(this.enlargeBox);
        	this.centerBottomPanel.Controls.Add(this.separatorPanel);
        	this.centerBottomPanel.Controls.Add(this.deleteBox);
        	this.centerBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.centerBottomPanel.Location = new System.Drawing.Point(0, 280);
        	this.centerBottomPanel.Name = "centerBottomPanel";
        	this.centerBottomPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
        	this.centerBottomPanel.Size = new System.Drawing.Size(471, 11);
        	this.centerBottomPanel.TabIndex = 3;
        	// 
        	// enlargeBox
        	// 
        	this.enlargeBox.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.enlargeBox.Dock = System.Windows.Forms.DockStyle.Right;
        	this.enlargeBox.Image = ((System.Drawing.Image)(resources.GetObject("enlargeBox.Image")));
        	this.enlargeBox.Location = new System.Drawing.Point(451, 2);
        	this.enlargeBox.Name = "enlargeBox";
        	this.enlargeBox.Size = new System.Drawing.Size(9, 9);
        	this.enlargeBox.TabIndex = 6;
        	this.enlargeBox.TabStop = false;
        	this.toolTip.SetToolTip(this.enlargeBox, "Enlarge");
        	this.enlargeBox.Click += new System.EventHandler(this.EnlargeBoxClick);
        	// 
        	// separatorPanel
        	// 
        	this.separatorPanel.Dock = System.Windows.Forms.DockStyle.Right;
        	this.separatorPanel.Location = new System.Drawing.Point(460, 2);
        	this.separatorPanel.Name = "separatorPanel";
        	this.separatorPanel.Size = new System.Drawing.Size(2, 9);
        	this.separatorPanel.TabIndex = 5;
        	// 
        	// deleteBox
        	// 
        	this.deleteBox.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.deleteBox.Dock = System.Windows.Forms.DockStyle.Right;
        	this.deleteBox.Image = ((System.Drawing.Image)(resources.GetObject("deleteBox.Image")));
        	this.deleteBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("deleteBox.InitialImage")));
        	this.deleteBox.Location = new System.Drawing.Point(462, 2);
        	this.deleteBox.Name = "deleteBox";
        	this.deleteBox.Size = new System.Drawing.Size(9, 9);
        	this.deleteBox.TabIndex = 4;
        	this.deleteBox.TabStop = false;
        	this.toolTip.SetToolTip(this.deleteBox, "Delete");
        	this.deleteBox.Click += new System.EventHandler(this.DeleteBoxClick);
        	// 
        	// noteControl
        	// 
        	this.noteControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.noteControl.IconVisible = false;
        	this.noteControl.Location = new System.Drawing.Point(0, 0);
        	this.noteControl.Name = "noteControl";
        	this.noteControl.Node = null;
        	this.noteControl.Note = null;
        	this.noteControl.ScrollBars = false;
        	this.noteControl.Size = new System.Drawing.Size(471, 280);
        	this.noteControl.TabIndex = 4;
        	this.noteControl.TextReadOnly = false;
        	this.noteControl.TitleReadOnly = false;
        	this.toolTip.SetToolTip(this.noteControl, "Memo");
        	this.noteControl.TopVisible = false;
        	this.noteControl.NoteTextChanged += new Awareness.UI.NoteHandler(this.NoteControlNoteTextChanged);
        	// 
        	// centerPanel
        	// 
        	this.centerPanel.Controls.Add(this.noteControl);
        	this.centerPanel.Controls.Add(this.centerBottomPanel);
        	this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.centerPanel.Location = new System.Drawing.Point(0, 24);
        	this.centerPanel.Name = "centerPanel";
        	this.centerPanel.Size = new System.Drawing.Size(471, 291);
        	this.centerPanel.TabIndex = 5;
        	// 
        	// ControlAddNote
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.centerPanel);
        	this.Controls.Add(this.topPanel);
        	this.Name = "ControlAddNote";
        	this.Size = new System.Drawing.Size(471, 315);
        	this.topPanel.ResumeLayout(false);
        	this.centerBottomPanel.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.enlargeBox)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.deleteBox)).EndInit();
        	this.centerPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel separatorPanel;
        private System.Windows.Forms.PictureBox enlargeBox;
        private System.Windows.Forms.PictureBox deleteBox;
        private System.Windows.Forms.Panel centerPanel;
        private Awareness.UI.ControlNoteTextView noteControl;
        private System.Windows.Forms.Panel centerBottomPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button addNoteButton;
    }
}
