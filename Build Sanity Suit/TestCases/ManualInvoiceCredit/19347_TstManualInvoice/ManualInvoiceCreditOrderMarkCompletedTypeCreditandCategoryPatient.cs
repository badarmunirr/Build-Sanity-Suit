using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{

    //TestCase ID : 19347
    //it requires validation from FINOPS
   [TestClass]
    public class B15_ManualInvoiceCreditOrderMarkCompletedTypeCreditandCategoryPatient
    {

        [TestMethod, TestCategory("BuildAutomation")]
        public void B15_TstManualInvoice_19347_ManualInvoiceCreditOrderCompleteTypeCreditandCategoryPatient()
        {

            WebClient client = DriverInitiazation.ClientndXrmAppInitialization();
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);

            LOGIN.RoleBasedLogin(xrmApp, client, Usersetting.BillingManager, Usersetting.pwd);


            
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
            string Message = "\r\nTest Case ID - B15_ManualInvoiceCreditOrderMarkCompletedTypeCreditandCategoryPatient\r\n";
            Helper.LogRecord(Message + "Invoice No : " + Variables.InvoiceNo + "\r\nStatus : " + Variables.mzk_visitstatus2);
            Variables.cli.Browser.Driver.Close();
        }
    }
}

