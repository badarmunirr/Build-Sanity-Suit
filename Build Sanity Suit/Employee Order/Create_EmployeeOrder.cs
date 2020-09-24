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
        static string WorkOrderNum;
        static string mzk_visitstatus3;
        public static WebClient cli;
        ReadData readData = Helper.ReadDataFromJSONFile();
        [TestMethod, TestCategory("BuildAutomation")]
        public void B12_CreateResourceToAccountToEmployeeOrder()
        {
            LOGIN loginobj = new LOGIN();
            //operational manager
            WebClient client = loginobj.RoleBasedLogin(usersetting.Admin, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();

            xrmApp.ThinkTime(4000);

            xrmApp.Navigation.OpenSubArea("Order Management", "Work Orders");
            xrmApp.ThinkTime(4000);
            xrmApp.Grid.SwitchView("All Employee Orders");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));


            xrmApp.CommandBar.ClickCommand("New");


            Lookupobj.Lookup("msdyn_workordertype", readData.EmployeeOrderData.msdyn_workordertype, xrmApp);

            DateTime mzk_scheduledstartdatetime = DateTime.Today.AddDays(1).AddHours(10);
            xrmApp.Entity.SetValue("mzk_scheduledstartdatetime", mzk_scheduledstartdatetime, "dd/MM/yyyy", "hh:mm");

            DateTime mzk_scheduledenddatetime = DateTime.Today.AddDays(3).AddHours(10);
            xrmApp.Entity.SetValue("mzk_scheduledenddatetime", mzk_scheduledenddatetime, "dd/MM/yyyy", "hh:mm");

            Lookupobj.Lookup("mzk_deliverymethods", readData.EmployeeOrderData.mzk_deliverymethods, xrmApp);


            xrmApp.ThinkTime(3000);
            xrmApp.Entity.Save();

            xrmApp.ThinkTime(3000);
            //string mzk_visitstatus =  xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            //Assert.IsTrue(mzk_visitstatus.StartsWith("Draft"));
            string msdyn_postalcode = xrmApp.Entity.GetValue("msdyn_postalcode");
            Assert.IsNotNull(msdyn_postalcode);
            xrmApp.ThinkTime(5000);
            xrmApp.Entity.SelectTab("Products and Services");
            xrmApp.ThinkTime(4000);
            xrmApp.Entity.SubGrid.ClickCommand("workorderproductsgrid", "New Work Order Product");

            Lookupobj.LookupQuickCreate("msdyn_product", readData.EmployeeOrderData.msdyn_product, xrmApp);
            // xrmApp.ThinkTime(2000);
            //Lookupobj.LookupQuickCreate("msdyn_unit", EmployeeOrder.unit);

            xrmApp.QuickCreate.SetValue("msdyn_quantity", readData.EmployeeOrderData.msdyn_quantity);
            xrmApp.ThinkTime(2000);
            xrmApp.QuickCreate.Save();


            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));
            xrmApp.CommandBar.ClickCommand("Propose Order");
            xrmApp.ThinkTime(2000);
            mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
            Assert.IsTrue(mzk_visitstatus3.StartsWith("Proposed"));

            WorkOrderNum = xrmApp.Entity.GetHeaderValue("msdyn_name");
        }
        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - B12_Create_EmployeeOrder\r\n";
            Helper.LogRecord(Message + "Employee Order Number : " + WorkOrderNum +"\r\nWork Order Status : "+ mzk_visitstatus3);
            cli.Browser.Driver.Close();
        }
    }
}


