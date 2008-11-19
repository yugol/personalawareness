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


namespace awareness.ui
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
        	this.addNoteButton = new System.Windows.Forms.Button();
        	this.removeNoteButton = new System.Windows.Forms.Button();
        	this.topPanel = new System.Windows.Forms.Panel();
        	this.centerBottomPanel = new System.Windows.Forms.Panel();
        	this.enlargeButton = new System.Windows.Forms.Button();
        	this.spacer = new System.Windows.Forms.Panel();
        	this.noteControl = new awareness.ui.ControlNoteTextView();
        	this.centerPanel = new System.Windows.Forms.Panel();
        	this.topPanel.SuspendLayout();
        	this.centerBottomPanel.SuspendLayout();
        	this.centerPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// addNoteButton
        	// 
        	this.addNoteButton.Dock = System.Windows.Forms.DockStyle.Right;
        	this.addNoteButton.Location = new System.Drawing.Point(396, 0);
        	this.addNoteButton.Name = "addNoteButton";
        	this.addNoteButton.Size = new System.Drawing.Size(75, 24);
        	this.addNoteButton.TabIndex = 0;
        	this.addNoteButton.Text = "Add note";
        	this.addNoteButton.UseVisualStyleBackColor = true;
        	this.addNoteButton.Click += new System.EventHandler(this.AddNoteButtonClick);
        	// 
        	// removeNoteButton
        	// 
        	this.removeNoteButton.Dock = System.Windows.Forms.DockStyle.Right;
        	this.removeNoteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.removeNoteButton.Location = new System.Drawing.Point(449, 0);
        	this.removeNoteButton.Name = "removeNoteButton";
        	this.removeNoteButton.Size = new System.Drawing.Size(22, 22);
        	this.removeNoteButton.TabIndex = 1;
        	this.removeNoteButton.Text = "X";
        	this.removeNoteButton.UseVisualStyleBackColor = true;
        	this.removeNoteButton.Click += new System.EventHandler(this.RemoveNoteButtonClick);
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
        	this.centerBottomPanel.Controls.Add(this.enlargeButton);
        	this.centerBottomPanel.Controls.Add(this.spacer);
        	this.centerBottomPanel.Controls.Add(this.removeNoteButton);
        	this.centerBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.centerBottomPanel.Location = new System.Drawing.Point(0, 269);
        	this.centerBottomPanel.Name = "centerBottomPanel";
        	this.centerBottomPanel.Size = new System.Drawing.Size(471, 22);
        	this.centerBottomPanel.TabIndex = 3;
        	// 
        	// enlargeButton
        	// 
        	this.enlargeButton.Dock = System.Windows.Forms.DockStyle.Right;
        	this.enlargeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.enlargeButton.Location = new System.Drawing.Point(423, 0);
        	this.enlargeButton.Name = "enlargeButton";
        	this.enlargeButton.Size = new System.Drawing.Size(22, 22);
        	this.enlargeButton.TabIndex = 2;
        	this.enlargeButton.Text = "O";
        	this.enlargeButton.UseVisualStyleBackColor = true;
        	this.enlargeButton.Click += new System.EventHandler(this.EnlargeButtonClick);
        	// 
        	// spacer
        	// 
        	this.spacer.Dock = System.Windows.Forms.DockStyle.Right;
        	this.spacer.Location = new System.Drawing.Point(445, 0);
        	this.spacer.Name = "spacer";
        	this.spacer.Size = new System.Drawing.Size(4, 22);
        	this.spacer.TabIndex = 3;
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
        	this.noteControl.Size = new System.Drawing.Size(471, 269);
        	this.noteControl.TabIndex = 4;
        	this.noteControl.TextReadOnly = false;
        	this.noteControl.TitleReadOnly = false;
        	this.noteControl.TopVisible = false;
        	this.noteControl.NoteTextChanged += new awareness.ui.NoteHandler(this.NoteControlNoteTextChanged);
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
        	this.centerPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.Panel centerPanel;
        private awareness.ui.ControlNoteTextView noteControl;
        private System.Windows.Forms.Panel spacer;
        private System.Windows.Forms.Button enlargeButton;
        private System.Windows.Forms.Panel centerBottomPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button removeNoteButton;
        private System.Windows.Forms.Button addNoteButton;
    }
}
