using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{

    //TestCase ID : 19348
    //it requires validation from FINOPS
   // [TestClass]
    public class B16_ManualInvoiceCreditOrderMarkCompletedTypeInvoiceandCategoryPatient
    {
        ReadData readData = Helper.ReadDataFromJSONFile();
        static string mzk_visitstatus2;
        static string InvoiceNo;
        public static WebClient cli;

        [TestMethod, TestCategory("BuildAutomation")]
        public void B16_TstManualInvoice_19348_ManualInvoiceCreditOrderCompleteTypeInvoiceandCategoryPatient()
        {
            CreateMethod Create = new CreateMethod();
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.BillingManager, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
 
            Create.ManualInvoice(xrmApp, client, "Patient", "Invoice");


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
            string Message = "\r\nTest Case ID - B16_ManualInvoiceCreditOrderMarkCompletedTypeInvoiceandCategoryPatient\r\n";
            Helper.LogRecord(Message + "Invoice Number : " + InvoiceNo + "\r\nInvoice Status : " + mzk_visitstatus2);
            cli.Browser.Driver.Close();
        }
    }
}

