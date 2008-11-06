/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/10/2008
 * Time: 19:52
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public enum TitleFormats { HIDDEN, DAY_OF_WEEK, DAY_OF_MONTH }
    
    public partial class ControlActionsList : UserControl
    {
        public string Title
        {
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; }
        }
        
        TitleFormats titleFormat = TitleFormats.DAY_OF_WEEK;
        public TitleFormats TitleFormat
        {
            get { return titleFormat; }
            set 
            { 
                titleFormat = value;
                titleLabel.Visible = (titleFormat != TitleFormats.HIDDEN);
            }
        }
        
        public bool HeadersVisible
        {
            get { return actionsView.HeaderStyle != ColumnHeaderStyle.None; }
            set 
            { 
                actionsView.HeaderStyle = value ?  ColumnHeaderStyle.Nonclickable : ColumnHeaderStyle.None;
            }
        }
        
        TimeInterval timeInterval;
        public TimeInterval TimeInterval
        {
            get { return timeInterval; }
            set 
            { 
                timeInterval = value;
                if (timeInterval == null)
                {
                    titleLabel.Text = "";    
                }
                else
                {
                    switch (titleFormat)
                    {
                        case TitleFormats.DAY_OF_WEEK:
                            titleLabel.Text = timeInterval.First.ToString("dddd, MMM d");
                            switch (timeInterval.First.Day)
                            {
                                case 1:
                                    titleLabel.Text += "st";
                                    break;
                                case 2:
                                    titleLabel.Text += "nd";
                                    break;
                                case 3:
                                    titleLabel.Text += "rd";
                                    break;
                                default:
                                    titleLabel.Text += "th";
                                    break;
                            }
                            break;
                        case TitleFormats.DAY_OF_MONTH:
                            titleLabel.Text = timeInterval.First.ToString("d");
                            break;
                    }
                    
                    if (timeInterval.First.Date.Equals(DateTime.Now.Date))
                    {
                        titleLabel.Text += "  -  (Today)";
                        titleLabel.ForeColor = SystemColors.HighlightText;
                        titleLabel.BackColor = SystemColors.Highlight;
                    }
                    else
                    {
                        titleLabel.ForeColor = SystemColors.ControlText;
                        titleLabel.BackColor = SystemColors.Control;
                    }
                    
                    UpdateActions();
                }
            }
        }
        
        public ControlActionsList()
        {
            InitializeComponent();
            actionsView.Items.Clear();
            TimeInterval = null;
            DbUtil.DataContextChanged += new DatabaseChangedHandler(UpdateActions);
        }
        
        void ActionsViewSizeChanged(object sender, EventArgs e)
        {
            int whatWidth = actionsView.Width - 
                            actionsView.Columns[0].Width - 
                            actionsView.Columns[1].Width - 
                            Configuration.LIST_VIEW_SCROLL_BAR_WIDTH;
            actionsView.Columns[2].Width = whatWidth;
        }
        
        public void UpdateActions()
        {
            Debug.WriteLine("UpdateActions");
            if (timeInterval != null)
            {
                actionsView.BeginUpdate();
                actionsView.Items.Clear();
                List<ActionOccurrence> occurrences = DbUtil.GetActionOccurrences(timeInterval);
                foreach (ActionOccurrence occurrence in occurrences)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = occurrence;
                    item.Text = occurrence.Start.ToString("HH:mm");
                    item.SubItems.Add((occurrence.Action.Start.Equals(occurrence.Action.End)) ? 
                                      ("") : (occurrence.End.ToString("HH:mm")));
                    item.SubItems.Add(occurrence.Action.Name);
                    actionsView.Items.Add(item);
                }
                actionsView.EndUpdate();
            }
        }

        
    }
}
