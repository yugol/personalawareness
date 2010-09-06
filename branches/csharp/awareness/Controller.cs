/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 7/23/2009
 * Time: 2:14 PM
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
using Awareness.DB;
using Awareness.UI;
using System.Diagnostics;

namespace Awareness
{
	public delegate void DataChangedHandler();

	public static class Controller
	{
		public static event DataChangedHandler StorageOpened;
		public static event DataChangedHandler StorageClosing;
		
		static string GetFileExtension(string fileName)
		{
			return fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
		}

		static DataStorage storage;
		public static DataStorage Storage
		{
			get {
				return storage;
			}
		}

		static FormMain view;
		public static FormMain View
		{
			get {
				return view;
			}
			set {
				view = value;
			}
		}

		public static void OpenStorage(string storageId)
		{
			Debug.WriteLine("Controller.OpenStorage |-");

			CloseStorage();

			string ext = GetFileExtension(storageId);

			if (ext == "sdf" || ext == "mfd") {
				storage = new Awareness.DB.Mssql.DataStorage(storageId);
			}

			if (storage != null) {
				Configuration.LastStorageId = storageId;
				if (StorageOpened != null) {
					StorageOpened();
				}
			}

			Debug.WriteLine("Controller.OpenStorage -|");
		}

		public static void DumpSql(string fileName)
		{
			StreamWriter writer = new StreamWriter(fileName, false);
			string ext = GetFileExtension(fileName);
			Dumper dumper = null;
			
			try {
				if (ext == "ssql") {
					dumper = new Awareness.DB.Mssql.Dumper(storage);
				}
				dumper.DumpAll(writer);
			} finally {
				if (writer != null) {
					writer.Dispose();
				}
			}
		}

		public static void RestoreFromSqlDump(string fileName)
		{
			StreamReader reader = null;
			try {
				reader = new StreamReader(fileName);
				if (StorageClosing != null) {
					StorageClosing();
				}
				storage.RestoreDb(reader);
			} finally {
				if (reader != null) {
					reader.Dispose();
				}
				if (StorageOpened != null) {
					StorageOpened();
				}
			}
		}

		public static void CloseStorage()
		{
			if (storage != null) {
				if (StorageClosing != null) {
					StorageClosing();
				}
				storage.Close();
			}
			storage = null;
		}

		public static bool IsDBAvailable()
		{
			return (storage != null);
		}

	}
}
