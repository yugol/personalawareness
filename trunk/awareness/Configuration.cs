/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 31/08/2008
 * Time: 00:33
 *
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using awareness.db;

namespace awareness
{
    public static class Configuration {
        // TODO: save meal report reason
        // TODO: add some Guttenberg project books
        // TODO: notes can be marked as readonly
        // FEATURE: calculator dialog
        // FEATURE: calendar dialog
        // FEATURE: tea timer
        // TODO: set min date and max date for all controls
        // TODO: limits for all DateTimePickers
        // TODO: implement dirty bit for reports update update

#if DEBUG
        static string dataFolder = @"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data";
        internal const string DATA_FILTER = "SQL Server (*.mdf)|*.mdf|SQL Server Compact (*.sdf)|*.sdf";
#else
        static string dataFolder = Path.Combine(Application.StartupPath, "data");
        internal const string DATA_FILTER = "SQL Server Compact (*.sdf)|*.sdf|SQL Server (*.mdf)|*.mdf";
#endif

        internal static string DATA_FOLDER { get { return dataFolder; } }

        static Configuration(){
            if (!Directory.Exists(DATA_FOLDER)){
                Directory.CreateDirectory(DATA_FOLDER);
            }
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
        internal const int MAX_REPEAT_TIMES = 10000;
        internal static readonly RecurrencePattern DEFAULT_RECURRENCE_PATTERN = new RecurrencePattern(RecurrencePattern.STEP_DAILY, 1, 0);

        internal static string FOOD_ENERGY_MEASURE_UNIT = "kcal/100g";
        internal const int LIST_VIEW_SCROLL_BAR_WIDTH = 25;

        internal static Color ALTERNATE_BACKGROUND = SystemColors.Control; // Color.FromArgb(235, 235, 235); // TODO: search for show selection when unfocused
        internal static Color NORMAL_BACKGROUND = SystemColors.Window; //Color.FromArgb(255, 255, 255);

        internal static Font DEFAULT_FONT = new Font(SystemFonts.DefaultFont.FontFamily, SystemFonts.DefaultFont.Size, FontStyle.Regular);
        internal static Font BOLD_FONT = new Font(DEFAULT_FONT.FontFamily, DEFAULT_FONT.Size, FontStyle.Bold);
        internal static Font ITALIC_FONT = new Font(DEFAULT_FONT.FontFamily, DEFAULT_FONT.Size - 1, FontStyle.Italic);
    }
}
