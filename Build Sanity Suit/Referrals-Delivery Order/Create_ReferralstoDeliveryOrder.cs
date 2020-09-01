using System;
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
        [TestMethod, TestCategory("BuildAutomation")]

        public void A7_CreateReferral()
        {
            WebDriverWait wait = new WebDriverWait(global.client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();
            LOGIN loginobj = new LOGIN();
            loginobj.Login();
            global.xrmApp.ThinkTime(4000);
            global.xrmApp.Navigation.OpenSubArea("Referral", "Referrals");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.CommandBar.ClickCommand("New");

            Lookupobj.Lookup("parentcontactid", ReferraltodeliviryOrderdata.PatientName);

            global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_patientconsent", Value = true });

            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_patientswitchstatus", Value = ReferraltodeliviryOrderdata.patientswitchstatus });

            global.xrmApp.Entity.SetValue("mzk_anonymousreference", ReferraltodeliviryOrderdata.anonymousreference);

            global.xrmApp.Entity.SetValue("mzk_hospitalreferencenumber", ReferraltodeliviryOrderdata.hospitalreferencenumber);
            global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.SelectTab("General");

            global.xrmApp.Entity.SetValue("name", ReferraltodeliviryOrderdata.ReferalName);

            Lookupobj.Lookup("mzk_contract", ReferraltodeliviryOrderdata.ServiceAgreement);

            Lookupobj.Lookup("mzk_diagnosisgroup", ReferraltodeliviryOrderdata.diagnosisgroup);
   
            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_nursingstatus", Value = ReferraltodeliviryOrderdata.nursingstatus });

            //Lookupobj.Lookup("mzk_contractdeliverymethod", "aHUS");

            //global.xrmApp.Entity.SetValue("description", "description");

            if (global.client.Browser.Driver.HasElement(By.XPath("//a[contains(@aria-label,'Reduced Price Patient')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@aria-label,'Reduced Price Patient')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//a[contains(@aria-label,'Reduced Price Patient')]")).Click();

            }
            else
            {
                Console.WriteLine("No Element found");
            }
            global.xrmApp.ThinkTime(2000);
            Lookupobj.Lookup("pricelevelid", ReferraltodeliviryOrderdata.PriceList);
            //global.xrmApp.ThinkTime(2000);
            //Lookupobj.Lookup("mzk_masterpathway", ReferraltodeliviryOrderdata.MasterPathway);
            //Referrer
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_referringprescriber", ReferraltoNurseOrderdata.refferingprescriber);
    
            global.xrmApp.Entity.SetValue("mzk_pmireferencenumber", ReferraltodeliviryOrderdata.pmireferencenumber);

            global.xrmApp.Entity.SetValue("mzk_billingreferencenumber", ReferraltodeliviryOrderdata.billingreferencenumber);

            global.xrmApp.Entity.SetValue("mzk_pmipolicynumber", ReferraltodeliviryOrderdata.pmipolicynumber);

            global.xrmApp.Entity.SetValue("mzk_legacyreferralnumber", ReferraltodeliviryOrderdata.legacyreferralnumber);
            global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.Save();
            //global.xrmApp.ThinkTime(3000);
            //global.xrmApp.BusinessProcessFlow.SelectStage("Receive");
            //global.xrmApp.BusinessProcessFlow.NextStage("Receive");
            //global.xrmApp.BusinessProcessFlow.SelectStage("Confirm");
            //global.xrmApp.ThinkTime(3000);
            //// in place of finsih button 
            ////when support for finish button in uci is added need to replace this line of code
            //global.client.Browser.Driver.FindElement(By.XPath("//button[contains(@data-id,'finishButtonContainer')]")).Click(true);
            //global.xrmApp.ThinkTime(3000);
            //global.xrmApp.BusinessProcessFlow.Close("Confirm");
            //global.xrmApp.ThinkTime(3000);
            //global.xrmApp.Entity.Save();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")));
            // when support for hidden field is added need to replace this line of code
            string casenumber = global.client.Browser.Driver.FindElement(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")).Text;
            global.xrmApp.ThinkTime(2000);
            var mzk_visitstatus2 = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_status" });
            Assert.IsTrue(mzk_visitstatus2.StartsWith("Active"));
            string address1_postalcode = global.xrmApp.Entity.GetValue("address1_postalcode");
            Assert.IsNotNull(address1_postalcode);
            global.xrmApp.ThinkTime(3000);
            global.xrmApp.Navigation.OpenSubArea("Referral", "Cases");
            global.xrmApp.ThinkTime(3000);
            global.xrmApp.Grid.Search(casenumber);
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.Grid.OpenRecord(0);
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Entity.SelectTab("Delivery and Nursing Visit");
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Entity.SubGrid.ClickCommand("DeliveryAndNursingVisitGrid", "Add New Work Order");
            //global.xrmApp.ThinkTime(2000);
            //global.xrmApp.Entity.SelectForm("Visit Detail");
            //global.xrmApp.ThinkTime(5000);
            if (global.client.Browser.Driver.HasElement(By.XPath("//button[contains(@data-id,'cancelButton')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@data-id,'cancelButton')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//button[contains(@data-id,'cancelButton')]")).Click();
            }
            else
            {
                Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            }
            
            global.xrmApp.ThinkTime(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-id='msdyn_servicerequest.fieldControl-LookupResultsDropdown_msdyn_servicerequest_selected_tag_text']")));
            string casenumber2 = global.client.Browser.Driver.FindElement(By.CssSelector("div[data-id='msdyn_servicerequest.fieldControl-LookupResultsDropdown_msdyn_servicerequest_selected_tag_text']")).Text;
            Assert.IsTrue(casenumber2.StartsWith(casenumber));
            
            Lookupobj.Lookup("msdyn_workordertype", ReferraltodeliviryOrderdata.workordertype);
            //global.xrmApp.ThinkTime(2000);
            //Lookupobj.Lookup("msdyn_serviceterritory", ReferraltodeliviryOrderdata.serviceterritory);
            //global.xrmApp.ThinkTime(2000);
            //global.xrmApp.Entity.SetValue("mzk_region", ReferraltodeliviryOrderdata.region);
            //global.xrmApp.Entity.SetValue("mzk_district", ReferraltodeliviryOrderdata.district);
            
            //DateTime mzk_proposedvisitdatetime = DateTime.Today.AddDays(1).AddHours(10);
            //global.xrmApp.Entity.SetValue("mzk_proposedvisitdatetime", mzk_proposedvisitdatetime,"dd/MM/yyyy", "hh:mm");
            
            //DateTime mzk_proposedvisitenddatetime = DateTime.Today.AddDays(1).AddHours(10);
            //global.xrmApp.Entity.SetValue("mzk_proposedvisitenddatetime", mzk_proposedvisitenddatetime, "dd/MM/yyyy", "hh:mm");
           //code change suggested by faiza
            DateTime mzk_scheduledstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            global.xrmApp.Entity.SetValue("mzk_scheduledstartdatetime", mzk_scheduledstartdatetime, "dd/MM/yyyy", "hh:mm");
            
            DateTime mzk_scheduledenddatetime = DateTime.Today.AddDays(3).AddHours(10);
            global.xrmApp.Entity.SetValue("mzk_scheduledenddatetime", mzk_scheduledenddatetime, "dd/MM/yyyy", "hh:mm");
            
            Lookupobj.Lookup("mzk_deliverymethods", ReferraltodeliviryOrderdata.deliverymethods);

            //Lookupobj.Lookup("mzk_deliveryroute", ReferraltodeliviryOrderdata.deliveryroute);
            //global.xrmApp.ThinkTime(2000);
            //global.xrmApp.Entity.SetValue("mzk_legacyordernumber", ReferraltodeliviryOrderdata.legacyordernumber);
            //global.xrmApp.ThinkTime(2000);
            //Lookupobj.Lookup("mzk_contractdeliveryfrequency", ReferraltodeliviryOrderdata.contractdeliveryfrequency);
            global.xrmApp.ThinkTime(3000);
            global.xrmApp.Entity.Save();
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.ThinkTime(3000);
            var mzk_visitstatus = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus.StartsWith("Draft"));
            string msdyn_postalcode = global.xrmApp.Entity.GetValue("msdyn_postalcode");
            Assert.IsNotNull(msdyn_postalcode);
            global.xrmApp.ThinkTime(4000);
            global.xrmApp.Entity.SelectTab("Products And Services");
            global.xrmApp.ThinkTime(4000);
            global.xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Ancillary Item");

            Lookupobj.LookupQuickCreate("msdyn_product", ReferraltodeliviryOrderdata.productname);
            //global.xrmApp.ThinkTime(2000);
            //Lookupobj.LookupQuickCreate("msdyn_unit", ReferraltodeliviryOrderdata.unit);

            global.xrmApp.QuickCreate.SetValue("msdyn_quantity", ReferraltodeliviryOrderdata.qunantity);
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.QuickCreate.Save();
            ////Service
            //global.xrmApp.ThinkTime(5000);
            //global.xrmApp.Entity.SubGrid.ClickCommand("workorderservicesgrid", "New Work Order Service");
            //global.xrmApp.ThinkTime(3000);
            //Lookupobj.Lookup("msdyn_service", ReferraltodeliviryOrderdata.servicename);
            //global.xrmApp.ThinkTime(5000);
            //global.xrmApp.CommandBar.ClickCommand("Save & Close");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));
            global.xrmApp.CommandBar.ClickCommand("Propose Order");
            global.xrmApp.ThinkTime(2000);
            var mzk_visitstatus3 = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus3.StartsWith("Proposed"));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.CommandBar.ClickCommand("Save & Close");

        }
        [TestCleanup]
        public void teardown()
        {
            //global.xrmApp.Navigation.SignOut();
            ////global.client.Browser.Driver.Quit();
        }
    }
}


