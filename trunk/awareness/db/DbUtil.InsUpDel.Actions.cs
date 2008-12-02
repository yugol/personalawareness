/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 24/11/2008
 * Time: 23:09
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

using System.Linq;

namespace awareness.db
{
    partial class DbUtil {
        internal static void AddAction(DalAction action){
            if (action.Parent == null){
                action.Parent = dataContext.GetActionById(AwarenessDataContext.ACTION_ROOT_ID);
            }

            action.Index = GetChildActions(action.Parent).Count();

            dataContext.actions.InsertOnSubmit(action);
            dataContext.SubmitChanges();

            NotifyActionsChanged();
        }

        internal static void InsertAction(int index, DalAction action){
            if (index < 0){
                index = 0;
            }

            if (action.Parent == null){
                action.Parent = dataContext.GetActionById(AwarenessDataContext.ACTION_ROOT_ID);
            }

            IQueryable<DalAction> postSiblings = GetChildActions(action.Parent).Where(a => a.Index >= index);
            foreach (DalAction sibling in postSiblings){
                sibling.Index += 1;
            }

            if (postSiblings.Count() > 0){
                action.Index = index;
            } else {
                action.Index = GetChildActions(action.Parent).Count();
            }

            dataContext.actions.InsertOnSubmit(action);
            dataContext.SubmitChanges();

            NotifyActionsChanged();
        }

        internal static void AttachNote(DalAction action){
            if (!action.HasNote){
                DalNote note = new DalNote();
                note.Parent = dataContext.GetNoteById(AwarenessDataContext.NOTE_ACTIONS_ID);
                note.Title = "";
                note.IsPermanent = true;
                InsertNote(note);
                action.Note = note;
                UpdateActionTimeStamp(action);
            }
        }

        internal static void UpdateActionTimeStamp(DalAction action){
            action.ModificationTime = RemoveMilliseconds(DateTime.Now);
            UpdateAction(action);
        }

        internal static void CompleteAction(DalAction action){
            action.CompletionTime = RemoveMilliseconds(DateTime.Now);
            UpdateAction(action);
        }

        internal static void UnCompleteAction(DalAction action){
            action.CompletionTime = Configuration.ZERO_DATE;
            UpdateAction(action);
        }

        internal static void UpdateAction(DalAction action){
            if (action.Id == action.ParentId){
                throw new ArgumentException("Cannot parent an action to self");
            }
            if (action.HasNote){
                action.Note.Title = action.Name;
                UpdateNote(action.Note);
            }
            dataContext.SubmitChanges();

            NotifyActionsChanged();
        }

        internal static void DeleteActionRecursive(DalAction action){
            foreach (DalAction child in GetChildActions(action)){
                DeleteActionRecursive(child);
            }
            DeleteAction(action);

            NotifyActionsChanged();
        }

        private static void DeleteAction(DalAction action){
            DalNote note = (action.HasNote) ? action.Note : null;
            int index = action.Index;

            dataContext.actions.DeleteOnSubmit(action);
            dataContext.SubmitChanges();

            IQueryable<DalAction> postSiblings = GetChildActions(action.Parent).Where(a => a.Index > index);
            foreach (DalAction sibling in postSiblings){
                sibling.Index -= 1;
            }
            dataContext.SubmitChanges();

            if (note != null){
                DeleteNote(note);
            }
        }

        private static void NotifyActionsChanged() {
            if (ActionsChanged != null){
                ActionsChanged();
            }
        }
    }
}
