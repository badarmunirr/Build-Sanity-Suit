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
    }
}
