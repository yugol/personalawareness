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
 * Date: 26/10/2008
 * Time: 20:19
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace awareness.ui
{
    /// <summary>
    /// Description of FormCalculatorInput.
    /// </summary>
    public partial class FormCalculatorInput : Form
    {
        private CalculatorLogic calc = new CalculatorLogic();
        
        bool isModal;
        public bool IsModal
        {
            get { return isModal; }
            set 
            { 
                isModal = value;
                buttonOk.Visible = isModal;
                buttonCancel.Visible = isModal;
            }
        }
        
        
        public FormCalculatorInput()
        {
            InitializeComponent();
            
            IsModal = true;
            outputLabel.Text = calc.ValueString;
        }
        
        void Button1Click(object sender, EventArgs e)
        {
            calc.WriteChar('1');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button2Click(object sender, EventArgs e)
        {
            calc.WriteChar('2');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button3Click(object sender, EventArgs e)
        {
            calc.WriteChar('3');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button4Click(object sender, EventArgs e)
        {
            calc.WriteChar('4');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button5Click(object sender, EventArgs e)
        {
            calc.WriteChar('5');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button6Click(object sender, EventArgs e)
        {
            calc.WriteChar('6');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button7Click(object sender, EventArgs e)
        {
            calc.WriteChar('7');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button8Click(object sender, EventArgs e)
        {
            calc.WriteChar('8');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button9Click(object sender, EventArgs e)
        {
            calc.WriteChar('9');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button0Click(object sender, EventArgs e)
        {
            calc.WriteChar('0');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonSignClick(object sender, EventArgs e)
        {
            calc.WriteChar('~');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonDotClick(object sender, EventArgs e)
        {
            calc.WriteChar('.');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonPlusClick(object sender, EventArgs e)
        {
            calc.WriteChar('+');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonMinusClick(object sender, EventArgs e)
        {
            calc.WriteChar('-');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonMultiplyClick(object sender, EventArgs e)
        {
            calc.WriteChar('*');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonDivideClick(object sender, EventArgs e)
        {
            calc.WriteChar('/');
            outputLabel.Text = calc.ValueString;
        }
        
        
        void ButtonEqualsClick(object sender, EventArgs e)
        {
            calc.WriteChar('=');
            outputLabel.Text = calc.ValueString;
        }
                
        void ButtonClearEverythingClick(object sender, EventArgs e)
        {
            calc.WriteChar('C');
            outputLabel.Text = calc.ValueString;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!IsModal)
            {
                e.Cancel = true;
                Visible = false;
            }
        }
        
    }
}