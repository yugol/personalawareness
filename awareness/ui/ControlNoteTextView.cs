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

using awareness.db;

namespace awareness.ui
{
    public partial class ControlNoteTextView : UserControl
    {
        public event EventHandler NoteTextChanged;
        
        TreeNode node = null;
        public TreeNode Node
        {
            get { return node; }
            set
            {
                node = value;
                if (node != null)
                {
                    Note = (DalNote) node.Tag;
                }
            }
        }
        
        DalNote note;
        public DalNote Note
        {
            get
            {
                if (note != null)
                {
                    note.Title = titleBox.Text;
                    note.Text = textBox.Text;
                }
                return note;
            }
            set
            {
                note = value;
                if (note == null)
                {
                    iconsPicture.Image = null;
                    titleBox.Text = "";
                    creationTimeBox.Text = "";
                    textBox.Text = "";
                }
                else
                {
                    // iconsPicture.Image = null;
                    titleBox.Text = note.Title;
                    creationTimeBox.Text = note.CreationTime.ToString("yyyy/MM/dd HH:mm:ss");
                    textBox.Text = note.Text;
                    titleBox.ReadOnly = note.IsPermanent;
                }
            }
        }
        
        public bool TopVisible
        {
            get { return topPanel.Visible; }
            set { topPanel.Visible = value; }
        }
        
        public ControlNoteTextView()
        {
            InitializeComponent();
            titleBox.MaxLength = int.Parse(DalNote.MAX_TITLE_CHAR_COUNT);
            Note = null;
            TopVisible = true;
        }
        
        public void FocusTitle()
        {
            titleBox.Focus();
        }
        
        public void UpdateNote()
        {
            if (Note != null)
            {
                DbUtil.UpdateNote(Note);
            }
        }
        
        void TitleBoxLeave(object sender, EventArgs e)
        {
            UpdateNote();
        }

        void TextBoxLeave(object sender, EventArgs e)
        {
            UpdateNote();
        }
        
        void TitleBoxTextChanged(object sender, EventArgs e)
        {
            if (Node != null)
            {
                Node.Text = titleBox.Text;
            }
        }
        
        void TitleBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox.Focus();
            }
        }
        
        void TitleBoxEnter(object sender, EventArgs e)
        {
            titleBox.SelectAll();
        }
        
        void TextBoxTextChanged(object sender, EventArgs e)
        {
            if (NoteTextChanged != null)
            {
                NoteTextChanged(sender, e);
            }
        }
    }
}
