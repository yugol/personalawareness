/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 02/11/2008
 * Time: 19:37
 * 
 */
using System;
using System.Windows.Forms;

namespace awareness.ui
{
    partial class ControlTransactions
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
        
        void SelectLayoutLabelClick(object sender, EventArgs e){
            SelectPanelExpanded = !SelectPanelExpanded;
        }
        
    }
}
