/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 19/11/2008
 * Time: 13:33
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
    public partial class FormNoteTextView : Form {
        public event NoteHandler NoteTextChanged;

        public DalNote Note
        {
            get { return noteControl.Note; }
            set
            {
                noteControl.Note = value;
                if (value != null){
                    Text = value.Title;
                } else {
                    Text = "~no~note~";
                }
            }
        }

        public FormNoteTextView()
        {
            InitializeComponent();
        }

        void NoteControlNoteTextChanged(object sender, DalNote note)
        {
            if (NoteTextChanged != null){
                NoteTextChanged(sender, note);
            }
        }
    }
}