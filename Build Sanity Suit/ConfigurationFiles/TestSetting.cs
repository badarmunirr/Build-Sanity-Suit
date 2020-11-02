﻿using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    class TestSetting
    {

    }
    public static class Usersetting
    {
        public static string Admin = System.Configuration.ConfigurationManager.AppSettings["Admin"].ToString();
        public static string OperationalManager = System.Configuration.ConfigurationManager.AppSettings["OperationalManager"].ToString();
        public static string BillingManager = System.Configuration.ConfigurationManager.AppSettings["BillingManager"].ToString();
        public static string contractManager = System.Configuration.ConfigurationManager.AppSettings["contractManager"].ToString();
        //public static string Scheduler = System.Configuration.ConfigurationManager.AppSettings["Scheduler"].ToString();
        //public static string IncidentViewer = System.Configuration.ConfigurationManager.AppSettings["IncidentViewer"].ToString();
        //public static string PriceController = System.Configuration.ConfigurationManager.AppSettings["PriceController"].ToString();

        public static string url = System.Configuration.ConfigurationManager.AppSettings["CRMUrl"].ToString();
        public static string pwd = System.Configuration.ConfigurationManager.AppSettings["CRMPassword"].ToString();
        public static string AppName = System.Configuration.ConfigurationManager.AppSettings["AppName"].ToString();
        public static string AppName2 = System.Configuration.ConfigurationManager.AppSettings["AppName3"].ToString();
    }


    public static class LOGIN
    {

        public static void RoleBasedLogin(XrmApp xrmApp, WebClient client, string user, string pwd)
        {
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            client.Browser.Driver.Navigate().GoToUrl(Usersetting.url);
            xrmApp.ThinkTime(5000);
            if (client.Browser.Driver.HasElement(By.Id("i0116")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("i0116")));
                client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(user);
                client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Keys.Enter);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("passwordInput")));
                client.Browser.Driver.FindElement(By.Id("passwordInput")).SendKeys(pwd);
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
                xrmApp.ThinkTime(5000);
                string url = client.Browser.Driver.Url;
                if (url == Usersetting.url + "main.aspx?forceUCI=1&pagetype=apps")
                {
                    client.Browser.Driver.Navigate().GoToUrl(Usersetting.url + "main.aspx?forceUCI=1&pagetype=apps");
                    xrmApp.ThinkTime(10000);
                    // xrmApp.Navigation.OpenApp(Usersetting.AppName);

                    xrmApp.Navigation.OpenApp(Usersetting.AppName);
                }
                else
                {
                    client.Browser.Driver.Navigate().GoToUrl(Usersetting.url);
                    xrmApp.ThinkTime(10000);
                }

            }

            //public WebClient Login()
            //{

            //    WebClient client = new Microsoft.Dynamics365.UIAutomation.Api.UCI.WebClient(TestSetting.options);
            //    XrmApp xrmApp = new XrmApp(client);
            //    WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            //    client.Browser.Driver.Navigate().GoToUrl(usersetting.url);
            //    xrmApp.ThinkTime(5000);
            //    if (client.Browser.Driver.HasElement(By.Id("i0116")))
            //    {
            //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("i0116")));
            //        client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(usersetting.Admin);
            //        client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Keys.Enter);
            //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("passwordInput")));
            //        client.Browser.Driver.FindElement(By.Id("passwordInput")).SendKeys(usersetting.pwd);
            //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("submitButton")));
            //        client.Browser.Driver.FindElement(By.Id("submitButton")).Click();
            //        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
            //        client.Browser.Driver.FindElement(By.Id("idSIButton9")).SendKeys(Keys.Enter);
            //        if (client.Browser.Driver.HasElement(By.Id("idSubmit_ProofUp_Redirect")))
            //        {
            //            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("idSubmit_ProofUp_Redirect")));
            //            client.Browser.Driver.FindElement(By.Id("idSubmit_ProofUp_Redirect")).SendKeys(Keys.Enter);
            //        }
            //        else
            //        {
            //            Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //        }
            //        if (client.Browser.Driver.HasElement(By.PartialLinkText("Skip setup")))
            //        {
            //            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Skip setup")));
            //            client.Browser.Driver.FindElement(By.PartialLinkText("Skip setup")).Click();
            //        }
            //        else
            //        {
            //            Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //        }
            //        if (client.Browser.Driver.HasElement(By.Id("idSIButton9")))
            //        {
            //            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("idSIButton9")));
            //            client.Browser.Driver.FindElement(By.Id("idSIButton9")).SendKeys(Keys.Enter);
            //        }
            //        else
            //        {
            //            Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //        }
            //        client.Browser.Driver.Navigate().GoToUrl(usersetting.url + "main.aspx?forceUCI=1&pagetype=apps");
            //        xrmApp.ThinkTime(10000);

            //        xrmApp.Navigation.OpenApp(usersetting.AppName);

            //    }
            //    return client;
            //    //if ( client.Browser.Driver.HasElement(By.Id("i0116")))
            //    //{
            //    //     client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Variables.user);
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //    //}
            //    // xrmApp.ThinkTime(25000);
            //    //if ( client.Browser.Driver.HasElement(By.Id("i0116")))
            //    //{
            //    //     client.Browser.Driver.FindElement(By.Id("i0116")).SendKeys(Keys.Enter);
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //    //}

            //    // xrmApp.ThinkTime(20000);
            //    //if ( client.Browser.Driver.HasElement(By.Id("passwordInput")))
            //    //{
            //    //     client.Browser.Driver.FindElement(By.Id("passwordInput")).SendKeys(Variables.pwd);
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //    //}
            //    // xrmApp.ThinkTime(10000);
            //    // client.Browser.Driver.FindElement(By.Id("submitButton")).Click();
            //    // xrmApp.ThinkTime(10000);
            //    //if ( client.Browser.Driver.HasElement(By.Id("idSIButton9")))
            //    //{
            //    //     client.Browser.Driver.FindElement(By.Id("idSIButton9")).SendKeys(Keys.Enter);
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //    //}
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("Element is visible");
            //    //}
            //    // client.Browser.Driver.Close();

            //}


        }

    }

    public static class DriverInitiazation
    {
        public static BrowserOptions options = new BrowserOptions
        {
            BrowserType = BrowserType.Chrome,
            PrivateMode = true,
            FireEvents = false,
            Headless = false,
            UserAgent = false,

        };
        public static WebClient ClientndXrmAppInitialization()
        {

            WebClient client = new Microsoft.Dynamics365.UIAutomation.Api.UCI.WebClient(options);
            return client;
        }
    }




}

