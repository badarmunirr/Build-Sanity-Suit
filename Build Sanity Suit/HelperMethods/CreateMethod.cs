using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;


namespace Build_Sanity_Suit
{

    public static class CreateMethod
    {
        //Initilizations
        //static HelperFunction Lookupobj = new HelperFunction();
        // static readonly string textFile = System.IO.Directory.GetCurrentDirectory() + @"\\Referral.txt";
        static ReadData readData = Helper.ReadDataFromJSONFile();

        public class Configdata
        {
            public static string datePattern = "dd/MM/yyyy";
            public static string TimePattern = "HH:mm";
        }

        public static void Address(XrmApp xrmApp, WebClient client)
        {
            client.Browser.Driver.WaitForPageToLoad();
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));
            if (client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@data-countrycode,'GB')]"))).Click();

                xrmApp.Entity.SetValue("address1_name", readData.PatientData.address1_name);

                xrmApp.Entity.SetValue("address1_line1", readData.PatientData.address3_line1);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']"))).Click();
            }
            else
            {
                Console.WriteLine("No Element found");
            }

            if (client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]"))).Click();

                xrmApp.Entity.SetValue("address2_name", readData.PatientData.address2_name);

                xrmApp.Entity.SetValue("address2_line1", readData.PatientData.address3_line1);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']"))).Click();
            }
            else
            {
                Console.WriteLine("No Element found");
            }
            xrmApp.ThinkTime(2000);
            if (client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address3_line1.fieldControl_container')]")))
            {

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address3_line1.fieldControl_container')]"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]"))).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]"))).Click();

                xrmApp.Entity.SetValue("address3_name", readData.PatientData.address3_name);

                xrmApp.Entity.SetValue("address3_line1", readData.PatientData.address3_line1);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']"))).Click();
            }
            else
            {
                Console.WriteLine("No Element found");
            }

        }
        public static void Referral(XrmApp xrmApp, WebClient client)
        {

            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));

            xrmApp.Navigation.OpenSubArea("Referral", "Referrals");
            client.Browser.Driver.WaitForPageToLoad();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.CommandBar.ClickCommand("New");

            Lookup("parentcontactid", readData.ReferraltodeliviryOrderData.parentcontactid, xrmApp, client);

            xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_patientconsent", Value = true });

            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_patientswitchstatus", Value = readData.ReferraltodeliviryOrderData.mzk_patientswitchstatus });

            xrmApp.Entity.SetValue("mzk_anonymousreference", readData.ReferraltodeliviryOrderData.mzk_anonymousreference);

            xrmApp.Entity.SetValue("mzk_hospitalreferencenumber", readData.ReferraltodeliviryOrderData.mzk_hospitalreferencenumber);
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Entity.SelectTab("General");

            //xrmApp.Entity.SetValue("name", readData.ReferraltodeliviryOrderData.name);

            Lookup("mzk_contract", readData.ReferraltodeliviryOrderData.mzk_contract, xrmApp, client);

            Lookup("mzk_diagnosisgroup", readData.ReferraltodeliviryOrderData.mzk_diagnosisgroup, xrmApp, client);

            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_nursingstatus", Value = readData.ReferraltodeliviryOrderData.mzk_nursingstatus });

            //Lookupobj.Lookup("mzk_contractdeliverymethod", "aHUS");

            // xrmApp.Entity.SetValue("description", "description");
            xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_reducedpricepatient", Value = true });

            //if (client.Browser.Driver.HasElement(By.XPath("//a[contains(@aria-label,'Reduced Price Patient')]")))
            //{
            //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@aria-label,'Reduced Price Patient')]"))).Click();


            //}
            //else
            //{
            //    Console.WriteLine("No Element found");
            //}

            Lookup("pricelevelid", readData.ReferraltodeliviryOrderData.pricelevelid, xrmApp, client);
            // xrmApp.ThinkTime(2000);
            //Lookupobj.Lookup("mzk_masterpathway", ReferraltodeliviryOrderdata.MasterPathway);
            //Referrer
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_referringprescriber", ReferraltoNurseOrderdata.refferingprescriber);

            xrmApp.Entity.SetValue("mzk_pmireferencenumber", readData.ReferraltodeliviryOrderData.mzk_pmireferencenumber);

            xrmApp.Entity.SetValue("mzk_billingreferencenumber", readData.ReferraltodeliviryOrderData.mzk_billingreferencenumber);

            xrmApp.Entity.SetValue("mzk_pmipolicynumber", readData.ReferraltodeliviryOrderData.mzk_pmipolicynumber);

            xrmApp.Entity.SetValue("mzk_legacyreferralnumber", readData.ReferraltodeliviryOrderData.mzk_legacyreferralnumber);


            xrmApp.Entity.Save();
            client.Browser.Driver.WaitForPageToLoad();
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
            //string RefNumber = xrmApp.Entity.GetHeaderValue("mzk_requestnumber");
            //string logFile = System.IO.Directory.GetCurrentDirectory() + @"\\Referral.txt";
            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFile, true))
            //{
            //    file.WriteLine(RefNumber);
            //}
            // }

        }

        public static void DeliveryOrder(XrmApp xrmApp, WebClient client, string casenumber)
        {
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));
            xrmApp.Navigation.OpenSubArea("Referral", "Cases");

            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Grid.Search(casenumber);
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Grid.OpenRecord(0);
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Entity.SelectTab("Delivery and Nursing Visit");
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Entity.SubGrid.ClickCommand("DeliveryAndNursingVisitGrid", "Add New Work Order");
            // xrmApp.ThinkTime(2000);
            // xrmApp.Entity.SelectForm("Visit Detail");
            // xrmApp.ThinkTime(5000);
            //if (client.Browser.Driver.HasElement(By.XPath("//button[contains(@data-id,'cancelButton')]")))
            //{
            //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@data-id,'cancelButton')]")));
            //    client.Browser.Driver.FindElement(By.XPath("//button[contains(@data-id,'cancelButton')]")).Click();
            //}
            //else
            //{
            //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //}
            client.Browser.Driver.WaitForPageToLoad();
            string casenumber2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-id='msdyn_servicerequest.fieldControl-LookupResultsDropdown_msdyn_servicerequest_selected_tag_text']"))).Text;
            Assert.IsTrue(casenumber2.StartsWith(casenumber));

            Lookup("msdyn_workordertype", readData.ReferraltodeliviryOrderData.msdyn_workordertype, xrmApp, client);
            //
            //Lookupobj.Lookup("msdyn_serviceterritory", ReferraltodeliviryOrderdata.serviceterritory);
            // xrmApp.ThinkTime(2000);
            // xrmApp.Entity.SetValue("mzk_region", ReferraltodeliviryOrderdata.region);
            // xrmApp.Entity.SetValue("mzk_district", ReferraltodeliviryOrderdata.district);
             xrmApp.Entity.SetValue("mzk_prescriptionponumber", Wholesaleorderdata.prescriptionponumber);
            //DateTime mzk_proposedvisitdatetime = DateTime.Today.AddDays(1).AddHours(10);
            // xrmApp.Entity.SetValue("mzk_proposedvisitdatetime", mzk_proposedvisitdatetime,"dd/MM/yyyy", "hh:mm");

            //DateTime mzk_proposedvisitenddatetime = DateTime.Today.AddDays(1).AddHours(10);
            // xrmApp.Entity.SetValue("mzk_proposedvisitenddatetime", mzk_proposedvisitenddatetime, "dd/MM/yyyy", "hh:mm");
            //code change suggested by faiza
            DateTime mzk_scheduledstartdatetime = DateTime.Today.AddDays(4).AddHours(10);
            xrmApp.Entity.SetValue("mzk_scheduledstartdatetime", mzk_scheduledstartdatetime, Configdata.datePattern, Configdata.TimePattern);

            DateTime mzk_scheduledenddatetime = DateTime.Today.AddDays(5).AddHours(15);
            xrmApp.Entity.SetValue("mzk_scheduledenddatetime", mzk_scheduledenddatetime, Configdata.datePattern, Configdata.TimePattern);

            Lookup("mzk_deliverymethods", readData.ReferraltodeliviryOrderData.mzk_deliverymethods, xrmApp, client);

            //Lookupobj.Lookup("mzk_deliveryroute", ReferraltodeliviryOrderdata.deliveryroute);
            // xrmApp.ThinkTime(2000);
            // xrmApp.Entity.SetValue("mzk_legacyordernumber", ReferraltodeliviryOrderdata.legacyordernumber);
    
            Lookup("mzk_contractdeliveryfrequency", readData.ReferraltodeliviryOrderData.contractdeliveryfrequency, xrmApp, client);

            xrmApp.Entity.Save();
            client.Browser.Driver.WaitForPageToLoad();
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));

            string mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus.StartsWith("Draft"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));
            client.Browser.Driver.WaitForPageToLoad();
            string msdyn_postalcode = xrmApp.Entity.GetValue("msdyn_postalcode");
            Assert.IsNotNull(msdyn_postalcode);
            xrmApp.Entity.SelectTab("Products And Services");
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//li[@title='Products And Services']"))).Click();
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Ancillary Item");

            LookupQuickCreate("msdyn_product", readData.ReferraltodeliviryOrderData.msdyn_product, xrmApp);
            // xrmApp.ThinkTime(2000);
            //Lookupobj.LookupQuickCreate("msdyn_unit", ReferraltodeliviryOrderdata.unit);

            xrmApp.QuickCreate.SetValue("msdyn_quantity", readData.ReferraltodeliviryOrderData.msdyn_quantity);

            xrmApp.QuickCreate.Save();


            client.Browser.Driver.WaitForPageToLoad();

            //string[] products = { "PRO-004930", "PRO-004916", "PRO-004543", "PRO-004186" , "PRO-003964", "PRO-002469", "PRO-002531" , "PRO-002214" };

            //foreach (string product in products)
            //{

            //    xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Medication");

            //    xrmApp.QuickCreate.SetValue(new BooleanItem { Name = "mzk_showprimaryproducts", Value = false });


            //    LookupQuickCreate("msdyn_product", product, xrmApp);
            //    // xrmApp.ThinkTime(2000);
            //    //Lookupobj.LookupQuickCreate("msdyn_unit", ReferraltodeliviryOrderdata.unit);

            //    xrmApp.QuickCreate.SetValue("msdyn_quantity", readData.ReferraltodeliviryOrderData.msdyn_quantity);

            //    xrmApp.QuickCreate.Save();
            //}

            ////Service
            // xrmApp.ThinkTime(5000);
            // xrmApp.Entity.SubGrid.ClickCommand("workorderservicesgrid", "New Work Order Service");
            // xrmApp.ThinkTime(3000);
            //Lookupobj.Lookup("msdyn_service", ReferraltodeliviryOrderdata.servicename);
            // xrmApp.ThinkTime(5000);
            // xrmApp.CommandBar.ClickCommand("Save & Close");


        }
        public static void NurseOrder(XrmApp xrmApp, WebClient client, string casenumber)
        {
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));
            xrmApp.Navigation.OpenSubArea("Referral", "Cases");
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Grid.Search(casenumber);
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Grid.OpenRecord(0);
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Entity.SelectTab("Delivery and Nursing Visit");
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Entity.SubGrid.ClickCommand("DeliveryAndNursingVisitGrid", "Add New Work Order");
            // xrmApp.ThinkTime(2000);
            // xrmApp.Entity.SelectForm("Visit Detail");
            // xrmApp.ThinkTime(5000);
            //if (client.Browser.Driver.HasElement(By.XPath("//button[contains(@data-id,'cancelButton')]")))
            //{
            //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@data-id,'cancelButton')]")));
            //    client.Browser.Driver.FindElement(By.XPath("//button[contains(@data-id,'cancelButton')]")).Click();
            //}
            //else
            //{
            //    Console.WriteLine("No 'Stay Signed In' Dialog appeared");
            //}

            string casenumber2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-id='msdyn_servicerequest.fieldControl-LookupResultsDropdown_msdyn_servicerequest_selected_tag_text']"))).Text;
            Assert.IsTrue(casenumber2.StartsWith(casenumber));
            Lookup("msdyn_workordertype", readData.ReferralstoNurseOrderData.msdyn_workordertype, xrmApp, client);
            // xrmApp.ThinkTime(2000);
            //Lookupobj.Lookup("msdyn_serviceterritory", ReferraltodeliviryOrderdata.serviceterritory);
            // xrmApp.ThinkTime(2000);
            // xrmApp.Entity.SetValue("mzk_region", ReferraltodeliviryOrderdata.region);
            // xrmApp.Entity.SetValue("mzk_district", ReferraltoNurseOrderdata.district);
            // xrmApp.ThinkTime(2000);
            //DateTime mzk_proposedvisitdatetime = DateTime.Today.AddDays(1).AddHours(10);
            // xrmApp.Entity.SetValue("mzk_proposedvisitdatetime", mzk_proposedvisitdatetime, "dd/MM/yyyy", "hh:mm");
            // xrmApp.ThinkTime(2000);
            //DateTime mzk_proposedvisitenddatetime = DateTime.Today.AddDays(1).AddHours(10);
            // xrmApp.Entity.SetValue("mzk_proposedvisitenddatetime", mzk_proposedvisitenddatetime, "dd/MM/yyyy", "hh:mm");

            DateTime mzk_scheduledstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            xrmApp.Entity.SetValue("mzk_scheduledstartdatetime", mzk_scheduledstartdatetime, Configdata.datePattern, Configdata.TimePattern);

            DateTime mzk_scheduledenddatetime = DateTime.Today.AddDays(3).AddHours(10);
            xrmApp.Entity.SetValue("mzk_scheduledenddatetime", mzk_scheduledenddatetime, Configdata.datePattern, Configdata.TimePattern);

            xrmApp.Entity.Save();
            client.Browser.Driver.WaitForPageToLoad();
            string mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus2.StartsWith("Proposed"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Complete')]")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@data-id='navbutton']"))).Click();
            client.Browser.Driver.WaitForPageToLoad();
            string msdyn_postalcode = xrmApp.Entity.GetValue("msdyn_postalcode");
            Assert.IsNotNull(msdyn_postalcode);
            xrmApp.Entity.SelectTab("Products And Services");
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//li[@title='Products And Services']"))).Click();
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Entity.SubGrid.ClickCommand("workorderservicesgrid", "New Work Order Service");

            LookupQuickCreate("msdyn_service", readData.ReferralstoNurseOrderData.msdyn_service, xrmApp);

            //Lookupobj.LookupQuickCreate("msdyn_unit", Referraldata.unit);

            xrmApp.QuickCreate.SetValue("mzk_quantity", readData.ReferralstoNurseOrderData.mzk_quantity);

            xrmApp.QuickCreate.Save();
            client.Browser.Driver.WaitForPageToLoad();
        }
        public static void WholesaleOrder(XrmApp xrmApp, WebClient client)
        {
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Navigation.OpenSubArea("Referral", "Wholesale Orders");
            client.Browser.Driver.WaitForPageToLoad();
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.CommandBar.ClickCommand("New");
            // xrmApp.ThinkTime(2000);
            // xrmApp.Entity.SelectForm("Wholesale Order");
            // xrmApp.ThinkTime(1000);
            //if (client.Browser.Driver.HasElement(By.XPath("//button[contains(@data-id,'cancelButton')]")))
            //{
            //    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@data-id,'cancelButton')]")));
            //    client.Browser.Driver.FindElement(By.XPath("//button[contains(@data-id,'cancelButton')]")).Click();
            //}
            //else
            //{
            //    Console.WriteLine("Element not found");
            //}
            Lookup("mzk_contract", readData.WholesaleOrderData.mzk_contract, xrmApp, client);

            Lookup("msdyn_workordertype", readData.WholesaleOrderData.msdyn_workordertype, xrmApp, client);

            // xrmApp.Entity.SetValue("mzk_prescriptionponumber", Wholesaleorderdata.prescriptionponumber);
            //// xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_distributioncenter", "Khi");
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_region", "Khi");

            // xrmApp.Entity.SetValue("mzk_district", Wholesaleorderdata.district);

            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_emergencyorder", Value = false });
            //Visit Date and Time Information
           
            //DateTime mzk_proposedvisitdatetime = DateTime.Today.AddDays(1).AddHours(12);
            // xrmApp.Entity.SetValue("mzk_proposedvisitdatetime", mzk_proposedvisitdatetime, "dd/MM/yyyy", "hh:mm");

            //DateTime mzk_proposedvisitenddatetime = DateTime.Today.AddDays(1).AddHours(12);
            // xrmApp.Entity.SetValue("mzk_proposedvisitenddatetime", mzk_proposedvisitenddatetime, "dd/MM/yyyy", "hh:mm");
            DateTime mzk_scheduledstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            xrmApp.Entity.SetValue("mzk_scheduledstartdatetime", mzk_scheduledstartdatetime, Configdata.datePattern, Configdata.TimePattern);

            DateTime mzk_scheduledenddatetime = DateTime.Today.AddDays(2).AddHours(12);
            xrmApp.Entity.SetValue("mzk_scheduledenddatetime", mzk_scheduledenddatetime, Configdata.datePattern, Configdata.TimePattern);
            //Visit Reasons
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_emergencyreasons", "mzk_emergencyreasons");
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_failurevisitsubreason", "mzk_failurevisitsubreason");
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_outofslareason", "mzk_outofslareason");
            //Cancellation Information
            // xrmApp.ThinkTime(1000);
            ////Lookupobj.Lookup("mzk_cancelreason", "mzk_cancelreason");
            // xrmApp.ThinkTime(1000);
            //DateTime mzk_cancellationdatetime = DateTime.Today.AddDays(1).AddHours(10);
            // xrmApp.Entity.SetValue("mzk_cancellationdatetime", mzk_cancellationdatetime);
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_cancelledby", "Alex");
            //Delivery Information

            //Lookupobj.Lookup("mzk_contractdeliveryfrequency", Wholesaleorderdata.deliveryfrequency);
    
            Lookup("mzk_deliverymethods", readData.WholesaleOrderData.mzk_deliverymethods, xrmApp, client);

            //Lookupobj.Lookup("mzk_deliveryroute", Wholesaleorderdata.deliveryroute);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_drivername", Wholesaleorderdata.drivername);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_vanid", Wholesaleorderdata.vanid);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_visitnotes", Wholesaleorderdata.visitnotes);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_drivercomments", Wholesaleorderdata.drivercomments);
            // xrmApp.ThinkTime(1000);
            string mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });//msdyn_servicerequest
            Assert.IsTrue(mzk_visitstatus.StartsWith("Draft"));
            xrmApp.Entity.Save();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            client.Browser.Driver.WaitForPageToLoad();

            //string casenumber = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'msdyn_servicerequest.fieldControl-LookupResultsDropdown_msdyn_servicerequest_selected_tag"))).Text;
            //Assert.IsNotNull(casenumber);

            string msdyn_postalcode = xrmApp.Entity.GetValue("msdyn_postalcode");
            Assert.IsNotNull(msdyn_postalcode);
            //Products And Services
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//li[@title='Products And Services']"))).Click();
            xrmApp.Entity.SelectTab("Products And Services");
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");

            LookupQuickCreate("msdyn_product", readData.WholesaleOrderData.msdyn_product, xrmApp);
            // xrmApp.ThinkTime(2000);
            //Lookupobj.LookupQuickCreate("msdyn_unit", Wholesaleorderdata.unit);
            // xrmApp.ThinkTime(1000);
            xrmApp.QuickCreate.SetValue("msdyn_quantity", readData.WholesaleOrderData.msdyn_quantity);
            xrmApp.QuickCreate.SetValue("msdyn_description", readData.WholesaleOrderData.msdyn_description);
            xrmApp.QuickCreate.SetValue("msdyn_internaldescription", readData.WholesaleOrderData.msdyn_internaldescription);
            xrmApp.QuickCreate.Save();
            client.Browser.Driver.WaitForPageToLoad();
            //Service
            // xrmApp.ThinkTime(5000);
            // xrmApp.Entity.SubGrid.ClickCommand("workorderservicesgrid", "New Work Order Service");
            // xrmApp.ThinkTime(3000);
            //Lookupobj.Lookup("msdyn_service", Wholesaleorderdata.servicename);
            // xrmApp.ThinkTime(5000);
            // xrmApp.CommandBar.ClickCommand("Save & Close");
            // xrmApp.ThinkTime(5000);
            //if ( client.Browser.Driver.HasElement(By.CssSelector("button[data-id='ignore_save']")))
            //{
            //     client.Browser.Driver.FindElement(By.CssSelector("button[data-id='ignore_save']")).SendKeys(Keys.Enter);
            //}
            //else
            //{
            //    Console.WriteLine("Update Duplicate Record");
            //}
            // xrmApp.ThinkTime(1000);
        }
        public static void Resource(XrmApp xrmApp, WebClient client)
        {
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));

            string UserName = readData.ResourceData.userid;
            string UserNameTrim = UserName.Remove(9);
            xrmApp.ThinkTime(4000);
            xrmApp.Navigation.OpenSubArea("Others", "Bookable Resources");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.CommandBar.ClickCommand("New");

            xrmApp.Entity.SetValue(new OptionSet { Name = "resourcetype", Value = readData.ResourceData.resourcetype });

            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_resourcesubtype", Value = readData.ResourceData.mzk_resourcesubtype });

            Lookup("userid", readData.ResourceData.userid, xrmApp, client); //need to update this everytime

            Lookup("mzk_gendervalue", readData.ResourceData.mzk_gendervalue, xrmApp, client);

            //    Lookupobj.Lookup("mzk_language", ResourceToPatData.language, xrmApp);


            xrmApp.Entity.SetValue("mzk_address1name", readData.ResourceData.mzk_address1name);

            xrmApp.Entity.SetValue("mzk_address1line1", readData.ResourceData.mzk_address1line1);


            xrmApp.Entity.SetValue("mzk_city1", readData.ResourceData.mzk_city1);

            xrmApp.Entity.SetValue("mzk_postalcode1", readData.ResourceData.mzk_postalcode1);

            xrmApp.Entity.SetValue("mzk_country1", readData.ResourceData.mzk_country1);

            xrmApp.Entity.SetValue("mzk_address1countrycodeiso", readData.ResourceData.mzk_address1countrycodeiso);


            //Default Delivery Address
            xrmApp.Entity.SetValue("mzk_address2name", readData.ResourceData.mzk_address2name);

            xrmApp.Entity.SetValue("mzk_address2line1", readData.ResourceData.mzk_address2line1);


            xrmApp.Entity.SetValue("mzk_city2", readData.ResourceData.mzk_city2);

            xrmApp.Entity.SetValue("mzk_postalcode2", readData.ResourceData.mzk_postalcode2);
            xrmApp.Entity.SetValue("mzk_country2", readData.ResourceData.mzk_country2);
            xrmApp.Entity.SetValue("mzk_address2countrycodeiso", readData.ResourceData.mzk_address2countrycodeiso);

            xrmApp.Entity.Save();
            xrmApp.ThinkTime(2000);
            if (client.Browser.Driver.HasElement(By.XPath("//a[contains(@aria-label,'Convert into Contact')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@aria-label,'Convert into Contact')]")));
                client.Browser.Driver.FindElement(By.XPath("//a[contains(@aria-label,'Convert into Contact')]")).Click();

            }
            else
            {
                Console.WriteLine("No Element found");
            }

            Random random = new Random();
            int randomnumber = random.Next(01111, 09999);
            string payrollnumber = "EMP_" + randomnumber.ToString();
            xrmApp.Entity.SetValue("mzk_payrollnumberemployeeref", payrollnumber);
            xrmApp.Entity.Save();
            xrmApp.ThinkTime(500);
            //Field gender =  xrmApp.Entity.GetField("mzk_gendervalue");
            //Assert.IsTrue(gender.IsRequired);
            // xrmApp.ThinkTime(5000);
            //Field language =  xrmApp.Entity.GetField("mzk_language");
            //Assert.IsTrue(language.IsRequired);
            xrmApp.Navigation.OpenSubArea("Others", "Bookable Resources");
            xrmApp.ThinkTime(2000);
            xrmApp.Grid.Search(UserNameTrim);
            xrmApp.ThinkTime(2000);
            xrmApp.Grid.HighLightRecord(0);
            xrmApp.ThinkTime(2000);
            xrmApp.CommandBar.ClickCommand("Assign");
            xrmApp.ThinkTime(2000);
            xrmApp.Dialogs.Assign(Dialogs.AssignTo.Team, "Hah");
            xrmApp.ThinkTime(2000);
            xrmApp.Navigation.OpenArea("MazikCare Referral Management");
            xrmApp.ThinkTime(5000);
            xrmApp.Navigation.OpenSubArea("Customers", "Accounts");
            xrmApp.Grid.Search(UserNameTrim);
            xrmApp.ThinkTime(5000);
            xrmApp.Grid.OpenRecord(0);
            string accountnumber = xrmApp.Entity.GetValue("accountnumber");
            Assert.IsTrue(accountnumber.StartsWith(payrollnumber));
        }
        public static void Payer(XrmApp xrmApp, WebClient client)
        {

            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Payers']"))).Click();
            xrmApp.Navigation.OpenSubArea("Customers", "Payers");
            //client.Browser.Driver.WaitForPageToLoad();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='New']")));
            xrmApp.CommandBar.ClickCommand("New");

            xrmApp.Entity.SetValue("name", readData.PayerData.name);

            xrmApp.Entity.SetValue("telephone1", readData.PayerData.telephone1);

            xrmApp.Entity.SetValue("emailaddress1", readData.PayerData.emailaddress1);

            // xrmApp.Entity.SetValue("mzk_aeemailaddress", Payerdata.email2);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_pqcemailaddress", Payerdata.email3);
            // xrmApp.Entity.SetValue("mzk_pspid", Payerdata.pspid+i);
            xrmApp.Entity.SetValue("mzk_vatnum", readData.PayerData.mzk_vatnum);

            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_accountcategory", Value = readData.PayerData.mzk_accountcategory });
            
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_billingfrequency", Value = readData.PayerData.mzk_billingfrequency });
            
            xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_showcreditlimit", Value = true });
            // unable to set value in credit limit field 
            // xrmApp.Entity.SetValue("creditlimit", "555");


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[contains(@aria-label,'Credit Limit')]"))).Click();
            client.Browser.Driver.FindElement(By.XPath("//input[contains(@aria-label,'Credit Limit')]")).SendKeys("5555");

            Lookup("mzk_paymentterms", readData.PayerData.mzk_paymentterms, xrmApp, client);
            //Lookupobj.Lookup("mzk_patientlanguage", Payerdata.patientlanguage);
            DateTime mzk_dateoflastcreditcheck = DateTime.Today;
            xrmApp.Entity.SetValue("mzk_dateoflastcreditcheck", mzk_dateoflastcreditcheck, Configdata.datePattern);
            DateTime mzk_dateoflastfinancialregistrationdocuments = DateTime.Today;
            xrmApp.Entity.SetValue("mzk_dateoflastfinancialregistrationdocuments", mzk_dateoflastfinancialregistrationdocuments, Configdata.datePattern);
            // Address
            Address(xrmApp, client);
            //Lookupobj.Lookup("primarycontactid", Payerdata.primarycontactid);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SelectTab("Details");
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue(new OptionSet { Name = "preferredcontactmethodcode", Value = Payerdata.preferdcontactmethod });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotemail", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotbulkemail", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotphone", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotfax", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotpostalmail", Value = false });

            xrmApp.Entity.Save();
            client.Browser.Driver.WaitForPageToLoad();
            if (client.Browser.Driver.HasElement(By.CssSelector("button[data-id='ignore_save']")))
            {
                xrmApp.Dialogs.DuplicateDetection(true);
          //client.Browser.Driver.FindElement(By.CssSelector("button[data-id='ignore_save']")).SendKeys(Keys.Enter);
            }
            else
            {
                Console.WriteLine("Update Duplicate Record");
            }
           wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@title='Vaildate Payer']")));
            //client.Browser.Driver.WaitForPageToLoad();
            xrmApp.CommandBar.ClickCommand("Vaildate Payer");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("confirmButton")));
      
            xrmApp.Dialogs.ConfirmationDialog(true);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("confirmButton")));
            xrmApp.Dialogs.ConfirmationDialog(true);
            Assert.IsTrue(xrmApp.Entity.GetValue("mzk_address1countrycodeiso").StartsWith("GB"));
            Assert.IsTrue(xrmApp.Entity.GetValue("mzk_address2countrycodeiso").StartsWith("GB"));
            client.Browser.Driver.WaitUntilVisible(By.CssSelector("*[aria-label='Validated: Yes']")).IsVisible();
           // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='New']")));

            //Field address1_line1 =  xrmApp.Entity.GetField("address1_line1");
            //Assert.IsTrue(address1_line1.IsRequired);
            //Field address2_line1 =  xrmApp.Entity.GetField("address2_line1");
            //Assert.IsTrue(address2_line1.IsRequired);

            //string accountnumber =  xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "accountnumber" });
            //Assert.IsFalse(accountnumber.StartsWith("---"));
        }
        public static void Patient(XrmApp xrmApp, WebClient client)
        {
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));
            xrmApp.Navigation.OpenSubArea("Customers", "Patients");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.CommandBar.ClickCommand("New");
            Lookup("mzk_title", readData.PatientData.mzk_title, xrmApp, client);

            xrmApp.Entity.SetValue("firstname", readData.PatientData.firstname);

            xrmApp.Entity.SetValue("lastname", readData.PatientData.lastname);

            Lookup("mzk_gender", readData.PatientData.mzk_gender, xrmApp, client);

            xrmApp.Entity.SetValue("mzk_preferredname", readData.PatientData.mzk_preferredname);// Optional

            DateTime birthday = new DateTime(1995, 3, 1);

            xrmApp.Entity.SetValue("birthdate", birthday, Configdata.datePattern);

            //  xrmApp.Entity.SetValue("mzk_mothersidentifier", Patientdata.motherifentification);//optional

            xrmApp.Entity.SetValue(new OptionSet { Name = "familystatuscode", Value = readData.PatientData.familystatuscode });
            //optional
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_nationality", Patientdata.nationality);
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_ethnicity", Patientdata.ethnicity);
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_race", Patientdata.race);

            Lookup("mzk_patientlanguage", readData.PatientData.mzk_patientlanguage, xrmApp, client);
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_disability", Patientdata.disability);//optional
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_carerresponsibility", "Vision Impairment");//optional

            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_vippatient", Value = true });//optional

            xrmApp.Entity.SetValue("mzk_patientinstructions", readData.PatientData.mzk_patientinstructions);//optional

            xrmApp.Entity.SetValue("mzk_medicalhistory", readData.PatientData.mzk_medicalhistory);
            //optional
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_selffundingaccount", "Payer");
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_gpname", "Mark Hyman");
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_gpsurgeryname", "Ramsey Hospital");
            //Identification
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_legacyhahnumber", Patientdata.legacyhahnumber);

            string[] identificationtype = { "National ID", "Passport", "Work Permit", "Driver's License Number", "Other", "National Health Care ID" };

            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_patientidentificationtype", Value = identificationtype[0] });

            Random random = new Random();
            int randomnumber = random.Next(0111111111, 0999999999);
            xrmApp.Entity.SetValue("mzk_primaryidentificationnumber", randomnumber.ToString());

            DateTime mzk_primaryidentificationexpirationdate = DateTime.Today.AddDays(1);

            xrmApp.Entity.SetValue("mzk_primaryidentificationexpirationdate", mzk_primaryidentificationexpirationdate, Configdata.datePattern);
            ;
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_secondaryidentificationtype", Value = identificationtype[1] });

            xrmApp.Entity.SetValue("mzk_secondaryidentificationnumber", "0123456");
            DateTime mzk_secondaryidentificationexpirationdate = DateTime.Today.AddDays(10);

            xrmApp.Entity.SetValue("mzk_secondaryidentificationexpirationdate", mzk_secondaryidentificationexpirationdate, Configdata.datePattern);

            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_otheridentificationtype", Value = identificationtype[4] });

            xrmApp.Entity.SetValue("mzk_otheridentificationnumber", "012345");
            DateTime mzk_otheridentificationexpirationdate = DateTime.Today.AddDays(10);
            xrmApp.Entity.SetValue("mzk_otheridentificationexpirationdate", mzk_otheridentificationexpirationdate, Configdata.datePattern);
            //CONTACT DETAILS
            xrmApp.Entity.SetValue("telephone1", readData.PatientData.telephone1);
            xrmApp.Entity.SetValue("telephone2", readData.PatientData.telephone2);
            xrmApp.Entity.SetValue("telephone3", readData.PatientData.telephone3);
            xrmApp.Entity.SetValue("mobilephone", readData.PatientData.mobilephone);
            xrmApp.Entity.SetValue("emailaddress1", readData.PatientData.emailaddress1);

            Address(xrmApp, client);
            //Contact Methods

            // xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_emailpreferences", Value = Patientdata.emailpreferences });

            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotphone", Value = true });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_smstextingpreferences", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_letterpreferences", Value = false });

            //// xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_contactpreferredtime", Value = "12:00 AM" });
            //// xrmApp.ThinkTime(500);
            //// xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_contactpreferredtimeto", Value = "12:00 AM" });
            // xrmApp.ThinkTime(500);
            // xrmApp.Entity.SetValue(new OptionSet { Name = "preferredcontactmethodcode", Value = Patientdata.preferdcontactmethod });
            // xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_survey", Value = Patientdata.survey });
            ////Shipping

            ////Scheduling Preference
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SelectTab("Scheduling Preference");
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencemonday", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencetuesday", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencewednesday", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencethursday", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencefriday", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencesaturday", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencesunday", Value = true });

            xrmApp.Entity.Save();
            client.Browser.Driver.WaitForPageToLoad();
            if (client.Browser.Driver.HasElement(By.CssSelector("button[data-id='ignore_save']")))
            {
                xrmApp.Dialogs.DuplicateDetection(true);
            }
            else
            {
                Console.WriteLine("Update Duplicate Record");
            }
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Save & Close')]")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            Assert.IsTrue(xrmApp.Entity.GetValue("mzk_address1countrycodeiso").StartsWith("GB"));
            Assert.IsTrue(xrmApp.Entity.GetValue("mzk_address2countrycodeiso").StartsWith("GB"));
            Assert.IsTrue(xrmApp.Entity.GetValue("mzk_address3countrycodeiso").StartsWith("GB"));
            foreach (string idtype in identificationtype)
            {
                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_patientidentificationtype", Value = idtype });
                Field primaryfield = xrmApp.Entity.GetField("mzk_primaryidentificationnumber");
                Assert.IsTrue(primaryfield.IsRequired);
                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_secondaryidentificationtype", Value = idtype });
                Field secondryfield = xrmApp.Entity.GetField("mzk_secondaryidentificationnumber");
                Assert.IsTrue(secondryfield.IsRequired);
                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_otheridentificationtype", Value = idtype });
                Field otherField = xrmApp.Entity.GetField("mzk_otheridentificationnumber");
                Assert.IsTrue(otherField.IsRequired);
            }
            //Field address1_line1 =  xrmApp.Entity.GetField("address1_line1");
            //Assert.IsTrue(address1_line1.IsRequired);
            //Field address2_line1 =  xrmApp.Entity.GetField("address2_line1");
            //Assert.IsTrue(address2_line1.IsRequired);
            //Field address3_line1 =  xrmApp.Entity.GetField("address3_line1");
            //Assert.IsTrue(address3_line1.IsRequired);

            string mzk_patientmrn = xrmApp.Entity.GetValue("mzk_patientmrn");
            string mzk_agecalculated = xrmApp.Entity.GetValue("mzk_agecalculated");
            string mzk_pincode = xrmApp.Entity.GetValue("mzk_pincode");
            string mzk_failedpincode = xrmApp.Entity.GetValue("mzk_failedpincode");
            //Assert.IsNotNull(mzk_agecalculated);
            //Assert.IsNotNull(mzk_patientmrn);
            //Assert.IsNotNull(mzk_failedpincode);
            ////Assert.IsNotNull(mzk_pincode);

            Assert.IsFalse(mzk_patientmrn.StartsWith("---"));
            Assert.IsFalse(mzk_agecalculated.StartsWith("---"));
            Assert.IsFalse(mzk_pincode.StartsWith("---"));
            Assert.IsFalse(mzk_failedpincode.StartsWith("---"));
        }
        public static void ManualInvoice(XrmApp xrmApp, WebClient client, string Category, string Type)
        {
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));

            if (Type == "Invoice" && Category == "Organization" || Type == "Credit" && Category == "Organization")
            {
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.Navigation.OpenSubArea("Referral", "Manual Invoice/Credit");
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.CommandBar.ClickCommand("New");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Payer']"))).SendKeys(Keys.ArrowDown);


                DateTime mzk_actualvisitstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
                xrmApp.Entity.SetValue("mzk_actualvisitstartdatetime", mzk_actualvisitstartdatetime, Conifgdata.datePattern, Conifgdata.TimePattern);

                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_category", Value = Category });

                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualordertype", Value = Type });

                //Lookupobj.Lookup("mzk_payer", TestData19273.payer);

                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingfrequency", Value = readData.TstManualInvoice_19273Data.mzk_manualbillingfrequency });

                xrmApp.Entity.SetValue("mzk_prescriptionponumber", readData.TstManualInvoice_19273Data.mzk_prescriptionponumber);

               
                //Lookupobj.Lookup("msdyn_serviceaccount", TestData19273.account);

                Lookup("mzk_contract", readData.TstManualInvoice_19273Data.mzk_contract, xrmApp, client);

                //Lookupobj.Lookup("msdyn_servicerequest", TestData19273.Case);

                xrmApp.Entity.Save();

                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.Entity.SelectTab("Products And Services");
                client.Browser.Driver.WaitForPageToLoad();

                xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");
                client.Browser.Driver.WaitForPageToLoad();
                LookupQuickCreate("msdyn_product", readData.TstManualInvoice_19273Data.msdyn_product, xrmApp);

                
                xrmApp.QuickCreate.SetValue("msdyn_quantity", readData.TstManualInvoice_19273Data.msdyn_quantity);

                xrmApp.QuickCreate.Save();
                client.Browser.Driver.WaitForPageToLoad();
                var mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(mzk_visitstatus.StartsWith("Proposed"));

            }
            if (Type == "Invoice" && Category == "Patient" || Type == "Credit" && Category == "Patient")
            {
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.Navigation.OpenSubArea("Referral", "Manual Invoice/Credit");
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.CommandBar.ClickCommand("New");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//label[text()='Payer']"))).SendKeys(Keys.ArrowDown);
                DateTime mzk_actualvisitstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
                xrmApp.Entity.SetValue("mzk_actualvisitstartdatetime", mzk_actualvisitstartdatetime, Conifgdata.datePattern, Conifgdata.TimePattern);

                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_category", Value = Category });

                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualordertype", Value = Type });

                //Lookupobj.Lookup("mzk_payer", TestData19347.payer);

                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingfrequency", Value = readData.TstManualInvoice_19347Data.mzk_manualbillingfrequency });

                xrmApp.Entity.SetValue("mzk_prescriptionponumber", readData.TstManualInvoice_19347Data.mzk_prescriptionponumber);

               
                //Lookupobj.Lookup("msdyn_serviceaccount", TestData19347.patient);

                //Lookupobj.Lookup("mzk_service", TestData19347.service);

                Lookup("mzk_referral", readData.TstManualInvoice_19347Data.mzk_referral, xrmApp, client);

                // Lookupobj.Lookup("mzk_contract", TestData19347.contract);

                //Lookupobj.Lookup("msdyn_servicerequest", TestData19347.Case);

                xrmApp.Entity.Save();
    

                client.Browser.Driver.WaitForPageToLoad();


                xrmApp.Entity.SelectTab("Products And Services");

                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");
                client.Browser.Driver.WaitForPageToLoad();
                LookupQuickCreate("msdyn_product", readData.TstManualInvoice_19347Data.msdyn_product, xrmApp);

                xrmApp.QuickCreate.SetValue("msdyn_quantity", readData.TstManualInvoice_19347Data.msdyn_quantity);
                xrmApp.QuickCreate.Save();
                client.Browser.Driver.WaitForPageToLoad();
                var mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(mzk_visitstatus.StartsWith("Proposed"));
        
            }

        }
        public static void Provider(XrmApp xrmApp, WebClient client)
        {

           WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Healthcare Providers']"))).Click();

            xrmApp.Navigation.OpenSubArea("Customers", "Healthcare Providers");
           // client.Browser.Driver.WaitForPageToLoad();
             wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.CommandBar.ClickCommand("New");
            Address(xrmApp, client);
            xrmApp.Entity.SetValue("name", readData.HealthCareProviderData.name);

            // xrmApp.Entity.SetValue("accountnumber", Healthcareproviderdata.accountnumber);

            xrmApp.Entity.SetValue("telephone1", readData.HealthCareProviderData.telephone1);

            xrmApp.Entity.SetValue("fax", readData.HealthCareProviderData.fax);

            xrmApp.Entity.SetValue("emailaddress1", readData.HealthCareProviderData.emailaddress1);

            //Lookupobj.Lookup("mzk_payer", Healthcareproviderdata.payer);

            xrmApp.Entity.SetValue("mzk_taxidnumber", readData.HealthCareProviderData.mzk_taxidnumber);//optional

            Lookup("mzk_category", readData.HealthCareProviderData.mzk_category, xrmApp, client);

            xrmApp.Entity.SetValue("mzk_hospitalid", readData.HealthCareProviderData.mzk_hospitalid);

            Lookup("mzk_paymentterms", readData.HealthCareProviderData.mzk_paymentterms, xrmApp, client);

            Lookup("mzk_patientlanguage", readData.HealthCareProviderData.mzk_patientlanguage, xrmApp, client);

            DateTime mzk_dateoflastregulatorycheck = DateTime.Today;
            xrmApp.Entity.SetValue("mzk_dateoflastregulatorycheck", mzk_dateoflastregulatorycheck, Configdata.datePattern);
            // Address

            // xrmApp.ThinkTime(5000);

            //Lookupobj.Lookup("primarycontactid", Healthcareproviderdata.primarycontactid);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SelectTab("Details");
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue(new OptionSet { Name = "preferredcontactmethodcode", Value = Healthcareproviderdata.preferdcontactmethod });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotemail", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotbulkemail", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotphone", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotfax", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotpostalmail", Value = false });
            xrmApp.Entity.Save();
            client.Browser.Driver.WaitForPageToLoad();
            if (client.Browser.Driver.HasElement(By.CssSelector("button[data-id='ignore_save']")))
            {
                xrmApp.Dialogs.DuplicateDetection(true);
            }
            else
            {
                Console.WriteLine("Update Duplicate Record");
            }
            client.Browser.Driver.WaitForPageToLoad();
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            Assert.IsTrue(xrmApp.Entity.GetValue("mzk_address1countrycodeiso").StartsWith("GB"));
            Assert.IsTrue(xrmApp.Entity.GetValue("mzk_address2countrycodeiso").StartsWith("GB"));
            client.Browser.Driver.WaitForPageToLoad();
            //Field address1_line1 =  xrmApp.Entity.GetField("address1_line1");
            //Assert.IsTrue(address1_line1.IsRequired);

            //Field address2_line1 =  xrmApp.Entity.GetField("address2_line1");
            //Assert.IsTrue(address2_line1.IsRequired);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SelectTab("Referrers");
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SubGrid.ClickCommand("Health_Care_Provider_Clinicians", "New Healthcare Provider Clinician");
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_prescriber", Healthcareproviderdata.priscriber);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_multiplewards", Healthcareproviderdata.telephone1);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_sites", Healthcareproviderdata.telephone1);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_department", Healthcareproviderdata.telephone1);

        }
        public static void EmployeeOrder(XrmApp xrmApp, WebClient client)
        {


            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));
            client.Browser.Driver.WaitForPageToLoad();

            xrmApp.Navigation.OpenSubArea("Order Management", "Work Orders");
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Grid.SwitchView("All Employee Orders");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));


            xrmApp.CommandBar.ClickCommand("New");


            Lookup("msdyn_workordertype", readData.EmployeeOrderData.msdyn_workordertype, xrmApp, client);

            DateTime mzk_scheduledstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            xrmApp.Entity.SetValue("mzk_scheduledstartdatetime", mzk_scheduledstartdatetime, Configdata.datePattern, Configdata.TimePattern);

            DateTime mzk_scheduledenddatetime = DateTime.Today.AddDays(3).AddHours(10);
            xrmApp.Entity.SetValue("mzk_scheduledenddatetime", mzk_scheduledenddatetime, Configdata.datePattern, Configdata.TimePattern);

            Lookup("mzk_deliverymethods", readData.EmployeeOrderData.mzk_deliverymethods, xrmApp, client);
            xrmApp.Entity.Save();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            client.Browser.Driver.WaitForPageToLoad();
            //string mzk_visitstatus =  xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            //Assert.IsTrue(mzk_visitstatus.StartsWith("Draft"));
            string msdyn_postalcode = xrmApp.Entity.GetValue("msdyn_postalcode");
            Assert.IsNotNull(msdyn_postalcode);
            xrmApp.Entity.SelectTab("Products and Services");
            client.Browser.Driver.WaitForPageToLoad();
            xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");

            LookupQuickCreate("msdyn_product", readData.EmployeeOrderData.msdyn_product, xrmApp);
            // xrmApp.ThinkTime(2000);
            //Lookupobj.LookupQuickCreate("msdyn_unit", EmployeeOrder.unit);
            xrmApp.QuickCreate.SetValue("msdyn_quantity", readData.EmployeeOrderData.msdyn_quantity);

            xrmApp.QuickCreate.Save();
            client.Browser.Driver.WaitForPageToLoad();
        }

        public static void Lookup(string LookupFieldName, string LookupFieldValue, XrmApp xrmApp, WebClient client)
        {
            LookupItem LookupVeriable = new LookupItem { Name = LookupFieldName, Value = LookupFieldValue, Index = 0 };
            xrmApp.Entity.SetValue(LookupVeriable);

        }
        public static void LookupQuickCreate(string LookupFieldName, string LookupFieldValue, XrmApp xrmApp)
        {

            LookupItem LookupQuickVeriable = new LookupItem { Name = LookupFieldName, Value = LookupFieldValue, Index = 0 };
            xrmApp.QuickCreate.SetValue(LookupQuickVeriable);

        }

    }


    public static class Variables
    {
        public static WebClient cli;
        public static string WorkOrderNum;
        public static string mzk_visitstatus3;
       


        public static string casenumber;
        public static string RefNumber;
        public static string WorkOrderNo;
        public static string DeliveryOrderNo;
        public static string NurseOrderNo;
        public static string OrderNum;
        public static string mzk_visitstatus2;
        public static string InvoiceNo;
    }


}