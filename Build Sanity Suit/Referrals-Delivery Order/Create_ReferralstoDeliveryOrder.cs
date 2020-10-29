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
    public class A7_Create_ReferralstoDeliveryOrder
    {
        CreateMethod Create = new CreateMethod();

        public static WebClient cli;
        static string casenumber;
        static string RefNumber;
        static string mzk_visitstatus3;
        static string WorkOrderNo;

        [TestMethod, TestCategory("BuildAutomation")]
        public void A7_CreateReferral()
        {
            ReadData readData = Helper.ReadDataFromJSONFile();
            var CreateReferral = new Action(() =>
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));


                Create.Referral(xrmApp, client);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")));
                // when support for hidden field is added need to replace this line of code
                casenumber = client.Browser.Driver.FindElement(By.CssSelector("div[data-id='mzk_case.fieldControl-LookupResultsDropdown_mzk_case_selected_tag_text']")).Text;
                xrmApp.ThinkTime(2000);
                string mzk_visitstatus2 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_status" });
                Assert.IsTrue(mzk_visitstatus2.StartsWith("Active"));
                string address1_postalcode = xrmApp.Entity.GetValue("address1_postalcode");
                Assert.IsNotNull(address1_postalcode);
                xrmApp.ThinkTime(3000);
                RefNumber = xrmApp.Entity.GetHeaderValue("mzk_requestnumber");
                xrmApp.ThinkTime(2000);
                xrmApp.Navigation.OpenSubArea("Referral", "Referrals");
                xrmApp.ThinkTime(2000);
                xrmApp.Grid.Search(RefNumber);
                xrmApp.ThinkTime(2000);
                xrmApp.Grid.HighLightRecord(0);
                xrmApp.ThinkTime(2000);
                xrmApp.CommandBar.ClickCommand("Assign");
                xrmApp.ThinkTime(2000);
                xrmApp.Dialogs.Assign(Dialogs.AssignTo.Team, "Hah");
                xrmApp.ThinkTime(2000);
                cli.Browser.Driver.Close();
            });



            var CreateDeliveryOrder = new Action(() =>
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));


                Create.DeliveryOrder(xrmApp, client, casenumber);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));

                xrmApp.CommandBar.ClickCommand("Propose Order");
                xrmApp.ThinkTime(2000);
                mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                Assert.IsTrue(mzk_visitstatus3.StartsWith("Proposed"));
                //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));

                WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");
                xrmApp.ThinkTime(2000);



            });
            CreateReferral();

            CreateDeliveryOrder();

        }



        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A7_Create_ReferralstoDeliveryOrder\r\n";
            Helper.LogRecord(Message + "Referral Number : " + RefNumber + "\r\nCase Number : " + casenumber + "\r\nWork Order Number : " + WorkOrderNo + "\r\nWork Order Status : " + mzk_visitstatus3);
            //cli.Browser.Driver.Close();
        }
    }
}


