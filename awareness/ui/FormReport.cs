/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 16/09/2008
 * Time: 22:55
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace awareness.ui
{
    public partial class FormReport : Form
    {
        public ZedGraphControl Graph
        {
            get { return graphControl; }
        }
        
        public FormReport()
        {
            InitializeComponent();
        }
    }
}
