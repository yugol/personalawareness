/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/10/2008
 * Time: 19:52
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using Awareness.DB;

// SHOULD: items have note as tooltip
// SHOULD: double click on item allows action edit

namespace Awareness.UI
{
    public enum ETitleFormats { HIDDEN, DAY_OF_WEEK, DAY_OF_MONTH }

    public partial class ControlActionsList : UserControl {
        public string Title
        {
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; }
        }

        ETitleFormats titleFormat = ETitleFormats.DAY_OF_WEEK;
        public ETitleFormats TitleFormat
        {
            get { return titleFormat; }
            set
            {
                titleFormat = value;
                titleLabel.Visible = (titleFormat != ETitleFormats.HIDDEN);
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
                if (timeInterval == null){
                    titleLabel.Text = "";
                } else {
                    switch (titleFormat){
                        case ETitleFormats.DAY_OF_WEEK:
                            titleLabel.Text = timeInterval.First.ToString("dddd, MMM d");
                            switch (timeInterval.First.Day){
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
                        case ETitleFormats.DAY_OF_MONTH:
                            titleLabel.Text = timeInterval.First.ToString("d");
                            break;
                    }

                    if (timeInterval.First.Date.Equals(DateTime.Now.Date)){
                        titleLabel.Text += "  -  (Today)";
                        titleLabel.ForeColor = SystemColors.HighlightText;
                        titleLabel.BackColor = SystemColors.Highlight;
                    } else {
                        titleLabel.ForeColor = SystemColors.ControlText;
                        titleLabel.BackColor = SystemColors.Control;
                    }

                    UpdateActions();
                }
            }
        }

        public ControlActionsList(){
            InitializeComponent();
            actionsView.Items.Clear();
            TimeInterval = null;
            DBUtil.DataContextChanged += new DatabaseChangedHandler(UpdateActions);
        }

        void ActionsViewSizeChanged(object sender, EventArgs e){
            int whatWidth = actionsView.Width -
                actionsView.Columns[1].Width -
                actionsView.Columns[2].Width -
                Configuration.LIST_VIEW_SCROLL_BAR_WIDTH;
            actionsView.Columns[0].Width = whatWidth;
        }

        public void UpdateActions(){
            if (timeInterval != null && DBUtil.IsDbAvailable()){
                Debug.WriteLine("UpdateActions");
                actionsView.BeginUpdate();
                actionsView.Items.Clear();
                List<ActionOccurrence> occurrences = DBUtil.GetActionOccurrences(timeInterval);
                foreach (ActionOccurrence occurrence in occurrences){
                    actionsView.Items.Add(ItemFromAction(occurrence));
                }
                actionsView.EndUpdate();
            }
        }

        ListViewItem ItemFromAction(ActionOccurrence occurrence)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = occurrence;
            item.Text = occurrence.Action.Name;
            item.SubItems.Add(occurrence.Start.ToString("HH:mm"));
            item.SubItems.Add((occurrence.Action.Start.Equals(occurrence.Action.End)) ? ("") : (occurrence.End.ToString("HH:mm")));
            if (occurrence.Action.HasNote) {
                item.ToolTipText = occurrence.Action.Note.Text;
            }
            return item;
        }
        
        void ActionsViewMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                ListViewItem item = actionsView.GetItemAt(e.X, e.Y);
                if (item == null) {
                    DalAction action = new DalAction();
                    action.Name = DalAction.DefaultNewActionName;
                    action.Start = TimeInterval.First.Date;
                    action.End = action.Start;
                    
                    TimeInterval time = new TimeInterval(action.Start, action.End);
                    ActionOccurrence occurrence = new ActionOccurrence(action, time);
                    
                    item = ItemFromAction(occurrence);
                    actionsView.Items.Add(item);
                    item.BeginEdit();
                } else {
                    FormEditAction dlg = new FormEditAction();
                    dlg.Action = ((ActionOccurrence) item.Tag).Action;
                    dlg.ShowDialog();
                }
            }
        }
        
        void ActionsViewAfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ListViewItem item = actionsView.Items[e.Item];
            if (string.IsNullOrEmpty(e.Label)) {
        	    actionsView.Items.Remove(item);
        	} else {
                DalAction action = ((ActionOccurrence) item.Tag).Action;
        	    action.Name = e.Label;
            	if (action.Parent == null) {
            	    DBUtil.AddAction(action);
            	} else {
            	    DBUtil.UpdateAction(action);
            	}
        	}
        }
    }
}
