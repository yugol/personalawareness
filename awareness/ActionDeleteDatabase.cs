/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 31/08/2008
 * Time: 02:44
 *
 */
using System;

using awareness.db;
using awareness.ui;

namespace awareness
{
    public class ActionDeleteDatabase {
        FormMain mainForm = null;

        public ActionDeleteDatabase(FormMain mainForm){
            this.mainForm = mainForm;
        }

        public void Run(){
            DbUtil.DeleteDataContext();
            new ActionOpenDatabase(mainForm, "").Run();
        }
    }
}
