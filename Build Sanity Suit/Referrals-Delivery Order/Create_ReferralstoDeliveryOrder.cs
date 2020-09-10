﻿using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class A7_Create_ReferralstoDeliveryOrder
    {
        public static WebClient cli;

        [TestMethod, TestCategory("BuildAutomation")]
        public void A7_CreateReferral()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.Login();
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();



            xrmApp.ThinkTime(4000);
            xrmApp.Navigation.OpenSubArea("Referral", "Referrals");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.CommandBar.ClickCommand("New");

            Lookupobj.Lookup("parentcontactid", ReferraltodeliviryOrderdata.PatientName, xrmApp);

            xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_patientconsent", Value = true });

            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_patientswitchstatus", Value = ReferraltodeliviryOrderdata.patientswitchstatus });

            xrmApp.Entity.SetValue("mzk_anonymousreference", ReferraltodeliviryOrderdata.anonymousreference);

            xrmApp.Entity.SetValue("mzk_hospitalreferencenumber", ReferraltodeliviryOrderdata.hospitalreferencenumber);
            xrmApp.ThinkTime(1000);
            xrmApp.Entity.SelectTab("General");

            xrmApp.Entity.SetValue("name", ReferraltodeliviryOrderdata.ReferalName);

            Lookupobj.Lookup("mzk_contract", ReferraltodeliviryOrderdata.ServiceAgreement, xrmApp);

            Lookupobj.Lookup("mzk_diagnosisgroup", ReferraltodeliviryOrderdata.diagnosisgroup, xrmApp);

            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_nursingstatus", Value = ReferraltodeliviryOrderdata.nursingstatus });

            //Lookupobj.Lookup("mzk_contractdeliverymethod", "aHUS");

            // xrmApp.Entity.SetValue("description", "description");

            if (client.Browser.Driver.HasElement(By.XPath("//a[contains(@aria-label,'Reduced Price Patient')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@aria-label,'Reduced Price Patient')]")));
                client.Browser.Driver.FindElement(By.XPath("//a[contains(@aria-label,'Reduced Price Patient')]")).Click();

            }
            else
            {
                Console.WriteLine("No Element found");
            }
            xrmApp.ThinkTime(5000);
            Lookupobj.Lookup("pricelevelid", ReferraltodeliviryOrderdata.PriceList, xrmApp);
            // xrmApp.ThinkTime(2000);
            //Lookupobj.Lookup("mzk_masterpathway", ReferraltodeliviryOrderdata.MasterPathway);
            //Referrer
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_referringprescriber", ReferraltoNurseOrderdata.refferingprescriber);

            xrmApp.Entity.SetValue("mzk_pmireferencenumber", ReferraltodeliviryOrderdata.pmireferencenumber);

            xrmApp.Entity.SetValue("mzk_billingreferencenumber", ReferraltodeliviryOrderdata.billingreferencenumber);

            xrmApp.Entity.SetValue("mzk_pmipolicynumber", ReferraltodeliviryOrderdata.pmipolicynumber);

            xrmApp.Entity.SetValue("mzk_legacyreferralnumber", ReferraltodeliviryOrderdata.legacyreferralnumber);
            xrmApp.ThinkTime(1000);
            xrmApp.Entity.Save();
            // xrmApp.ThinkTime(3000);
            // xrmApp.BusinessProcessFlow.SelectStage("Receive");
            // xrmApp.BusinessProcessFlow.NextStage("Receive");
            // xrmApp.BusinessProcessFlow.SelectStage("Confirm");
            // xrmApp.ThinkTime(3000);
            //// in place of finsih button 
            ////when support for finish button in uci is added need to replace this line of code
            // client.Browser.Driver.FindElement(By.XPath("//button[contains(@data-id,'finishButtonContainer')]")).Click(true);
            // xrmApp.ThinkTime(3000);
            // xrmApp.BusinessProcessFlow.Close("Confirm");
            // xrmApp.ThinkTime(3000);
            // xrmApp.Entity.Save();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")));
            // when support for hidden field is added need to replace this line of code
            string casenumber = client.Browser.Driver.FindElement(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")).Text;
            xrmApp.ThinkTime(2000);
            string mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_status" });
            Assert.IsTrue(mzk_visitstatus2.StartsWith("Active"));
            string address1_postalcode = xrmApp.Entity.GetValue("address1_postalcode");
            Assert.IsNotNull(address1_postalcode);
            xrmApp.ThinkTime(3000);
            xrmApp.Navigation.OpenSubArea("Referral", "Cases");
            xrmApp.ThinkTime(3000);
            xrmApp.Grid.Search(casenumber);
            xrmApp.ThinkTime(2000);
            xrmApp.Grid.OpenRecord(0);
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SelectTab("Delivery and Nursing Visit");
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SubGrid.ClickCommand("DeliveryAndNursingVisitGrid", "Add New Work Order");
            // xrmApp.ThinkTime(2000);
            // xrmApp.Entity.SelectForm("Visit Detail");
            // xrmApp.ThinkTime(5000);
            if (client.Browser.Driver.HasElement(By.XPath("//button[contains(@data-id,'cancelButton')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@data-id,'cancelButton')]")));
                client.Browser.Driver.FindElement(By.XPath("//button[contains(@data-id,'cancelButton')]")).Click();
            }
            else
            {
                Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            }

            xrmApp.ThinkTime(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-id='msdyn_servicerequest.fieldControl-LookupResultsDropdown_msdyn_servicerequest_selected_tag_text']")));
            string casenumber2 = client.Browser.Driver.FindElement(By.CssSelector("div[data-id='msdyn_servicerequest.fieldControl-LookupResultsDropdown_msdyn_servicerequest_selected_tag_text']")).Text;
            Assert.IsTrue(casenumber2.StartsWith(casenumber));

            Lookupobj.Lookup("msdyn_workordertype", ReferraltodeliviryOrderdata.workordertype, xrmApp);
            //
            //Lookupobj.Lookup("msdyn_serviceterritory", ReferraltodeliviryOrderdata.serviceterritory);
            // xrmApp.ThinkTime(2000);
            // xrmApp.Entity.SetValue("mzk_region", ReferraltodeliviryOrderdata.region);
            // xrmApp.Entity.SetValue("mzk_district", ReferraltodeliviryOrderdata.district);

            //DateTime mzk_proposedvisitdatetime = DateTime.Today.AddDays(1).AddHours(10);
            // xrmApp.Entity.SetValue("mzk_proposedvisitdatetime", mzk_proposedvisitdatetime,"dd/MM/yyyy", "hh:mm");

            //DateTime mzk_proposedvisitenddatetime = DateTime.Today.AddDays(1).AddHours(10);
            // xrmApp.Entity.SetValue("mzk_proposedvisitenddatetime", mzk_proposedvisitenddatetime, "dd/MM/yyyy", "hh:mm");
            //code change suggested by faiza
            DateTime mzk_scheduledstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            xrmApp.Entity.SetValue("mzk_scheduledstartdatetime", mzk_scheduledstartdatetime, "dd/MM/yyyy", "hh:mm");

            DateTime mzk_scheduledenddatetime = DateTime.Today.AddDays(3).AddHours(10);
            xrmApp.Entity.SetValue("mzk_scheduledenddatetime", mzk_scheduledenddatetime, "dd/MM/yyyy", "hh:mm");
            xrmApp.ThinkTime(5000);
            Lookupobj.Lookup("mzk_deliverymethods", ReferraltodeliviryOrderdata.deliverymethods, xrmApp);

            //Lookupobj.Lookup("mzk_deliveryroute", ReferraltodeliviryOrderdata.deliveryroute);
            // xrmApp.ThinkTime(2000);
            // xrmApp.Entity.SetValue("mzk_legacyordernumber", ReferraltodeliviryOrderdata.legacyordernumber);
            // xrmApp.ThinkTime(2000);
            //Lookupobj.Lookup("mzk_contractdeliveryfrequency", ReferraltodeliviryOrderdata.contractdeliveryfrequency);
            xrmApp.ThinkTime(3000);
            xrmApp.Entity.Save();
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.ThinkTime(3000);
            string mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus.StartsWith("Draft"));
            string msdyn_postalcode = xrmApp.Entity.GetValue("msdyn_postalcode");
            Assert.IsNotNull(msdyn_postalcode);
            xrmApp.ThinkTime(4000);
            xrmApp.Entity.SelectTab("Products And Services");
            xrmApp.ThinkTime(4000);
            xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Ancillary Item");

            Lookupobj.LookupQuickCreate("msdyn_product", ReferraltodeliviryOrderdata.productname, xrmApp);
            // xrmApp.ThinkTime(2000);
            //Lookupobj.LookupQuickCreate("msdyn_unit", ReferraltodeliviryOrderdata.unit);

            xrmApp.QuickCreate.SetValue("msdyn_quantity", ReferraltodeliviryOrderdata.qunantity);
            xrmApp.ThinkTime(2000);
            xrmApp.QuickCreate.Save();
            ////Service
            // xrmApp.ThinkTime(5000);
            // xrmApp.Entity.SubGrid.ClickCommand("workorderservicesgrid", "New Work Order Service");
            // xrmApp.ThinkTime(3000);
            //Lookupobj.Lookup("msdyn_service", ReferraltodeliviryOrderdata.servicename);
            // xrmApp.ThinkTime(5000);
            // xrmApp.CommandBar.ClickCommand("Save & Close");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));
            xrmApp.CommandBar.ClickCommand("Propose Order");
            xrmApp.ThinkTime(2000);
            string mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus3.StartsWith("Proposed"));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.CommandBar.ClickCommand("Save & Close");

        }
        [TestCleanup]
        public void Teardown()
        {
            cli.Browser.Driver.Close();
        }
    }
}


