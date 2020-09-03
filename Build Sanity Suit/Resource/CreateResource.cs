using System;
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
        //meed to update user everytime
        [TestMethod, TestCategory("BuildAutomation")]

        public void B11_CreateResourceToAccountTypeEmployee()
        {
            WebDriverWait wait = new WebDriverWait(global.client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();
            LOGIN loginobj = new LOGIN();
            loginobj.Login();
            global.xrmApp.ThinkTime(4000);
            global.xrmApp.Navigation.OpenArea("Settings");
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.Navigation.OpenSubArea("Others", "Resources");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.CommandBar.ClickCommand("New");

            global.xrmApp.Entity.SetValue(new OptionSet { Name = "resourcetype", Value = ResourceToPatData.resourcetype });

            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_resourcesubtype", Value = ResourceToPatData.resourcesubtype });

            Lookupobj.Lookup("userid", ResourceToPatData.userid); //need to update this everytime

            Lookupobj.Lookup("mzk_gendervalue", ResourceToPatData.gender);

            Lookupobj.Lookup("mzk_language", ResourceToPatData.language);

            global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.SetValue("mzk_address1name", "Deployment ");
            global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.SetValue("mzk_address1line1", "10 Bridge Close");

            global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.SetValue("mzk_city1", "BRISTOL");

            global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.SetValue("mzk_postalcode1", "BS14 0TS");
            global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.SetValue("mzk_country1", "United Kingdom");
            global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.SetValue("mzk_address1countrycodeiso", "GB");
            global.xrmApp.ThinkTime(1000);

            //Default Delivery Address
            global.xrmApp.Entity.SetValue("mzk_address2name", "Delivery ");
            global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.SetValue("mzk_address2line1", "10 Bridge Close");
            global.xrmApp.ThinkTime(1000);

            global.xrmApp.Entity.SetValue("mzk_city2", "BRISTOL");

            global.xrmApp.Entity.SetValue("mzk_postalcode2", "BS14 0TS");
            global.xrmApp.Entity.SetValue("mzk_country2", "United Kingdom");
            global.xrmApp.Entity.SetValue("mzk_address2countrycodeiso", "GB");

            global.xrmApp.Entity.Save();
            global.xrmApp.ThinkTime(2000);
            if (global.client.Browser.Driver.HasElement(By.XPath("//a[contains(@aria-label,'Convert into Contact')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@aria-label,'Convert into Contact')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//a[contains(@aria-label,'Convert into Contact')]")).Click();

            }
            else
            {
                Console.WriteLine("No Element found");
            }



            Random random = new Random();
            int randomnumber = random.Next(01111, 09999);
            string payrollnumber = "EMP_" + randomnumber.ToString();
            global.xrmApp.Entity.SetValue("mzk_payrollnumberemployeeref", payrollnumber);
            global.xrmApp.Entity.Save();
            global.xrmApp.ThinkTime(5000);
            Field gender = global.xrmApp.Entity.GetField("mzk_gendervalue");
            Assert.IsTrue(gender.IsRequired);
            global.xrmApp.ThinkTime(5000);
            Field language = global.xrmApp.Entity.GetField("mzk_language");
            Assert.IsTrue(language.IsRequired);
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Navigation.OpenArea("MazikCare Referral Management");
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Navigation.OpenSubArea("Customers", "Accounts");

            string UserName = ResourceToPatData.userid;
            string UserNameTrim = UserName.Remove(9);

            global.xrmApp.Grid.Search(UserNameTrim);
            global.xrmApp.ThinkTime(5000);
            global.xrmApp.Grid.OpenRecord(0);

            string accountnumber = global.xrmApp.Entity.GetValue("accountnumber");
            Assert.IsTrue(accountnumber.StartsWith(payrollnumber));






           
        }
        [TestCleanup]
        public void teardown()
        {
            //global.xrmApp.Navigation.SignOut();
            ////global.client.Browser.Driver.Quit();
        }

    }
}

