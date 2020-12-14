
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;

namespace Build_Sanity_Suit
{

   [TestClass]
    public class ManualInvoiceTestCases:TestBase
    {
        public  WebClient client=null;

        [TestMethod, TestCategory("Sanity")]
        public void B13_TstManualInvoice_19273_Manualinvoicestatusiscompletedinvorg()
        {
            client = loginobj.RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);
            XrmApp xrmApp = new XrmApp(client);

            CreateMethod.ManualInvoice(xrmApp,client, "Organization", "Invoice");
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.CommandBar.ClickCommand("Complete");
            client.Browser.Driver.WaitForPageToLoad();
            Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
            Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");

        }
        [TestMethod, TestCategory("Sanity")]
        public void B14_TstManualInvoice_19346_Manualinvoicecreditorderstatusiscompleted()
        {
            client = loginobj.RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);

            XrmApp xrmApp = new XrmApp(client);
            CreateMethod.ManualInvoice(xrmApp, client, "Organization", "Credit");
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.CommandBar.ClickCommand("Complete");
            client.Browser.Driver.WaitForPageToLoad();
            Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
            Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");



        }
        [TestMethod, TestCategory("Sanity")]
        public void B15_TstManualInvoice_19347_ManualInvoiceCreditOrderCompleteTypeCreditandCategoryPatient()
        {
            client = loginobj.RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);
            XrmApp xrmApp = new XrmApp(client);

            CreateMethod.ManualInvoice(xrmApp, client, "Patient", "Credit");
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.CommandBar.ClickCommand("Complete");
            client.Browser.Driver.WaitForPageToLoad();
            Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
            Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");



        }
        [TestMethod, TestCategory("Sanity")]
        public void B16_TstManualInvoice_19348_ManualInvoiceCreditOrderCompleteTypeInvoiceandCategoryPatient()
        {
            client = loginobj.RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);
            XrmApp xrmApp = new XrmApp(client);
            client.Browser.Driver.Manage().Window.Maximize();
            CreateMethod.ManualInvoice(xrmApp, client, "Patient", "Invoice");
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.CommandBar.ClickCommand("Complete");
            client.Browser.Driver.WaitForPageToLoad();
            Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
            Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");

        }
        [TestCleanup]
        public void Teardown()
        {
            Screenshot ss = ((ITakesScreenshot)client.Browser.Driver).GetScreenshot();
            string path = Directory.GetCurrentDirectory() + TestContext.TestName + ".png";
            ss.SaveAsFile(path);
            this.TestContext.AddResultFile(path);
            Cleanup("Manual Order No:" + Variables.InvoiceNo + "\r\nWorkOrder Status:" + Variables.mzk_visitstatus2);
            client.Browser.Driver.Close();
        }
    }
}

