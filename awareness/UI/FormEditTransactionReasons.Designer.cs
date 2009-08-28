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
 * Date: 05/09/2008
 * Time: 09:00
 * 
 */
namespace Awareness.ui
{
    partial class FormEditTransactionReasons
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
        	this.closeButton = new System.Windows.Forms.Button();
        	this.deleteButton = new System.Windows.Forms.Button();
        	this.updateButton = new System.Windows.Forms.Button();
        	this.newButton = new System.Windows.Forms.Button();
        	this.label1 = new System.Windows.Forms.Label();
        	this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
        	this.typeLabel = new System.Windows.Forms.Label();
        	this.typeCombo = new System.Windows.Forms.ComboBox();
        	this.energyLabel = new System.Windows.Forms.Label();
        	this.energyBox = new System.Windows.Forms.TextBox();
        	this.energyMeasureUnitLabel = new System.Windows.Forms.Label();
        	this.selectedTypeCombo = new System.Windows.Forms.ComboBox();
        	this.lastMealButton = new System.Windows.Forms.Button();
        	this.averageMealsButton = new System.Windows.Forms.Button();
        	this.reasonCombo = new System.Windows.Forms.ComboBox();
        	this.noteControl = new Awareness.ui.ControlAddNote();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// closeButton
        	// 
        	this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.closeButton.Location = new System.Drawing.Point(344, 128);
        	this.closeButton.Name = "closeButton";
        	this.closeButton.Size = new System.Drawing.Size(75, 23);
        	this.closeButton.TabIndex = 11;
        	this.closeButton.Text = "&Close";
        	this.closeButton.UseVisualStyleBackColor = true;
        	// 
        	// deleteButton
        	// 
        	this.deleteButton.Enabled = false;
        	this.deleteButton.Location = new System.Drawing.Point(344, 80);
        	this.deleteButton.Name = "deleteButton";
        	this.deleteButton.Size = new System.Drawing.Size(75, 23);
        	this.deleteButton.TabIndex = 10;
        	this.deleteButton.Text = "&Delete";
        	this.deleteButton.UseVisualStyleBackColor = true;
        	this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
        	// 
        	// updateButton
        	// 
        	this.updateButton.Enabled = false;
        	this.updateButton.Location = new System.Drawing.Point(344, 48);
        	this.updateButton.Name = "updateButton";
        	this.updateButton.Size = new System.Drawing.Size(75, 23);
        	this.updateButton.TabIndex = 9;
        	this.updateButton.Text = "&Update";
        	this.updateButton.UseVisualStyleBackColor = true;
        	this.updateButton.Click += new System.EventHandler(this.UpdateButtonClick);
        	// 
        	// newButton
        	// 
        	this.newButton.Enabled = false;
        	this.newButton.Location = new System.Drawing.Point(344, 16);
        	this.newButton.Name = "newButton";
        	this.newButton.Size = new System.Drawing.Size(75, 23);
        	this.newButton.TabIndex = 8;
        	this.newButton.Text = "&New";
        	this.newButton.UseVisualStyleBackColor = true;
        	this.newButton.Click += new System.EventHandler(this.NewButtonClick);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(8, 8);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(81, 13);
        	this.label1.TabIndex = 9;
        	this.label1.Text = "Stored reasons:";
        	// 
        	// errorProvider
        	// 
        	this.errorProvider.ContainerControl = this;
        	// 
        	// typeLabel
        	// 
        	this.typeLabel.AutoSize = true;
        	this.typeLabel.Location = new System.Drawing.Point(168, 32);
        	this.typeLabel.Name = "typeLabel";
        	this.typeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
        	this.typeLabel.Size = new System.Drawing.Size(34, 13);
        	this.typeLabel.TabIndex = 17;
        	this.typeLabel.Text = "Type:";
        	// 
        	// typeCombo
        	// 
        	this.typeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.typeCombo.FormattingEnabled = true;
        	this.typeCombo.Location = new System.Drawing.Point(168, 48);
        	this.typeCombo.Name = "typeCombo";
        	this.typeCombo.Size = new System.Drawing.Size(160, 21);
        	this.typeCombo.TabIndex = 3;
        	this.typeCombo.SelectedIndexChanged += new System.EventHandler(this.TypeComboSelectedIndexChanged);
        	// 
        	// energyLabel
        	// 
        	this.energyLabel.AutoSize = true;
        	this.energyLabel.Location = new System.Drawing.Point(168, 80);
        	this.energyLabel.Name = "energyLabel";
        	this.energyLabel.Size = new System.Drawing.Size(40, 13);
        	this.energyLabel.TabIndex = 19;
        	this.energyLabel.Text = "Energy";
        	// 
        	// energyBox
        	// 
        	this.energyBox.Location = new System.Drawing.Point(168, 96);
        	this.energyBox.Name = "energyBox";
        	this.energyBox.Size = new System.Drawing.Size(160, 20);
        	this.energyBox.TabIndex = 4;
        	this.energyBox.TextChanged += new System.EventHandler(this.EnergyBoxTextChanged);
        	this.energyBox.Validating += new System.ComponentModel.CancelEventHandler(this.EnergyBoxValidating);
        	// 
        	// energyMeasureUnitLabel
        	// 
        	this.energyMeasureUnitLabel.AutoSize = true;
        	this.energyMeasureUnitLabel.Location = new System.Drawing.Point(208, 80);
        	this.energyMeasureUnitLabel.Name = "energyMeasureUnitLabel";
        	this.energyMeasureUnitLabel.Size = new System.Drawing.Size(76, 13);
        	this.energyMeasureUnitLabel.TabIndex = 21;
        	this.energyMeasureUnitLabel.Text = "mmmm/mmmm";
        	// 
        	// selectedTypeCombo
        	// 
        	this.selectedTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.selectedTypeCombo.FormattingEnabled = true;
        	this.selectedTypeCombo.Location = new System.Drawing.Point(8, 24);
        	this.selectedTypeCombo.Name = "selectedTypeCombo";
        	this.selectedTypeCombo.Size = new System.Drawing.Size(144, 21);
        	this.selectedTypeCombo.TabIndex = 1;
        	this.selectedTypeCombo.SelectedIndexChanged += new System.EventHandler(this.SelectedTypeComboSelectedIndexChanged);
        	// 
        	// lastMealButton
        	// 
        	this.lastMealButton.Location = new System.Drawing.Point(176, 120);
        	this.lastMealButton.Name = "lastMealButton";
        	this.lastMealButton.Size = new System.Drawing.Size(152, 23);
        	this.lastMealButton.TabIndex = 5;
        	this.lastMealButton.Text = "Calculate based on &last meal";
        	this.lastMealButton.UseVisualStyleBackColor = true;
        	this.lastMealButton.Click += new System.EventHandler(this.LastMealButtonClick);
        	// 
        	// averageMealsButton
        	// 
        	this.averageMealsButton.Location = new System.Drawing.Point(176, 144);
        	this.averageMealsButton.Name = "averageMealsButton";
        	this.averageMealsButton.Size = new System.Drawing.Size(152, 23);
        	this.averageMealsButton.TabIndex = 6;
        	this.averageMealsButton.Text = "&Average on all meals";
        	this.averageMealsButton.UseVisualStyleBackColor = true;
        	this.averageMealsButton.Click += new System.EventHandler(this.Button1Click);
        	// 
        	// reasonCombo
        	// 
        	this.reasonCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
        	this.reasonCombo.FormattingEnabled = true;
        	this.reasonCombo.Location = new System.Drawing.Point(8, 48);
        	this.reasonCombo.Name = "reasonCombo";
        	this.reasonCombo.Size = new System.Drawing.Size(144, 208);
        	this.reasonCombo.TabIndex = 2;
        	this.reasonCombo.SelectedIndexChanged += new System.EventHandler(this.ReasonComboSelectedIndexChanged);
        	this.reasonCombo.TextChanged += new System.EventHandler(this.ReasonComboTextChanged);
        	// 
        	// noteControl
        	// 
        	this.noteControl.Location = new System.Drawing.Point(168, 184);
        	this.noteControl.Name = "noteControl";
        	this.noteControl.Note = null;
        	this.noteControl.Size = new System.Drawing.Size(250, 72);
        	this.noteControl.TabIndex = 7;
        	// 
        	// FormEditTransactionReasons
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.CancelButton = this.closeButton;
        	this.ClientSize = new System.Drawing.Size(426, 262);
        	this.Controls.Add(this.noteControl);
        	this.Controls.Add(this.reasonCombo);
        	this.Controls.Add(this.averageMealsButton);
        	this.Controls.Add(this.lastMealButton);
        	this.Controls.Add(this.selectedTypeCombo);
        	this.Controls.Add(this.energyMeasureUnitLabel);
        	this.Controls.Add(this.energyBox);
        	this.Controls.Add(this.energyLabel);
        	this.Controls.Add(this.typeCombo);
        	this.Controls.Add(this.typeLabel);
        	this.Controls.Add(this.closeButton);
        	this.Controls.Add(this.deleteButton);
        	this.Controls.Add(this.updateButton);
        	this.Controls.Add(this.newButton);
        	this.Controls.Add(this.label1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormEditTransactionReasons";
        	this.ShowInTaskbar = false;
        	this.Text = "Transfer Reasons";
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ComboBox reasonCombo;
        private Awareness.ui.ControlAddNote noteControl;
        private System.Windows.Forms.Button averageMealsButton;
        private System.Windows.Forms.Button lastMealButton;
        private System.Windows.Forms.ComboBox selectedTypeCombo;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox typeCombo;
        private System.Windows.Forms.Label energyLabel;
        private System.Windows.Forms.TextBox energyBox;
        private System.Windows.Forms.Label energyMeasureUnitLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button closeButton;
    }
}
