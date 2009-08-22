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
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Awareness.db;

namespace Awareness.ui
{
    public partial class ControlActionsOverview : UserControl
    {
        public ControlActionsOverview()
        {
            InitializeComponent();
            DBUtil.DataContextChanged += new DatabaseChangedHandler(UpdateActionsTree);
        }

        void UpdateActionsTree()
        {
            actionsTree.BeginUpdate();

            actionsTree.Nodes.Clear();
            actionEditControl.Node = null;

            IEnumerable<DalAction> actions = Controller.Storage.GetRootActions();
            foreach (DalAction action in actions) {
                TreeNode node = Action2Node(action);
                actionsTree.Nodes.Add(node);
                _AddChildNodes(node);
                SetExpanded(node);
            }
            if (actionsTree.Nodes.Count > 0) {
                actionsTree.SelectedNode = actionsTree.Nodes[0];
            }

            actionsTree.EndUpdate();
        }

        void _AddChildNodes(TreeNode parentNode)
        {
            IEnumerable<DalAction> actions = Controller.Storage.GetChildActions((DalAction) parentNode.Tag);
            foreach (DalAction action in actions) {
                TreeNode node = Action2Node(action);
                parentNode.Nodes.Add(node);
                _AddChildNodes(node);
                SetExpanded(node);
            }
        }

        TreeNode Action2Node(DalAction action)
        {
            TreeNode node = new TreeNode();
            node.Tag = action;
            node.Text = action.Name;
            node.Checked = action.IsChecked;
            SetNodeImage(node);
            return node;
        }

        public static void SetNodeImage(TreeNode node)
        {
            if (node == null) {
                return;
            }
            DalAction action = (DalAction) node.Tag;
            switch (action.Type) {
            case DalAction.TYPE_GROUP:
                node.ImageIndex = (action.IsExpanded && node.Nodes.Count > 0) ? (1) : (0);
                break;
            case DalAction.TYPE_TODO:
                node.ImageIndex = 2;
                break;
            case DalAction.TYPE_TASK:
                node.ImageIndex = 3;
                break;
            default:
                throw new ArgumentException("Unknown action type");
            }
            node.SelectedImageIndex = node.ImageIndex;
        }

        void SetExpanded(TreeNode node)
        {
            if (((DalAction) node.Tag).IsExpanded) {
                node.Expand();
            }
        }

        void ActionsTreeAfterSelect(object sender, TreeViewEventArgs e)
        {
            actionEditControl.Node = e.Node;
        }

        void ActionsTreeMouseDown(object sender, MouseEventArgs e)
        {
            TreeNode mouseDownNode = actionsTree.GetNodeAt(e.Location);
            if (mouseDownNode != null) {
                actionsTree.SelectedNode = mouseDownNode;
            }
        }

        void ActionsTreeMouseUp(object sender, MouseEventArgs e)
        {
            actionTreeContextMenu.Tag = actionsTree.GetNodeAt(e.Location);
            UpdateContextMenu();
        }

        void ActionsTreeAfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            DalAction action = (DalAction) e.Node.Tag;
            if (e.Label != null) {
                action.Name = e.Label;
                Controller.Storage.UpdateAction(action, action.Note);
            }
        }

        void ActionsTreeAfterCollapse(object sender, TreeViewEventArgs e)
        {
            DalAction action = (DalAction) e.Node.Tag;
            if (action.IsExpanded) {
                action.IsExpanded = false;
                Controller.Storage.UpdateAction(action, action.Note);
            }
            SetNodeImage(e.Node);
        }

        void ActionsTreeAfterExpand(object sender, TreeViewEventArgs e)
        {
            DalAction action = (DalAction) e.Node.Tag;
            if (!action.IsExpanded) {
                action.IsExpanded = true;
                Controller.Storage.UpdateAction(action, action.Note);
            }
            SetNodeImage(e.Node);
        }

        void ActionsTreeAfterCheck(object sender, TreeViewEventArgs e)
        {
            DalAction action = (DalAction) e.Node.Tag;
            if (action.Type != DalAction.TYPE_GROUP) {
                action.IsChecked = e.Node.Checked;
                Controller.Storage.UpdateAction(action, action.Note);
                actionEditControl.Node = e.Node;
            }
        }

        void ActionsTreeBeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            DalAction action = (DalAction) e.Node.Tag;
            if (action.Type == DalAction.TYPE_GROUP) {
                e.Cancel = true;
            }
        }

        void ReminderToolButtonClick(object sender, EventArgs e)
        {
            UpdateActionsTree();
        }

        void ActionsTreeBeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            actionEditControl.UpdateAction();
        }
    }
}
