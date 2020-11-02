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
  
            var CreateReferral = new Action(() =>
            {
                WebClient client = DriverInitiazation.ClientndXrmAppInitialization();
                Variables.cli = client;
                XrmApp xrmApp = new XrmApp(client);

                LOGIN.RoleBasedLogin(xrmApp, client, Usersetting.Admin, Usersetting.pwd);


                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                
                HelperFunctions.Referral(xrmApp, client);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")));
                // when support for hidden field is added need to replace this line of code
                Variables.casenumber = client.Browser.Driver.FindElement(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")).Text;
                xrmApp.ThinkTime(2000);
                string mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_status" });
                Assert.IsTrue(mzk_visitstatus2.StartsWith("Active"));
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
                Variables.cli.Browser.Driver.Close();
            });

            var CreateDeliveryOrder = new Action(() =>
            {
                WebClient client = DriverInitiazation.ClientndXrmAppInitialization();
                Variables.cli = client;
                XrmApp xrmApp = new XrmApp(client);

                LOGIN.RoleBasedLogin(xrmApp, client, Usersetting.OperationalManager, Usersetting.pwd);

                
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));

                HelperFunctions.DeliveryOrder(xrmApp, client, Variables.casenumber);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));

                xrmApp.CommandBar.ClickCommand("Propose Order");
                xrmApp.ThinkTime(2000);
                Variables.mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(Variables.mzk_visitstatus3.StartsWith("Proposed"));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                Variables.WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");
                xrmApp.ThinkTime(2000);


            });
            CreateReferral();

            CreateDeliveryOrder();

        }



        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A7_Create_ReferralstoDeliveryOrder\r\n";
            HelperFunctions.LogRecord(Message + "Referral Number : " + Variables.RefNumber + "\r\nCase Number : " + Variables.casenumber + "\r\nWork Order Number : " + Variables.WorkOrderNo + "\r\nWork Order Status : " + Variables.mzk_visitstatus3);
            Variables.cli.Browser.Driver.Close();
        }
    }
}


