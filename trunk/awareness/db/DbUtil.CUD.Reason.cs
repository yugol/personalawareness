/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 09/12/2008
 * Time: 22:50
 *
 *
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


using System;

namespace Awareness.DB
{
    partial class DBUtil {

        internal static void InsertTransactionReason(DalReason reason, DalNote note){
            PreludeInsertNotable(reason, note, AwarenessDataContext.NOTE_REASONS_ID);
            dataContext.transactionReasons.InsertOnSubmit(reason);
            dataContext.SubmitChanges();
            NotifyTransactionReasonsChanged(reason);
        }

        internal static void UpdateTransactionReason(DalReason reason, DalNote note){
            PreludeUpdateNotable(reason, note, AwarenessDataContext.NOTE_REASONS_ID);
            NotifyTransactionReasonsChanged(reason);
        }

        internal static void UpdateTransactionReason(int id, sbyte type, string name, float energy, DalNote note){
            DalReason reason = dataContext.GetReasonById(id);
            PreludeUpdateNotable(reason, note, AwarenessDataContext.NOTE_REASONS_ID);
            dataContext.UpdateTransactionReasonType(id, type, name, energy);
            ReOpenDataContext();
        }

        internal static void DeleteTransactionReason(DalReason reason){
            try {
                DalNote note = (reason.HasNote) ? (reason.Note) : (null);
                dataContext.transactionReasons.DeleteOnSubmit(reason);
                dataContext.SubmitChanges();
                if (note != null){
                    DeleteNote(note);
                }
                NotifyTransactionReasonsChanged(reason);
            } catch (Exception ex) {
                ReOpenDataContext();
                throw ex;
            }
        }

        static void NotifyTransactionReasonsChanged(DalReason transactionReason){
            if (transactionReason is DalRecipe){
                if (RecipesChanged != null){
                    RecipesChanged();
                }
            } else if (transactionReason is DalFood) {
                if (FoodsChanged != null){
                    FoodsChanged();
                }
            } else if (transactionReason is DalConsumer) {
                if (ConsumersChanged != null){
                    ConsumersChanged();
                }
            } else {
                if (ReasonsChanged != null){
                    ReasonsChanged();
                }
            }
            if (TransactionReasonsChanged != null){
                TransactionReasonsChanged();
            }
        }
    }
}
