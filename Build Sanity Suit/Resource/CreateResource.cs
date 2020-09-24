﻿using System;
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
        public static WebClient cli;

        //meed to update user everytime
        [TestMethod, TestCategory("BuildAutomation")]
        public void B11_CreateResourceToAccountTypeEmployee()
        {
            ReadData readData = Helper.ReadDataFromJSONFile();
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.Admin, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();


            string UserName = readData.ResourceData.userid;
            string UserNameTrim = UserName.Remove(9);
            xrmApp.ThinkTime(4000);
            xrmApp.Navigation.OpenSubArea("Others", "Bookable Resources");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.Entity.SetValue(new OptionSet { Name = "resourcetype", Value = readData.ResourceData.resourcetype });

            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_resourcesubtype", Value = readData.ResourceData.mzk_resourcesubtype });

            Lookupobj.Lookup("userid", readData.ResourceData.userid, xrmApp); //need to update this everytime

            Lookupobj.Lookup("mzk_gendervalue", readData.ResourceData.mzk_gendervalue, xrmApp);

            //    Lookupobj.Lookup("mzk_language", ResourceToPatData.language, xrmApp);

            xrmApp.ThinkTime(1000);
            xrmApp.Entity.SetValue("mzk_address1name", readData.ResourceData.mzk_address1name);
            xrmApp.ThinkTime(1000);
            xrmApp.Entity.SetValue("mzk_address1line1", readData.ResourceData.mzk_address1line1);

            xrmApp.ThinkTime(1000);
            xrmApp.Entity.SetValue("mzk_city1", readData.ResourceData.mzk_city1);

            xrmApp.ThinkTime(1000);
            xrmApp.Entity.SetValue("mzk_postalcode1", readData.ResourceData.mzk_postalcode1);
            xrmApp.ThinkTime(1000);
            xrmApp.Entity.SetValue("mzk_country1", readData.ResourceData.mzk_country1);
            xrmApp.ThinkTime(1000);
            xrmApp.Entity.SetValue("mzk_address1countrycodeiso", readData.ResourceData.mzk_address1countrycodeiso);
            xrmApp.ThinkTime(1000);

            //Default Delivery Address
            xrmApp.Entity.SetValue("mzk_address2name", readData.ResourceData.mzk_address2name);
            xrmApp.ThinkTime(1000);
            xrmApp.Entity.SetValue("mzk_address2line1", readData.ResourceData.mzk_address2line1);
            xrmApp.ThinkTime(1000);

            xrmApp.Entity.SetValue("mzk_city2", readData.ResourceData.mzk_city2);

            xrmApp.Entity.SetValue("mzk_postalcode2", readData.ResourceData.mzk_postalcode2);
            xrmApp.Entity.SetValue("mzk_country2", readData.ResourceData.mzk_country2);
            xrmApp.Entity.SetValue("mzk_address2countrycodeiso", readData.ResourceData.mzk_address2countrycodeiso);

            xrmApp.Entity.Save();
            xrmApp.ThinkTime(2000);
            if (client.Browser.Driver.HasElement(By.XPath("//a[contains(@aria-label,'Convert into Contact')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@aria-label,'Convert into Contact')]")));
                client.Browser.Driver.FindElement(By.XPath("//a[contains(@aria-label,'Convert into Contact')]")).Click();

            }
            else
            {
                Console.WriteLine("No Element found");
            }



            Random random = new Random();
            int randomnumber = random.Next(01111, 09999);
            string payrollnumber = "EMP_" + randomnumber.ToString();
            xrmApp.Entity.SetValue("mzk_payrollnumberemployeeref", payrollnumber);
            xrmApp.Entity.Save();
            xrmApp.ThinkTime(5000);
            //Field gender =  xrmApp.Entity.GetField("mzk_gendervalue");
            //Assert.IsTrue(gender.IsRequired);
            // xrmApp.ThinkTime(5000);
            //Field language =  xrmApp.Entity.GetField("mzk_language");
            //Assert.IsTrue(language.IsRequired);


            xrmApp.Navigation.OpenSubArea("Others", "Bookable Resources");
            xrmApp.ThinkTime(2000);
            xrmApp.Grid.Search(UserNameTrim);
            xrmApp.ThinkTime(2000);
            xrmApp.Grid.HighLightRecord(0);
            xrmApp.ThinkTime(2000);
            xrmApp.CommandBar.ClickCommand("Assign");
            xrmApp.ThinkTime(2000);
            xrmApp.Dialogs.Assign(Dialogs.AssignTo.Team, "Hah");
            xrmApp.ThinkTime(2000);


            xrmApp.Navigation.OpenArea("MazikCare Referral Management");
            xrmApp.ThinkTime(5000);
            xrmApp.Navigation.OpenSubArea("Customers", "Accounts");



            xrmApp.Grid.Search(UserNameTrim);
            xrmApp.ThinkTime(5000);
            xrmApp.Grid.OpenRecord(0);

            string accountnumber = xrmApp.Entity.GetValue("accountnumber");
            Assert.IsTrue(accountnumber.StartsWith(payrollnumber));



        }


        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - B11_Create_Resource---";
            LogHelper.LogRecord(Message);
            cli.Browser.Driver.Close();

        }

    }
}

