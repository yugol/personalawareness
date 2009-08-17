/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 7/23/2009
 * Time: 3:41 PM
 *
 *
 * Copyright (c) 2008, 2009 Iulian GORIAC
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
using System;
using System.IO;

namespace Awareness.db.mssql
{
    public partial class DataStorage : Awareness.db.DataStorage
    {
        AwarenessDataContext dataContext;

        public DataStorage(string storageId)
        : base(storageId)
        {
            Open();
            nick = Path.GetFileName(storageId);
        }

        void Open()
        {
            if (!File.Exists(ConnectionString)) {
                dataContext = new AwarenessDataContext(ConnectionString);
                dataContext.CreateDatabase();
            } else {
                dataContext = new AwarenessDataContext(ConnectionString);
            }
        }

        void ReOpen()
        {
            Close();
            Open();
        }

        public override void Close()
        {
            dataContext.Connection.Close();
            dataContext.Dispose();
        }

        public override void Delete()
        {
            dataContext.Connection.Close();
            dataContext.DeleteDatabase();
        }

    }
}
