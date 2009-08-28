/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 19/11/2008
 * Time: 08:21
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
using Awareness.db;

namespace Awareness.ui
{
    public partial class ControlAddNote : UserControl {
        public event NoteHandler NoteAdded;
        public event NoteHandler NoteTextChanged;
        public event NoteHandler NoteRemoved;

        public DalNote Note {
            get { return noteControl.Note; }
            set {
                if (value != null && value.Id == DataStorage.NOTE_ROOT_ID){
                    value = null;
                }
                noteControl.Note = value;
                topPanel.Visible = (value == null);
                centerPanel.Visible = !(value == null);
            }
        }

        public ControlAddNote(){
            InitializeComponent();
            Note = null;
        }

        void AddNoteButtonClick(object sender, EventArgs e){
            Note = new DalNote();
            if (NoteAdded != null){
                NoteAdded(sender, Note);
            }
        }

        void NoteControlNoteTextChanged(object sender, DalNote note){
            if (NoteTextChanged != null){
                NoteTextChanged(sender, note);
            }
        }

        void EnlargeBoxClick(object sender, EventArgs e){
            FormNoteTextView formView = new FormNoteTextView();
            formView.Note = Note;
            formView.Text = string.IsNullOrEmpty(Note.Title) ? "New note" : Note.Title;
            formView.NoteTextChanged += new NoteHandler(NoteControlNoteTextChanged);
            noteControl.Visible = false;
            formView.ShowDialog();
            Note = formView.Note;
            noteControl.Visible = true;
            formView.Dispose();
        }

        void DeleteBoxClick(object sender, EventArgs e){
            if (MessageBox.Show("Are you sure you want to delete this note?",
                                Note.Title,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes){
                if (NoteRemoved != null){
                    NoteRemoved(sender, Note);
                }
                Note = null;
            }
        }
    }
}
