/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 29/09/2008
 * Time: 14:12
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
    partial class ControlActionsOverview {
        void UpdateContextMenu(){
            TreeNode clickNode = (TreeNode) actionTreeContextMenu.Tag;
            bool onNode = clickNode != null;

            newActionToolStripMenuItem.Visible = true;
            toolStripSeparatorAction.Visible = true;
            if (onNode){
                DalAction action = (DalAction) clickNode.Tag;
                if (action.Type == DalAction.TYPE_GROUP){
                    newChildActionToolStripMenuItem.Visible = true;
                    newGroupToolStripMenuItem.Visible = true;
                    newSubgroupToolStripMenuItem.Visible = true;
                    toolStripSeparatorGroup.Visible = true;
                    deleteActionToolStripMenuItem.Visible = false;
                    deleteGroupToolStripMenuItem.Visible = true;
                } else {
                    newChildActionToolStripMenuItem.Visible = false;
                    newGroupToolStripMenuItem.Visible = true;
                    newSubgroupToolStripMenuItem.Visible = false;
                    toolStripSeparatorGroup.Visible = true;
                    deleteActionToolStripMenuItem.Visible = true;
                    deleteGroupToolStripMenuItem.Visible = false;
                }
            } else {
                newChildActionToolStripMenuItem.Visible = false;
                newGroupToolStripMenuItem.Visible = true;
                newSubgroupToolStripMenuItem.Visible = false;
                toolStripSeparatorGroup.Visible = false;
                deleteActionToolStripMenuItem.Visible = false;
                deleteGroupToolStripMenuItem.Visible = false;
            }
        }

        TreeNode CreateNewNode(string name, byte type){
            DalAction action = new DalAction() {
                Name = name, Type = type
            };
            return Action2Node(action);
        }

        void AddNode(TreeNode node){
            DalAction action = (DalAction) node.Tag;

            TreeNode clickNode = (TreeNode) actionTreeContextMenu.Tag;
            if (clickNode == null) {
                actionsTree.Nodes.Add(node);
            } else {
                if (clickNode.Parent == null){
                    actionsTree.Nodes.Add(node);
                } else {
                    action.Parent = (DalAction) clickNode.Parent.Tag;
                    clickNode.Parent.Nodes.Add(node);
                }
            }
            
            DBUtil.InsertAction(action, null);

            actionsTree.SelectedNode = node;
            node.BeginEdit();
        }

        void AddSubnode(TreeNode node){
            DalAction action = (DalAction) node.Tag;

            TreeNode clickNode = (TreeNode) actionTreeContextMenu.Tag;
            action.Parent = (DalAction) clickNode.Tag;

            clickNode.Nodes.Add(node);
            DBUtil.InsertAction(action, null);

            actionsTree.SelectedNode = node;
            node.BeginEdit();
        }

        void DeleteNode(TreeNode node){
            if (MessageBox.Show("Are you sure you want to delete the action?",
                                "Delete action",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.OK){
                DalAction action = (DalAction) node.Tag;

                DBUtil.DeleteActionRec(action);

                TreeNode nextSelected = node.NextVisibleNode;
                if (nextSelected == null){
                    nextSelected = node.PrevNode;
                }

                if (node.Parent == null){
                    actionsTree.Nodes.Remove(node);
                } else {
                    node.Parent.Nodes.Remove(node);
                }

                if (nextSelected == null){
                    actionEditControl.Node = null;
                } else {
                    actionsTree.SelectedNode = nextSelected;
                }
            }
        }

        void NewActionToolStripMenuItemClick(object sender, EventArgs e){
            TreeNode node = CreateNewNode(DalAction.DefaultNewActionName, DalAction.TYPE_TODO);
            AddNode(node);
        }

        void NewChildActionToolStripMenuItemClick(object sender, EventArgs e){
            TreeNode node = CreateNewNode(DalAction.DefaultNewActionName, DalAction.TYPE_TODO);
            AddSubnode(node);
        }

        void NewGroupToolStripMenuItemClick(object sender, EventArgs e){
            TreeNode node = CreateNewNode(DalAction.DefaultNewGroupName, DalAction.TYPE_GROUP);
            AddNode(node);
        }

        void NewSubgroupToolStripMenuItemClick(object sender, EventArgs e){
            TreeNode node = CreateNewNode(DalAction.DefaultNewGroupName, DalAction.TYPE_GROUP);
            AddSubnode(node);
        }

        void DeleteActionToolStripMenuItemClick(object sender, EventArgs e){
            TreeNode clickNode = (TreeNode) actionTreeContextMenu.Tag;
            DeleteNode(clickNode);
        }

        void DeleteGroupToolStripMenuItemClick(object sender, EventArgs e){
            TreeNode clickNode = (TreeNode) actionTreeContextMenu.Tag;
            DeleteNode(clickNode);
        }
    }
}
