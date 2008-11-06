/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 04/10/2008
 * Time: 12:24
 * 
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace awareness.ui
{
    public partial class ControlCommandSelector : UserControl
    {
        public event EventHandler CommandChanged;
        public event EventHandler TestClick;
        
        public string Command
        {
            get { return commandBox.Text; }
            set { commandBox.Text = value; }
        }
        
        public ControlCommandSelector()
        {
            InitializeComponent();
        }
        
        void CommandBoxTextChanged(object sender, EventArgs e)
        {
            if (CommandChanged != null)
            {
                CommandChanged(this, e);
            }
        }
        
        void BrowseButtonClick(object sender, EventArgs e)
        {
        	
        }
        
        void TestButtonClick(object sender, EventArgs e)
        {
            if (TestClick != null)
            {
                TestClick(this, e);
            }
        }
    }
}
