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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using System.Diagnostics;

using Awareness.DB;

namespace Awareness
{
    internal static class Configuration {
        // COULD: add some Guttenberg project books (problem when inserting large texts from SQL in SQL Server, works in Compact)
        // SHOULD: calendar colors
        // MUST: Update on view structure

        static Configuration()
        {
        	InitGlobalProperties();
            ReadGlobalProperties();
            Controller.StorageOpened += new DataChangedHandler(ResetStorageProperties);
        }
        
        #region Version

        internal static readonly float DBVersion = 1.1F;
        
        #endregion
        
        #region Formatting
        
        internal static readonly DateTime ZERO_DATE = new DateTime(1800, 01, 01, 0, 0, 0);
        internal static readonly DateTime MIN_DATE_TIME = new DateTime(1900, 1, 1);
        internal static readonly DateTime MAX_DATE_TIME = new DateTime(3000, 1, 1);
        internal const string DATE_FORMAT = "MMM d, yyyy";
        internal const string TIME_FORMAT = "HH:mm";
        internal const string FULL_TIME_FORMAT = "HH:mm:ss";
        internal const string DATE_TIME_FORMAT = DATE_FORMAT + "   " + TIME_FORMAT;
        internal const string DATE_FULL_TIME_FORMAT = DATE_FORMAT + "   " + FULL_TIME_FORMAT;
        internal const string SATUS_DATE_TIME_FORMAT = "dddd, " + DATE_FORMAT + " . ( " + TIME_FORMAT + " )";

        #endregion
        
        #region Appearance

        internal const int MAX_REPEAT_TIMES = 10000;
        internal static readonly RecurrencePattern DEFAULT_RECURRENCE_PATTERN = new RecurrencePattern(RecurrencePattern.STEP_DAILY, 1, 0);

        internal static readonly string FOOD_ENERGY_MEASURE_UNIT = "kcal/100g";
        internal const int LIST_VIEW_SCROLL_BAR_WIDTH = 25;

        internal static readonly Color ALTERNATE_BACKGROUND = SystemColors.Control; // Color.FromArgb(235, 235, 235);
        internal static readonly Color NORMAL_BACKGROUND = SystemColors.Window; //Color.FromArgb(255, 255, 255);

        internal static readonly Font DEFAULT_FONT = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Regular);
        internal static readonly Font BOLD_FONT = new Font(DEFAULT_FONT.FontFamily, DEFAULT_FONT.Size, FontStyle.Bold);
        internal static readonly Font ITALIC_FONT = new Font(DEFAULT_FONT.FontFamily, DEFAULT_FONT.Size - 1, FontStyle.Italic);
        
        #endregion

        #region Storage

        internal const string DataFilter = "SQL Server Compact (*.sdf)|*.sdf|SQL Server (*.mdf)|*.mdf|All files (*.*)|*.*";

        static readonly string dataFolder = Path.Combine(Application.StartupPath, "data");
        internal static string DataFolder 
        { 
        	get 
        	{
	            if (!Directory.Exists(dataFolder)) {
	                Directory.CreateDirectory(dataFolder);
	            }
        		return dataFolder; 
        	}
        }
        
        #endregion
        
		#region Global Properties
		
		static string lastStorageId = "lastStorageId";
		static string mealManagerHistoryLength = "mealManagerHistoryLength";
		public const int defaultMealManagerHistoryLength = 50;
		
		static Dictionary<string, string> globalProperties = new Dictionary<string, string>();
		
		static void InitGlobalProperties() 
		{
			globalProperties.Add(lastStorageId, "");
			globalProperties.Add(mealManagerHistoryLength, defaultMealManagerHistoryLength.ToString());
		}
		
        public static int MealManagerHistoryLength 
        { 
        	get 
        	{ 
        		int len = defaultMealManagerHistoryLength;
        		try {
        			len = int.Parse(globalProperties[mealManagerHistoryLength]);
        		} catch {
        			globalProperties.Add(mealManagerHistoryLength, defaultMealManagerHistoryLength.ToString());
        			SaveGlobalProperties();
        		}
        		return len;
        	}
            set 
            {
            	globalProperties[mealManagerHistoryLength] = value.ToString();
            	SaveGlobalProperties();
            }
        }
		
        internal static string LastStorageId
        {
        	get { return globalProperties[lastStorageId]; }
            set 
            {
            	globalProperties[lastStorageId] = value;
            	SaveGlobalProperties();
            }
        }

        static string ConfigFileName 
        {
			get 
			{
				string configFileName = Path.Combine(Application.StartupPath,"config.properties");
				if(!File.Exists(configFileName)) {
					File.CreateText(configFileName).Close();
				}
				return configFileName;
			}
		}
		
		static void ReadGlobalProperties() 
		{
			string[] properties = File.ReadAllLines(ConfigFileName);
			foreach (string line in properties) {
				try {
					string[] prop = line.Split('=');
					prop[0] = prop[0].Trim();
					prop[1] = prop[1].Trim();
					globalProperties[prop[0]] = prop[1];
				} catch {
				}
			}
		}		
		
		static void SaveGlobalProperties() 
		{
			string[] properties = new string[globalProperties.Count];
			int index = 0;
			foreach (string key in globalProperties.Keys) {
				properties[index] = string.Format("{0}={1}", key, globalProperties[key]);
				++index;
			}
			File.WriteAllLines(ConfigFileName, properties);
		}
		
		#endregion
        
        #region Storage Properties
        
        static XmlProperties storageProperties = null;
        internal static XmlProperties StorageProperties {
            get {
                if (storageProperties == null){
                    storageProperties = new XmlProperties(Controller.Storage.GetProperties().Xml);
                }
                return storageProperties;
            }
        }
        static void ResetStorageProperties()
        {
            Debug.WriteLine("Configuration.ResetStorageProperties |-");
            
            storageProperties = null;
            
            Debug.WriteLine("Configuration.ResetStorageProperties -|");
        }
        
        #endregion

	}
}
