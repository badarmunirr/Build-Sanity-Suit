using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class A3_Create_Payers
    {
        static string PayerNum;
        public static WebClient cli;
        CreateMethod Create = new CreateMethod();

        [TestMethod, TestCategory("BuildAutomation")]
        public void A3_CreatePayer()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.OperationalManager, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);


            Create.Payer(xrmApp,client);
            PayerNum = xrmApp.Entity.GetHeaderValue("accountnumber");
            xrmApp.ThinkTime(2000);


        }

        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A3_Create_Payers\r\n";
            Helper.LogRecord(Message + "Payer No : " + PayerNum );
            cli.Browser.Driver.Close();
        }
    }
}

