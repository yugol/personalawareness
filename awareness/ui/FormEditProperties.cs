/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 04/12/2008
 * Time: 00:33
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
using System.Drawing;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness.UI
{
    public partial class FormEditProperties : Form {
        public FormEditProperties(){
            InitializeComponent();
            Data2Ui();
        }

        void Data2Ui() {
            symbolBox.Text = Configuration.DBProperties.CurrencySymbol;
            placementCheck.Checked = Configuration.DBProperties.PlaceCurrencySymbolAfterValue;
        }

        void Ui2Data() {
            Configuration.DBProperties.CurrencySymbol = symbolBox.Text;
            Configuration.DBProperties.PlaceCurrencySymbolAfterValue = placementCheck.Checked;
            DBUtil.UpdateProperties();
        }
        
        void SymbolBoxValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(symbolBox.Text.Trim())){
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Please enter a non-empty name");
            } else {
                errorProvider.Clear();
            }
        }
        
        void OkButtonClick(object sender, EventArgs e)
        {
        	Ui2Data();
        }
    }
}
