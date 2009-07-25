/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 7/25/2009
 * Time: 12:17 PM
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

namespace Awareness.db.mssql
{
    partial class DataStorage
    {
        public override void InsertTransferLocation(DalTransferLocation transferLocation, DalNote note)
        {
            PreludeInsertNotable(transferLocation, note, NOTE_TRANSFER_LOCATIONS_ID);
            dataContext.transferLocations.InsertOnSubmit(transferLocation);
            dataContext.SubmitChanges();
            NotifyTransferLocationsChanged(transferLocation);
        }

        public override void UpdateTransferLocation(DalTransferLocation transferLocation, DalNote note)
        {
            PreludeUpdateNotable(transferLocation, note, NOTE_TRANSFER_LOCATIONS_ID);
            NotifyTransferLocationsChanged(transferLocation);
        }

        public override void DeleteTransferLocation(DalTransferLocation transferLocation)
        {
            DalNote note = (transferLocation.HasNote) ? (transferLocation.Note) : (null);
            dataContext.transferLocations.DeleteOnSubmit(transferLocation);
            dataContext.SubmitChanges();
            if (note != null){
                DeleteNote(note);
            }
            NotifyTransferLocationsChanged(transferLocation);
        }
    }
}
