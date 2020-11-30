using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using System;
using System.IO;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Runtime.Serialization.Json;
using System.Text;


namespace Build_Sanity_Suit
{

    public class TestBase
    {
        public static LOGIN loginobj = new LOGIN();
        public static ExtentReports extent = null;
        public ExtentTest test = null;


        public readonly string ReportFile = System.IO.Directory.GetCurrentDirectory() + "\\TestResults\\" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Second.ToString() + "Report.html";

        public TestContext TestContext { get; set; }



        [TestInitialize]
        public void Initialize()
        {

            if (extent == null)
            {
                extent = new ExtentReports();
                extent.AddSystemInfo("Browser", Enum.GetName(typeof(BrowserType), BrowserType.Chrome));

                extent.AddSystemInfo("D365 CE Instance",
                    System.Configuration.ConfigurationManager.AppSettings["CRMUrl"]);
                extent.AddSystemInfo("Result File",
                    System.IO.Directory.GetCurrentDirectory() + "\\TestResults\\");

            }


            var htmlReporter = new ExtentHtmlReporter(ReportFile);
            htmlReporter.Config.Theme = Theme.Dark;
            extent.AttachReporter(htmlReporter);
            test = extent.CreateTest(TestContext.TestName).Info("Test Started");
        }


        public void Cleanup(string value)
        {
            if (TestContext.CurrentTestOutcome.ToString() == "Passed")
            {

                test.Log(Status.Info, "Test Ended");
                test.Log(Status.Pass, "Test Passed");
                //client.Browser.Driver.Close();

            }
            else if (TestContext.CurrentTestOutcome.ToString() == "Failed")
            {
                test.Log(Status.Info, "Test Ended");
                test.Log(Status.Fail, "Test Failed");
            }
            extent.Flush();

            string Message = "\r\n" + TestContext.FullyQualifiedTestClassName + "\r\n" + TestContext.TestName + "\r\n" + TestContext.CurrentTestOutcome + "\r\n" + value + "\r\n";
            Helper.LogRecord(Message);


        }


        public void AddScreenShot(WebClient client, string title)
        {


            var filePath = System.IO.Directory.GetCurrentDirectory() + "\\TestResults\\" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Second.ToString() + ".png";
            // Wait for the page to be idle (UCI only)
            client.Browser.Driver.WaitForTransaction();
            client.Browser.TakeWindowScreenShot(filePath, ScreenshotImageFormat.Png);

            test.Info(title, MediaEntityBuilder.CreateScreenCaptureFromPath(filePath).Build());
        }

        //[AssemblyInitialize]
        //public static void AssemblyInitialize()
        //{
        //    var chromeProcesses = Process.GetProcessesByName("chromedriver");
        //    foreach (var process in chromeProcesses)
        //    {
        //        process.Kill();
        //    }
        //    var geckoProcesses = Process.GetProcessesByName("geckodriver");
        //    foreach (var process in geckoProcesses)
        //    {
        //        process.Kill();
        //    }
        //    var ieDriverServiceProcesses = Process.GetProcessesByName("IEDriverServer");
        //    foreach (var process in ieDriverServiceProcesses)
        //    {
        //        process.Kill();
        //    }

        //}

    }


    public static class Helper
    {

        public static ReadData ReadDataFromJSONFile()
        {
            using (StreamReader r = new StreamReader("..\\..\\DataFiles\\AllData.json"))
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

        static readonly string logFile = System.IO.Directory.GetCurrentDirectory() + "\\TestResults\\" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt";
        static readonly string refile = System.IO.Directory.GetCurrentDirectory() + "\\TestResults\\Ref" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".txt";

        public static void LogRecord(string Message)
        {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFile, true))
            {
                file.WriteLine(Message);
                file.Close();
            }
            //string LoggerPath = System.IO.Directory.GetCurrentDirectory() + "\\Logger.txt";
            //File.WriteAllText(LoggerPath, Message);
        }

        public static void CheckExistingFiles()
        {
            DirectoryInfo d = new DirectoryInfo(System.IO.Directory.GetCurrentDirectory() + "\\TestResults\\");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.txt"); //Getting Text files
            string str = "";
            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;

                if (str != refile)
                {
                    file.Delete();
                }
            }

        }

        public static void SaveReferral(string Message)
        {
            CheckExistingFiles();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(refile, true))
            {
                file.WriteLine(Message);
            }
            //string LoggerPath = System.IO.Directory.GetCurrentDirectory() + "\\Logger.txt";
            //File.WriteAllText(LoggerPath, Message);
        }
        public static string ReadReferral()
        {
            string[] lines = File.ReadAllLines(refile);
            string SolutionName = lines[0].Replace("SolutionName:-", "").Trim();
            //Console.WriteLine(SolutionName);

            return SolutionName;
        }


    }
}
