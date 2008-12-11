/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 19/11/2008
 * Time: 11:48
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
        private static bool IsEmpty (DalNote note) {
            if (note == null){
                return true;
            }
            if (note.Text.Trim() == ""){
                return true;
            }
            return false;
        }

        private static void PrepareNoteForNotable(DalNote note, Notable notable, int noteParentId){
            note.Parent = dataContext.GetNoteById(noteParentId);
            note.Title = notable.Name;
            note.IsPermanent = true;
        }

        private static void PreludeInsertNotable(Notable notable, DalNote note, int noteParentId) {
            if (!IsEmpty(note)){
                PrepareNoteForNotable(note, notable, noteParentId);
                StoreNote(note);
                notable.Note = note;
            } else {
                notable.Note = GetRootNote();
            }
        }

        private static void PreludeUpdateNotable(Notable notable, DalNote note, int noteParentId) {
            if (!notable.HasNote){
                if (!IsEmpty(note)){
                    PrepareNoteForNotable(note, notable, noteParentId);
                    StoreNote(note);
                    notable.Note = note;
                }
                dataContext.SubmitChanges();
            } else {
                DalNote oldNote = notable.Note;
                if (IsEmpty(note)){
                    notable.Note = GetRootNote();
                    dataContext.SubmitChanges();
                    DeleteNote(oldNote);
                } else {
                    PrepareNoteForNotable(note, notable, noteParentId);
                    StoreNote(note);
                    if (note.Id != oldNote.Id){
                        notable.Note = note;
                        dataContext.SubmitChanges();
                        DeleteNote(oldNote);
                    } else {
                        dataContext.SubmitChanges();
                    }
                }
            }
        }

        internal static void InsertNote(DalNote note){
            if (note.Parent == null){
                note.Parent = GetRootNote();
            }
            dataContext.notes.InsertOnSubmit(note);
            dataContext.SubmitChanges();
        }

        internal static void UpdateNote(DalNote note){
            if (note.Id == note.ParentId){
                throw new ArgumentException("Cannot parent a note to self");
            }
            dataContext.SubmitChanges();
        }

        internal static void StoreNote(DalNote note) {
            if (note.Id == 0){
                InsertNote(note);
            } else {
                UpdateNote(note);
            }
        }

        internal static void DeleteNote(DalNote note){
            if (note.Id <= AwarenessDataContext.RESERVED_NOTES){
                throw new ArgumentException("Trying to delete a reserved note");
            }
            dataContext.notes.DeleteOnSubmit(note);
            dataContext.SubmitChanges();
        }
        
    }
}
