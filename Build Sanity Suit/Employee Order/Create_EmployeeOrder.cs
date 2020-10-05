using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    //[TestClass]
    public class B12_Create_EmployeeOrder
    {
        static string WorkOrderNum;
        static string mzk_visitstatus3;
        public static WebClient cli;
        CreateMethod Create = new CreateMethod();

        [TestMethod, TestCategory("BuildAutomation")]
        public void B12_CreateResourceToAccountToEmployeeOrder()
        {
            LOGIN loginobj = new LOGIN();
            //operational manager
            WebClient client = loginobj.RoleBasedLogin(usersetting.Admin, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();
            Create.EmployeeOrder(xrmApp,client);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));
            xrmApp.CommandBar.ClickCommand("Propose Order");
            xrmApp.ThinkTime(2000);
            mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus3.StartsWith("Proposed"));

            WorkOrderNum = xrmApp.Entity.GetHeaderValue("msdyn_name");
        }
        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - B12_Create_EmployeeOrder\r\n";
            Helper.LogRecord(Message + "Employee Order Number : " + WorkOrderNum +"\r\nWork Order Status : "+ mzk_visitstatus3);
            cli.Browser.Driver.Close();
        }
    }
}


