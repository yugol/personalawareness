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
 * Date: 26/09/2008
 * Time: 11:58
 * 
 */
 
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

using Awareness.db;

namespace Awareness.ui
{
    partial class ControlNotesViewer
    {

        #region enable scrolling
        
        private const int WM_VSCROLL = 277; // Vertical scroll
        private const int SB_LINEUP = 0; // Scrolls one line up
        private const int SB_LINEDOWN = 1; // Scrolls one line down
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);        
        
        #endregion
        
        const int SCROLL_AREA = 10;
        
        TreeNode oldDropNode = null;
        
        Color defaultForeColor;
        Color defaultBackColor;
        Color selectedForeColor = SystemColors.HighlightText;
        Color selectedBackColor = SystemColors.Highlight;
        
        void NotesTreeItemDrag(object sender, ItemDragEventArgs e)
        {
            // Debug.WriteLine("ItemDrag");
            
            TreeNode dragNode = (TreeNode) e.Item;
            DalNote note = (DalNote) dragNode.Tag;
            if (!note.IsPermanent)
            {
                defaultForeColor = notesTree.ForeColor;
                defaultBackColor = notesTree.BackColor;
                oldDropNode = null;
                
                notesTree.DoDragDrop(dragNode, DragDropEffects.Move);
            }
        }
        
        void NotesTreeDragEnter(object sender, DragEventArgs e)
        {
            // Debug.WriteLine("DragEnter");
            
            e.Effect = DragDropEffects.Move;
        }

        void NotesTreeDragOver(object sender, DragEventArgs e)
        {
            Point mousePosInsideContol = notesTree.PointToClient(new Point(e.X, e.Y));
            TreeNode dragNode = (TreeNode) e.Data.GetData(typeof(TreeNode));
            TreeNode dropNode = notesTree.GetNodeAt(mousePosInsideContol);

            Debug.WriteLine("DragOver " + dragNode.Text + " -> " + (dropNode == null ? "null" : dropNode.Text));

            e.Effect = DragDropEffects.Move;
            if (!CanDrop(dragNode, dropNode))
            {
                e.Effect = DragDropEffects.None;
            }
            
            if (dropNode == null)
            {
                RestoreOldDropNodeColors();    
            }
            else
            {
                dropNode.EnsureVisible();
                if (dropNode != oldDropNode)
                {
                    dropNode.BackColor = selectedBackColor;
                    dropNode.ForeColor = selectedForeColor;
                    RestoreOldDropNodeColors();
                    oldDropNode = dropNode;
                }
            }

            AutoScrollUpDown(mousePosInsideContol);
        }
        
        void NotesTreeDragLeave(object sender, EventArgs e)
        {
            // Debug.WriteLine("DragLeave");
            
            RestoreOldDropNodeColors();
        }

        void NotesTreeDragDrop(object sender, DragEventArgs e)
        {
            Point mousePosInsideContol = notesTree.PointToClient(new Point(e.X, e.Y));
            TreeNode dragNode = (TreeNode) e.Data.GetData(typeof(TreeNode));
            TreeNode dropNode = notesTree.GetNodeAt(mousePosInsideContol);
            
            Debug.WriteLine("* DragDrop " + dragNode.Text + " -> " + (dropNode == null ? "null" : dropNode.Text));
            
            ReParent(dragNode, dropNode);
            
            RestoreOldDropNodeColors();
        }
        
        void RestoreOldDropNodeColors()
        {
            if (oldDropNode != null) 
            {
                oldDropNode.BackColor = defaultBackColor;
                oldDropNode.ForeColor = defaultForeColor;
            }
        }
        
        bool CanDrop(TreeNode dragNode, TreeNode dropNode)
        {
            if (dropNode == null)
            {
                return dragNode.Parent != null;
            }
            
            DalNote note = (DalNote)dropNode.Tag;
            if (note.IsPermanent)
            {
                return false;    
            }
            
            if (dropNode.Equals(dragNode.Parent))
            {
                return false;
            }
            
            TreeNode parent = dropNode;
            while (parent != null)
            {
                if (parent.Equals(dragNode))
                {
                    return false;
                }
                parent = parent.Parent;
            }
            
            return true;
        }
        
        void AutoScrollUpDown(Point mousePoint)
        {
            if (mousePoint.Y >= 0 && mousePoint.Y < SCROLL_AREA)
            {
                SendMessage(notesTree.Handle, WM_VSCROLL, (IntPtr)SB_LINEUP, IntPtr.Zero);
            }
            else if (mousePoint.Y < notesTree.Height && mousePoint.Y >= notesTree.Height - SCROLL_AREA)
            {
                SendMessage(notesTree.Handle, WM_VSCROLL, (IntPtr)SB_LINEDOWN, IntPtr.Zero);
            }
        }
        
        void ReParent(TreeNode node, TreeNode newParent)
        {
            try
            {
                DalNote parentNote = null;
                if (newParent == null)
                {
                    parentNote = DBUtil.GetRootNote();
                }
                else
                {
                    parentNote = (DalNote) newParent.Tag;   
                }
                DalNote note = (DalNote) node.Tag;
                note.Parent = parentNote;
                DBUtil.UpdateNote(note);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;                
            }

            notesTree.BeginUpdate();
            
            if (node.Parent == null)
            {
                notesTree.Nodes.Remove(node);
            }
            else
            {
                node.Parent.Nodes.Remove(node);
            }
            
            if (newParent == null)
            {
                notesTree.Nodes.Add(node);
            }
            else
            {
                newParent.Nodes.Add(node);    
            }
            
            notesTree.SelectedNode = node;
            
            notesTree.EndUpdate();
        }

    }
}
