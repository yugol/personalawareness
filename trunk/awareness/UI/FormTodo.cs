/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 02/12/2008
 * Time: 22:08
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
using System.Windows.Forms;

namespace Awareness.UI
{
    public partial class FormTodo : Form
    {
        public FormTodo()
        {
            InitializeComponent();
            ReadTodoNote();
            Controller.StorageOpened += new DataChangedHandler(StorageOpened);
            Controller.StorageClosing += new DataChangedHandler(StorageClosing);
        }

        void StorageOpened()
        {
            ReadTodoNote();
        }

        void StorageClosing()
        {
            NullifyTodoNote();
        }

        void FormTodoFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }

        void ReadTodoNote()
        {
            noteControl.Note = Controller.Storage.GetTodoNote();
        }

        void NullifyTodoNote()
        {
            Visible = false;
            noteControl.Note = null;
        }

        void FormTodoVisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) {
                noteControl.UpdateNote();
            } else {
                ReadTodoNote();
            }
        }
    }
}
