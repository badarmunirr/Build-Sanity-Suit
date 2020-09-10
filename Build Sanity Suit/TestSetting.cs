using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    class TestSetting
    {
        public static BrowserOptions options = new BrowserOptions
        {
            BrowserType = BrowserType.Chrome,
            PrivateMode = true,
            FireEvents = false,
            Headless = false,
            UserAgent = false,

        };

    }
    public class Variables
    {
        public static string url = System.Configuration.ConfigurationManager.AppSettings["CRMUrl"].ToString();
        public static string user = System.Configuration.ConfigurationManager.AppSettings["CRMUser"].ToString();
        public static string pwd = System.Configuration.ConfigurationManager.AppSettings["CRMPassword"].ToString();
        public static string AppName = System.Configuration.ConfigurationManager.AppSettings["AppName"].ToString();
        public static string Sitemapsection = System.Configuration.ConfigurationManager.AppSettings["Sitemapsection"].ToString();
        public static string Sitemapsubsection = System.Configuration.ConfigurationManager.AppSettings["Sitemapsubsection"].ToString();
    }


    public class LOGIN
    {
        // [TestMethod, TestCategory("BuildAutomation")]

        public WebClient Login()
        {

            WebClient client = new Microsoft.Dynamics365.UIAutomation.Api.UCI.WebClient(TestSetting.options);
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            client.Browser.Driver.Navigate().GoToUrl(Variables.url);
            xrmApp.ThinkTime(5000);
            if (client.Browser.Driver.HasElement(By.Id("i0116")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("i0116")));
                client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Variables.user);
                client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Keys.Enter);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("passwordInput")));
                client.Browser.Driver.FindElement(By.Id("passwordInput")).SendKeys(Variables.pwd);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("submitButton")));
                client.Browser.Driver.FindElement(By.Id("submitButton")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
                client.Browser.Driver.FindElement(By.Id("idSIButton9")).SendKeys(Keys.Enter);
                if (client.Browser.Driver.HasElement(By.Id("idSubmit_ProofUp_Redirect")))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("idSubmit_ProofUp_Redirect")));
                    client.Browser.Driver.FindElement(By.Id("idSubmit_ProofUp_Redirect")).SendKeys(Keys.Enter);
                }
                else
                {
                    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
                }
                if (client.Browser.Driver.HasElement(By.PartialLinkText("Skip setup")))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Skip setup")));
                    client.Browser.Driver.FindElement(By.PartialLinkText("Skip setup")).Click();
                }
                else
                {
                    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
                }
                if (client.Browser.Driver.HasElement(By.Id("idSIButton9")))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
                    client.Browser.Driver.FindElement(By.Id("idSIButton9")).SendKeys(Keys.Enter);
                }
                else
                {
                    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
                }
                client.Browser.Driver.Navigate().GoToUrl(Variables.url + "main.aspx?forceUCI=1&pagetype=apps");
                xrmApp.ThinkTime(10000);
                xrmApp.Navigation.OpenApp(Variables.AppName);

            }
            return client;
            //if ( client.Browser.Driver.HasElement(By.Id("i0116")))
            //{
            //     client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Variables.user);
            //}
            //else
            //{
            //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //}
            // xrmApp.ThinkTime(25000);
            //if ( client.Browser.Driver.HasElement(By.Id("i0116")))
            //{
            //     client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Keys.Enter);
            //}
            //else
            //{
            //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //}

            // xrmApp.ThinkTime(20000);
            //if ( client.Browser.Driver.HasElement(By.Id("passwordInput")))
            //{
            //     client.Browser.Driver.FindElement(By.Id("passwordInput")).SendKeys(Variables.pwd);
            //}
            //else
            //{
            //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //}
            // xrmApp.ThinkTime(10000);
            // client.Browser.Driver.FindElement(By.Id("submitButton")).Click();
            // xrmApp.ThinkTime(10000);
            //if ( client.Browser.Driver.HasElement(By.Id("idSIButton9")))
            //{
            //     client.Browser.Driver.FindElement(By.Id("idSIButton9")).SendKeys(Keys.Enter);
            //}
            //else
            //{
            //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //}
            //}
            //else
            //{
            //    Console.WriteLine("Element is visible");
            //}
            // client.Browser.Driver.Close();

        }


    }

    public class HelperFunction
    {
        public void Lookup(String LookupFieldName, String LookupFieldValue,XrmApp xrmApp)
        {
            LookupItem LookupVeriable = new LookupItem { Name = LookupFieldName, Value = LookupFieldValue, Index = 0 };
            xrmApp.Entity.SetValue(LookupVeriable);

        }
        public void LookupQuickCreate(String LookupFieldName, String LookupFieldValue, XrmApp xrmApp)
        {

            LookupItem LookupQuickVeriable = new LookupItem { Name = LookupFieldName, Value = LookupFieldValue, Index = 0 };
              xrmApp.QuickCreate.SetValue(LookupQuickVeriable);

        }

    }

}


