/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 11/09/2008
 * Time: 12:06
 * 
 */
namespace awareness.ui
{
    partial class ControlMealsDailyReport
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
        	this.bottomPanel = new System.Windows.Forms.FlowLayoutPanel();
        	this.energyMeasureUnitLabel = new System.Windows.Forms.Label();
        	this.energyValueLabel = new System.Windows.Forms.Label();
        	this.energyNameLabel = new System.Windows.Forms.Label();
        	this.mealsView = new System.Windows.Forms.ListView();
        	this.whatColumn = new System.Windows.Forms.ColumnHeader();
        	this.quantityColumn = new System.Windows.Forms.ColumnHeader();
        	this.energyColumn = new System.Windows.Forms.ColumnHeader();
        	this.topPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.whyCombo = new System.Windows.Forms.ComboBox();
        	this.datePicker = new awareness.ui.ControlJumperDatePicker();
        	this.bottomPanel.SuspendLayout();
        	this.topPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// bottomPanel
        	// 
        	this.bottomPanel.Controls.Add(this.energyMeasureUnitLabel);
        	this.bottomPanel.Controls.Add(this.energyValueLabel);
        	this.bottomPanel.Controls.Add(this.energyNameLabel);
        	this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.bottomPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        	this.bottomPanel.Location = new System.Drawing.Point(0, 323);
        	this.bottomPanel.Name = "bottomPanel";
        	this.bottomPanel.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
        	this.bottomPanel.Size = new System.Drawing.Size(473, 26);
        	this.bottomPanel.TabIndex = 1;
        	// 
        	// energyMeasureUnitLabel
        	// 
        	this.energyMeasureUnitLabel.AutoSize = true;
        	this.energyMeasureUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.energyMeasureUnitLabel.Location = new System.Drawing.Point(438, 7);
        	this.energyMeasureUnitLabel.Name = "energyMeasureUnitLabel";
        	this.energyMeasureUnitLabel.Size = new System.Drawing.Size(32, 13);
        	this.energyMeasureUnitLabel.TabIndex = 1;
        	this.energyMeasureUnitLabel.Text = "Kcal";
        	this.energyMeasureUnitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// energyValueLabel
        	// 
        	this.energyValueLabel.AutoSize = true;
        	this.energyValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.energyValueLabel.Location = new System.Drawing.Point(393, 7);
        	this.energyValueLabel.Name = "energyValueLabel";
        	this.energyValueLabel.Size = new System.Drawing.Size(39, 13);
        	this.energyValueLabel.TabIndex = 0;
        	this.energyValueLabel.Text = "0,000";
        	this.energyValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// energyNameLabel
        	// 
        	this.energyNameLabel.AutoSize = true;
        	this.energyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.energyNameLabel.Location = new System.Drawing.Point(305, 7);
        	this.energyNameLabel.Name = "energyNameLabel";
        	this.energyNameLabel.Size = new System.Drawing.Size(82, 13);
        	this.energyNameLabel.TabIndex = 2;
        	this.energyNameLabel.Text = "Total energy:";
        	this.energyNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// mealsView
        	// 
        	this.mealsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        	        	        	this.whatColumn,
        	        	        	this.quantityColumn,
        	        	        	this.energyColumn});
        	this.mealsView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mealsView.FullRowSelect = true;
        	this.mealsView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        	this.mealsView.Location = new System.Drawing.Point(0, 25);
        	this.mealsView.MultiSelect = false;
        	this.mealsView.Name = "mealsView";
        	this.mealsView.Size = new System.Drawing.Size(473, 298);
        	this.mealsView.TabIndex = 2;
        	this.mealsView.UseCompatibleStateImageBehavior = false;
        	this.mealsView.View = System.Windows.Forms.View.Details;
        	// 
        	// whatColumn
        	// 
        	this.whatColumn.Text = "What";
        	this.whatColumn.Width = 200;
        	// 
        	// quantityColumn
        	// 
        	this.quantityColumn.Text = "Quantity";
        	this.quantityColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.quantityColumn.Width = 100;
        	// 
        	// energyColumn
        	// 
        	this.energyColumn.Text = "Energy";
        	this.energyColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        	this.energyColumn.Width = 100;
        	// 
        	// topPanel
        	// 
        	this.topPanel.ColumnCount = 2;
        	this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 310F));
        	this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        	this.topPanel.Controls.Add(this.whyCombo, 1, 0);
        	this.topPanel.Controls.Add(this.datePicker, 0, 0);
        	this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
        	this.topPanel.Location = new System.Drawing.Point(0, 0);
        	this.topPanel.Name = "topPanel";
        	this.topPanel.RowCount = 1;
        	this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.topPanel.Size = new System.Drawing.Size(473, 25);
        	this.topPanel.TabIndex = 3;
        	// 
        	// whyCombo
        	// 
        	this.whyCombo.Dock = System.Windows.Forms.DockStyle.Right;
        	this.whyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.whyCombo.FormattingEnabled = true;
        	this.whyCombo.Location = new System.Drawing.Point(323, 2);
        	this.whyCombo.Margin = new System.Windows.Forms.Padding(3, 2, 0, 3);
        	this.whyCombo.Name = "whyCombo";
        	this.whyCombo.Size = new System.Drawing.Size(150, 21);
        	this.whyCombo.TabIndex = 4;
        	this.whyCombo.SelectedIndexChanged += new System.EventHandler(this.WhyComboSelectedIndexChanged);
        	// 
        	// datePicker
        	// 
        	this.datePicker.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.datePicker.JumpSize = awareness.ui.JumpSize.Day;
        	this.datePicker.Location = new System.Drawing.Point(0, 3);
        	this.datePicker.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
        	this.datePicker.MinimumSize = new System.Drawing.Size(244, 20);
        	this.datePicker.Name = "datePicker";
        	this.datePicker.Size = new System.Drawing.Size(307, 20);
        	this.datePicker.TabIndex = 5;
        	this.datePicker.Value = new System.DateTime(2008, 10, 3, 19, 46, 55, 979);
        	// 
        	// ControlMealsDailyReport
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.mealsView);
        	this.Controls.Add(this.topPanel);
        	this.Controls.Add(this.bottomPanel);
        	this.Name = "ControlMealsDailyReport";
        	this.Size = new System.Drawing.Size(473, 349);
        	this.Load += new System.EventHandler(this.ControlMealsDailyReportLoad);
        	this.bottomPanel.ResumeLayout(false);
        	this.bottomPanel.PerformLayout();
        	this.topPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private awareness.ui.ControlJumperDatePicker datePicker;
        private System.Windows.Forms.ComboBox whyCombo;
        private System.Windows.Forms.ColumnHeader energyColumn;
        private System.Windows.Forms.ColumnHeader quantityColumn;
        private System.Windows.Forms.ColumnHeader whatColumn;
        private System.Windows.Forms.Label energyNameLabel;
        private System.Windows.Forms.ListView mealsView;
        private System.Windows.Forms.Label energyMeasureUnitLabel;
        private System.Windows.Forms.Label energyValueLabel;
        private System.Windows.Forms.FlowLayoutPanel bottomPanel;
        private System.Windows.Forms.TableLayoutPanel topPanel;
    }
}
