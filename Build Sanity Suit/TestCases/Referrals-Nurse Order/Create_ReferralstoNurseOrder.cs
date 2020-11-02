using System;
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
    public class A8_Create_ReferralstoNurseOrder
    {

        [TestMethod, TestCategory("BuildAutomation")]
        public void A8_CreateReferralNurse()
        {

            ReadData readData = Helper.ReadDataFromJSONFile();
            //CreateMethod Create = new CreateMethod();

            var CreateReferral = new Action(() =>
            {
                WebClient client = DriverInitiazation.ClientndXrmAppInitialization();
                Variables.cli = client;
                XrmApp xrmApp = new XrmApp(client);

                LOGIN.RoleBasedLogin(xrmApp, client, Usersetting.Admin, Usersetting.pwd);

                 WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));

                CreateMethod.Referral(xrmApp, client);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")));
                // when support for hidden field is added need to replace this line of code
                Variables.casenumber = client.Browser.Driver.FindElement(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")).Text;
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
                Variables.cli.Browser.Driver.Quit();

            });

            var CreateNurseOrder = new Action(() =>
            {
                WebClient client = DriverInitiazation.ClientndXrmAppInitialization();
                Variables.cli = client;
                XrmApp xrmApp = new XrmApp(client);

                LOGIN.RoleBasedLogin(xrmApp, client, Usersetting.OperationalManager, Usersetting.pwd);

               WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                CreateMethod.NurseOrder(xrmApp, client, Variables.casenumber);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Complete')]")));
                xrmApp.CommandBar.ClickCommand("Complete");
                xrmApp.ThinkTime(2000);
                Variables.mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(Variables.mzk_visitstatus3.StartsWith("Completed"));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                Variables.WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");
            });

            CreateReferral();
            CreateNurseOrder();
        }
        
        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A8_Create_ReferralstoNurseOrder\r\n";
            Helper.LogRecord(Message + "Referral Number : " + Variables.RefNumber + "\r\nCase Number : " + Variables.casenumber + "\r\nWork Order Number : " + Variables.WorkOrderNo + "\r\nWork Order Status : " + Variables.mzk_visitstatus3);
            Variables.cli.Browser.Driver.Close();
        }
    }

}



