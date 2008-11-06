/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 16/09/2008
 * Time: 22:55
 * 
 */
namespace awareness.ui
{
    partial class FormReport
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
        	this.graphControl = new ZedGraph.ZedGraphControl();
        	this.SuspendLayout();
        	// 
        	// graphControl
        	// 
        	this.graphControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.graphControl.Location = new System.Drawing.Point(0, 0);
        	this.graphControl.Name = "graphControl";
        	this.graphControl.ScrollGrace = 0;
        	this.graphControl.ScrollMaxX = 0;
        	this.graphControl.ScrollMaxY = 0;
        	this.graphControl.ScrollMaxY2 = 0;
        	this.graphControl.ScrollMinX = 0;
        	this.graphControl.ScrollMinY = 0;
        	this.graphControl.ScrollMinY2 = 0;
        	this.graphControl.Size = new System.Drawing.Size(632, 450);
        	this.graphControl.TabIndex = 0;
        	// 
        	// FormReport
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(632, 450);
        	this.Controls.Add(this.graphControl);
        	this.Name = "FormReport";
        	this.Text = "FormReport";
        	this.ResumeLayout(false);
        }
        private ZedGraph.ZedGraphControl graphControl;
    }
}
