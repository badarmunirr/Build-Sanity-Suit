using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Build_Sanity_Suit
{

    //TestCase ID : 19273

    [TestClass]
    public class B13_ManualInvoiceCreditOrderMarkCompletedTypeInvoiceandCategoryOrganization
    {
        static string InvoiceNo;
        public static WebClient cli;

        [TestMethod, TestCategory("BuildAutomation")]
        public void B13_TstManualInvoice_19273_Manualinvoicestatusiscompletedinvorg()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.BillingManager, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            HelperFunction Lookupobj = new HelperFunction();


            xrmApp.ThinkTime(4000);
            xrmApp.Navigation.OpenSubArea("Referral", "Manual Invoice/Credit");
            xrmApp.ThinkTime(5000);
            xrmApp.CommandBar.ClickCommand("New");
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_category", Value = TestData19273.Category });
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualordertype", Value = TestData19273.manualworkordertype });
            xrmApp.ThinkTime(5000);
            //Lookupobj.Lookup("mzk_payer", TestData19273.payer);
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingfrequency", Value = TestData19273.billingfrequency });
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SetValue("mzk_prescriptionponumber", TestData19273.prescriptionponumber);

            DateTime mzk_actualvisitstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            xrmApp.Entity.SetValue("mzk_actualvisitstartdatetime", mzk_actualvisitstartdatetime, Conifgdata.datePattern, Conifgdata.TimePattern);

            //Lookupobj.Lookup("msdyn_serviceaccount", TestData19273.account);

            Lookupobj.Lookup("mzk_contract", TestData19273.contract, xrmApp);

            //Lookupobj.Lookup("msdyn_servicerequest", TestData19273.Case);

            xrmApp.Entity.Save();
            var mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus.StartsWith("Proposed"));
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SelectTab("Products And Services");
            xrmApp.ThinkTime(3000);
            xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");
            xrmApp.ThinkTime(3000);
            Lookupobj.LookupQuickCreate("msdyn_product", TestData19273.product, xrmApp);
            xrmApp.ThinkTime(3000);
            xrmApp.QuickCreate.SetValue("msdyn_quantity", TestData19273.quantity);
            xrmApp.ThinkTime(3000);
            xrmApp.QuickCreate.Save();
            xrmApp.ThinkTime(2000);
            xrmApp.CommandBar.ClickCommand("Complete");
            xrmApp.ThinkTime(2000);
            var mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus2.StartsWith("Completed"));
            xrmApp.ThinkTime(2000);


            InvoiceNo = xrmApp.Entity.GetValue("msdyn_name");



        }
        [TestCleanup]
        public void teardown()
        {
            string Message = "B13_ManualInvoiceCreditOrderMarkCompletedTypeInvoiceandCategoryOrganization---";
            Helper.LogRecord(Message + " Invoice No : " + InvoiceNo);
            cli.Browser.Driver.Close();
        }
    }
}

