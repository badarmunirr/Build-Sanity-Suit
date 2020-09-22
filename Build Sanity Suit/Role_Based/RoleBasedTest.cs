using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;
using Xceed.Wpf.Toolkit;
using System.Diagnostics;

namespace Build_Sanity_Suit
{
    
    [TestClass]
    public class RoleBasedTest
    {


        public static WebClient cli;
        static string contractnumber;

        [TestMethod, TestCategory("BuildAutomation")]
        public void TryRole1()
        {

            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.Admin, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();


            //xrmApp.Navigation.OpenSubArea("Referral", "Contract Management");
            //xrmApp.ThinkTime(2000);
            //xrmApp.CommandBar.ClickCommand("New");
            //xrmApp.ThinkTime(2000);

            //xrmApp.Entity.SelectTab("General");
            //xrmApp.ThinkTime(5000);
            //xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contracttypevalue", Value = "Service Agreement" });
            //xrmApp.ThinkTime(5000);
            //xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contractstatus", Value = "Live" });
            //xrmApp.ThinkTime(5000);
            //xrmApp.Entity.SetValue("mzk_name", ServiceAgreementData.name);
            //xrmApp.ThinkTime(500);
            //Lookupobj.Lookup("mzk_payer", ServiceAgreementData.payer, xrmApp);
            //xrmApp.ThinkTime(500);
            //Lookupobj.Lookup("mzk_provider", ServiceAgreementData.provider, xrmApp);
            //xrmApp.ThinkTime(500);
            //Lookupobj.Lookup("mzk_mastercontractagreement", ServiceAgreementData.mastercontractagreement, xrmApp);
            //xrmApp.ThinkTime(500);
            //Lookupobj.Lookup("mzk_subcontract", ServiceAgreementData.subcontract, xrmApp);
            //xrmApp.ThinkTime(500);
            //Lookupobj.Lookup("mzk_service", ServiceAgreementData.service, xrmApp);
            //xrmApp.ThinkTime(500);
            //Lookupobj.Lookup("mzk_contractsubtype", ServiceAgreementData.contractsubtype, xrmApp);
            //// xrmApp.ThinkTime(2000);
            //// xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_pediatric", Value = "No" });
            //// xrmApp.ThinkTime(2000);
            //// xrmApp.Entity.SetValue("mzk_keycontractinformation", "mzk_keycontractinformation");
            //DateTime startdate = DateTime.Today.AddDays(1);
            //xrmApp.Entity.SetValue("mzk_startdate", startdate, "dd/MM/yyyy");
            //DateTime enddate = startdate.AddDays(2);
            //xrmApp.Entity.SetValue("mzk_enddate", enddate, "dd/MM/yyyy");
            //DateTime issuedate = DateTime.Today.AddDays(1);
            //xrmApp.Entity.SetValue("mzk_issuedate", issuedate, "dd/MM/yyyy");
            ////DateTime reviewdate = DateTime.Today.AddDays(1);
            //// xrmApp.Entity.SetValue("mzk_reviewdate", reviewdate);
            //xrmApp.ThinkTime(2000);
            //xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_inherit", Value = "Yes" });
            //// xrmApp.Entity.SetValue("mzk_description", "mzk_description");
            //// xrmApp.Entity.SetValue("mzk_contractspecialinstructions", "mzk_contractspecialinstructions");
            //// xrmApp.Entity.SetValue("mzk_frameworkreference", "mzk_frameworkreference");
            //xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_wholesalecontract", Value = ServiceAgreementData.WholeSale });
            //xrmApp.Entity.Save();
            //xrmApp.ThinkTime(1000);
            //xrmApp.Dialogs.ConfirmationDialog(true);
            //xrmApp.ThinkTime(5000);


            contractnumber = xrmApp.Entity.GetHeaderValue("mzk_contractid");

            //Debug.WriteLine("First Value", contractnumber);
        }
        [TestMethod, TestCategory("BuildAutomation")]

        public void TryRole2()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.Admin, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();

            string referralContract = contractnumber;
            //Debug.WriteLine("Second Value", referralContract);

            //xrmApp.ThinkTime(4000);
            //xrmApp.Navigation.OpenSubArea("Referral", "Referrals");
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            //xrmApp.CommandBar.ClickCommand("New");

            //Lookupobj.Lookup("parentcontactid", ReferraltodeliviryOrderdata.PatientName, xrmApp);

            //xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_patientconsent", Value = true });

            //xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_patientswitchstatus", Value = ReferraltodeliviryOrderdata.patientswitchstatus });

            //xrmApp.Entity.SetValue("mzk_anonymousreference", ReferraltodeliviryOrderdata.anonymousreference);

            //xrmApp.Entity.SetValue("mzk_hospitalreferencenumber", ReferraltodeliviryOrderdata.hospitalreferencenumber);
            //xrmApp.ThinkTime(1000);
            //xrmApp.Entity.SelectTab("General");


            //xrmApp.Entity.SetValue("name", ReferraltodeliviryOrderdata.ReferalName);

            //Lookupobj.Lookup("mzk_contract", referralContract, xrmApp);


        }




        [TestCleanup]
        public void Teardown()
        {
            cli.Browser.Driver.Close();
        }
    }
}


