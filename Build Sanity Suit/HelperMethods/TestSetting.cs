using System;
using System.Collections.Generic;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            DisableGpu = true,
            DefaultThinkTime = 20,
            StartMaximized= true,
            Width=4000,
            Height=2000,
  
           
        };

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
        public static string AdminPassword = System.Configuration.ConfigurationManager.AppSettings["AdminPassword"].ToString();
        public static string AppName = System.Configuration.ConfigurationManager.AppSettings["AppName"].ToString();
        public static string AppName2 = System.Configuration.ConfigurationManager.AppSettings["AppName3"].ToString();

    }


    public class LOGIN
    {
      
        public WebClient RoleBasedLogin(string user, string pwd)
        {
            By uid = By.Id("i0116");
            By pwdinput = By.Id("passwordInput");
            By submitbutton = By.Id("submitButton");
            By nextbutton = By.Id("idSIButton9");
            By redirect = By.Id("idSubmit_ProofUp_Redirect");
            By skipsteup = By.PartialLinkText("Skip setup");
            By iframe = By.CssSelector("iframe#AppLandingPage");

            WebClient client = new Microsoft.Dynamics365.UIAutomation.Api.UCI.WebClient(TestSetting.options);
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));

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
            return client;


        }
    }



}


