using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;

namespace Build_Sanity_Suit
{
     [TestClass]
    public class B10_Create_WholesaleOrders : TestBase
    {

        [TestMethod, TestCategory("Sanity")]
        public void B10_CreateWholesaleOrder()
        {
            //Retry(() =>
            //{
                RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
                // WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                CreateMethod.WholesaleOrder(xrmApp, client);
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.CommandBar.ClickCommand("Propose Order");
                client.Browser.Driver.WaitForPageToLoad();
                // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Proposed"));
                client.Browser.Driver.WaitForPageToLoad();
                Variables.OrderNum = xrmApp.Entity.GetHeaderValue("msdyn_name");
            //}, 2, 1000);
        }

        [TestCleanup]
        public void Teardown()
        {

            Cleanup("Wholsale No:" + Variables.OrderNum + "\r\nWorkOrder Status:" + Variables.mzk_visitstatus2);

        }
    }
}

