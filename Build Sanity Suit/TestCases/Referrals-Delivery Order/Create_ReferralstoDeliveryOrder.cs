using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{

    [TestClass]
    public class A7_Create_ReferralstoDeliveryOrder:TestBase
    {
        public static WebClient cli;
        [TestMethod, TestCategory("Sanity")]
        public void A7_CreateReferraltoDelivery()
        {
            ReadData readData = Helper.ReadDataFromJSONFile();
            var CreateReferral = new Action(() =>
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.AdminPassword);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                
                CreateMethod.Referral(xrmApp, client);

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
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));

                
                for (int i = 0; i <= 35; i++)
                {
                    CreateMethod.DeliveryOrder(xrmApp, client, "CAS-229726-P9T0");

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));

                    //xrmApp.CommandBar.ClickCommand("Propose Order");
                    //xrmApp.ThinkTime(2000);
                    //Variables.mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                    //Assert.IsTrue(Variables.mzk_visitstatus3.StartsWith("Proposed"));
                    ////wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                    //Variables.WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");
                    //xrmApp.ThinkTime(2000);
                }


            });
            //CreateReferral();

            CreateDeliveryOrder();

        }

        [TestMethod, TestCategory("Sanity")]
        public void A7_CreateReferraltoDelivery2()
        {
            ReadData readData = Helper.ReadDataFromJSONFile();
            var CreateReferral = new Action(() =>
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.AdminPassword);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));

                CreateMethod.Referral(xrmApp, client);

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
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));


                for (int i = 0; i <= 35; i++)
                {
                    CreateMethod.DeliveryOrder(xrmApp, client, "CAS-229726-P9T0");

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));

                    //xrmApp.CommandBar.ClickCommand("Propose Order");
                    //xrmApp.ThinkTime(2000);
                    //Variables.mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                    //Assert.IsTrue(Variables.mzk_visitstatus3.StartsWith("Proposed"));
                    ////wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                    //Variables.WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");
                    //xrmApp.ThinkTime(2000);
                }


            });
            //CreateReferral();

            CreateDeliveryOrder();

        }

        [TestMethod, TestCategory("Sanity")]
        public void A7_CreateReferraltoDelivery3()
        {
            ReadData readData = Helper.ReadDataFromJSONFile();
            var CreateReferral = new Action(() =>
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.AdminPassword);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));

                CreateMethod.Referral(xrmApp, client);

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
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));


                for (int i = 0; i <= 35; i++)
                {
                    CreateMethod.DeliveryOrder(xrmApp, client, "CAS-229726-P9T0");

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));

                    //xrmApp.CommandBar.ClickCommand("Propose Order");
                    //xrmApp.ThinkTime(2000);
                    //Variables.mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                    //Assert.IsTrue(Variables.mzk_visitstatus3.StartsWith("Proposed"));
                    ////wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                    //Variables.WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");
                    //xrmApp.ThinkTime(2000);
                }


            });
            //CreateReferral();

            CreateDeliveryOrder();

        }

        [TestMethod, TestCategory("Sanity")]
        public void A7_CreateReferraltoDelivery4()
        {
            ReadData readData = Helper.ReadDataFromJSONFile();
            var CreateReferral = new Action(() =>
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.AdminPassword);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));

                CreateMethod.Referral(xrmApp, client);

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
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));


                for (int i = 0; i <= 35; i++)
                {
                    CreateMethod.DeliveryOrder(xrmApp, client, "CAS-229726-P9T0");

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));

                    //xrmApp.CommandBar.ClickCommand("Propose Order");
                    //xrmApp.ThinkTime(2000);
                    //Variables.mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                    //Assert.IsTrue(Variables.mzk_visitstatus3.StartsWith("Proposed"));
                    ////wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                    //Variables.WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");
                    //xrmApp.ThinkTime(2000);
                }


            });
            //CreateReferral();

            CreateDeliveryOrder();

        }

        [TestMethod, TestCategory("Sanity")]
        public void A7_CreateReferraltoDelivery5()
        {
            ReadData readData = Helper.ReadDataFromJSONFile();
            var CreateReferral = new Action(() =>
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.AdminPassword);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));

                CreateMethod.Referral(xrmApp, client);

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
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));


                for (int i = 0; i <= 35; i++)
                {
                    CreateMethod.DeliveryOrder(xrmApp, client, "CAS-229726-P9T0");

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Propose Order')]")));

                    //xrmApp.CommandBar.ClickCommand("Propose Order");
                    //xrmApp.ThinkTime(2000);
                    //Variables.mzk_visitstatus3 = xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "mzk_visitstatus" });
                    //Assert.IsTrue(Variables.mzk_visitstatus3.StartsWith("Proposed"));
                    ////wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                    //Variables.WorkOrderNo = xrmApp.Entity.GetValue("msdyn_name");
                    //xrmApp.ThinkTime(2000);
                }


            });
            //CreateReferral();

            CreateDeliveryOrder();

        }
        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Ref No:"+Variables.RefNumber+ "\r\nCaseNumber:" + Variables.casenumber+ "\r\nWorkOrder No:" + Variables.WorkOrderNo + "\r\nWorkOrder Status:" + Variables.mzk_visitstatus3);
           // cli.Browser.Driver.Close();
        }


    }
}


