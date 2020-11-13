
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Build_Sanity_Suit
{

    [TestClass]
    public class ManualInvoiceTestCases:TestBase
    {
        public static WebClient cli;
        [TestMethod, TestCategory("Sanity")]
        public void B13_TstManualInvoice_19273_Manualinvoicestatusiscompletedinvorg()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            CreateMethod.ManualInvoice(xrmApp,client, "Organization", "Invoice");
            xrmApp.ThinkTime(2000);
            xrmApp.CommandBar.ClickCommand("Complete");
            xrmApp.ThinkTime(2000);
            Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
            xrmApp.ThinkTime(2000);

            Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");

        }
        [TestMethod, TestCategory("Sanity")]
        public void B14_TstManualInvoice_19346_Manualinvoicecreditorderstatusiscompleted()
        {

            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);

            CreateMethod.ManualInvoice(xrmApp, client, "Organization", "Credit");
            xrmApp.ThinkTime(2000);
            xrmApp.CommandBar.ClickCommand("Complete");
            xrmApp.ThinkTime(2000);
            Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
            Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");



        }
        [TestMethod, TestCategory("Sanity")]
        public void B15_TstManualInvoice_19347_ManualInvoiceCreditOrderCompleteTypeCreditandCategoryPatient()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            CreateMethod.ManualInvoice(xrmApp, client, "Patient", "Credit");
            xrmApp.ThinkTime(2000);
            xrmApp.CommandBar.ClickCommand("Complete");
            xrmApp.ThinkTime(2000);
            Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));
            Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");



        }
        [TestMethod, TestCategory("Sanity")]
        public void B16_TstManualInvoice_19348_ManualInvoiceCreditOrderCompleteTypeInvoiceandCategoryPatient()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(Usersetting.BillingManager, Usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            CreateMethod.ManualInvoice(xrmApp, client, "Patient", "Invoice");


            xrmApp.ThinkTime(2000);
            xrmApp.CommandBar.ClickCommand("Complete");
            xrmApp.ThinkTime(2000);
            Variables.mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(Variables.mzk_visitstatus2.StartsWith("Completed"));

            Variables.InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");

        }
        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Manual Order No:" + Variables.InvoiceNo + "\r\nWorkOrder Status:" + Variables.mzk_visitstatus2);
            cli.Browser.Driver.Close();
        }
    }
}

