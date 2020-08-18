using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class Create_WholesaleOrders
    {
        [TestMethod, TestCategory("BuildAutomation")]

        public void CreateWholesaleOrder()
        {
            WebDriverWait wait = new WebDriverWait(global.client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();
            //LOGIN loginobj = new LOGIN();
            //loginobj.Login();
            global.xrmApp.ThinkTime(4000);
            global.xrmApp.Navigation.OpenSubArea("Referral", "Wholesale Orders");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.CommandBar.ClickCommand("New");
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.Entity.SelectForm("Wholesale Order");
            global.xrmApp.ThinkTime(5000);
            if (global.client.Browser.Driver.HasElement(By.XPath("//button[contains(@data-id,'cancelButton')]")))
            {
                global.client.Browser.Driver.FindElement(By.XPath("//button[contains(@data-id,'cancelButton')]")).Click();
            }
            else
            {
                Console.WriteLine("Element not found");
            }
            global.xrmApp.ThinkTime(1000);
            Lookupobj.Lookup("mzk_contract", Wholesaleorderdata.contractname);
            global.xrmApp.ThinkTime(1000);
            Lookupobj.Lookup("msdyn_workordertype", Wholesaleorderdata.wholesaleordertype);
            global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_prescriptionponumber", Wholesaleorderdata.prescriptionponumber);
            ////global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_distributioncenter", "Khi");
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_region", "Khi");
            global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.SetValue("mzk_district", Wholesaleorderdata.district);
            global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_emergencyorder", Value = false });
            //Visit Date and Time Information
            global.xrmApp.ThinkTime(1000);
            DateTime mzk_proposedvisitdatetime = DateTime.Today.AddDays(1).AddHours(12);
            global.xrmApp.Entity.SetValue("mzk_proposedvisitdatetime", mzk_proposedvisitdatetime, "dd/MM/yyyy", "hh:mm");
            global.xrmApp.ThinkTime(1000);
            DateTime mzk_proposedvisitenddatetime = DateTime.Today.AddDays(1).AddHours(12); 
            global.xrmApp.Entity.SetValue("mzk_proposedvisitenddatetime", mzk_proposedvisitenddatetime, "dd/MM/yyyy", "hh:mm");
            global.xrmApp.ThinkTime(1000);
            DateTime mzk_scheduledstartdatetime = DateTime.Today.AddDays(1).AddHours(12); 
            global.xrmApp.Entity.SetValue("mzk_scheduledstartdatetime", mzk_scheduledstartdatetime, "dd/MM/yyyy", "hh:mm");
            global.xrmApp.ThinkTime(1000);
            DateTime mzk_scheduledenddatetime = DateTime.Today.AddDays(1).AddHours(12); 
            global.xrmApp.Entity.SetValue("mzk_scheduledenddatetime", mzk_scheduledenddatetime, "dd/MM/yyyy", "hh:mm");
            //Visit Reasons
            global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_emergencyreasons", "mzk_emergencyreasons");
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_failurevisitsubreason", "mzk_failurevisitsubreason");
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_outofslareason", "mzk_outofslareason");
            //Cancellation Information
            //global.xrmApp.ThinkTime(1000);
            ////Lookupobj.Lookup("mzk_cancelreason", "mzk_cancelreason");
            //global.xrmApp.ThinkTime(1000);
            //DateTime mzk_cancellationdatetime = DateTime.Today.AddDays(1).AddHours(10);
            //global.xrmApp.Entity.SetValue("mzk_cancellationdatetime", mzk_cancellationdatetime);
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_cancelledby", "Alex");
            //Delivery Information
            global.xrmApp.ThinkTime(1000);
            Lookupobj.Lookup("mzk_contractdeliveryfrequency", Wholesaleorderdata.deliveryfrequency);
            global.xrmApp.ThinkTime(1000);
            Lookupobj.Lookup("mzk_deliverymethods", Wholesaleorderdata.deliverymethods);
            global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_deliveryroute", Wholesaleorderdata.deliveryroute);
            global.xrmApp.ThinkTime(2000);
            //global.xrmApp.Entity.SetValue("mzk_drivername", Wholesaleorderdata.drivername);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_vanid", Wholesaleorderdata.vanid);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_visitnotes", Wholesaleorderdata.visitnotes);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_drivercomments", Wholesaleorderdata.drivercomments);
            //global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.Save();
            global.xrmApp.ThinkTime(2000);
            var mzk_visitstatus = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });//msdyn_servicerequest
            Assert.IsTrue(mzk_visitstatus.StartsWith("Draft"));
            global.xrmApp.ThinkTime(2000);
            string casenumber = global.client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'msdyn_servicerequest.fieldControl-LookupResultsDropdown_msdyn_servicerequest_selected_tag')]")).Text;
            Assert.IsFalse(casenumber.IsEmptyValue());
            //Products And Services
            global.xrmApp.ThinkTime(3000);
            global.xrmApp.Entity.SelectTab("Products And Services");
            global.xrmApp.ThinkTime(3000);
            global.xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");
            global.xrmApp.ThinkTime(2000);
            Lookupobj.LookupQuickCreate("msdyn_product", Wholesaleorderdata.productname);
            //global.xrmApp.ThinkTime(2000);
            //Lookupobj.LookupQuickCreate("msdyn_unit", Wholesaleorderdata.unit);
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.QuickCreate.SetValue("msdyn_quantity", Wholesaleorderdata.qunantity);
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.QuickCreate.Save();
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.CommandBar.ClickCommand("Save & Close");
            //Service
            //global.xrmApp.ThinkTime(5000);
            //global.xrmApp.Entity.SubGrid.ClickCommand("workorderservicesgrid", "New Work Order Service");
            //global.xrmApp.ThinkTime(3000);
            //Lookupobj.Lookup("msdyn_service", Wholesaleorderdata.servicename);
            //global.xrmApp.ThinkTime(5000);
            //global.xrmApp.CommandBar.ClickCommand("Save & Close");
            //global.xrmApp.ThinkTime(5000);
            global.xrmApp.ThinkTime(5000);
            if (global.client.Browser.Driver.HasElement(By.CssSelector("button[data-id='ignore_save']")))
            {
                global.client.Browser.Driver.FindElement(By.CssSelector("button[data-id='ignore_save']")).SendKeys(Keys.Enter);
            }
            else
            {
                Console.WriteLine("Update Duplicate Record");
            }
            global.xrmApp.ThinkTime(1000);
        }

    }
}

