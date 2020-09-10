using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{

    //TestCase ID : 19346

    [TestClass]
    public class B14_ManualInvoiceCreditOrderMarkCompletedTypeCreditCategoryOrganization
    {
        public static WebClient cli;

        [TestMethod, TestCategory("BuildAutomation")]
        public void B14_TstManualInvoice_19346_Manualinvoicecreditorderstatusiscompleted()
        {
            try
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.Login();
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                HelperFunction Lookupobj = new HelperFunction();

                xrmApp.ThinkTime(4000);
                xrmApp.Navigation.OpenSubArea("Referral", "Manual Invoice/Credit");
                xrmApp.ThinkTime(5000);
                xrmApp.CommandBar.ClickCommand("New");
                xrmApp.ThinkTime(5000);
                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_category", Value = TestData19346.Category });
                xrmApp.ThinkTime(5000);
                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualordertype", Value = TestData19346.manualworkordertype });
                xrmApp.ThinkTime(5000);
                //Lookupobj.Lookup("mzk_payer", TestData23633.payer);
                xrmApp.ThinkTime(5000);
                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingfrequency", Value = TestData19346.billingfrequency });
                xrmApp.ThinkTime(5000);
                xrmApp.Entity.SetValue("mzk_prescriptionponumber", TestData19346.prescriptionponumber);

                DateTime mzk_actualvisitstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
                xrmApp.Entity.SetValue("mzk_actualvisitstartdatetime", mzk_actualvisitstartdatetime, Conifgdata.datePattern, Conifgdata.TimePattern);

                // Lookupobj.Lookup("msdyn_serviceaccount", TestData19346.account);

                Lookupobj.Lookup("mzk_contract", TestData19346.contract, xrmApp);

                //Lookupobj.Lookup("msdyn_servicerequest", TestData19346.Case);

                xrmApp.Entity.Save();
                var mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(mzk_visitstatus.StartsWith("Proposed"));
                xrmApp.ThinkTime(3000);
                xrmApp.Entity.SelectTab("Products And Services");




                xrmApp.ThinkTime(3000);
                xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");

                Lookupobj.LookupQuickCreate("msdyn_product", TestData19346.product, xrmApp);

                xrmApp.QuickCreate.SetValue("msdyn_quantity", TestData19346.quantity);

                xrmApp.QuickCreate.Save();
                xrmApp.ThinkTime(2000);

                xrmApp.CommandBar.ClickCommand("Complete");
                xrmApp.ThinkTime(2000);
                var mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(mzk_visitstatus2.StartsWith("Completed"));
                if (mzk_visitstatus2.StartsWith("Completed"))
                {
                    string Message = "Manual Invoice B14" + " Pass";
                    Helper.LogRecord(Message);
                }
                
            }

            catch(Exception ex)
            {
                string Message = ex.Message.ToString() + "  " + "HealthCare PRovider"+ " Fail";
                Helper.LogRecord(Message);
            }
           

        }
        [TestCleanup]
        public void teardown()
        {

            cli.Browser.Driver.Close();
            string Message =   "HealthCare PRovider"+"Pass";
            Helper.LogRecord(Message);
        }
    }
}

