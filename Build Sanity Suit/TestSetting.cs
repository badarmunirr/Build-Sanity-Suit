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
    public static class global
    {

        public static WebClient client = new Microsoft.Dynamics365.UIAutomation.Api.UCI.WebClient(TestSetting.options);
        public static XrmApp xrmApp = new XrmApp(client);



    }

    public class LOGIN
    {
        [TestMethod, TestCategory("BuildAutomation")]

        public void Login()
        {

            WebDriverWait wait = new WebDriverWait(global.client.Browser.Driver, TimeSpan.FromSeconds(120000));
            global.xrmApp.ThinkTime(5000);
            if (global.client.Browser.Driver.HasElement(By.XPath("//*[contains(@data-text,'Home')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@data-text,'Home')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//*[contains(@data-text,'Home')]")).Click();
                global.xrmApp.ThinkTime(5000);
                if (global.client.Browser.Driver.HasElement(By.XPath("//button[contains(@data-id,'cancelButton')]")))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@data-id,'cancelButton')]")));
                    global.client.Browser.Driver.FindElement(By.XPath("//button[contains(@data-id,'cancelButton')]")).Click();
                }
                else
                {
                    Console.WriteLine("No Element found");
                }
            }
            else
            {
                Console.WriteLine("No Element found");
            }
            global.client.Browser.Driver.Navigate().GoToUrl(Variables.url);
            global.xrmApp.ThinkTime(5000);
            if (global.client.Browser.Driver.HasElement(By.Id("i0116")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("i0116")));
                global.client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Variables.user);
                global.client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Keys.Enter);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("passwordInput")));
                global.client.Browser.Driver.FindElement(By.Id("passwordInput")).SendKeys(Variables.pwd);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("submitButton")));
                global.client.Browser.Driver.FindElement(By.Id("submitButton")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
                global.client.Browser.Driver.FindElement(By.Id("idSIButton9")).SendKeys(Keys.Enter);
                if (global.client.Browser.Driver.HasElement(By.Id("idSubmit_ProofUp_Redirect")))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("idSubmit_ProofUp_Redirect")));
                    global.client.Browser.Driver.FindElement(By.Id("idSubmit_ProofUp_Redirect")).SendKeys(Keys.Enter);
                }
                else
                {
                    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
                }
                if (global.client.Browser.Driver.HasElement(By.PartialLinkText("Skip setup")))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Skip setup")));
                    global.client.Browser.Driver.FindElement(By.PartialLinkText("Skip setup")).Click();
                }
                else
                {
                    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
                }
                if (global.client.Browser.Driver.HasElement(By.Id("idSIButton9")))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
                    global.client.Browser.Driver.FindElement(By.Id("idSIButton9")).SendKeys(Keys.Enter);
                }
                else
                {
                    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
                }
                global.client.Browser.Driver.Navigate().GoToUrl(Variables.url + "main.aspx?forceUCI=1&pagetype=apps");
                global.xrmApp.ThinkTime(10000);
                global.xrmApp.Navigation.OpenApp(Variables.AppName);

                //if (global.client.Browser.Driver.HasElement(By.Id("i0116")))
                //{
                //    global.client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Variables.user);
                //}
                //else
                //{
                //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
                //}
                //global.xrmApp.ThinkTime(25000);
                //if (global.client.Browser.Driver.HasElement(By.Id("i0116")))
                //{
                //    global.client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Keys.Enter);
                //}
                //else
                //{
                //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
                //}

                //global.xrmApp.ThinkTime(20000);
                //if (global.client.Browser.Driver.HasElement(By.Id("passwordInput")))
                //{
                //    global.client.Browser.Driver.FindElement(By.Id("passwordInput")).SendKeys(Variables.pwd);
                //}
                //else
                //{
                //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
                //}
                //global.xrmApp.ThinkTime(10000);
                //global.client.Browser.Driver.FindElement(By.Id("submitButton")).Click();
                //global.xrmApp.ThinkTime(10000);
                //if (global.client.Browser.Driver.HasElement(By.Id("idSIButton9")))
                //{
                //    global.client.Browser.Driver.FindElement(By.Id("idSIButton9")).SendKeys(Keys.Enter);
                //}
                //else
                //{
                //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
                //}
            }
            else
            {
                Console.WriteLine("Element is visible");
            }
        }

        //public void Login2()
        //{
        //    WebDriverWait wait = new WebDriverWait(global.client.Browser.Driver, TimeSpan.FromSeconds(120000));
        //    if (global.client.Browser.Driver.HasElement(By.XPath("//*[contains(@data-test-id,'testuser2-d365@hah.co.uk')]"))) {
        //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@data-test-id,'testuser2-d365@hah.co.uk')]")));
        //        global.client.Browser.Driver.FindElement(By.XPath("//*[contains(@data-test-id,'testuser2-d365@hah.co.uk')]")).Click();
        //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("passwordInput")));
        //        global.client.Browser.Driver.FindElement(By.Id("passwordInput")).SendKeys(Variables.pwd);
        //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("submitButton")));
        //        global.client.Browser.Driver.FindElement(By.Id("submitButton")).Click();
        //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
        //        global.client.Browser.Driver.FindElement(By.Id("idSIButton9")).SendKeys(Keys.Enter);
        //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@data-id,'userInformationLauncher')]")));
        //    }
        //    else
        //    {
        //        Console.WriteLine("Element is visible");
        //    }
        //}

    }

    public class HelperFunction
    {
        public void Lookup(String LookupFieldName, String LookupFieldValue)
        {
            LookupItem LookupVeriable = new LookupItem { Name = LookupFieldName, Value = LookupFieldValue, Index = 0 };
            global.xrmApp.Entity.SetValue(LookupVeriable);

        }
        public void LookupQuickCreate(String LookupFieldName, String LookupFieldValue)
        {

            LookupItem LookupQuickVeriable = new LookupItem { Name = LookupFieldName, Value = LookupFieldValue, Index = 0 };
            global.xrmApp.QuickCreate.SetValue(LookupQuickVeriable);
   
        }

    }



}
