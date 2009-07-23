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
 * Date: 31/08/2008
 * Time: 01:02
 *
 */
using System;
using System.Windows.Forms;

using Awareness.db;
using Awareness.ui;

namespace Awareness
{
    public class ActionNewDatabase {
        FormMain mainForm = null;

        public ActionNewDatabase(FormMain mainForm){
            this.mainForm = mainForm;
        }

        public void Run(){
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = Configuration.DataFilter;
            sfd.InitialDirectory = Configuration.DataFolder;
            if (sfd.ShowDialog() == DialogResult.OK){
                string newDatabaseName = sfd.FileName;
                DBUtil.CreateDataContext(newDatabaseName);
                new ActionOpenDatabase(mainForm, newDatabaseName).Run();
            }
        }
    }
}
