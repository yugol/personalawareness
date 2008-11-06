/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 10/09/2008
 * Time: 16:04
 * 
 */
namespace awareness.ui
{
    partial class FormManageMeals
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
        	this.listPanel = new System.Windows.Forms.Panel();
        	this.mealsView = new System.Windows.Forms.ListView();
        	this.whenColumn = new System.Windows.Forms.ColumnHeader();
        	this.whatColumn = new System.Windows.Forms.ColumnHeader();
        	this.quantityColumn = new System.Windows.Forms.ColumnHeader();
        	this.whyColumn = new System.Windows.Forms.ColumnHeader();
        	this.topPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.bottomPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.deleteButton = new System.Windows.Forms.Button();
        	this.listPanel.SuspendLayout();
        	this.bottomPanel.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// listPanel
        	// 
        	this.listPanel.Controls.Add(this.mealsView);
        	this.listPanel.Controls.Add(this.topPanel);
        	this.listPanel.Controls.Add(this.bottomPanel);
        	this.listPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.listPanel.Location = new System.Drawing.Point(0, 0);
        	this.listPanel.Name = "listPanel";
        	this.listPanel.Size = new System.Drawing.Size(632, 450);
        	this.listPanel.TabIndex = 0;
        	// 
        	// mealsView
        	// 
        	this.mealsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        	        	        	this.whenColumn,
        	        	        	this.whatColumn,
        	        	        	this.quantityColumn,
        	        	        	this.whyColumn});
        	this.mealsView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.mealsView.FullRowSelect = true;
        	this.mealsView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        	this.mealsView.Location = new System.Drawing.Point(0, 3);
        	this.mealsView.MultiSelect = false;
        	this.mealsView.Name = "mealsView";
        	this.mealsView.Size = new System.Drawing.Size(632, 418);
        	this.mealsView.TabIndex = 0;
        	this.mealsView.UseCompatibleStateImageBehavior = false;
        	this.mealsView.View = System.Windows.Forms.View.Details;
        	this.mealsView.SelectedIndexChanged += new System.EventHandler(this.MealsViewSelectedIndexChanged);
        	// 
        	// whenColumn
        	// 
        	this.whenColumn.Text = "When";
        	this.whenColumn.Width = 100;
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
        	// whyColumn
        	// 
        	this.whyColumn.Text = "Why";
        	this.whyColumn.Width = 200;
        	// 
        	// topPanel
        	// 
        	this.topPanel.ColumnCount = 1;
        	this.topPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
        	this.topPanel.Location = new System.Drawing.Point(0, 0);
        	this.topPanel.Name = "topPanel";
        	this.topPanel.RowCount = 1;
        	this.topPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.topPanel.Size = new System.Drawing.Size(632, 3);
        	this.topPanel.TabIndex = 2;
        	// 
        	// bottomPanel
        	// 
        	this.bottomPanel.ColumnCount = 1;
        	this.bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        	this.bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.bottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        	this.bottomPanel.Controls.Add(this.deleteButton, 0, 0);
        	this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.bottomPanel.Location = new System.Drawing.Point(0, 421);
        	this.bottomPanel.Name = "bottomPanel";
        	this.bottomPanel.RowCount = 1;
        	this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.bottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        	this.bottomPanel.Size = new System.Drawing.Size(632, 29);
        	this.bottomPanel.TabIndex = 1;
        	// 
        	// deleteButton
        	// 
        	this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.deleteButton.Location = new System.Drawing.Point(554, 3);
        	this.deleteButton.Name = "deleteButton";
        	this.deleteButton.Size = new System.Drawing.Size(75, 23);
        	this.deleteButton.TabIndex = 4;
        	this.deleteButton.Text = "&Delete";
        	this.deleteButton.UseVisualStyleBackColor = true;
        	this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
        	// 
        	// FormManageMeals
        	// 
        	this.AcceptButton = this.deleteButton;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(632, 450);
        	this.Controls.Add(this.listPanel);
        	this.Name = "FormManageMeals";
        	this.Text = "Meals";
        	this.listPanel.ResumeLayout(false);
        	this.bottomPanel.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ColumnHeader whyColumn;
        private System.Windows.Forms.TableLayoutPanel topPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TableLayoutPanel bottomPanel;
        private System.Windows.Forms.ColumnHeader quantityColumn;
        private System.Windows.Forms.ColumnHeader whatColumn;
        private System.Windows.Forms.ColumnHeader whenColumn;
        private System.Windows.Forms.ListView mealsView;
        private System.Windows.Forms.Panel listPanel;
    }
}
