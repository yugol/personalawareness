/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 31/08/2008
 * Time: 01:02
 *
 */
using System;
using System.Windows.Forms;

using awareness.db;
using awareness.ui;

namespace awareness
{
    public class ActionNewDatabase {
        FormMain mainForm = null;

        public ActionNewDatabase(FormMain mainForm){
            this.mainForm = mainForm;
        }

        public void Run(){
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = Configuration.DATA_FILTER;
            sfd.InitialDirectory = Configuration.DATA_FOLDER;
            if (sfd.ShowDialog() == DialogResult.OK){
                string newDatabaseName = sfd.FileName;
                DbUtil.CreateDataContext(newDatabaseName);
                new ActionOpenDatabase(mainForm, newDatabaseName).Run();
            }
        }
    }
}
