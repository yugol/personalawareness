/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 7/25/2009
 * Time: 1:36 PM
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
        public override void InsertTransactionReason(DalReason reason, DalNote note)
        {
            PreludeInsertNotable(reason, note, DataStorage.NOTE_REASONS_ID);
            dataContext.transactionReasons.InsertOnSubmit(reason);
            dataContext.SubmitChanges();
            NotifyTransactionReasonsChanged(reason);
        }

        public override void UpdateTransactionReason(DalReason reason, DalNote note)
        {
            PreludeUpdateNotable(reason, note, DataStorage.NOTE_REASONS_ID);
            NotifyTransactionReasonsChanged(reason);
        }

        public override void UpdateTransactionReason(int id, sbyte type, string name, float energy, DalNote note)
        {
            DalReason reason = dataContext.GetReasonById(id);
            PreludeUpdateNotable(reason, note, DataStorage.NOTE_REASONS_ID);
            dataContext.UpdateTransactionReasonType(id, type, name, energy);
            ReOpen();
        }

        public override void DeleteTransactionReason(DalReason reason)
        {
            try {
                DalNote note = (reason.HasNote) ? (reason.Note) : (null);
                dataContext.transactionReasons.DeleteOnSubmit(reason);
                dataContext.SubmitChanges();
                if (note != null) {
                    DeleteNote(note);
                }
                NotifyTransactionReasonsChanged(reason);
            } catch (Exception ex) {
                ReOpen();
                throw ex;
            }
        }

    }
}
