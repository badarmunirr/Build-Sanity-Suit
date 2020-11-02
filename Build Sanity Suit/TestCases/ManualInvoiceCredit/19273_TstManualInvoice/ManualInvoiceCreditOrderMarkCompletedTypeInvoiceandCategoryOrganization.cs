using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Build_Sanity_Suit
{

    [TestClass]
    public class B13_ManualInvoiceCreditOrderMarkCompletedTypeInvoiceandCategoryOrganization
    {

        [TestMethod, TestCategory("BuildAutomation")]
        public void B13_TstManualInvoice_19273_Manualinvoicestatusiscompletedinvorg()
        {
            WebClient client = DriverInitiazation.ClientndXrmAppInitialization();
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);

            LOGIN.RoleBasedLogin(xrmApp, client, Usersetting.BillingManager, Usersetting.pwd);

            HelperFunctions.ManualInvoice(xrmApp,client, "Organization", "Invoice");

            xrmApp.ThinkTime(2000);
            xrmApp.CommandBar.ClickCommand("Complete");
            xrmApp.ThinkTime(2000);
            Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
            xrmApp.ThinkTime(2000);

            Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");



        }
        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - B13_ManualInvoiceCreditOrderMarkCompletedTypeInvoiceandCategoryOrganization\r\n";
            HelperFunctions.LogRecord(Message + "Invoice Number - " + Variables.InvoiceNo + "\r\nInvoice Status : " + Variables.mzk_visitstatus2);
            Variables.cli.Browser.Driver.Close();
        }
    }
}

