using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
   // [TestClass]
    public class B10_Create_WholesaleOrders
    {
        readonly CreateMethod Create = new CreateMethod();
        public static WebClient cli;
        static string OrderNum;
        static string mzk_visitstatus2;

        [TestMethod, TestCategory("BuildAutomation")]
        public void B10_CreateWholesaleOrder()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.OperationalManager, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));


            Create.WholesaleOrder(xrmApp, client);


            xrmApp.ThinkTime(2000);
            xrmApp.CommandBar.ClickCommand("Propose Order");
            xrmApp.ThinkTime(2000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus2.StartsWith("Proposed"));
            xrmApp.ThinkTime(1000);

            OrderNum = xrmApp.Entity.GetHeaderValue("msdyn_name");
        }

        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - B10_Create_WholesaleOrders\r\n";
            Helper.LogRecord(Message + "WholeSale Order Number - " + OrderNum + " \r\nWholeSale Order Status - " + mzk_visitstatus2);

            cli.Browser.Driver.Close();

        }

    }
}

