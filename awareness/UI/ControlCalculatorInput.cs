/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 26/11/2008
 * Time: 13:21
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


using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Awareness.ui
{
    public partial class ControlCalculatorInput : UserControl {
        public event EventHandler ValueChanged;

        public double Value {
            get
            {
                double val = 0;
                try {
                    val = Math.Round(double.Parse(valueBox.Text));
                } catch (Exception) {
                }
                return val;
            }
            set { valueBox.Text = Math.Round(value).ToString(); }
        }

        public ControlCalculatorInput(){
            InitializeComponent();
        }

        void CalculatorButtonClick(object sender, EventArgs e){
            FormCalculatorInput calculatorForm = new FormCalculatorInput();
            if (!double.IsNaN(Value)){
                calculatorForm.Value = Value;
            }
            calculatorForm.Location = PointToScreen(calculatorButton.Location);
            if (calculatorForm.ShowDialog() == DialogResult.OK) {
                Value = calculatorForm.Value;
            }
        }

        void ValueBoxTextChanged(object sender, EventArgs e){
            if (ValueChanged != null){
                ValueChanged(sender, e);
            }
        }
        
        public void SetToolTip(string tip) {
            toolTip.SetToolTip(valueBox, tip);
            toolTip.SetToolTip(calculatorButton, tip);
        }
    }
}
