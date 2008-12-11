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
 * Date: 05/09/2008
 * Time: 12:55
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness.UI
{
    public partial class ControlTransactionList : UserControl {
        public event EventHandler SelectedIndexChanged;

        Brush selectedBackground = new SolidBrush(SystemColors.Highlight);
        Brush selectedText = new SolidBrush(SystemColors.HighlightText);

        public DalTransaction SelectedTransaction
        {
            get
            {
                if (transactionList.SelectedItems.Count > 0){
                    return (DalTransaction) transactionList.SelectedItems[0].Tag;
                } else {
                    return null;
                }
            }
            set
            {
                if (value == null){
                    transactionList.SelectedItems.Clear();
                } else {
                    for (int i = 0; i < transactionList.Items.Count; ++i){
                        ListViewItem item = transactionList.Items[i];
                        if (item.Tag.Equals(value)){
                            item.Selected = true;
                            transactionList.EnsureVisible(i);
                            break;
                        }
                    }
                }
            }
        }

        public ControlTransactionList(){
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            Font doubleFont = new Font(Configuration.DEFAULT_FONT.FontFamily, Configuration.DEFAULT_FONT.Size * 2.1F, FontStyle.Regular);
            transactionList.Font = doubleFont;
        }

        public void SetData(IEnumerable<DalTransaction> transactions){
            transactionList.BeginUpdate();
            transactionList.Items.Clear();
            bool useAlternateBackground = false;
            foreach (DalTransaction transaction in transactions){
                ListViewItem item = new ListViewItem();
                item.Tag = transaction;
                item.BackColor = useAlternateBackground ? Configuration.ALTERNATE_BACKGROUND : Configuration.NORMAL_BACKGROUND;
                transactionList.Items.Add(item);
                useAlternateBackground = !useAlternateBackground;
            }
            transactionList.EndUpdate();
        }

        public void EnsureLastItemIsVisible(){
            if (transactionList.Items.Count > 0) {
                transactionList.EnsureVisible(transactionList.Items.Count - 1);
            }
        }

        void TransactionListResize(object sender, EventArgs e){
            column.Width = Width - Configuration.LIST_VIEW_SCROLL_BAR_WIDTH;
        }

        void TransactionListDrawItem(object sender, DrawListViewItemEventArgs e){
            if (e.Item.Selected){
                e.Graphics.FillRectangle(selectedBackground, e.Bounds);
            } else {
                e.DrawBackground();
            }
        }

        void TransactionListDrawSubItem(object sender, DrawListViewSubItemEventArgs e){
            DalTransaction transaction = (DalTransaction) e.Item.Tag;
            StringFormat sf = new StringFormat();
            Brush brush = Brushes.Black;
            if (e.Item.Selected){
                brush = selectedText;
            }

            // draw date
            int dateX = 7;
            string text = transaction.When.ToShortDateString();
            Rectangle bounds = new Rectangle(e.Bounds.X + dateX, e.Bounds.Y + 1, e.Bounds.Width - dateX, e.Bounds.Height - 1);
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Near;
            e.Graphics.DrawString(text, Configuration.DEFAULT_FONT, brush, bounds, sf);

            // draw reason
            int reasonX = (int) (Configuration.DEFAULT_FONT.Size * 17);
            text = transaction.Reason.Name;
            bounds = new Rectangle(e.Bounds.X + reasonX, e.Bounds.Y + 1, e.Bounds.Width - reasonX, e.Bounds.Height - 1);
            e.Graphics.DrawString(text, Configuration.BOLD_FONT, brush, bounds, sf);

            // draw ammount
            int ammountX = 7;
            int ammountY = 4;
            text = Util.FormatCurrency(transaction.Ammount);
            bounds = new Rectangle(e.Bounds.X, e.Bounds.Y + 1, e.Bounds.Width - ammountX, e.Bounds.Height - ammountY);
            sf.Alignment = StringAlignment.Far;
            sf.LineAlignment = StringAlignment.Far;
            if (transaction.To.IsBudget){
                brush = Brushes.Red;
            } else if (transaction.From.IsBudget) {
                brush = Brushes.MediumBlue;
            }
            if (e.Item.Selected){
                brush = selectedText;
            }
            e.Graphics.DrawString(text, Configuration.DEFAULT_FONT, brush, bounds, sf);

            // draw locations
            int locationsX = (int) (Configuration.DEFAULT_FONT.Size * 7);
            text = string.Format("{0} --> {1}", transaction.From, transaction.To);
            bounds = new Rectangle(e.Bounds.X + locationsX, e.Bounds.Y + 1, e.Bounds.Width - locationsX, e.Bounds.Height - 4);
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Far;
            brush = Brushes.DarkGray;
            if (e.Item.Selected){
                brush = selectedText;
            }
            e.Graphics.DrawString(text, Configuration.ITALIC_FONT, brush, bounds, sf);
        }

        void TransactionListSelectedIndexChanged(object sender, EventArgs e){
            if (SelectedIndexChanged != null){
                SelectedIndexChanged(sender, e);
            }
        }
    }
}
