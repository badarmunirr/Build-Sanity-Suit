﻿using AventStack.ExtentReports;
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
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{

    public class TestBase
    {

        public static ExtentReports extent = null;
        public ExtentTest test = null;
        public readonly string ReportFile = System.IO.Directory.GetCurrentDirectory() + "\\TestResults\\" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Second.ToString() + "Report.html";
        public TestContext TestContext { get; set; }
        public WebClient client = null;
        public XrmApp xrmApp = null;
        public WebDriverWait wait = null;

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
             client = new Microsoft.Dynamics365.UIAutomation.Api.UCI.WebClient(TestSetting.options);
             xrmApp = new XrmApp(client);

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
            Screenshot ss = ((ITakesScreenshot)client.Browser.Driver).GetScreenshot();
            string path = Directory.GetCurrentDirectory() + TestContext.TestName + ".png";
            ss.SaveAsFile(path);
            this.TestContext.AddResultFile(path);
            client.Browser.Driver.Close();

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
        public void RoleBasedLogin(string user, string pwd)
        {
            By uid = By.Id("i0116");
            By pwdinput = By.Id("passwordInput");
            By submitbutton = By.Id("submitButton");
            By nextbutton = By.Id("idSIButton9");
            By redirect = By.Id("idSubmit_ProofUp_Redirect");
            By skipsteup = By.PartialLinkText("Skip setup");
            By iframe = By.CssSelector("iframe#AppLandingPage");
             wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));
            client.Browser.Driver.Navigate().GoToUrl(Usersetting.url);
            client.Browser.Driver.WaitUntilVisible(uid);
            if (client.Browser.Driver.HasElement(uid))
            {

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(uid)).SendKeys(user);
                client.Browser.Driver.FindElement(uid).SendKeys(Keys.Enter);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(pwdinput)).SendKeys(pwd);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(submitbutton)).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(nextbutton)).SendKeys(Keys.Enter);

                if (client.Browser.Driver.HasElement(redirect))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(redirect)).SendKeys(Keys.Enter);
                }
                else
                {
                    Console.WriteLine("No Such Element");
                }
                //if (client.Browser.Driver.HasElement(skipsteup))
                //{
                //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(skipsteup)).Click();

                //}
                //else
                //{
                //    Console.WriteLine("No Such Element");
                //}
                //if (client.Browser.Driver.HasElement(nextbutton))
                //{
                //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(nextbutton)).SendKeys(Keys.Enter);
                //}
                //else
                //{
                //    Console.WriteLine("No Such Element");
                //}
                string url = client.Browser.Driver.Url;
                if (url == Usersetting.url + "main.aspx?forceUCI=1&pagetype=apps")
                {
                    client.Browser.Driver.WaitForPageToLoad();
                    client.Browser.Driver.WaitUntilVisible(iframe);
                    xrmApp.Navigation.OpenApp(Usersetting.AppName);

                }
                else
                {
                    client.Browser.Driver.Navigate().GoToUrl(Usersetting.url);
                    client.Browser.Driver.WaitForPageToLoad();
                }

            }



        }

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
