using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Build_Sanity_Suit
{
    public static class Helper
    {

        public static ReadData  ReadDataFromJSONFile()
        {
            using (StreamReader r = new StreamReader("..\\..\\AllData.json"))
            {

                string json = r.ReadToEnd();
                ReadData readData = new ReadData();
                readData = (ReadData)ObjectDeserializer(readData, json);
                //This is how you read data: readData.accountData.address1_line1

                return readData;
            }
        }



        public static object ObjectDeserializer(object jsonData, string jsonDatatoString)
        {
            using (var dms = new MemoryStream(Encoding.Unicode.GetBytes(jsonDatatoString)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(jsonData.GetType());
                jsonData = deserializer.ReadObject(dms);
                return jsonData;
            }
        }

        static string logFile = System.IO.Directory.GetCurrentDirectory() + @"\\Logger_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt";
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
