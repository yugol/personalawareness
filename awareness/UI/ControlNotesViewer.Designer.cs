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
namespace Awareness.UI
{
    partial class ControlNotesViewer
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the control.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlNotesViewer));
        	this.viewSplitter = new System.Windows.Forms.SplitContainer();
        	this.notesToolStripContainer = new System.Windows.Forms.ToolStripContainer();
        	this.notesTree = new System.Windows.Forms.TreeView();
        	this.notesToolStrip = new System.Windows.Forms.ToolStrip();
        	this.refreshToolButton = new System.Windows.Forms.ToolStripButton();
        	this.expandToolButton = new System.Windows.Forms.ToolStripButton();
        	this.collapseToolButton = new System.Windows.Forms.ToolStripButton();
        	this.expandAllToolButton = new System.Windows.Forms.ToolStripButton();
        	this.collapseAllToolButton = new System.Windows.Forms.ToolStripButton();
        	this.noteTextView = new Awareness.UI.ControlNoteTextView();
        	this.treeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.newNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.newChildNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.newSiblingNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.sep1 = new System.Windows.Forms.ToolStripSeparator();
        	this.deleteNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.viewSplitter.Panel1.SuspendLayout();
        	this.viewSplitter.Panel2.SuspendLayout();
        	this.viewSplitter.SuspendLayout();
        	this.notesToolStripContainer.ContentPanel.SuspendLayout();
        	this.notesToolStripContainer.TopToolStripPanel.SuspendLayout();
        	this.notesToolStripContainer.SuspendLayout();
        	this.notesToolStrip.SuspendLayout();
        	this.treeContextMenu.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// viewSplitter
        	// 
        	this.viewSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.viewSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        	this.viewSplitter.Location = new System.Drawing.Point(0, 0);
        	this.viewSplitter.Name = "viewSplitter";
        	// 
        	// viewSplitter.Panel1
        	// 
        	this.viewSplitter.Panel1.Controls.Add(this.notesToolStripContainer);
        	// 
        	// viewSplitter.Panel2
        	// 
        	this.viewSplitter.Panel2.Controls.Add(this.noteTextView);
        	this.viewSplitter.Size = new System.Drawing.Size(568, 388);
        	this.viewSplitter.SplitterDistance = 200;
        	this.viewSplitter.TabIndex = 0;
        	// 
        	// notesToolStripContainer
        	// 
        	this.notesToolStripContainer.BottomToolStripPanelVisible = false;
        	// 
        	// notesToolStripContainer.ContentPanel
        	// 
        	this.notesToolStripContainer.ContentPanel.Controls.Add(this.notesTree);
        	this.notesToolStripContainer.ContentPanel.Size = new System.Drawing.Size(200, 363);
        	this.notesToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.notesToolStripContainer.LeftToolStripPanelVisible = false;
        	this.notesToolStripContainer.Location = new System.Drawing.Point(0, 0);
        	this.notesToolStripContainer.Name = "notesToolStripContainer";
        	this.notesToolStripContainer.RightToolStripPanelVisible = false;
        	this.notesToolStripContainer.Size = new System.Drawing.Size(200, 388);
        	this.notesToolStripContainer.TabIndex = 2;
        	this.notesToolStripContainer.Text = "toolStripContainer1";
        	// 
        	// notesToolStripContainer.TopToolStripPanel
        	// 
        	this.notesToolStripContainer.TopToolStripPanel.Controls.Add(this.notesToolStrip);
        	this.notesToolStripContainer.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        	// 
        	// notesTree
        	// 
        	this.notesTree.AllowDrop = true;
        	this.notesTree.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.notesTree.HideSelection = false;
        	this.notesTree.Location = new System.Drawing.Point(0, 0);
        	this.notesTree.Name = "notesTree";
        	this.notesTree.Size = new System.Drawing.Size(200, 363);
        	this.notesTree.TabIndex = 1;
        	this.notesTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.NotesTreeAfterCollapse);
        	this.notesTree.DragLeave += new System.EventHandler(this.NotesTreeDragLeave);
        	this.notesTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NotesTreeMouseUp);
        	this.notesTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.NotesTreeDragDrop);
        	this.notesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.NotesTreeAfterSelect);
        	this.notesTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotesTreeMouseDown);
        	this.notesTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.NotesTreeDragEnter);
        	this.notesTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NotesTreeKeyDown);
        	this.notesTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.NotesTreeAfterExpand);
        	this.notesTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.NotesTreeItemDrag);
        	this.notesTree.DragOver += new System.Windows.Forms.DragEventHandler(this.NotesTreeDragOver);
        	// 
        	// notesToolStrip
        	// 
        	this.notesToolStrip.Dock = System.Windows.Forms.DockStyle.None;
        	this.notesToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.notesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.refreshToolButton,
        	        	        	this.expandToolButton,
        	        	        	this.collapseToolButton,
        	        	        	this.expandAllToolButton,
        	        	        	this.collapseAllToolButton});
        	this.notesToolStrip.Location = new System.Drawing.Point(3, 0);
        	this.notesToolStrip.Name = "notesToolStrip";
        	this.notesToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        	this.notesToolStrip.Size = new System.Drawing.Size(118, 25);
        	this.notesToolStrip.TabIndex = 0;
        	// 
        	// refreshToolButton
        	// 
        	this.refreshToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.refreshToolButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolButton.Image")));
        	this.refreshToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.refreshToolButton.Name = "refreshToolButton";
        	this.refreshToolButton.Size = new System.Drawing.Size(23, 22);
        	this.refreshToolButton.Text = "Refresh";
        	this.refreshToolButton.ToolTipText = "Refresh";
        	this.refreshToolButton.Click += new System.EventHandler(this.RefreshToolButtonClick);
        	// 
        	// expandToolButton
        	// 
        	this.expandToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.expandToolButton.Image = ((System.Drawing.Image)(resources.GetObject("expandToolButton.Image")));
        	this.expandToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.expandToolButton.Name = "expandToolButton";
        	this.expandToolButton.Size = new System.Drawing.Size(23, 22);
        	this.expandToolButton.Text = "Expand branch";
        	this.expandToolButton.ToolTipText = "Expand branch";
        	this.expandToolButton.Click += new System.EventHandler(this.ExpandToolButtonClick);
        	// 
        	// collapseToolButton
        	// 
        	this.collapseToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.collapseToolButton.Image = ((System.Drawing.Image)(resources.GetObject("collapseToolButton.Image")));
        	this.collapseToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.collapseToolButton.Name = "collapseToolButton";
        	this.collapseToolButton.Size = new System.Drawing.Size(23, 22);
        	this.collapseToolButton.Text = "Collapse branch";
        	this.collapseToolButton.ToolTipText = "Collapse branch";
        	this.collapseToolButton.Click += new System.EventHandler(this.CollapseToolButtonClick);
        	// 
        	// expandAllToolButton
        	// 
        	this.expandAllToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.expandAllToolButton.Image = ((System.Drawing.Image)(resources.GetObject("expandAllToolButton.Image")));
        	this.expandAllToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.expandAllToolButton.Name = "expandAllToolButton";
        	this.expandAllToolButton.Size = new System.Drawing.Size(23, 22);
        	this.expandAllToolButton.Text = "Expand all";
        	this.expandAllToolButton.Click += new System.EventHandler(this.ExpandAllToolButtonClick);
        	// 
        	// collapseAllToolButton
        	// 
        	this.collapseAllToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.collapseAllToolButton.Image = ((System.Drawing.Image)(resources.GetObject("collapseAllToolButton.Image")));
        	this.collapseAllToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.collapseAllToolButton.Name = "collapseAllToolButton";
        	this.collapseAllToolButton.Size = new System.Drawing.Size(23, 22);
        	this.collapseAllToolButton.Text = "Collapse all";
        	this.collapseAllToolButton.Click += new System.EventHandler(this.CollapseAllToolButtonClick);
        	// 
        	// noteTextView
        	// 
        	this.noteTextView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.noteTextView.IconVisible = true;
        	this.noteTextView.Location = new System.Drawing.Point(0, 0);
        	this.noteTextView.Name = "noteTextView";
        	this.noteTextView.Node = null;
        	this.noteTextView.Note = null;
        	this.noteTextView.ScrollBars = true;
        	this.noteTextView.Size = new System.Drawing.Size(364, 388);
        	this.noteTextView.TabIndex = 1;
        	this.noteTextView.TextReadOnly = false;
        	this.noteTextView.TitleReadOnly = false;
        	this.noteTextView.TopVisible = true;
        	// 
        	// treeContextMenu
        	// 
        	this.treeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.newNoteToolStripMenuItem,
        	        	        	this.newChildNoteToolStripMenuItem,
        	        	        	this.newSiblingNoteToolStripMenuItem,
        	        	        	this.sep1,
        	        	        	this.deleteNoteToolStripMenuItem});
        	this.treeContextMenu.Name = "treeContextMenu";
        	this.treeContextMenu.Size = new System.Drawing.Size(155, 98);
        	// 
        	// newNoteToolStripMenuItem
        	// 
        	this.newNoteToolStripMenuItem.Name = "newNoteToolStripMenuItem";
        	this.newNoteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.newNoteToolStripMenuItem.Text = "&New Note";
        	this.newNoteToolStripMenuItem.Click += new System.EventHandler(this.NewNoteToolStripMenuItemClick);
        	// 
        	// newChildNoteToolStripMenuItem
        	// 
        	this.newChildNoteToolStripMenuItem.Name = "newChildNoteToolStripMenuItem";
        	this.newChildNoteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.newChildNoteToolStripMenuItem.Text = "New &Child Note";
        	this.newChildNoteToolStripMenuItem.Click += new System.EventHandler(this.NewChildNoteToolStripMenuItemClick);
        	// 
        	// newSiblingNoteToolStripMenuItem
        	// 
        	this.newSiblingNoteToolStripMenuItem.Name = "newSiblingNoteToolStripMenuItem";
        	this.newSiblingNoteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.newSiblingNoteToolStripMenuItem.Text = "New &Sibling Note";
        	this.newSiblingNoteToolStripMenuItem.Click += new System.EventHandler(this.NewSiblingNoteToolStripMenuItemClick);
        	// 
        	// sep1
        	// 
        	this.sep1.Name = "sep1";
        	this.sep1.Size = new System.Drawing.Size(151, 6);
        	// 
        	// deleteNoteToolStripMenuItem
        	// 
        	this.deleteNoteToolStripMenuItem.Name = "deleteNoteToolStripMenuItem";
        	this.deleteNoteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.deleteNoteToolStripMenuItem.Text = "&Delete Note";
        	this.deleteNoteToolStripMenuItem.Click += new System.EventHandler(this.DeleteNoteToolStripMenuItemClick);
        	// 
        	// ControlNotesViewer
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.viewSplitter);
        	this.Name = "ControlNotesViewer";
        	this.Size = new System.Drawing.Size(568, 388);
        	this.VisibleChanged += new System.EventHandler(this.ControlNotesViewerVisibleChanged);
        	this.viewSplitter.Panel1.ResumeLayout(false);
        	this.viewSplitter.Panel2.ResumeLayout(false);
        	this.viewSplitter.ResumeLayout(false);
        	this.notesToolStripContainer.ContentPanel.ResumeLayout(false);
        	this.notesToolStripContainer.TopToolStripPanel.ResumeLayout(false);
        	this.notesToolStripContainer.TopToolStripPanel.PerformLayout();
        	this.notesToolStripContainer.ResumeLayout(false);
        	this.notesToolStripContainer.PerformLayout();
        	this.notesToolStrip.ResumeLayout(false);
        	this.notesToolStrip.PerformLayout();
        	this.treeContextMenu.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolStripButton collapseAllToolButton;
        private System.Windows.Forms.ToolStripButton expandAllToolButton;
        private System.Windows.Forms.ToolStripButton collapseToolButton;
        private System.Windows.Forms.ToolStripButton expandToolButton;
        private System.Windows.Forms.ToolStripButton refreshToolButton;
        private System.Windows.Forms.ToolStrip notesToolStrip;
        private System.Windows.Forms.ToolStripContainer notesToolStripContainer;
        private System.Windows.Forms.ToolStripMenuItem newSiblingNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newChildNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sep1;
        private System.Windows.Forms.ContextMenuStrip treeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newNoteToolStripMenuItem;
        private Awareness.UI.ControlNoteTextView noteTextView;
        private System.Windows.Forms.TreeView notesTree;
        private System.Windows.Forms.SplitContainer viewSplitter;
    }
}
