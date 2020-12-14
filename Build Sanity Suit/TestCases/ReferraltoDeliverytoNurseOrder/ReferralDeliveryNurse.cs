using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Api.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System.IO;

namespace Build_Sanity_Suit
{
   [TestClass]
    public class ReferralDeliveryNurse : TestBase
    {
        public WebClient client=null;

        [TestMethod, TestCategory("Sanity")]
        [DoNotParallelize]
        public void A1_CreateReferral()
        {
            var CreateReferral = new Action(() =>
            {
                client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
                XrmApp xrmApp = new XrmApp(client);

                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(60));
                CreateMethod.Referral(xrmApp, client);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")));
                // when support for hidden field is added need to replace this line of code
                Variables.casenumber = client.Browser.Driver.FindElement(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")).Text;
                Helper.SaveReferral(Variables.casenumber);
                client.Browser.Driver.WaitForPageToLoad();
                string mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_status" });
                Assert.IsTrue(mzk_visitstatus.StartsWith("Active"));
                string address1_postalcode = xrmApp.Entity.GetValue("address1_postalcode");
                Assert.IsNotNull(address1_postalcode);
                client.Browser.Driver.WaitForPageToLoad();
                Variables.RefNumber = xrmApp.Entity.GetHeaderValue("mzk_requestnumber");
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.Navigation.OpenSubArea("Referral", "Referrals");
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.Grid.Search(Variables.RefNumber);
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.Grid.HighLightRecord(0);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Assign')]")));
                xrmApp.CommandBar.ClickCommand("Assign");
                client.Browser.Driver.WaitForPageToLoad();
                xrmApp.Dialogs.Assign(Dialogs.AssignTo.Team, "Hah");

            });

            CreateReferral();
        }

       // [TestMethod, TestCategory("Sanity")]
        [DoNotParallelize]
        public void A2_CreateDeliveryOrder()
        {
            var CreateDeliveryOrder = new Action(() =>
            {
                client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(60));
                string cases = Helper.ReadReferral();
                CreateMethod.DeliveryOrder(xrmApp, client, cases);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));
                xrmApp.CommandBar.ClickCommand("Propose Order");
                client.Browser.Driver.WaitForPageToLoad();
                Variables.mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(Variables.mzk_visitstatus3.StartsWith("Proposed"));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                Variables.WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");


            });

            CreateDeliveryOrder();
        }

        [TestMethod, TestCategory("Sanity")]
        [DoNotParallelize]
        public void A3_CreateNurseOrder()
        {
            var CreateNurseOrder = new Action(() =>
            {

                client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));
                string cases = Helper.ReadReferral();
                CreateMethod.NurseOrder(xrmApp, client, cases);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Complete')]")));
                xrmApp.CommandBar.ClickCommand("Complete");
                client.Browser.Driver.WaitForPageToLoad();
                Variables.mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(Variables.mzk_visitstatus3.StartsWith("Completed"));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                Variables.WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");
            });
            CreateNurseOrder();
        }





        [TestCleanup]
        public void Teardown()
        {
            Screenshot ss = ((ITakesScreenshot)client.Browser.Driver).GetScreenshot();
            string path = Directory.GetCurrentDirectory() + TestContext.TestName + ".png";
            ss.SaveAsFile(path);
            this.TestContext.AddResultFile(path);
            Cleanup("Ref No:" + Variables.RefNumber + "\r\nCaseNumber:" + Variables.casenumber + "\r\nWorkOrder No:" + Variables.WorkOrderNo + "\r\nWorkOrder Status:" + Variables.mzk_visitstatus3);
            client.Browser.Driver.Close();
        }
    }
}
