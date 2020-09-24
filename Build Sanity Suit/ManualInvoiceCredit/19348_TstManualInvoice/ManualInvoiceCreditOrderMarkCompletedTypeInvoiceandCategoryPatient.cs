﻿using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{

    //TestCase ID : 19348
    //it requires validation from FINOPS
    [TestClass]
    public class B16_ManualInvoiceCreditOrderMarkCompletedTypeInvoiceandCategoryPatient
    {
        ReadData readData = Helper.ReadDataFromJSONFile();
        static string mzk_visitstatus2;
        static string InvoiceNo;
        public static WebClient cli;

        [TestMethod, TestCategory("BuildAutomation")]
        public void B16_TstManualInvoice_19348_ManualInvoiceCreditOrderCompleteTypeInvoiceandCategoryPatient()
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
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_category", Value = readData.TstManualInvoice_19348Data.mzk_category });
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualordertype", Value = readData.TstManualInvoice_19348Data.mzk_manualordertype });
            xrmApp.ThinkTime(5000);
            //Lookupobj.Lookup("mzk_payer", TestData19348.payer);
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingfrequency", Value = readData.TstManualInvoice_19348Data.mzk_manualbillingfrequency });
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SetValue("mzk_prescriptionponumber", readData.TstManualInvoice_19348Data.mzk_prescriptionponumber);

            DateTime mzk_actualvisitstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            xrmApp.Entity.SetValue("mzk_actualvisitstartdatetime", mzk_actualvisitstartdatetime, Conifgdata.datePattern, Conifgdata.TimePattern);

            //Lookupobj.Lookup("msdyn_serviceaccount", TestData19348.patient);

            //Lookupobj.Lookup("mzk_service", TestData19348.service);

            Lookupobj.Lookup("mzk_referral", readData.TstManualInvoice_19348Data.mzk_referral, xrmApp);

            // Lookupobj.Lookup("mzk_contract", TestData19348.contract);

            //Lookupobj.Lookup("msdyn_servicerequest", TestData19348.Case);

            xrmApp.Entity.Save();
            var mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus.StartsWith("Proposed"));

            xrmApp.ThinkTime(3000);
            xrmApp.Entity.SelectTab("Products And Services");
            xrmApp.ThinkTime(2000);




            xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");

            Lookupobj.LookupQuickCreate("msdyn_product", readData.TstManualInvoice_19348Data.msdyn_product, xrmApp);

            xrmApp.QuickCreate.SetValue("msdyn_quantity", readData.TstManualInvoice_19348Data.msdyn_quantity);
            xrmApp.ThinkTime(3000);
            xrmApp.QuickCreate.Save();

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

