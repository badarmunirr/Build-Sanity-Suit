using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;


namespace Build_Sanity_Suit
{
    [TestClass]
    public class B11_Create_Resource
    {
        //meed to update user everytime
        [TestMethod, TestCategory("BuildAutomation")]

        public void B11_CreateResourceToAccountTypeEmployee()
        {
            WebDriverWait wait = new WebDriverWait(global.client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();
            LOGIN loginobj = new LOGIN();
            loginobj.Login();
            global.xrmApp.ThinkTime(4000);
            global.xrmApp.Navigation.OpenArea("Settings");
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.Navigation.OpenSubArea("Others", "Resources");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.CommandBar.ClickCommand("New");

            global.xrmApp.Entity.SetValue(new OptionSet { Name = "resourcetype", Value = "User" });

            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_resourcesubtype", Value = "Nurse" });

            Lookupobj.Lookup("userid", "testuser6-d365@hah.co.uk"); //need to update this everytime

            Lookupobj.Lookup("mzk_gendervalue", "Male");

            Lookupobj.Lookup("mzk_language", "en-GB");

            global.xrmApp.Entity.Save();

            Field gender = global.xrmApp.Entity.GetField("mzk_gendervalue");
            string gendervalue = global.xrmApp.Entity.GetValue("mzk_gendervalue");
            Assert.IsTrue(gender.IsRequired);
            Assert.IsNotNull(gendervalue);

            Field language = global.xrmApp.Entity.GetField("mzk_language");
            string languagevalue = global.xrmApp.Entity.GetValue("mzk_language");
            Assert.IsTrue(language.IsRequired);
            Assert.IsNotNull(languagevalue);
            if (global.client.Browser.Driver.HasElement(By.XPath("//span[contains(@title,'Convert into Contact')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(@title,'Convert into Contact')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//span[contains(@title,'Convert into Contact')]")).Click();

            }
            else
            {
                Console.WriteLine("No Element found");
            }

            Random random = new Random();
            int randomnumber = random.Next(01111, 09999);
            string payrollnumber = "EMP_" + randomnumber.ToString();
            global.xrmApp.Entity.SetValue("mzk_payrollnumberemployeeref", payrollnumber);
            global.xrmApp.Entity.Save();
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Navigation.OpenArea("MazikCare Referral Management");
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Navigation.OpenSubArea("Customers", "Accounts");

            string UserName = Variables.user;
            string UserNameTrim = UserName.Remove(9);

            global.xrmApp.Grid.Search(UserNameTrim);
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Grid.OpenRecord(0);

            string accountnumber = global.xrmApp.Entity.GetValue("accountnumber");
            Assert.IsTrue(accountnumber.StartsWith(payrollnumber));






            //Lookupobj.Lookup("msdyn_workordertype", Wholesaleorderdata.wholesaleordertype);

            //
            ////global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_distributioncenter", "Khi");
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_region", "Khi");
      
            //global.xrmApp.Entity.SetValue("mzk_district", Wholesaleorderdata.district);
   
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_emergencyorder", Value = false });
            //Visit Date and Time Information
 
            DateTime mzk_proposedvisitdatetime = DateTime.Today.AddDays(1).AddHours(12);
            global.xrmApp.Entity.SetValue("mzk_proposedvisitdatetime", mzk_proposedvisitdatetime, "dd/MM/yyyy", "hh:mm");

            DateTime mzk_proposedvisitenddatetime = DateTime.Today.AddDays(1).AddHours(12);
            global.xrmApp.Entity.SetValue("mzk_proposedvisitenddatetime", mzk_proposedvisitenddatetime, "dd/MM/yyyy", "hh:mm");
            DateTime mzk_scheduledstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            global.xrmApp.Entity.SetValue("mzk_scheduledstartdatetime", mzk_scheduledstartdatetime, "dd/MM/yyyy", "hh:mm");

            DateTime mzk_scheduledenddatetime = DateTime.Today.AddDays(2).AddHours(12);
            global.xrmApp.Entity.SetValue("mzk_scheduledenddatetime", mzk_scheduledenddatetime, "dd/MM/yyyy", "hh:mm");
            //Visit Reasons
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_emergencyreasons", "mzk_emergencyreasons");

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
    
            Lookupobj.Lookup("mzk_contractdeliveryfrequency", Wholesaleorderdata.deliveryfrequency);
       
            Lookupobj.Lookup("mzk_deliverymethods", Wholesaleorderdata.deliverymethods);
         
            //Lookupobj.Lookup("mzk_deliveryroute", Wholesaleorderdata.deliveryroute);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_drivername", Wholesaleorderdata.drivername);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_vanid", Wholesaleorderdata.vanid);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_visitnotes", Wholesaleorderdata.visitnotes);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_drivercomments", Wholesaleorderdata.drivercomments);
            //global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.Save();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.ThinkTime(1000);
            var mzk_visitstatus = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });//msdyn_servicerequest
            Assert.IsTrue(mzk_visitstatus.StartsWith("Draft"));
            global.xrmApp.ThinkTime(2000);
            string casenumber = global.client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'msdyn_servicerequest.fieldControl-LookupResultsDropdown_msdyn_servicerequest_selected_tag')]")).Text;
            Assert.IsNotNull(casenumber);
            string msdyn_postalcode = global.xrmApp.Entity.GetValue("msdyn_postalcode");
            Assert.IsNotNull(msdyn_postalcode);
            //Products And Services
            global.xrmApp.ThinkTime(3000);
            global.xrmApp.Entity.SelectTab("Products And Services");
            global.xrmApp.ThinkTime(3000);
            global.xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");
   
            Lookupobj.LookupQuickCreate("msdyn_product", Wholesaleorderdata.productname);
            //global.xrmApp.ThinkTime(2000);
            //Lookupobj.LookupQuickCreate("msdyn_unit", Wholesaleorderdata.unit);
            //global.xrmApp.ThinkTime(1000);
            global.xrmApp.QuickCreate.SetValue("msdyn_quantity", Wholesaleorderdata.qunantity);

            global.xrmApp.QuickCreate.Save();
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.CommandBar.ClickCommand("Propose Order");
            global.xrmApp.ThinkTime(2000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            var mzk_visitstatus2 = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus2.StartsWith("Proposed"));
            global.xrmApp.ThinkTime(1000);
            global.xrmApp.CommandBar.ClickCommand("Save & Close");
            //Service
            //global.xrmApp.ThinkTime(5000);
            //global.xrmApp.Entity.SubGrid.ClickCommand("workorderservicesgrid", "New Work Order Service");
            //global.xrmApp.ThinkTime(3000);
            //Lookupobj.Lookup("msdyn_service", Wholesaleorderdata.servicename);
            //global.xrmApp.ThinkTime(5000);
            //global.xrmApp.CommandBar.ClickCommand("Save & Close");
            //global.xrmApp.ThinkTime(5000);
            //if (global.client.Browser.Driver.HasElement(By.CssSelector("button[data-id='ignore_save']")))
            //{
            //    global.client.Browser.Driver.FindElement(By.CssSelector("button[data-id='ignore_save']")).SendKeys(Keys.Enter);
            //}
            //else
            //{
            //    Console.WriteLine("Update Duplicate Record");
            //}
            //global.xrmApp.ThinkTime(1000);
        }
        [TestCleanup]
        public void teardown()
        {
            //global.xrmApp.Navigation.SignOut();
            ////global.client.Browser.Driver.Quit();
        }

    }
}

