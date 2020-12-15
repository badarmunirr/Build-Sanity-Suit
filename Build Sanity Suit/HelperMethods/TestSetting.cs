using System;
using System.Collections.Generic;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    class TestSetting:TestBase
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
            UCITestMode=true
  
           
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






}


