/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 11/09/2008
 * Time: 10:56
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class ControlAvailableFoods : UserControl
    {
        bool dirty;
        bool Dirty
        {
            get { return dirty; }
            set
            {
                datePicker.Enabled = value;
                whatBox.Enabled = value;
                whyCombo.Enabled = value;
                quantityBox.Enabled = value;
                consumeButton.Enabled = value;
                dirty = value;
            }
        }
        
        public ControlAvailableFoods()
        {
            InitializeComponent();
            
            DbUtil.DataContextChanged += new DatabaseChangedHandler(UpdateAvailableFoods);
            DbUtil.MealsChanged += new DatabaseChangedHandler(UpdateAvailableFoods);
            DbUtil.FoodsChanged += new DatabaseChangedHandler(UpdateAvailableFoods);
            DbUtil.TransactionsChanged += new DatabaseChangedHandler(UpdateAvailableFoods);
        }
        
        void UpdateAvailableFoods()
        {
            AwarenessDataContext dc = DbUtil.GetDataContext();
            IEnumerable<DalFood> foods = dc.transactionReasons.OfType<DalFood>().OrderBy(f => f.Name);
            availableFoodsView.Items.Clear();
            bool useAlternateBackground = false;
            foreach (DalFood food in foods)
            {
                float available = DbUtil.GetAvailableQuantity(food);
                if (available != 0)
                {
                    ListViewItem item = new ListViewItem(food.Name);
                    item.Tag = food;
                    item.SubItems.Add(available.ToString());
                    item.BackColor = useAlternateBackground ? Configuration.ALTERNATE_BACKGROUND : Configuration.NORMAL_BACKGROUND;
                    useAlternateBackground = !useAlternateBackground;
                    availableFoodsView.Items.Add(item);
                }
            }
            ClearEditBoxes();
        }
        
        void AvailableFoodsViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (availableFoodsView.SelectedItems.Count > 0)
            {
                DalFood what = (DalFood) availableFoodsView.SelectedItems[0].Tag;
                whatBox.Tag = what;
                whatBox.Text = what.Name;
                quantityBox.Text = availableFoodsView.SelectedItems[0].SubItems[1].Text;
                UiUtil.FillFoodConsumptionReasons(whyCombo, what);
                Dirty = true;
            }
            else
            {
                ClearEditBoxes();
            }
        }

        void ClearEditBoxes()
        {
            whatBox.Tag = null;
            whatBox.Text = "";
            quantityBox.Text = "";
            // whyCombo.SelectedItem = null;
            Dirty = false;
        }
        
        void ConsumeButtonClick(object sender, EventArgs e)
        {
            // TODO: run validation
            DalMeal meal = new DalMeal() 
            {
                When = datePicker.Value.Date, 
                What = (DalFood) whatBox.Tag, 
                Quantity = float.Parse(quantityBox.Text), 
                Why = (DalReason) whyCombo.SelectedItem 
            };
            DbUtil.InsertMeal(meal);
        }
        
        void WhyComboSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(whyCombo.SelectedItem is DalReason))
            {
                whyCombo.SelectedItem = null;
            }
        }
        
        void QuantityBoxValidating(object sender, CancelEventArgs e)
        {
            try
            {
                if (int.Parse(quantityBox.Text) <= 0)
                {
                    throw new ApplicationException();
                }
                errorProvider.Clear();
            }
            catch (Exception)
            {
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Please enter a positive integer value");
            }
        }
    }
    

}
