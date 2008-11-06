/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 31/08/2008
 * Time: 00:28
 *
 */
using System;
using System.IO;
using System.Windows.Forms;

using awareness.db;
using awareness.ui;

namespace awareness
{
    public class ActionOpenDatabase {
        string databaseName = null;
        FormMain mainForm = null;

        public static string UiPickDatabaseName(){
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = Configuration.DATA_FILTER;
            ofd.InitialDirectory = Configuration.DATA_FOLDER;
            if (ofd.ShowDialog() == DialogResult.OK){
                return ofd.FileName;
            }
            return "";
        }

        public ActionOpenDatabase(FormMain mainForm){
            this.mainForm = mainForm;
            this.databaseName = Configuration.LAST_DATABASE_NAME;
        }

        public ActionOpenDatabase(FormMain mainForm, string databaseName){
            this.mainForm = mainForm;
            this.databaseName = databaseName;
        }

        public void Run(){
            if (!string.IsNullOrEmpty(databaseName)){
                try {
                    DbUtil.OpenDataContext(databaseName);
                } catch (Exception err)   {
                    MessageBox.Show(err.Message, "Could not open database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    databaseName = "";
                }
            }
            ChangeConfiguration();
            ChangeUi();
        }

        void ChangeConfiguration(){
            Configuration.LAST_DATABASE_NAME = databaseName;
        }

        void ChangeUi(){
            mainForm.DisableEnableActions();
            string titleText = "Personal Awareness";
            if (Configuration.LAST_DATABASE_NAME != ""){
                titleText += " - ";
                titleText += Path.GetFileName(Configuration.LAST_DATABASE_NAME);
            }
            mainForm.Text = titleText;
        }
    }
}
