using System;
using System.IO;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class B12_Create_EmployeeOrder : TestBase
    {

        [TestMethod, TestCategory("Sanity")]
        public void B12_CreateResourcetoAccountToEmployeeOrder()
        {
            Retry(() =>
            {
                RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
                wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                CreateMethod.EmployeeOrder(xrmApp, client);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));
                xrmApp.CommandBar.ClickCommand("Propose Order");
                client.Browser.Driver.WaitForPageToLoad();
                Variables.mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(Variables.mzk_visitstatus3.StartsWith("Proposed"));
                Variables.WorkOrderNum = xrmApp.Entity.GetHeaderValue("msdyn_name");
            }, 2, 1000);
        }
        [TestCleanup]
        public void Teardown()
        {

            Cleanup("Employee Order No:" + Variables.WorkOrderNum + "\r\nWorkOrder Status:" + Variables.mzk_visitstatus3);

        }
    }
}


