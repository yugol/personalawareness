/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 02/12/2008
 * Time: 22:08
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
    partial class FormTodo
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
        	this.noteControl = new Awareness.UI.ControlNoteTextView();
        	this.SuspendLayout();
        	// 
        	// noteControl
        	// 
        	this.noteControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.noteControl.IconVisible = false;
        	this.noteControl.Location = new System.Drawing.Point(0, 0);
        	this.noteControl.Name = "noteControl";
        	this.noteControl.Node = null;
        	this.noteControl.Note = null;
        	this.noteControl.ScrollBars = true;
        	this.noteControl.Size = new System.Drawing.Size(312, 486);
        	this.noteControl.TabIndex = 0;
        	this.noteControl.TextReadOnly = false;
        	this.noteControl.TitleReadOnly = false;
        	this.noteControl.TopVisible = false;
        	// 
        	// FormTodo
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(312, 486);
        	this.Controls.Add(this.noteControl);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        	this.Name = "FormTodo";
        	this.ShowInTaskbar = false;
        	this.Text = "To Do";
        	this.VisibleChanged += new System.EventHandler(this.FormTodoVisibleChanged);
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTodoFormClosing);
        	this.ResumeLayout(false);
        }
        private Awareness.UI.ControlNoteTextView noteControl;
    }
}
