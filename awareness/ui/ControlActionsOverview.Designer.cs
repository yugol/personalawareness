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
 * Date: 28/09/2008
 * Time: 19:11
 * 
 */
namespace awareness.ui
{
    partial class ControlActionsOverview
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
        	System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0");
        	System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node6");
        	System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node7");
        	System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
        	        	        	treeNode2,
        	        	        	treeNode3});
        	System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node11");
        	System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node14");
        	System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node15");
        	System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node12", new System.Windows.Forms.TreeNode[] {
        	        	        	treeNode6,
        	        	        	treeNode7});
        	System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node18");
        	System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node17", new System.Windows.Forms.TreeNode[] {
        	        	        	treeNode9});
        	System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node16", new System.Windows.Forms.TreeNode[] {
        	        	        	treeNode10});
        	System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Node13", new System.Windows.Forms.TreeNode[] {
        	        	        	treeNode11});
        	System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Node8", new System.Windows.Forms.TreeNode[] {
        	        	        	treeNode5,
        	        	        	treeNode8,
        	        	        	treeNode12});
        	System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Node9");
        	System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Node10");
        	System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Node2", new System.Windows.Forms.TreeNode[] {
        	        	        	treeNode13,
        	        	        	treeNode14,
        	        	        	treeNode15});
        	System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Node3");
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlActionsOverview));
        	this.splitContainer = new System.Windows.Forms.SplitContainer();
        	this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
        	this.actionsTree = new System.Windows.Forms.TreeView();
        	this.actionTreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.newActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.newChildActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparatorAction = new System.Windows.Forms.ToolStripSeparator();
        	this.newGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.newSubgroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparatorGroup = new System.Windows.Forms.ToolStripSeparator();
        	this.deleteActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.deleteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.actionIcons = new System.Windows.Forms.ImageList(this.components);
        	this.toolStrip = new System.Windows.Forms.ToolStrip();
        	this.filterToolButton = new System.Windows.Forms.ToolStripDropDownButton();
        	this.unindentToolButton = new System.Windows.Forms.ToolStripButton();
        	this.indentToolButton = new System.Windows.Forms.ToolStripButton();
        	this.moveUpToolButton = new System.Windows.Forms.ToolStripButton();
        	this.moveDownToolButton = new System.Windows.Forms.ToolStripButton();
        	this.actionEditControl = new awareness.ui.ControlActionEdit();
        	this.splitContainer.Panel1.SuspendLayout();
        	this.splitContainer.Panel2.SuspendLayout();
        	this.splitContainer.SuspendLayout();
        	this.toolStripContainer.ContentPanel.SuspendLayout();
        	this.toolStripContainer.TopToolStripPanel.SuspendLayout();
        	this.toolStripContainer.SuspendLayout();
        	this.actionTreeContextMenu.SuspendLayout();
        	this.toolStrip.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// splitContainer
        	// 
        	this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer.Name = "splitContainer";
        	// 
        	// splitContainer.Panel1
        	// 
        	this.splitContainer.Panel1.Controls.Add(this.toolStripContainer);
        	// 
        	// splitContainer.Panel2
        	// 
        	this.splitContainer.Panel2.Controls.Add(this.actionEditControl);
        	this.splitContainer.Size = new System.Drawing.Size(640, 480);
        	this.splitContainer.SplitterDistance = 173;
        	this.splitContainer.TabIndex = 0;
        	// 
        	// toolStripContainer
        	// 
        	this.toolStripContainer.BottomToolStripPanelVisible = false;
        	// 
        	// toolStripContainer.ContentPanel
        	// 
        	this.toolStripContainer.ContentPanel.Controls.Add(this.actionsTree);
        	this.toolStripContainer.ContentPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
        	this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(173, 455);
        	this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.toolStripContainer.LeftToolStripPanelVisible = false;
        	this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
        	this.toolStripContainer.Name = "toolStripContainer";
        	this.toolStripContainer.RightToolStripPanelVisible = false;
        	this.toolStripContainer.Size = new System.Drawing.Size(173, 480);
        	this.toolStripContainer.TabIndex = 1;
        	this.toolStripContainer.Text = "toolStripContainer1";
        	// 
        	// toolStripContainer.TopToolStripPanel
        	// 
        	this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
        	this.toolStripContainer.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        	// 
        	// actionsTree
        	// 
        	this.actionsTree.CheckBoxes = true;
        	this.actionsTree.ContextMenuStrip = this.actionTreeContextMenu;
        	this.actionsTree.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.actionsTree.FullRowSelect = true;
        	this.actionsTree.HideSelection = false;
        	this.actionsTree.ImageIndex = 0;
        	this.actionsTree.ImageList = this.actionIcons;
        	this.actionsTree.LabelEdit = true;
        	this.actionsTree.Location = new System.Drawing.Point(0, 0);
        	this.actionsTree.Name = "actionsTree";
        	treeNode1.Name = "Node0";
        	treeNode1.Text = "Node0";
        	treeNode2.Name = "Node6";
        	treeNode2.Text = "Node6";
        	treeNode3.Name = "Node7";
        	treeNode3.Text = "Node7";
        	treeNode4.Name = "Node1";
        	treeNode4.Text = "Node1";
        	treeNode5.Name = "Node11";
        	treeNode5.Text = "Node11";
        	treeNode6.Name = "Node14";
        	treeNode6.Text = "Node14";
        	treeNode7.Name = "Node15";
        	treeNode7.Text = "Node15";
        	treeNode8.Name = "Node12";
        	treeNode8.Text = "Node12";
        	treeNode9.Name = "Node18";
        	treeNode9.Text = "Node18";
        	treeNode10.Name = "Node17";
        	treeNode10.Text = "Node17";
        	treeNode11.Name = "Node16";
        	treeNode11.Text = "Node16";
        	treeNode12.Name = "Node13";
        	treeNode12.Text = "Node13";
        	treeNode13.Name = "Node8";
        	treeNode13.Text = "Node8";
        	treeNode14.Name = "Node9";
        	treeNode14.Text = "Node9";
        	treeNode15.Name = "Node10";
        	treeNode15.Text = "Node10";
        	treeNode16.Name = "Node2";
        	treeNode16.Text = "Node2";
        	treeNode17.Name = "Node3";
        	treeNode17.Text = "Node3";
        	this.actionsTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
        	        	        	treeNode1,
        	        	        	treeNode4,
        	        	        	treeNode16,
        	        	        	treeNode17});
        	this.actionsTree.SelectedImageIndex = 0;
        	this.actionsTree.Size = new System.Drawing.Size(173, 453);
        	this.actionsTree.TabIndex = 0;
        	this.actionsTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.ActionsTreeAfterCheck);
        	this.actionsTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.ActionsTreeAfterCollapse);
        	this.actionsTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.ActionsTreeAfterLabelEdit);
        	this.actionsTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ActionsTreeMouseUp);
        	this.actionsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ActionsTreeAfterSelect);
        	this.actionsTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ActionsTreeMouseDown);
        	this.actionsTree.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.ActionsTreeBeforeCheck);
        	this.actionsTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.ActionsTreeAfterExpand);
        	// 
        	// actionTreeContextMenu
        	// 
        	this.actionTreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.newActionToolStripMenuItem,
        	        	        	this.newChildActionToolStripMenuItem,
        	        	        	this.toolStripSeparatorAction,
        	        	        	this.newGroupToolStripMenuItem,
        	        	        	this.newSubgroupToolStripMenuItem,
        	        	        	this.toolStripSeparatorGroup,
        	        	        	this.deleteActionToolStripMenuItem,
        	        	        	this.deleteGroupToolStripMenuItem});
        	this.actionTreeContextMenu.Name = "actionTreeContextMenu";
        	this.actionTreeContextMenu.Size = new System.Drawing.Size(155, 148);
        	// 
        	// newActionToolStripMenuItem
        	// 
        	this.newActionToolStripMenuItem.Name = "newActionToolStripMenuItem";
        	this.newActionToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.newActionToolStripMenuItem.Text = "New Action";
        	this.newActionToolStripMenuItem.Click += new System.EventHandler(this.NewActionToolStripMenuItemClick);
        	// 
        	// newChildActionToolStripMenuItem
        	// 
        	this.newChildActionToolStripMenuItem.Name = "newChildActionToolStripMenuItem";
        	this.newChildActionToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.newChildActionToolStripMenuItem.Text = "New Child Action";
        	this.newChildActionToolStripMenuItem.Click += new System.EventHandler(this.NewChildActionToolStripMenuItemClick);
        	// 
        	// toolStripSeparatorAction
        	// 
        	this.toolStripSeparatorAction.Name = "toolStripSeparatorAction";
        	this.toolStripSeparatorAction.Size = new System.Drawing.Size(151, 6);
        	// 
        	// newGroupToolStripMenuItem
        	// 
        	this.newGroupToolStripMenuItem.Name = "newGroupToolStripMenuItem";
        	this.newGroupToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.newGroupToolStripMenuItem.Text = "New Group";
        	this.newGroupToolStripMenuItem.Click += new System.EventHandler(this.NewGroupToolStripMenuItemClick);
        	// 
        	// newSubgroupToolStripMenuItem
        	// 
        	this.newSubgroupToolStripMenuItem.Name = "newSubgroupToolStripMenuItem";
        	this.newSubgroupToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.newSubgroupToolStripMenuItem.Text = "New Subgroup";
        	this.newSubgroupToolStripMenuItem.Click += new System.EventHandler(this.NewSubgroupToolStripMenuItemClick);
        	// 
        	// toolStripSeparatorGroup
        	// 
        	this.toolStripSeparatorGroup.Name = "toolStripSeparatorGroup";
        	this.toolStripSeparatorGroup.Size = new System.Drawing.Size(151, 6);
        	// 
        	// deleteActionToolStripMenuItem
        	// 
        	this.deleteActionToolStripMenuItem.Name = "deleteActionToolStripMenuItem";
        	this.deleteActionToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.deleteActionToolStripMenuItem.Text = "Delete Action";
        	this.deleteActionToolStripMenuItem.Click += new System.EventHandler(this.DeleteActionToolStripMenuItemClick);
        	// 
        	// deleteGroupToolStripMenuItem
        	// 
        	this.deleteGroupToolStripMenuItem.Name = "deleteGroupToolStripMenuItem";
        	this.deleteGroupToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
        	this.deleteGroupToolStripMenuItem.Text = "Delete Group";
        	this.deleteGroupToolStripMenuItem.Click += new System.EventHandler(this.DeleteGroupToolStripMenuItemClick);
        	// 
        	// actionIcons
        	// 
        	this.actionIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("actionIcons.ImageStream")));
        	this.actionIcons.TransparentColor = System.Drawing.Color.Magenta;
        	this.actionIcons.Images.SetKeyName(0, "closed_notebook.bmp");
        	this.actionIcons.Images.SetKeyName(1, "opened_notebook.bmp");
        	this.actionIcons.Images.SetKeyName(2, "todo.bmp");
        	this.actionIcons.Images.SetKeyName(3, "task.bmp");
        	// 
        	// toolStrip
        	// 
        	this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
        	this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.filterToolButton,
        	        	        	this.unindentToolButton,
        	        	        	this.indentToolButton,
        	        	        	this.moveUpToolButton,
        	        	        	this.moveDownToolButton});
        	this.toolStrip.Location = new System.Drawing.Point(3, 0);
        	this.toolStrip.Name = "toolStrip";
        	this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        	this.toolStrip.Size = new System.Drawing.Size(124, 25);
        	this.toolStrip.TabIndex = 0;
        	// 
        	// filterToolButton
        	// 
        	this.filterToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.filterToolButton.Image = ((System.Drawing.Image)(resources.GetObject("filterToolButton.Image")));
        	this.filterToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.filterToolButton.Name = "filterToolButton";
        	this.filterToolButton.Size = new System.Drawing.Size(29, 22);
        	this.filterToolButton.Text = "toolStripDropDownButton1";
        	this.filterToolButton.ToolTipText = "Filter";
        	// 
        	// unindentToolButton
        	// 
        	this.unindentToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.unindentToolButton.Image = ((System.Drawing.Image)(resources.GetObject("unindentToolButton.Image")));
        	this.unindentToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.unindentToolButton.Name = "unindentToolButton";
        	this.unindentToolButton.Size = new System.Drawing.Size(23, 22);
        	this.unindentToolButton.Text = "toolStripButton2";
        	this.unindentToolButton.ToolTipText = "Unindent";
        	// 
        	// indentToolButton
        	// 
        	this.indentToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.indentToolButton.Image = ((System.Drawing.Image)(resources.GetObject("indentToolButton.Image")));
        	this.indentToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.indentToolButton.Name = "indentToolButton";
        	this.indentToolButton.Size = new System.Drawing.Size(23, 22);
        	this.indentToolButton.Text = "toolStripButton5";
        	this.indentToolButton.ToolTipText = "Indent";
        	// 
        	// moveUpToolButton
        	// 
        	this.moveUpToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.moveUpToolButton.Image = ((System.Drawing.Image)(resources.GetObject("moveUpToolButton.Image")));
        	this.moveUpToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.moveUpToolButton.Name = "moveUpToolButton";
        	this.moveUpToolButton.Size = new System.Drawing.Size(23, 22);
        	this.moveUpToolButton.Text = "toolStripButton6";
        	this.moveUpToolButton.ToolTipText = "Move up";
        	// 
        	// moveDownToolButton
        	// 
        	this.moveDownToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.moveDownToolButton.Image = ((System.Drawing.Image)(resources.GetObject("moveDownToolButton.Image")));
        	this.moveDownToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.moveDownToolButton.Name = "moveDownToolButton";
        	this.moveDownToolButton.Size = new System.Drawing.Size(23, 22);
        	this.moveDownToolButton.Text = "toolStripButton7";
        	this.moveDownToolButton.ToolTipText = "Move down";
        	// 
        	// actionEditControl
        	// 
        	this.actionEditControl.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.actionEditControl.Location = new System.Drawing.Point(0, 0);
        	this.actionEditControl.Name = "actionEditControl";
        	this.actionEditControl.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
        	this.actionEditControl.Size = new System.Drawing.Size(463, 480);
        	this.actionEditControl.TabIndex = 0;
        	// 
        	// ControlActionsOverview
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.splitContainer);
        	this.Name = "ControlActionsOverview";
        	this.Size = new System.Drawing.Size(640, 480);
        	this.splitContainer.Panel1.ResumeLayout(false);
        	this.splitContainer.Panel2.ResumeLayout(false);
        	this.splitContainer.ResumeLayout(false);
        	this.toolStripContainer.ContentPanel.ResumeLayout(false);
        	this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
        	this.toolStripContainer.TopToolStripPanel.PerformLayout();
        	this.toolStripContainer.ResumeLayout(false);
        	this.toolStripContainer.PerformLayout();
        	this.actionTreeContextMenu.ResumeLayout(false);
        	this.toolStrip.ResumeLayout(false);
        	this.toolStrip.PerformLayout();
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ImageList actionIcons;
        private System.Windows.Forms.ToolStripMenuItem newChildActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSubgroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorAction;
        private System.Windows.Forms.ToolStripMenuItem deleteGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newActionToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip actionTreeContextMenu;
        private System.Windows.Forms.ToolStrip toolStrip;
        private awareness.ui.ControlActionEdit actionEditControl;
        private System.Windows.Forms.ToolStripButton moveDownToolButton;
        private System.Windows.Forms.ToolStripButton moveUpToolButton;
        private System.Windows.Forms.ToolStripButton indentToolButton;
        private System.Windows.Forms.ToolStripButton unindentToolButton;
        private System.Windows.Forms.ToolStripDropDownButton filterToolButton;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.TreeView actionsTree;
        private System.Windows.Forms.SplitContainer splitContainer;
    }
}
