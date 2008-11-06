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
 * Date: 02/11/2008
 * Time: 19:37
 * 
 */
using System;
using System.Windows.Forms;

namespace awareness.ui
{
    partial class ControlTransactions
    {
        int selectPanelNormalHeight;


        public bool SelectPanelExpanded
        {
            get { return (selectLayoutLabel.ImageIndex == 0); }
            set
            {
                if (value)
                {
                    selectLayoutLabel.ImageIndex = 0;
                    selectPanel.Height = selectPanelNormalHeight;
                    foreach (Control c in selectPanel.Controls)
                    {
                        c.Visible = true;
                    }
                }
                else
                {
                    selectLayoutLabel.ImageIndex = 1;
                    selectPanel.Height = selectLayoutLabel.Height + selectLayoutLabel.Margin.Top + 2;
                    foreach (Control c in selectPanel.Controls)
                    {
                        if (!c.Equals(selectLayoutLabel))
                        {
                            c.Visible = false;
                        }
                    }
                }
            }
        }
        
        void SelectLayoutLabelClick(object sender, EventArgs e){
            SelectPanelExpanded = !SelectPanelExpanded;
        }
        
    }
}
