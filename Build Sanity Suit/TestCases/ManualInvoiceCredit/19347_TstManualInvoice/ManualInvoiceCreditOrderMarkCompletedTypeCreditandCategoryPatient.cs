using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{
   //[TestClass]
    public class B15_ManualInvoiceCreditOrderMarkCompletedTypeCreditandCategoryPatient:TestBase
    {
        public static WebClient cli;
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
        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Manual Order No:" + Variables.InvoiceNo + "\r\nWorkOrder Status:" + Variables.mzk_visitstatus2);
            cli.Browser.Driver.Close();
        }
    }
}

