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

namespace Awareness.db
{
    partial class DBUtil {
        
        internal static void InsertAction(DalAction action, DalNote note){
            if (action.Parent == null){
                action.Parent = GetRootAction();
            }
            PreludeInsertNotable(action, note, AwarenessDataContext.NOTE_ACTIONS_ID);
            dataContext.actions.InsertOnSubmit(action);
            dataContext.SubmitChanges();
            NotifyActionsChanged();
        }

        internal static void UpdateAction(DalAction action, DalNote note){
            UpdateActionNoNotification(action, note);
            NotifyActionsChanged();
        }

        internal static void UpdateActionNoNotification(DalAction action, DalNote note){
            PreludeUpdateNotable(action, note, AwarenessDataContext.NOTE_ACTIONS_ID);
        }

        internal static void DeleteActionRec(DalAction action){
            foreach (DalAction child in GetChildActions(action)){
                DeleteActionRec(child);
            }
            DeleteOneAction(action);
            NotifyActionsChanged();
        }

        private static void DeleteOneAction(DalAction action){
            DalNote note = (action.HasNote) ? (action.Note) : (null);
            dataContext.actions.DeleteOnSubmit(action);
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
