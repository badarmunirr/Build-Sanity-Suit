using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class B10_Create_WholesaleOrders
    {
        public static WebClient cli;
        static string OrderNum;
        static string mzk_visitstatus2;

        [TestMethod, TestCategory("BuildAutomation")]
        public void B10_CreateWholesaleOrder()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.OperationalManager, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();


            ReadData readData = Helper.ReadDataFromJSONFile();
            xrmApp.ThinkTime(4000);
            xrmApp.Navigation.OpenSubArea("Referral", "Wholesale Orders");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.CommandBar.ClickCommand("New");
            // xrmApp.ThinkTime(2000);
            // xrmApp.Entity.SelectForm("Wholesale Order");
            // xrmApp.ThinkTime(1000);
            if (client.Browser.Driver.HasElement(By.XPath("//button[contains(@data-id,'cancelButton')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@data-id,'cancelButton')]")));
                client.Browser.Driver.FindElement(By.XPath("//button[contains(@data-id,'cancelButton')]")).Click();
            }
            else
            {
                Console.WriteLine("Element not found");
            }

            Lookupobj.Lookup("mzk_contract", readData.WholesaleOrderData.mzk_contract, xrmApp);

            Lookupobj.Lookup("msdyn_workordertype", readData.WholesaleOrderData.msdyn_workordertype, xrmApp);

            // xrmApp.Entity.SetValue("mzk_prescriptionponumber", Wholesaleorderdata.prescriptionponumber);
            //// xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_distributioncenter", "Khi");
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_region", "Khi");

            // xrmApp.Entity.SetValue("mzk_district", Wholesaleorderdata.district);

            // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_emergencyorder", Value = false });
            //Visit Date and Time Information
            xrmApp.ThinkTime(3000);
            //DateTime mzk_proposedvisitdatetime = DateTime.Today.AddDays(1).AddHours(12);
            // xrmApp.Entity.SetValue("mzk_proposedvisitdatetime", mzk_proposedvisitdatetime, "dd/MM/yyyy", "hh:mm");

            //DateTime mzk_proposedvisitenddatetime = DateTime.Today.AddDays(1).AddHours(12);
            // xrmApp.Entity.SetValue("mzk_proposedvisitenddatetime", mzk_proposedvisitenddatetime, "dd/MM/yyyy", "hh:mm");
            DateTime mzk_scheduledstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            xrmApp.Entity.SetValue("mzk_scheduledstartdatetime", mzk_scheduledstartdatetime, "dd/MM/yyyy", "hh:mm");

            DateTime mzk_scheduledenddatetime = DateTime.Today.AddDays(3).AddHours(12);
            xrmApp.Entity.SetValue("mzk_scheduledenddatetime", mzk_scheduledenddatetime, "dd/MM/yyyy", "hh:mm");
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
            xrmApp.ThinkTime(5000);
            Lookupobj.Lookup("mzk_deliverymethods", readData.WholesaleOrderData.mzk_deliverymethods, xrmApp);

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
            xrmApp.Entity.Save();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.ThinkTime(1000);
            string mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });//msdyn_servicerequest
            Assert.IsTrue(mzk_visitstatus.StartsWith("Draft"));
            OrderNum = xrmApp.Entity.GetHeaderValue("msdyn_name");
            xrmApp.ThinkTime(2000);
            string casenumber = client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'msdyn_servicerequest.fieldControl-LookupResultsDropdown_msdyn_servicerequest_selected_tag')]")).Text;
            Assert.IsNotNull(casenumber);
            string msdyn_postalcode = xrmApp.Entity.GetValue("msdyn_postalcode");
            Assert.IsNotNull(msdyn_postalcode);
            //Products And Services
            xrmApp.ThinkTime(3000);
            xrmApp.Entity.SelectTab("Products And Services");
            xrmApp.ThinkTime(3000);
            xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");

            Lookupobj.LookupQuickCreate("msdyn_product", readData.WholesaleOrderData.msdyn_product, xrmApp);
            // xrmApp.ThinkTime(2000);
            //Lookupobj.LookupQuickCreate("msdyn_unit", Wholesaleorderdata.unit);
            // xrmApp.ThinkTime(1000);
            xrmApp.QuickCreate.SetValue("msdyn_quantity", readData.WholesaleOrderData.msdyn_quantity);
            xrmApp.QuickCreate.SetValue("msdyn_description", readData.WholesaleOrderData.msdyn_description);
            xrmApp.QuickCreate.SetValue("msdyn_internaldescription", readData.WholesaleOrderData.msdyn_internaldescription);
            xrmApp.QuickCreate.Save();
            xrmApp.ThinkTime(2000);
            xrmApp.CommandBar.ClickCommand("Propose Order");
            xrmApp.ThinkTime(2000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus2.StartsWith("Proposed"));
            xrmApp.ThinkTime(1000);
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

        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - B10_Create_WholesaleOrders\r\n";
            LogHelper.LogRecord(Message + "WholeSale Order Number - " + OrderNum + " \r\nWholeSale Order Status - " + mzk_visitstatus2);

            cli.Browser.Driver.Close();

        }

    }
}

