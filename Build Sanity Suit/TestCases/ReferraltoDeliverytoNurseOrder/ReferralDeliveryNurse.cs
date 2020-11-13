using System;
using System.Linq;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class ReferralDeliveryNurse : TestBase
    {
        public WebClient client;
        LOGIN lOGIN = new LOGIN();

        [TestMethod, TestCategory("Sanity")]
        [DoNotParallelize]
        public void A1_CreateReferral()
        {
            var CreateReferral = new Action(() =>
            {

                client = lOGIN.RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                CreateMethod.Referral(xrmApp, client);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")));
                // when support for hidden field is added need to replace this line of code
                Variables.casenumber = client.Browser.Driver.FindElement(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")).Text;
                //Helper.SaveReferral(Variables.casenumber);
                Helper.SaveReferral(Variables.casenumber);
                xrmApp.ThinkTime(2000);
                string mzk_visitstatus = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_status" });
                Assert.IsTrue(mzk_visitstatus.StartsWith("Active"));
                string address1_postalcode = xrmApp.Entity.GetValue("address1_postalcode");
                Assert.IsNotNull(address1_postalcode);
                xrmApp.ThinkTime(3000);
                Variables.RefNumber = xrmApp.Entity.GetHeaderValue("mzk_requestnumber");
                xrmApp.ThinkTime(2000);
                xrmApp.Navigation.OpenSubArea("Referral", "Referrals");
                xrmApp.ThinkTime(2000);
                xrmApp.Grid.Search(Variables.RefNumber);
                xrmApp.ThinkTime(2000);
                xrmApp.Grid.HighLightRecord(0);
                xrmApp.ThinkTime(2000);
                xrmApp.CommandBar.ClickCommand("Assign");
                xrmApp.ThinkTime(2000);
                xrmApp.Dialogs.Assign(Dialogs.AssignTo.Team, "Hah");
                xrmApp.ThinkTime(2000);


            });

            CreateReferral();
        }

        [TestMethod, TestCategory("Sanity")]
        [DoNotParallelize]
        public void A2_CreateDeliveryOrder()
        {
            var CreateDeliveryOrder = new Action(() =>
            {
                client = lOGIN.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                string cases = Helper.ReadReferral();
                Console.WriteLine(cases);
                CreateMethod.DeliveryOrder(xrmApp, client, cases);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));
                xrmApp.CommandBar.ClickCommand("Propose Order");
                xrmApp.ThinkTime(2000);
                Variables.mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(Variables.mzk_visitstatus3.StartsWith("Proposed"));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                Variables.WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");
                xrmApp.ThinkTime(2000);
            });

            CreateDeliveryOrder();
        }

        [TestMethod, TestCategory("Sanity")]
        [DoNotParallelize]
        public void A3_CreateNurseOrder()
        {
            var CreateNurseOrder = new Action(() =>
            {

                client = lOGIN.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);

                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                string cases = Helper.ReadReferral();
                Console.WriteLine(cases);
                CreateMethod.NurseOrder(xrmApp, client, cases);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Complete')]")));
                xrmApp.CommandBar.ClickCommand("Complete");
                xrmApp.ThinkTime(2000);
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
            Cleanup("Ref No:" + Variables.RefNumber + "\r\nCaseNumber:" + Variables.casenumber + "\r\nWorkOrder No:" + Variables.WorkOrderNo + "\r\nWorkOrder Status:" + Variables.mzk_visitstatus3);
            client.Browser.Driver.Close();
        }
    }
}
