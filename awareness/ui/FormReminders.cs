/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 24/11/2008
 * Time: 21:48
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
using System.Drawing;
using System.Windows.Forms;

using Awareness;

namespace Awareness.ui
{
    public partial class FormReminders : Form {
        public FormReminders() {
            InitializeComponent();
        }

        public void RefreshDueTimes(object sender, EventArgs e) {
            DateTime now = DateTime.Now;
            foreach (ListViewItem item in occurencesView.Items){
                ActionOccurrence occurrence = (ActionOccurrence) item.Tag;
                item.SubItems[2].Text = Util.FormatTimeSpan(occurrence.Start.Subtract(now));
            }
        }

        void FormRemindersFormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Visible = false;
        }

        public void Clear() {
            occurencesView.Items.Clear();
            completeButton.Enabled = false;
        }

        public void Add(ActionOccurrence occurrence) {
            ListViewItem item = new ListViewItem();
            item.Tag = occurrence;
            item.Text = occurrence.Start.ToString("yyyy-MM-dd HH:mm");
            item.SubItems.Add(occurrence.Action.Name);
            item.SubItems.Add("*");
            occurencesView.Items.Add(item);
        }

        void OccurencesViewSelectedIndexChanged(object sender, EventArgs e){
            completeButton.Enabled = (occurencesView.SelectedIndices.Count > 0);
        }
    }
}
