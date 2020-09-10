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
        public static void LogRecord(string Message)
        {

            string LoggerPath = System.IO.Directory.GetCurrentDirectory() + "\\Logger.txt";
            File.WriteAllText(LoggerPath, Message);
        }
    }
}
