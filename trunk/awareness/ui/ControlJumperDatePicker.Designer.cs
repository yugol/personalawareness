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
 * Date: 03/10/2008
 * Time: 18:33
 * 
 */
namespace Awareness.UI
{
    partial class ControlJumperDatePicker
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlJumperDatePicker));
        	this.leftLeftButton = new System.Windows.Forms.Button();
        	this.imageList = new System.Windows.Forms.ImageList(this.components);
        	this.leftButton = new System.Windows.Forms.Button();
        	this.datePicker = new System.Windows.Forms.DateTimePicker();
        	this.rightButton = new System.Windows.Forms.Button();
        	this.rightRightButton = new System.Windows.Forms.Button();
        	this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        	this.todayButton = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// leftLeftButton
        	// 
        	this.leftLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.leftLeftButton.ImageIndex = 0;
        	this.leftLeftButton.ImageList = this.imageList;
        	this.leftLeftButton.Location = new System.Drawing.Point(0, 0);
        	this.leftLeftButton.Name = "leftLeftButton";
        	this.leftLeftButton.Size = new System.Drawing.Size(20, 20);
        	this.leftLeftButton.TabIndex = 0;
        	this.leftLeftButton.UseVisualStyleBackColor = true;
        	this.leftLeftButton.Click += new System.EventHandler(this.LeftLeftButtonClick);
        	// 
        	// imageList
        	// 
        	this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
        	this.imageList.TransparentColor = System.Drawing.Color.Magenta;
        	this.imageList.Images.SetKeyName(0, "left_left_jump.bmp");
        	this.imageList.Images.SetKeyName(1, "left_jump.bmp");
        	this.imageList.Images.SetKeyName(2, "right_jump.bmp");
        	this.imageList.Images.SetKeyName(3, "right_right_jump.bmp");
        	// 
        	// leftButton
        	// 
        	this.leftButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.leftButton.ImageIndex = 1;
        	this.leftButton.ImageList = this.imageList;
        	this.leftButton.Location = new System.Drawing.Point(24, 0);
        	this.leftButton.Name = "leftButton";
        	this.leftButton.Size = new System.Drawing.Size(20, 20);
        	this.leftButton.TabIndex = 1;
        	this.leftButton.UseVisualStyleBackColor = true;
        	this.leftButton.Click += new System.EventHandler(this.LeftButtonClick);
        	// 
        	// datePicker
        	// 
        	this.datePicker.Location = new System.Drawing.Point(56, 0);
        	this.datePicker.Name = "datePicker";
        	this.datePicker.Size = new System.Drawing.Size(132, 20);
        	this.datePicker.TabIndex = 2;
        	this.datePicker.ValueChanged += new System.EventHandler(this.DatePickerValueChanged);
        	// 
        	// rightButton
        	// 
        	this.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.rightButton.ImageIndex = 2;
        	this.rightButton.ImageList = this.imageList;
        	this.rightButton.Location = new System.Drawing.Point(200, 0);
        	this.rightButton.Name = "rightButton";
        	this.rightButton.Size = new System.Drawing.Size(20, 20);
        	this.rightButton.TabIndex = 3;
        	this.rightButton.UseVisualStyleBackColor = true;
        	this.rightButton.Click += new System.EventHandler(this.RightButtonClick);
        	// 
        	// rightRightButton
        	// 
        	this.rightRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.rightRightButton.ImageIndex = 3;
        	this.rightRightButton.ImageList = this.imageList;
        	this.rightRightButton.Location = new System.Drawing.Point(224, 0);
        	this.rightRightButton.Name = "rightRightButton";
        	this.rightRightButton.Size = new System.Drawing.Size(20, 20);
        	this.rightRightButton.TabIndex = 4;
        	this.rightRightButton.UseVisualStyleBackColor = true;
        	this.rightRightButton.Click += new System.EventHandler(this.RightRightButtonClick);
        	// 
        	// todayButton
        	// 
        	this.todayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.todayButton.Location = new System.Drawing.Point(256, 0);
        	this.todayButton.Name = "todayButton";
        	this.todayButton.Size = new System.Drawing.Size(48, 20);
        	this.todayButton.TabIndex = 5;
        	this.todayButton.Text = "Today";
        	this.todayButton.UseVisualStyleBackColor = true;
        	this.todayButton.Click += new System.EventHandler(this.TodayButtonClick);
        	// 
        	// ControlJumperDatePicker
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.todayButton);
        	this.Controls.Add(this.rightRightButton);
        	this.Controls.Add(this.rightButton);
        	this.Controls.Add(this.datePicker);
        	this.Controls.Add(this.leftButton);
        	this.Controls.Add(this.leftLeftButton);
        	this.MinimumSize = new System.Drawing.Size(304, 20);
        	this.Name = "ControlJumperDatePicker";
        	this.Size = new System.Drawing.Size(304, 20);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.Button todayButton;
        private System.Windows.Forms.Button rightRightButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button leftLeftButton;
    }
}
