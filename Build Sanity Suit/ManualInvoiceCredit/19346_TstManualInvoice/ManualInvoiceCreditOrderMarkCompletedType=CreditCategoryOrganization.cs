using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{

    //TestCase ID : 19346

    [TestClass]
    public class B14_ManualInvoiceCreditOrderMarkCompletedTypeCreditCategoryOrganization
    {
        [TestMethod, TestCategory("BuildAutomation")]
        public void B14_TstManualInvoice_19346_Manualinvoicecreditorderstatusiscompleted()
        {
            HelperFunction Lookupobj = new HelperFunction();
            LOGIN loginobj = new LOGIN();
            loginobj.Login();

            global.xrmApp.Navigation.OpenSubArea("Referral", "Manual Invoice/Credit");
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.CommandBar.ClickCommand("New");
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_category", Value = TestData19346.Category });
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualordertype", Value = TestData19346.manualworkordertype });
            global.xrmApp.ThinkTime(5000);
            //Lookupobj.Lookup("mzk_payer", TestData23633.payer);
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingfrequency", Value = TestData19346.billingfrequency });
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Entity.SetValue("mzk_prescriptionponumber", TestData19346.prescriptionponumber);
 
            DateTime mzk_actualvisitstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            global.xrmApp.Entity.SetValue("mzk_actualvisitstartdatetime", mzk_actualvisitstartdatetime, Conifgdata.datePattern, Conifgdata.TimePattern);

            // Lookupobj.Lookup("msdyn_serviceaccount", TestData19346.account);

            Lookupobj.Lookup("mzk_contract", TestData19346.contract);

            //Lookupobj.Lookup("msdyn_servicerequest", TestData19346.Case);

            global.xrmApp.Entity.Save();
            var mzk_visitstatus = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus.StartsWith("Proposed"));
            global.xrmApp.ThinkTime(3000);
            global.xrmApp.Entity.SelectTab("Products And Services");




            global.xrmApp.ThinkTime(3000);
            global.xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");

            Lookupobj.LookupQuickCreate("msdyn_product", TestData19346.product);

            global.xrmApp.QuickCreate.SetValue("msdyn_quantity", TestData19346.quantity);

            global.xrmApp.QuickCreate.Save();
            global.xrmApp.ThinkTime(2000);

            global.xrmApp.CommandBar.ClickCommand("Complete");
            global.xrmApp.ThinkTime(2000);
            var mzk_visitstatus2 = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus2.StartsWith("Completed"));
            


        }
    }
}

