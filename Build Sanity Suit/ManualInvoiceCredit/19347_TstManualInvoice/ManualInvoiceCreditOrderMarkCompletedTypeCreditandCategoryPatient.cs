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
            HelperFunction Lookupobj = new HelperFunction();
            LOGIN loginobj = new LOGIN();
            loginobj.Login();
            global.xrmApp.Navigation.OpenSubArea("Referral", "Manual Invoice/Credit");
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.CommandBar.ClickCommand("New");
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_category", Value = TestData19347.Category });
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualordertype", Value = TestData19347.manualworkordertype });
            global.xrmApp.ThinkTime(5000);
            //Lookupobj.Lookup("mzk_payer", TestData19347.payer);
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingfrequency", Value = TestData19347.billingfrequency });
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Entity.SetValue("mzk_prescriptionponumber", TestData19347.prescriptionponumber);
 
            DateTime mzk_actualvisitstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            global.xrmApp.Entity.SetValue("mzk_actualvisitstartdatetime", mzk_actualvisitstartdatetime, Conifgdata.datePattern, Conifgdata.TimePattern);

            //Lookupobj.Lookup("msdyn_serviceaccount", TestData19347.patient);

            //Lookupobj.Lookup("mzk_service", TestData19347.service);

            Lookupobj.Lookup("mzk_referral", TestData19347.referral);

            // Lookupobj.Lookup("mzk_contract", TestData19347.contract);

            //Lookupobj.Lookup("msdyn_servicerequest", TestData19347.Case);

            global.xrmApp.Entity.Save();

            var mzk_visitstatus = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus.StartsWith("Proposed"));
            global.xrmApp.ThinkTime(3000);
            global.xrmApp.Entity.SelectTab("Products And Services");
            global.xrmApp.ThinkTime(2000);




            global.xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");
   
            Lookupobj.LookupQuickCreate("msdyn_product", TestData19347.productname);

            global.xrmApp.QuickCreate.SetValue("msdyn_quantity", TestData19347.quantity);
            global.xrmApp.ThinkTime(3000);
            global.xrmApp.QuickCreate.Save();

            global.xrmApp.ThinkTime(2000);
            global.xrmApp.CommandBar.ClickCommand("Complete");
            global.xrmApp.ThinkTime(2000);
            var mzk_visitstatus2 = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus2.StartsWith("Completed"));

         



        }
    }
}

