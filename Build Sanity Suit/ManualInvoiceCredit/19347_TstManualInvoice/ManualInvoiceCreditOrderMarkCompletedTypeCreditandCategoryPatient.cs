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
        public static WebClient cli;

        [TestMethod, TestCategory("BuildAutomation")]
        public void B15_TstManualInvoice_19347_ManualInvoiceCreditOrderCompleteTypeCreditandCategoryPatient()
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
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_category", Value = TestData19347.Category });
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualordertype", Value = TestData19347.manualworkordertype });
            xrmApp.ThinkTime(5000);
            //Lookupobj.Lookup("mzk_payer", TestData19347.payer);
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingfrequency", Value = TestData19347.billingfrequency });
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SetValue("mzk_prescriptionponumber", TestData19347.prescriptionponumber);

            DateTime mzk_actualvisitstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            xrmApp.Entity.SetValue("mzk_actualvisitstartdatetime", mzk_actualvisitstartdatetime, Conifgdata.datePattern, Conifgdata.TimePattern);

            //Lookupobj.Lookup("msdyn_serviceaccount", TestData19347.patient);

            //Lookupobj.Lookup("mzk_service", TestData19347.service);

            Lookupobj.Lookup("mzk_referral", TestData19347.referral, xrmApp);

            // Lookupobj.Lookup("mzk_contract", TestData19347.contract);

            //Lookupobj.Lookup("msdyn_servicerequest", TestData19347.Case);

            xrmApp.Entity.Save();

            var mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus.StartsWith("Proposed"));
            xrmApp.ThinkTime(3000);
            xrmApp.Entity.SelectTab("Products And Services");
            xrmApp.ThinkTime(2000);




            xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");

            Lookupobj.LookupQuickCreate("msdyn_product", TestData19347.productname, xrmApp);

            xrmApp.QuickCreate.SetValue("msdyn_quantity", TestData19347.quantity);
            xrmApp.ThinkTime(3000);
            xrmApp.QuickCreate.Save();

            xrmApp.ThinkTime(2000);
            xrmApp.CommandBar.ClickCommand("Complete");
            xrmApp.ThinkTime(2000);
            var mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus2.StartsWith("Completed"));


        }
        [TestCleanup]
        public void teardown()
        {
            cli.Browser.Driver.Close();
        }
    }
}

