
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;

namespace Build_Sanity_Suit
{

    [TestClass]
    public class ManualInvoiceTestCases : TestBase
    {


        [TestMethod, TestCategory("Sanity")]
        public void B13_TstManualInvoice_19273_Manualinvoicestatusiscompletedinvorg()
        {
            //Retry(() =>
            //{
                RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);
                CreateMethod.ManualInvoice(xrmApp, client, "Organization", "Invoice");
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.CommandBar.ClickCommand("Complete");
                client.Browser.Driver.WaitForPageToLoad();
                Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
                Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");
            //}, 2, 1000);
        }
        [TestMethod, TestCategory("Sanity")]
        public void B14_TstManualInvoice_19346_Manualinvoicecreditorderstatusiscompleted()
        {
            //Retry(() =>
            //{
                RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);
                CreateMethod.ManualInvoice(xrmApp, client, "Organization", "Credit");
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.CommandBar.ClickCommand("Complete");
                client.Browser.Driver.WaitForPageToLoad();
                Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
                Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");
            //}, 2, 1000);


        }
        [TestMethod, TestCategory("Sanity")]
        public void B15_TstManualInvoice_19347_ManualInvoiceCreditOrderCompleteTypeCreditandCategoryPatient()
        {
            //Retry(() =>
            //{
                RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);
                CreateMethod.ManualInvoice(xrmApp, client, "Patient", "Credit");
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.CommandBar.ClickCommand("Complete");
                client.Browser.Driver.WaitForPageToLoad();
                Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
                Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");
            //}, 2, 1000);


        }
        [TestMethod, TestCategory("Sanity")]
        public void B16_TstManualInvoice_19348_ManualInvoiceCreditOrderCompleteTypeInvoiceandCategoryPatient()
        {

            //Retry(() =>
            //{
                RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);
                CreateMethod.ManualInvoice(xrmApp, client, "Patient", "Invoice");
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.CommandBar.ClickCommand("Complete");
                client.Browser.Driver.WaitForPageToLoad();
                Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
                Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");
            //}, 2, 1000);
        }
        [TestCleanup]
        public void Teardown()
        {

            Cleanup("Manual Order No:" + Variables.InvoiceNo + "\r\nWorkOrder Status:" + Variables.mzk_visitstatus2);

        }
    }
}

