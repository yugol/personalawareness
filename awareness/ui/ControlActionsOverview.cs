/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 28/09/2008
 * Time: 19:11
 * 
 */
using System;
using System.Linq;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class ControlActionsOverview : UserControl
    {
        public ControlActionsOverview()
        {
            InitializeComponent();
            DbUtil.DataContextChanged += new DatabaseChangedHandler(UpdateActionTree);
        }
        
        void UpdateActionTree()
        {
            actionsTree.BeginUpdate();
            
            actionsTree.Nodes.Clear();
            actionEditControl.Node = null;
            
            IQueryable<DalAction> actions = DbUtil.GetRootActions();
            foreach (DalAction action in actions)
            {
                TreeNode node = Action2Node(action);
                actionsTree.Nodes.Add(node);
                _AddChildNodes(node);
                SetExpanded(node);
            }
            if (actionsTree.Nodes.Count > 0)
            {
                actionsTree.SelectedNode = actionsTree.Nodes[0];
            }
            
            actionsTree.EndUpdate();
        }

        void _AddChildNodes(TreeNode parentNode)
        {
            IQueryable<DalAction> actions = DbUtil.GetChildActions((DalAction) parentNode.Tag);
            foreach (DalAction action in actions)
            {
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
            node.Checked = action.IsCompleted;
            SetNodeImage(node);
            return node;
        }

        public static void SetNodeImage(TreeNode node)
        {
            DalAction action = (DalAction) node.Tag;
            switch (action.Type) 
            {
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
            if (((DalAction) node.Tag).IsExpanded)
            {
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
            if (mouseDownNode != null)
            {
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
            if (e.Label != null)
            {
                action.Name = e.Label;
                DbUtil.UpdateActionTimeStamp(action);
            }
        }
        
        void ActionsTreeAfterCollapse(object sender, TreeViewEventArgs e)
        {
            DalAction action = (DalAction) e.Node.Tag;
            if (action.IsExpanded)
            {
                action.IsExpanded = false;
                DbUtil.UpdateAction(action);
            }
            SetNodeImage(e.Node);
        }
        
        void ActionsTreeAfterExpand(object sender, TreeViewEventArgs e)
        {
            DalAction action = (DalAction) e.Node.Tag;
            if (!action.IsExpanded)
            {
                action.IsExpanded = true;
                DbUtil.UpdateAction(action);
            }
            SetNodeImage(e.Node);
        }
        
        void ActionsTreeAfterCheck(object sender, TreeViewEventArgs e)
        {
            DalAction action = (DalAction) e.Node.Tag;
            if (action.Type != DalAction.TYPE_GROUP)
            {
                if (e.Node.Checked)
                {
                    DbUtil.CompleteAction(action);
                }
                else
                {
                    DbUtil.UnCompleteAction(action);
                }
                actionEditControl.Node = e.Node;
            }
        }
        
        void ActionsTreeBeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
        	DalAction action = (DalAction) e.Node.Tag;
            if (action.Type == DalAction.TYPE_GROUP)
            {
                e.Cancel = true;
            }
        }
        
    }
}
