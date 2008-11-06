/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 30/08/2008
 * Time: 22:07
 *
 */
using System;
using System.Windows.Forms;

using awareness.ui;

namespace awareness {
    internal sealed class Program {
        [STAThread]
        private static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
