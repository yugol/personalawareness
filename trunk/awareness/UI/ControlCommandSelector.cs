/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 04/10/2008
 * Time: 12:24
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
    public partial class ControlCommandSelector : UserControl {
        public event EventHandler CommandChanged;
        public event EventHandler TestClick;

        public string Command
        {
            get { return commandBox.Text; }
            set { commandBox.Text = value; }
        }

        public ControlCommandSelector(){
            InitializeComponent();
        }

        void CommandBoxTextChanged(object sender, EventArgs e){
            if (CommandChanged != null){
                CommandChanged(this, e);
            }
        }

        void BrowseButtonClick(object sender, EventArgs e){
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK){
                Command = ofd.FileName;
            }
        }

        void TestButtonClick(object sender, EventArgs e){
            if (TestClick != null){
                TestClick(this, e);
            }
        }
    }
}
