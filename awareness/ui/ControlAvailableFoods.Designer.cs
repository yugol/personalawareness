﻿/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 11/09/2008
 * Time: 10:56
 * 
 */
namespace awareness.ui
{
    partial class ControlAvailableFoods
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
        	this.availableFoodsView = new System.Windows.Forms.ListView();
        	this.whatColumn = new System.Windows.Forms.ColumnHeader();
        	this.quantityColumn = new System.Windows.Forms.ColumnHeader();
        	this.datePicker = new System.Windows.Forms.DateTimePicker();
        	this.quantityBox = new System.Windows.Forms.TextBox();
        	this.whatBox = new System.Windows.Forms.TextBox();
        	this.consumeButton = new System.Windows.Forms.Button();
        	this.availableFoodsBottomPanel = new System.Windows.Forms.TableLayoutPanel();
        	this.whyCombo = new System.Windows.Forms.ComboBox();
        	this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        	this.availableFoodsBottomPanel.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// availableFoodsView
        	// 
        	this.availableFoodsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        	        	        	this.whatColumn,
        	        	        	this.quantityColumn});
        	this.availableFoodsView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.availableFoodsView.FullRowSelect = true;
        	this.availableFoodsView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
        	this.availableFoodsView.HideSelection = false;
        	this.availableFoodsView.Location = new System.Drawing.Point(0, 0);
        	this.availableFoodsView.MultiSelect = false;
        	this.availableFoodsView.Name = "availableFoodsView";
        	this.availableFoodsView.Size = new System.Drawing.Size(509, 268);
        	this.availableFoodsView.TabIndex = 3;
        	this.availableFoodsView.UseCompatibleStateImageBehavior = false;
        	this.availableFoodsView.View = System.Windows.Forms.View.Details;
        	this.availableFoodsView.SelectedIndexChanged += new System.EventHandler(this.AvailableFoodsViewSelectedIndexChanged);
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
        	// datePicker
        	// 
        	this.datePicker.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        	this.datePicker.Location = new System.Drawing.Point(0, 3);
        	this.datePicker.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
        	this.datePicker.Name = "datePicker";
        	this.datePicker.Size = new System.Drawing.Size(98, 20);
        	this.datePicker.TabIndex = 0;
        	// 
        	// quantityBox
        	// 
        	this.quantityBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.quantityBox.Location = new System.Drawing.Point(282, 3);
        	this.quantityBox.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
        	this.quantityBox.Name = "quantityBox";
        	this.quantityBox.Size = new System.Drawing.Size(57, 20);
        	this.quantityBox.TabIndex = 1;
        	this.quantityBox.Validating += new System.ComponentModel.CancelEventHandler(this.QuantityBoxValidating);
        	// 
        	// whatBox
        	// 
        	this.whatBox.Cursor = System.Windows.Forms.Cursors.Arrow;
        	this.whatBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.whatBox.Location = new System.Drawing.Point(104, 3);
        	this.whatBox.Name = "whatBox";
        	this.whatBox.ReadOnly = true;
        	this.whatBox.Size = new System.Drawing.Size(172, 20);
        	this.whatBox.TabIndex = 2;
        	// 
        	// consumeButton
        	// 
        	this.consumeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.availableFoodsBottomPanel.SetColumnSpan(this.consumeButton, 4);
        	this.consumeButton.Location = new System.Drawing.Point(418, 32);
        	this.consumeButton.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
        	this.consumeButton.Name = "consumeButton";
        	this.consumeButton.Size = new System.Drawing.Size(75, 23);
        	this.consumeButton.TabIndex = 3;
        	this.consumeButton.Text = "&Consume";
        	this.consumeButton.UseVisualStyleBackColor = true;
        	this.consumeButton.Click += new System.EventHandler(this.ConsumeButtonClick);
        	// 
        	// availableFoodsBottomPanel
        	// 
        	this.availableFoodsBottomPanel.ColumnCount = 4;
        	this.availableFoodsBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        	this.availableFoodsBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
        	this.availableFoodsBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
        	this.availableFoodsBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
        	this.availableFoodsBottomPanel.Controls.Add(this.datePicker, 0, 0);
        	this.availableFoodsBottomPanel.Controls.Add(this.quantityBox, 2, 0);
        	this.availableFoodsBottomPanel.Controls.Add(this.whatBox, 1, 0);
        	this.availableFoodsBottomPanel.Controls.Add(this.consumeButton, 0, 1);
        	this.availableFoodsBottomPanel.Controls.Add(this.whyCombo, 3, 0);
        	this.availableFoodsBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.availableFoodsBottomPanel.Location = new System.Drawing.Point(0, 268);
        	this.availableFoodsBottomPanel.Name = "availableFoodsBottomPanel";
        	this.availableFoodsBottomPanel.RowCount = 2;
        	this.availableFoodsBottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
        	this.availableFoodsBottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
        	this.availableFoodsBottomPanel.Size = new System.Drawing.Size(509, 58);
        	this.availableFoodsBottomPanel.TabIndex = 2;
        	// 
        	// whyCombo
        	// 
        	this.whyCombo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.whyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.whyCombo.FormattingEnabled = true;
        	this.whyCombo.Location = new System.Drawing.Point(358, 3);
        	this.whyCombo.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
        	this.whyCombo.Name = "whyCombo";
        	this.whyCombo.Size = new System.Drawing.Size(135, 21);
        	this.whyCombo.TabIndex = 4;
        	this.whyCombo.SelectedIndexChanged += new System.EventHandler(this.WhyComboSelectedIndexChanged);
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// ControlAvailableFoods
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.availableFoodsView);
        	this.Controls.Add(this.availableFoodsBottomPanel);
        	this.Name = "ControlAvailableFoods";
        	this.Size = new System.Drawing.Size(509, 326);
        	this.availableFoodsBottomPanel.ResumeLayout(false);
        	this.availableFoodsBottomPanel.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox whyCombo;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TableLayoutPanel availableFoodsBottomPanel;
        private System.Windows.Forms.Button consumeButton;
        private System.Windows.Forms.TextBox whatBox;
        private System.Windows.Forms.TextBox quantityBox;
        private System.Windows.Forms.ColumnHeader quantityColumn;
        private System.Windows.Forms.ColumnHeader whatColumn;
        private System.Windows.Forms.ListView availableFoodsView;
    }
}
