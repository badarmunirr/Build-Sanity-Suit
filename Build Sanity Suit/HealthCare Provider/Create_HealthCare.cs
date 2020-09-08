using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.IO;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class A1_Create_HealthCare
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }



        [TestMethod, TestCategory("BuildAutomation")]

        public void A1_CreateProvider()
        {
            WebDriverWait wait = new WebDriverWait(global.client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();
            LOGIN loginobj = new LOGIN();
            loginobj.Login();
            global.xrmApp.ThinkTime(4000);
            global.xrmApp.Navigation.OpenSubArea("Customers", "Healthcare Providers");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.CommandBar.ClickCommand("New");

            global.xrmApp.Entity.SetValue("name", Healthcareproviderdata.name);

            //global.xrmApp.Entity.SetValue("accountnumber", Healthcareproviderdata.accountnumber);

            global.xrmApp.Entity.SetValue("telephone1", Healthcareproviderdata.telephone1);

            global.xrmApp.Entity.SetValue("fax", Healthcareproviderdata.fax);

            global.xrmApp.Entity.SetValue("emailaddress1", Healthcareproviderdata.email);

            //Lookupobj.Lookup("mzk_payer", Healthcareproviderdata.payer);

            global.xrmApp.Entity.SetValue("mzk_taxidnumber", Healthcareproviderdata.taxid);//optional

            Lookupobj.Lookup("mzk_category", Healthcareproviderdata.category);

            global.xrmApp.Entity.SetValue("mzk_hospitalid", Healthcareproviderdata.hospitalid);

            Lookupobj.Lookup("mzk_paymentterms", Healthcareproviderdata.paymentterms);

            Lookupobj.Lookup("mzk_patientlanguage", Healthcareproviderdata.patientlanguage);
            DateTime mzk_dateoflastregulatorycheck = DateTime.Today;
            global.xrmApp.Entity.SetValue("mzk_dateoflastregulatorycheck", mzk_dateoflastregulatorycheck, "dd/MM/yyyy");
            // Address
            global.xrmApp.ThinkTime(2000);
            if (global.client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@data-countrycode,'GB')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//*[contains(@data-countrycode,'GB')]")).Click();

                global.xrmApp.Entity.SetValue("address1_name", Healthcareproviderdata.address1name);

                global.xrmApp.Entity.SetValue("address1_line1", Healthcareproviderdata.fulladdress);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")).Click();
            }
            else
            {
                Console.WriteLine("No Element found");
            }
            global.xrmApp.ThinkTime(2000);
            if (global.client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")).Click();

                global.xrmApp.Entity.SetValue("address2_name", Healthcareproviderdata.address2name);

                global.xrmApp.Entity.SetValue("address2_line1", Healthcareproviderdata.fulladdress);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")).Click();
            }
            else
            {
                Console.WriteLine("No Element found");
            }
            //global.xrmApp.ThinkTime(5000);

            //Lookupobj.Lookup("primarycontactid", Healthcareproviderdata.primarycontactid);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SelectTab("Details");
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue(new OptionSet { Name = "preferredcontactmethodcode", Value = Healthcareproviderdata.preferdcontactmethod });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "donotemail", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "donotbulkemail", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "donotphone", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "donotfax", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "donotpostalmail", Value = false });
            //global.xrmApp.ThinkTime(1000);
            global.xrmApp.Entity.Save();
            global.xrmApp.ThinkTime(2000);
            if (global.client.Browser.Driver.HasElement(By.CssSelector("button[data-id='ignore_save']")))
            {
                global.client.Browser.Driver.FindElement(By.CssSelector("button[data-id='ignore_save']")).SendKeys(Keys.Enter);
            }
            else
            {
                Console.WriteLine("Update Duplicate Record");
            }
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            string mzk_address1countrycodeiso = global.xrmApp.Entity.GetValue("mzk_address1countrycodeiso");
            Assert.IsTrue(mzk_address1countrycodeiso.StartsWith("GB"));
            global.xrmApp.ThinkTime(1000);
            string mzk_address2countrycodeiso = global.xrmApp.Entity.GetValue("mzk_address2countrycodeiso");
            Assert.IsTrue(mzk_address2countrycodeiso.StartsWith("GB"));
            //Field address1_line1 = global.xrmApp.Entity.GetField("address1_line1");
            //Assert.IsTrue(address1_line1.IsRequired);

            //Field address2_line1 = global.xrmApp.Entity.GetField("address2_line1");
            //Assert.IsTrue(address2_line1.IsRequired);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SelectTab("Referrers");
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SubGrid.ClickCommand("Health_Care_Provider_Clinicians", "New Healthcare Provider Clinician");
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_prescriber", Healthcareproviderdata.priscriber);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_multiplewards", Healthcareproviderdata.telephone1);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_sites", Healthcareproviderdata.telephone1);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_department", Healthcareproviderdata.telephone1);

            global.xrmApp.ThinkTime(2000);
            global.xrmApp.CommandBar.ClickCommand("Save & Close");

        }
        
        [TestCleanup]
        public void teardown()
        {



        Screenshot ss = ((ITakesScreenshot)global.client.Browser.Driver).GetScreenshot();
            string path = Directory.GetCurrentDirectory() + "A1_Create_HealthCare.png";
            ss.SaveAsFile(path);
            TestContext.AddResultFile(path);


    }
    }


}

