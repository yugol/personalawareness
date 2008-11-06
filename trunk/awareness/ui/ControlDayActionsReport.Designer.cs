/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/10/2008
 * Time: 20:58
 * 
 */
namespace awareness.ui
{
    partial class ControlDayActionsReport
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
        	this.datePicker = new awareness.ui.ControlJumperDatePicker();
        	this.actionsListControl = new awareness.ui.ControlActionsList();
        	this.SuspendLayout();
        	// 
        	// datePicker
        	// 
        	this.datePicker.Dock = System.Windows.Forms.DockStyle.Top;
        	this.datePicker.JumpSize = awareness.ui.JumpSize.Day;
        	this.datePicker.Location = new System.Drawing.Point(0, 0);
        	this.datePicker.MinimumSize = new System.Drawing.Size(244, 20);
        	this.datePicker.Name = "datePicker";
        	this.datePicker.Size = new System.Drawing.Size(538, 22);
        	this.datePicker.TabIndex = 0;
        	this.datePicker.Value = new System.DateTime(2008, 10, 3, 21, 1, 11, 839);
        	// 
        	// actionsListControl
        	// 
        	this.actionsListControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.actionsListControl.HeadersVisible = true;
        	this.actionsListControl.Location = new System.Drawing.Point(0, 22);
        	this.actionsListControl.Name = "actionsListControl";
        	this.actionsListControl.Size = new System.Drawing.Size(538, 367);
        	this.actionsListControl.TabIndex = 1;
        	this.actionsListControl.TimeInterval = null;
        	this.actionsListControl.Title = "When";
        	this.actionsListControl.TitleFormat = awareness.ui.TitleFormats.HIDDEN;
        	// 
        	// ControlDayActionsReport
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.actionsListControl);
        	this.Controls.Add(this.datePicker);
        	this.Name = "ControlDayActionsReport";
        	this.Size = new System.Drawing.Size(538, 389);
        	this.Load += new System.EventHandler(this.ControlDayActionsReportLoad);
        	this.ResumeLayout(false);
        }
        private awareness.ui.ControlActionsList actionsListControl;
        private awareness.ui.ControlJumperDatePicker datePicker;
    }
}
