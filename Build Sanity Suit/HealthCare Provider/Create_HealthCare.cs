using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class A1_Create_HealthCare
    {
        static string AccountNum;
        public static WebClient cli;
        CreateMethod Create = new CreateMethod();


        [TestMethod, TestCategory("BuildAutomation")]
        public void A1_CreateProvider()
        {

            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.OperationalManager, usersetting.pwd);
            cli = client;

            XrmApp xrmApp = new XrmApp(client);
            Create.Provider(xrmApp, client);

            AccountNum = xrmApp.Entity.GetHeaderValue("accountnumber");
        }

        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A1_Create_HealthCare\r\n";
            Helper.LogRecord(Message + "HealthCare Provider Number : " + AccountNum);
            cli.Browser.Driver.Close();
        }
    }


}

