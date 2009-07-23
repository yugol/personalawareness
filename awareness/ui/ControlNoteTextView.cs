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
 * Date: 25/09/2008
 * Time: 14:45
 *
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Awareness.db;

namespace Awareness.ui
{
    public partial class ControlNoteTextView : UserControl {
        public event NoteHandler NoteTextChanged;

        TreeNode node = null;
        public TreeNode Node
        {
            get { return node; }
            set
            {
                node = value;
                if (node != null){
                    Note = (DalNote) node.Tag;
                }
            }
        }

        DalNote note;
        public DalNote Note
        {
            get
            {
                if (note != null){
                    note.Title = titleBox.Text;
                    note.Text = textBox.Text;
                }
                return note;
            }
            set
            {
                note = value;
                if (note == null){
                    iconsPicture.Image = null;
                    titleBox.Text = "";
                    creationTimeBox.Text = "";
                    textBox.Text = "";
                } else {
                    // iconsPicture.Image = null;
                    titleBox.Text = note.Title;
                    creationTimeBox.Text = note.CreationTime.ToString(Configuration.DATE_FULL_TIME_FORMAT);
                    textBox.Text = note.Text;
                    TitleReadOnly = note.IsPermanent;
                }
            }
        }

        public bool TopVisible
        {
            get { return topPanel.Visible; }
            set { topPanel.Visible = value; }
        }

        public bool ScrollBars
        {
            get { return textBox.ScrollBars == System.Windows.Forms.ScrollBars.Both; }
            set
            {
                if (value){
                    textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
                } else {
                    textBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
                }
            }
        }

        public bool IconVisible
        {
            get { return iconsPicture.Visible; }
            set { iconsPicture.Visible = value; }
        }

        public bool TitleReadOnly
        {
            get { return titleBox.ReadOnly; }
            set { titleBox.ReadOnly = value; }
        }

        public bool TextReadOnly
        {
            get { return textBox.ReadOnly; }
            set { textBox.ReadOnly = value; }
        }

        public ControlNoteTextView(){
            InitializeComponent();
            titleBox.MaxLength = int.Parse(DalNote.MAX_TITLE_CHAR_COUNT);
            Note = null;
            TopVisible = true;
            ScrollBars = true;
            TitleReadOnly = false;
            TextReadOnly = false;
            Controller.StorageClosing += new DataChangedHandler(UpdateNote);
        }

        public void FocusTitle(){
            titleBox.Focus();
        }

        public void UpdateNote(){
            if (Note != null){
                Controller.Storage.UpdateNote(Note);
            }
        }

        void TitleBoxLeave(object sender, EventArgs e){
            UpdateNote();
        }

        void TextBoxLeave(object sender, EventArgs e){
            UpdateNote();
        }

        void TitleBoxTextChanged(object sender, EventArgs e){
            if (Node != null){
                Node.Text = titleBox.Text;
            }
        }

        void TitleBoxKeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Enter){
                textBox.Focus();
            }
        }

        void TitleBoxEnter(object sender, EventArgs e){
            titleBox.SelectAll();
        }

        void TextBoxTextChanged(object sender, EventArgs e){
            if (NoteTextChanged != null){
                NoteTextChanged(sender, Note);
            }
        }
    }
}
