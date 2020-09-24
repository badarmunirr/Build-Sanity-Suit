﻿using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    //admin 
    //operational Manager
    [TestClass]
    public class A7_Create_ReferralstoDeliveryOrder
    {
        public static WebClient cli;
        static string casenumber;
        static string RefNumber;
        static string mzk_visitstatus3;
        static string WorkOrderNo;

        [TestMethod, TestCategory("BuildAutomation")]
        public void A7_CreateReferral()
        {
            ReadData readData = Helper.ReadDataFromJSONFile();
            var CreateReferral = new Action(() =>
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(usersetting.Admin, usersetting.pwd);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                HelperFunction Lookupobj = new HelperFunction();
                xrmApp.ThinkTime(4000);
                xrmApp.Navigation.OpenSubArea("Referral", "Referrals");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                xrmApp.CommandBar.ClickCommand("New");

                Lookupobj.Lookup("parentcontactid", readData.ReferraltodeliviryOrderData.parentcontactid, xrmApp);

                xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_patientconsent", Value = true });

                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_patientswitchstatus", Value = readData.ReferraltodeliviryOrderData.mzk_patientswitchstatus });

                xrmApp.Entity.SetValue("mzk_anonymousreference", readData.ReferraltodeliviryOrderData.mzk_anonymousreference);

                xrmApp.Entity.SetValue("mzk_hospitalreferencenumber", readData.ReferraltodeliviryOrderData.mzk_hospitalreferencenumber);
                xrmApp.ThinkTime(1000);
                xrmApp.Entity.SelectTab("General");

                xrmApp.Entity.SetValue("name", readData.ReferraltodeliviryOrderData.name);

                Lookupobj.Lookup("mzk_contract", readData.ReferraltodeliviryOrderData.mzk_contract, xrmApp);

                Lookupobj.Lookup("mzk_diagnosisgroup", readData.ReferraltodeliviryOrderData.mzk_diagnosisgroup, xrmApp);

                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_nursingstatus", Value = readData.ReferraltodeliviryOrderData.mzk_nursingstatus });

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
                Lookupobj.Lookup("pricelevelid", readData.ReferraltodeliviryOrderData.pricelevelid, xrmApp);
                // xrmApp.ThinkTime(2000);
                //Lookupobj.Lookup("mzk_masterpathway", ReferraltodeliviryOrderdata.MasterPathway);
                //Referrer
                // xrmApp.ThinkTime(1000);
                //Lookupobj.Lookup("mzk_referringprescriber", ReferraltoNurseOrderdata.refferingprescriber);

                xrmApp.Entity.SetValue("mzk_pmireferencenumber", readData.ReferraltodeliviryOrderData.mzk_pmireferencenumber);

                xrmApp.Entity.SetValue("mzk_billingreferencenumber", readData.ReferraltodeliviryOrderData.mzk_billingreferencenumber);

                xrmApp.Entity.SetValue("mzk_pmipolicynumber", readData.ReferraltodeliviryOrderData.mzk_pmipolicynumber);

                xrmApp.Entity.SetValue("mzk_legacyreferralnumber", readData.ReferraltodeliviryOrderData.mzk_legacyreferralnumber);
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
                casenumber = client.Browser.Driver.FindElement(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")).Text;
                xrmApp.ThinkTime(2000);
                string mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_status" });
                Assert.IsTrue(mzk_visitstatus2.StartsWith("Active"));
                string address1_postalcode = xrmApp.Entity.GetValue("address1_postalcode");
                Assert.IsNotNull(address1_postalcode);
                xrmApp.ThinkTime(3000);
                RefNumber = xrmApp.Entity.GetHeaderValue("mzk_requestnumber");
                xrmApp.ThinkTime(2000);
                xrmApp.Navigation.OpenSubArea("Referral", "Referrals");
                xrmApp.ThinkTime(2000);
                xrmApp.Grid.Search(RefNumber);
                xrmApp.ThinkTime(2000);
                xrmApp.Grid.HighLightRecord(0);
                xrmApp.ThinkTime(2000);
                xrmApp.CommandBar.ClickCommand("Assign");
                xrmApp.ThinkTime(2000);
                xrmApp.Dialogs.Assign(Dialogs.AssignTo.Team, "Hah");
                xrmApp.ThinkTime(2000);
                cli.Browser.Driver.Close();
            });



            var CreateDeliveryOrder = new Action(() =>
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(usersetting.OperationalManager, usersetting.pwd);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                HelperFunction Lookupobj = new HelperFunction();

                xrmApp.ThinkTime(3000);
                xrmApp.Navigation.OpenSubArea("Referral", "Cases");
                xrmApp.ThinkTime(3000);
                string refcasenu = casenumber;
                xrmApp.Grid.Search(refcasenu);
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

                Lookupobj.Lookup("msdyn_workordertype", readData.ReferraltodeliviryOrderData.msdyn_workordertype, xrmApp);
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
                Lookupobj.Lookup("mzk_deliverymethods", readData.ReferraltodeliviryOrderData.mzk_deliverymethods, xrmApp);

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

                Lookupobj.LookupQuickCreate("msdyn_product", readData.ReferraltodeliviryOrderData.msdyn_product, xrmApp);
                // xrmApp.ThinkTime(2000);
                //Lookupobj.LookupQuickCreate("msdyn_unit", ReferraltodeliviryOrderdata.unit);

                xrmApp.QuickCreate.SetValue("msdyn_quantity", readData.ReferraltodeliviryOrderData.msdyn_quantity);
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
                mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(mzk_visitstatus3.StartsWith("Proposed"));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");

            });
            CreateReferral();
            CreateDeliveryOrder();
        }

        //}

        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A7_Create_ReferralstoDeliveryOrder\r\n";
            LogHelper.LogRecord(Message + "Referral Number : " + RefNumber + "\r\nCase Number : " + casenumber + "\r\nWork Order Number : " + WorkOrderNo + "\r\nWork Order Status : " + mzk_visitstatus3);
            cli.Browser.Driver.Close();
        }
    }
}


