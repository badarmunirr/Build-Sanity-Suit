using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Sanity_Suit
{
    public static class Helper
    {
        static string logFile = System.IO.Directory.GetCurrentDirectory() + @"\\Logs\\Logger_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt";
        public static void LogRecord(string Message)
        {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFile, true))
            {
                file.WriteLine(Message);
            }
            //string LoggerPath = System.IO.Directory.GetCurrentDirectory() + "\\Logger.txt";
            //File.WriteAllText(LoggerPath, Message);
        }
    }
}
