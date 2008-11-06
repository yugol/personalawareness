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
 * Time: 15:12
 * 
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    // TODO: drag and drop to move notes
    // FEATURE: refresh tree button
    // FEATURE: expand all button
    // FEATURE: collapse all button
    // FEATURE: expand branch button
    // FEATURE: collapse branch button
    
    public partial class ControlNotesViewer : UserControl
    {
        public ControlNoteTextView TextView
        {
            get { return noteTextView; }
        }
                
        public ControlNotesViewer()
        {
            InitializeComponent();
            DbUtil.DataContextChanged += new DatabaseChangedHandler(UpdateNotesView);
        }
        
        void UpdateNotesView()
        {
            notesTree.BeginUpdate();
            
            notesTree.Nodes.Clear();
            IQueryable<DalNote> notes = DbUtil.GetRootNotes();
            if (notes.Count() > 0)
            {
                foreach (DalNote note in notes)
                {
                    TreeNode node = new TreeNode();
                    AssignNote2Node(node, note);
                    notesTree.Nodes.Add(node);
                    _AddChildNodes(node);
                    SetExpanded(node);
                }
                noteTextView.Visible = true;
                notesTree.SelectedNode = notesTree.Nodes[0];
            }
            else
            {
                noteTextView.Visible = false;
            }
            
            notesTree.EndUpdate();
        }

        void _AddChildNodes(TreeNode parentNode)
        {
            DalNote parentNote = (DalNote) parentNode.Tag;
            IQueryable<DalNote> notes = DbUtil.GetChildNotes(parentNote);
            foreach (DalNote note in notes)
            {
                TreeNode node = new TreeNode();
                AssignNote2Node(node, note);
                parentNode.Nodes.Add(node);
                _AddChildNodes(node);
                SetExpanded(node);
            }
        }
        
        void AssignNote2Node(TreeNode node, DalNote note)
        {
            node.Tag = note;
            node.Text = note.Title;
            if (note.IsExpanded)
            {
                node.Expand();
            }
        }
        
        void SetExpanded(TreeNode node)
        {
            if (((DalNote) node.Tag).IsExpanded)
            {
                node.Expand();
            }
            else
            {
                node.Collapse();
            }
        }
        
        void AssignNode2Note(TreeNode node)
        {
            DalNote note = (DalNote)node.Tag;
            note.IsExpanded = node.IsExpanded;
            DbUtil.UpdateNote(note);
        }

        void NotesTreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            noteTextView.Node = e.Node;
        }
                
        void NewNoteToolStripMenuItemClick(object sender, EventArgs e)
        {
            notesTree.BeginUpdate();
            
            DalNote newNote = new DalNote() { Icon = 0, Title = "New note" };
            DbUtil.InsertNote(newNote);

            TreeNode newNode = new TreeNode();
            AssignNote2Node(newNode, newNote);
            notesTree.Nodes.Add(newNode);
            
            noteTextView.Visible = true;
            notesTree.SelectedNode = newNode;

            notesTree.EndUpdate();
            TextView.FocusTitle();
        }
        
        void NewChildNoteToolStripMenuItemClick(object sender, EventArgs e)
        {
            notesTree.BeginUpdate();
            
            TreeNode parentNode = (TreeNode) treeContextMenu.Tag;
            
            DalNote newNote = new DalNote() { Icon = 0, Title = "New note" };
            newNote.Parent = (DalNote) parentNode.Tag;
            DbUtil.InsertNote(newNote);

            TreeNode newNode = new TreeNode();
            AssignNote2Node(newNode, newNote);
            parentNode.Nodes.Add(newNode);
            
            noteTextView.Visible = true;
            notesTree.SelectedNode = newNode;

            notesTree.EndUpdate();
            TextView.FocusTitle();
        }
        
        void NewSiblingNoteToolStripMenuItemClick(object sender, EventArgs e)
        {
            notesTree.BeginUpdate();
            
            TreeNode siblingNode = (TreeNode) treeContextMenu.Tag;

            DalNote newNote = new DalNote() { Icon = 0, Title = "New note" };
            newNote.Parent = ((DalNote) siblingNode.Tag).Parent;
            DbUtil.InsertNote(newNote);

            TreeNode newNode = new TreeNode();
            AssignNote2Node(newNode, newNote);
            if (siblingNode.Parent != null)
            {
                siblingNode.Parent.Nodes.Add(newNode);
            }
            else
            {
                notesTree.Nodes.Add(newNode);
            }
            
            noteTextView.Visible = true;
            notesTree.SelectedNode = newNode;

            notesTree.EndUpdate();
            TextView.FocusTitle();
        }

        void NotesTreeAfterExpand(object sender, TreeViewEventArgs e)
        {
            AssignNode2Note(e.Node);
        }
        
        void NotesTreeAfterCollapse(object sender, TreeViewEventArgs e)
        {
            AssignNode2Note(e.Node);
        }
        
        void DeleteNoteToolStripMenuItemClick(object sender, EventArgs e)
        {
            TreeNode node = (TreeNode) treeContextMenu.Tag;
            DeleteNode(node);        
        }

        void DeleteNode(TreeNode node)
        {
            DalNote note = (DalNote) node.Tag;
            if (!note.IsPermanent)
            {
                if (MessageBox.Show("Are you sure you want to delete note with all the subnotes?\n" + note.Title, 
                                    "Delete note",
                                    MessageBoxButtons.OKCancel, 
                                    MessageBoxIcon.Question, 
                                    MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    notesTree.BeginUpdate();
    
                    TreeNode nextSelected = node.NextNode;
                    if (nextSelected == null) 
                    {
                        nextSelected = node.PrevNode;
                        if (nextSelected == null) 
                        {
                            nextSelected = node.Parent;
                        }
                    }
    
                    _RecDeleteNode(node);
                    if (node.Parent != null)
                    {
                        node.Parent.Nodes.Remove(node);
                    }
                    else
                    {
                        notesTree.Nodes.Remove(node);
                    }
    
                    if (nextSelected == null) 
                    {
                        noteTextView.Visible = false;
                    }
                    else 
                    {
                        notesTree.SelectedNode = nextSelected;
                    }
    
                    notesTree.EndUpdate();
                }
            }
        }
        
        void _RecDeleteNode(TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
            {
                _RecDeleteNode(child);
            }
            DbUtil.DeleteNote((DalNote) node.Tag);
        }
        
        void NotesTreeKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteNode(notesTree.SelectedNode);
            }
        }
        
        void NotesTreeMouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = notesTree.GetNodeAt(e.Location);
            bool onNode = node != null;
            if (onNode)
            {
                notesTree.SelectedNode = node;    
            }
        }
        
        void NotesTreeMouseUp(object sender, MouseEventArgs e)
        {
            TreeNode node = notesTree.GetNodeAt(e.Location);
            bool onNode = node != null;
            if (onNode)
            {
                notesTree.SelectedNode = node;
                DalNote note = (DalNote) node.Tag;
                if (note.IsPermanent)
                {
                    return;    
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                newNoteToolStripMenuItem.Visible = !onNode;
                newChildNoteToolStripMenuItem.Visible = onNode;
                newSiblingNoteToolStripMenuItem.Visible = onNode;
                sep1.Visible = onNode;
                deleteNoteToolStripMenuItem.Visible = onNode;
                
                treeContextMenu.Tag = node;
                treeContextMenu.Show((Control) sender, e.Location);
            }
        }
        
        void RefreshToolButtonClick(object sender, EventArgs e)
        {
            UpdateNotesView();	
        }
    }
}
