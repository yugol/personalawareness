/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 12/09/2008
 * Time: 16:00
 * 
 */
using System;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class FormManageTransactions
    {
        int selectPanelNormalHeight;


        public bool SelectPanelExpanded
        {
            get { return (selectLayoutLabel.ImageIndex == 0); }
            set
            {
                if (value)
                {
                    selectLayoutLabel.ImageIndex = 0;
                    selectPanel.Height = selectPanelNormalHeight;
                    foreach (Control c in selectPanel.Controls)
                    {
                        c.Visible = true;
                    }
                }
                else
                {
                    selectLayoutLabel.ImageIndex = 1;
                    selectPanel.Height = selectLayoutLabel.Height + selectLayoutLabel.Margin.Top + 2;
                    foreach (Control c in selectPanel.Controls)
                    {
                        if (!c.Equals(selectLayoutLabel))
                        {
                            c.Visible = false;
                        }
                    }
                }
            }
        }

        void SelectLayoutLabelClick(object sender, EventArgs e)
        {
            SelectPanelExpanded = !SelectPanelExpanded;
        }

        void TransferLocationSelectionComboSelectedIndexChanged(object sender, EventArgs e)
        {
            if (transferLocationSelectionCombo.SelectedItem is DalTransferLocation)
            {
                selectedTransferLocation = (DalTransferLocation) transferLocationSelectionCombo.SelectedItem;
            }
            else
            {
                transferLocationSelectionCombo.SelectedItem = null;
                selectedTransferLocation = null;
            }
            ReadTransactions();
        }
        
        void ReasonSelectionBoxTextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(reasonSelectionBox.Text))
            {
                reasonSelectionPattern = null;    
            }
            else
            {
                reasonSelectionPattern = reasonSelectionBox.Text;
            }
            ReadTransactions();
        }
    }
}
