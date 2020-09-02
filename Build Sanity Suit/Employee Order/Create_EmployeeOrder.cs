using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class B12_Create_EmployeeOrder
    {
        [TestMethod, TestCategory("BuildAutomation")]

        public void B12_CreateResourceToAccountToEmployeeOrder()
        {
            WebDriverWait wait = new WebDriverWait(global.client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();
            LOGIN loginobj = new LOGIN();
            loginobj.Login();
            global.xrmApp.ThinkTime(4000);
            global.xrmApp.Navigation.OpenSubArea("Order Management", "Work Orders");
            global.xrmApp.Grid.SwitchView("All Employee Orders");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));


            global.xrmApp.CommandBar.ClickCommand("New");

            
            Lookupobj.Lookup("msdyn_workordertype", EmployeeOrder.workordertype);
           
            DateTime mzk_scheduledstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            global.xrmApp.Entity.SetValue("mzk_scheduledstartdatetime", mzk_scheduledstartdatetime, "dd/MM/yyyy", "hh:mm");
            
            DateTime mzk_scheduledenddatetime = DateTime.Today.AddDays(3).AddHours(10);
            global.xrmApp.Entity.SetValue("mzk_scheduledenddatetime", mzk_scheduledenddatetime, "dd/MM/yyyy", "hh:mm");
            
            Lookupobj.Lookup("mzk_deliverymethods", EmployeeOrder.deliverymethods);


            global.xrmApp.ThinkTime(3000);
            global.xrmApp.Entity.Save();

            global.xrmApp.ThinkTime(3000);
            //string mzk_visitstatus = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            //Assert.IsTrue(mzk_visitstatus.StartsWith("Draft"));
            string msdyn_postalcode = global.xrmApp.Entity.GetValue("msdyn_postalcode");
            Assert.IsNotNull(msdyn_postalcode);
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Entity.SelectTab("Products and Services");
            global.xrmApp.ThinkTime(4000);
            global.xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");

            Lookupobj.LookupQuickCreate("msdyn_product", EmployeeOrder.productname);
            //global.xrmApp.ThinkTime(2000);
            //Lookupobj.LookupQuickCreate("msdyn_unit", EmployeeOrder.unit);

            global.xrmApp.QuickCreate.SetValue("msdyn_quantity", EmployeeOrder.qunantity);
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.QuickCreate.Save();


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));
            global.xrmApp.CommandBar.ClickCommand("Propose Order");
            global.xrmApp.ThinkTime(2000);
            string mzk_visitstatus3 = global.xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus3.StartsWith("Proposed"));
              

        }
        [TestCleanup]
        public void teardown()
        {
            //global.xrmApp.Navigation.SignOut();
            ////global.client.Browser.Driver.Quit();
        }
    }
}


