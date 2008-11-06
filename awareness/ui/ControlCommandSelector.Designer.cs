/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 04/10/2008
 * Time: 12:24
 * 
 */
namespace awareness.ui
{
    partial class ControlCommandSelector
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
        	this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
        	this.commandBox = new System.Windows.Forms.TextBox();
        	this.browseButton = new System.Windows.Forms.Button();
        	this.testButton = new System.Windows.Forms.Button();
        	this.tablePanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// tablePanel
        	// 
        	this.tablePanel.ColumnCount = 3;
        	this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
        	this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
        	this.tablePanel.Controls.Add(this.commandBox, 0, 0);
        	this.tablePanel.Controls.Add(this.browseButton, 1, 0);
        	this.tablePanel.Controls.Add(this.testButton, 2, 0);
        	this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tablePanel.Location = new System.Drawing.Point(0, 0);
        	this.tablePanel.Name = "tablePanel";
        	this.tablePanel.RowCount = 1;
        	this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tablePanel.Size = new System.Drawing.Size(208, 28);
        	this.tablePanel.TabIndex = 0;
        	// 
        	// commandBox
        	// 
        	this.commandBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
        	this.commandBox.Location = new System.Drawing.Point(3, 4);
        	this.commandBox.Name = "commandBox";
        	this.commandBox.Size = new System.Drawing.Size(120, 20);
        	this.commandBox.TabIndex = 0;
        	this.commandBox.TextChanged += new System.EventHandler(this.CommandBoxTextChanged);
        	// 
        	// browseButton
        	// 
        	this.browseButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.browseButton.Location = new System.Drawing.Point(128, 2);
        	this.browseButton.Margin = new System.Windows.Forms.Padding(2);
        	this.browseButton.Name = "browseButton";
        	this.browseButton.Size = new System.Drawing.Size(26, 24);
        	this.browseButton.TabIndex = 1;
        	this.browseButton.Text = "...";
        	this.browseButton.UseVisualStyleBackColor = true;
        	this.browseButton.Click += new System.EventHandler(this.BrowseButtonClick);
        	// 
        	// testButton
        	// 
        	this.testButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.testButton.Location = new System.Drawing.Point(158, 2);
        	this.testButton.Margin = new System.Windows.Forms.Padding(2);
        	this.testButton.Name = "testButton";
        	this.testButton.Size = new System.Drawing.Size(48, 24);
        	this.testButton.TabIndex = 2;
        	this.testButton.Text = "Test";
        	this.testButton.UseVisualStyleBackColor = true;
        	this.testButton.Click += new System.EventHandler(this.TestButtonClick);
        	// 
        	// ControlCommandSelector
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.tablePanel);
        	this.MinimumSize = new System.Drawing.Size(140, 28);
        	this.Name = "ControlCommandSelector";
        	this.Size = new System.Drawing.Size(208, 28);
        	this.tablePanel.ResumeLayout(false);
        	this.tablePanel.PerformLayout();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.TableLayoutPanel tablePanel;
    }
}
