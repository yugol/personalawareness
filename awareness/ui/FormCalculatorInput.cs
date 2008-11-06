/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 26/10/2008
 * Time: 20:19
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace awareness.ui
{
    /// <summary>
    /// Description of FormCalculatorInput.
    /// </summary>
    public partial class FormCalculatorInput : Form
    {
        private Calculator calc = new Calculator();
        
        bool isModal;
        public bool IsModal
        {
            get { return isModal; }
            set 
            { 
                isModal = value;
                buttonOk.Visible = isModal;
                buttonCancel.Visible = isModal;
            }
        }
        
        
        public FormCalculatorInput()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            IsModal = true;
            outputLabel.Text = calc.ValueString;
        }
        
        void Button1Click(object sender, EventArgs e)
        {
            calc.WriteChar('1');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button2Click(object sender, EventArgs e)
        {
            calc.WriteChar('2');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button3Click(object sender, EventArgs e)
        {
            calc.WriteChar('3');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button4Click(object sender, EventArgs e)
        {
            calc.WriteChar('4');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button5Click(object sender, EventArgs e)
        {
            calc.WriteChar('5');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button6Click(object sender, EventArgs e)
        {
            calc.WriteChar('6');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button7Click(object sender, EventArgs e)
        {
            calc.WriteChar('7');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button8Click(object sender, EventArgs e)
        {
            calc.WriteChar('8');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button9Click(object sender, EventArgs e)
        {
            calc.WriteChar('9');
            outputLabel.Text = calc.ValueString;
        }
        
        void Button0Click(object sender, EventArgs e)
        {
            calc.WriteChar('0');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonSignClick(object sender, EventArgs e)
        {
            calc.WriteChar('~');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonDotClick(object sender, EventArgs e)
        {
            calc.WriteChar('.');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonPlusClick(object sender, EventArgs e)
        {
            calc.WriteChar('+');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonMinusClick(object sender, EventArgs e)
        {
            calc.WriteChar('-');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonMultiplyClick(object sender, EventArgs e)
        {
            calc.WriteChar('*');
            outputLabel.Text = calc.ValueString;
        }
        
        void ButtonDivideClick(object sender, EventArgs e)
        {
            calc.WriteChar('/');
            outputLabel.Text = calc.ValueString;
        }
        
        
        void ButtonEqualsClick(object sender, EventArgs e)
        {
            calc.WriteChar('=');
            outputLabel.Text = calc.ValueString;
        }
                
        void ButtonClearEverythingClick(object sender, EventArgs e)
        {
            calc.WriteChar('C');
            outputLabel.Text = calc.ValueString;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!IsModal)
            {
                e.Cancel = true;
                Visible = false;
            }
        }
    }
}
