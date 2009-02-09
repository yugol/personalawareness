/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 31/08/2008
 * Time: 00:33
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
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness
{
    internal static class Configuration {
        // TODO: add some Guttenberg project books (problem when inserting large texts from SQL in SQL Server, works in Compact)
        // TODO: yes / no dialog when you want to delete note
        // TODO: calendar colors
        
        internal static readonly float DBVersion = 1.0F;
        internal static readonly string AppVersion = "0.1.6";
        
        
//#if DEBUG
//        static string dataFolder = @"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data";
//        internal const string DATA_FILTER = "SQL Server (*.mdf)|*.mdf|SQL Server Compact (*.sdf)|*.sdf";
//#else
        static string dataFolder = Path.Combine(Application.StartupPath, "data");
        internal const string DATA_FILTER = "SQL Server Compact (*.sdf)|*.sdf|SQL Server (*.mdf)|*.mdf";
//#endif

        internal static string DATA_FOLDER { get { return dataFolder; } }

        static Configuration(){
            ManagerReminders.Load();

            if (!Directory.Exists(DATA_FOLDER)){
                Directory.CreateDirectory(DATA_FOLDER);
            }

            DBUtil.DataContextClosing += new DatabaseChangedHandler(ClearDBProperties);
        }

        static string lastDatabaseName = "";
        internal static string LAST_DATABASE_NAME
        {
            get {return lastDatabaseName;}
            set {lastDatabaseName = value;}
        }

        internal static readonly DateTime ZERO_DATE = new DateTime(1800, 01, 01, 0, 0, 0);
        internal static readonly DateTime MIN_DATE_TIME = new DateTime(1900, 1, 1);
        internal static readonly DateTime MAX_DATE_TIME = new DateTime(3000, 1, 1);
        internal static readonly string DATE_FORMAT = "MMM d, yyyy";
        internal static readonly string TIME_FORMAT = "HH:mm";
        internal static readonly string FULL_TIME_FORMAT = "HH:mm:ss";
        internal static readonly string DATE_TIME_FORMAT = DATE_FORMAT + "   " + TIME_FORMAT;
        internal static readonly string DATE_FULL_TIME_FORMAT = DATE_FORMAT + "   " + FULL_TIME_FORMAT;
        internal static readonly string SATUS_DATE_TIME_FORMAT = "dddd, " + DATE_FORMAT + " . ( " + TIME_FORMAT + " )";
        
        internal const int MAX_REPEAT_TIMES = 10000;
        internal static readonly RecurrencePattern DEFAULT_RECURRENCE_PATTERN = new RecurrencePattern(RecurrencePattern.STEP_DAILY, 1, 0);

        internal static readonly string FOOD_ENERGY_MEASURE_UNIT = "kcal/100g";
        internal const int LIST_VIEW_SCROLL_BAR_WIDTH = 25;

        internal static readonly Color ALTERNATE_BACKGROUND = SystemColors.Control; // Color.FromArgb(235, 235, 235);
        internal static readonly Color NORMAL_BACKGROUND = SystemColors.Window; //Color.FromArgb(255, 255, 255);

        internal static readonly Font DEFAULT_FONT = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Regular);
        internal static readonly Font BOLD_FONT = new Font(DEFAULT_FONT.FontFamily, DEFAULT_FONT.Size, FontStyle.Bold);
        internal static readonly Font ITALIC_FONT = new Font(DEFAULT_FONT.FontFamily, DEFAULT_FONT.Size - 1, FontStyle.Italic);

        #region DB Properties

        private static XmlProperties dbProperties = null;
        
        internal static XmlProperties DBProperties {
            get {
                if (dbProperties == null){
                    dbProperties = new XmlProperties(DBUtil.GetProperties().Xml);
                }
                return dbProperties;
            }
        }
        
        private static void ClearDBProperties() {
            dbProperties = null;
        }

        #endregion
    }
}
