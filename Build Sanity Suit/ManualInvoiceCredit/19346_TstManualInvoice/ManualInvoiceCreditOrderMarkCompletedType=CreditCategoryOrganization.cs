using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{

    //TestCase ID : 19346

    [TestClass]
    public class B14_ManualInvoiceCreditOrderMarkCompletedTypeCreditCategoryOrganization
    {
        ReadData readData = Helper.ReadDataFromJSONFile();
        static string mzk_visitstatus2;
        static string InvoiceNo;
        public static WebClient cli;
        CreateMethod Create = new CreateMethod();
        [TestMethod, TestCategory("BuildAutomation")]
        public void B14_TstManualInvoice_19346_Manualinvoicecreditorderstatusiscompleted()
        {

            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.BillingManager, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
  
            Create.ManualInvoice(xrmApp, client, "Credit", "Orgnization");
            xrmApp.ThinkTime(2000);

            xrmApp.CommandBar.ClickCommand("Complete");
            xrmApp.ThinkTime(2000);
            mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus2.StartsWith("Completed"));

            InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");



        }
        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - B14_ManualInvoiceCreditOrderMarkCompletedTypeCreditCategoryOrganization\r\n";
            Helper.LogRecord(Message + "Invoice Number : " + InvoiceNo + "\r\nInvoice Status : " + mzk_visitstatus2);
            cli.Browser.Driver.Close();
        }
    }
}

