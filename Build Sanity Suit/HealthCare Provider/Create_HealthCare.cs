using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class A1_Create_HealthCare
    {
        static string AccountNum;
        public static WebClient cli;
        ReadData readData = Helper.ReadDataFromJSONFile();

        [TestMethod, TestCategory("BuildAutomation")]
        public void A1_CreateProvider()
        {

            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.OperationalManager, usersetting.pwd);
            cli = client;
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            XrmApp xrmApp = new XrmApp(client);
            HelperFunction Lookupobj = new HelperFunction();

            xrmApp.ThinkTime(4000);
            xrmApp.Navigation.OpenSubArea("Customers", "Healthcare Providers");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.CommandBar.ClickCommand("New");
            xrmApp.ThinkTime(5000);
            xrmApp.ThinkTime(2000);
            if (client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")));
                client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@data-countrycode,'GB')]")));
                client.Browser.Driver.FindElement(By.XPath("//*[contains(@data-countrycode,'GB')]")).Click();

                xrmApp.Entity.SetValue("address1_name", readData.HealthCareProviderData.address1_name);

                xrmApp.Entity.SetValue("address1_line1", readData.HealthCareProviderData.address1_line1);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")));
                client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")).Click();
            }
            else
            {
                Console.WriteLine("No Element found");
            }
            xrmApp.ThinkTime(2000);
            if (client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")));
                client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")));
                client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")).Click();

                xrmApp.Entity.SetValue("address2_name", readData.HealthCareProviderData.address2_name);

                xrmApp.Entity.SetValue("address2_line1", readData.HealthCareProviderData.address2_line1);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")));
                client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")).Click();
            }
            else
            {
                Console.WriteLine("No Element found");
            }

            xrmApp.Entity.SetValue("name", readData.HealthCareProviderData.name);

            // xrmApp.Entity.SetValue("accountnumber", Healthcareproviderdata.accountnumber);

            xrmApp.Entity.SetValue("telephone1", readData.HealthCareProviderData.telephone1);

            xrmApp.Entity.SetValue("fax", readData.HealthCareProviderData.fax);

            xrmApp.Entity.SetValue("emailaddress1", readData.HealthCareProviderData.emailaddress1);

            //Lookupobj.Lookup("mzk_payer", Healthcareproviderdata.payer);

            xrmApp.Entity.SetValue("mzk_taxidnumber", readData.HealthCareProviderData.mzk_taxidnumber);//optional

            Lookupobj.Lookup("mzk_category", readData.HealthCareProviderData.mzk_category, xrmApp);

            xrmApp.Entity.SetValue("mzk_hospitalid", readData.HealthCareProviderData.mzk_hospitalid);

            Lookupobj.Lookup("mzk_paymentterms", readData.HealthCareProviderData.mzk_paymentterms, xrmApp);

            Lookupobj.Lookup("mzk_patientlanguage", readData.HealthCareProviderData.mzk_patientlanguage, xrmApp);

            DateTime mzk_dateoflastregulatorycheck = DateTime.Today;
            xrmApp.Entity.SetValue("mzk_dateoflastregulatorycheck", mzk_dateoflastregulatorycheck, "dd/MM/yyyy");
            // Address

            // xrmApp.ThinkTime(5000);

            //Lookupobj.Lookup("primarycontactid", Healthcareproviderdata.primarycontactid);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SelectTab("Details");
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue(new OptionSet { Name = "preferredcontactmethodcode", Value = Healthcareproviderdata.preferdcontactmethod });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotemail", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotbulkemail", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotphone", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotfax", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotpostalmail", Value = false });
            xrmApp.ThinkTime(1000);
            xrmApp.Entity.Save();
            xrmApp.ThinkTime(2000);
            if (client.Browser.Driver.HasElement(By.CssSelector("button[data-id='ignore_save']")))
            {
                client.Browser.Driver.FindElement(By.CssSelector("button[data-id='ignore_save']")).SendKeys(Keys.Enter);
            }
            else
            {
                Console.WriteLine("Update Duplicate Record");
            }
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            string mzk_address1countrycodeiso = xrmApp.Entity.GetValue("mzk_address1countrycodeiso");
            Assert.IsTrue(mzk_address1countrycodeiso.StartsWith("GB"));
            xrmApp.ThinkTime(1000);
            string mzk_address2countrycodeiso = xrmApp.Entity.GetValue("mzk_address2countrycodeiso");
            Assert.IsTrue(mzk_address2countrycodeiso.StartsWith("GB"));
            //Field address1_line1 =  xrmApp.Entity.GetField("address1_line1");
            //Assert.IsTrue(address1_line1.IsRequired);

            //Field address2_line1 =  xrmApp.Entity.GetField("address2_line1");
            //Assert.IsTrue(address2_line1.IsRequired);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SelectTab("Referrers");
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SubGrid.ClickCommand("Health_Care_Provider_Clinicians", "New Healthcare Provider Clinician");
            // xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_prescriber", Healthcareproviderdata.priscriber);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_multiplewards", Healthcareproviderdata.telephone1);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_sites", Healthcareproviderdata.telephone1);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_department", Healthcareproviderdata.telephone1);


            AccountNum = xrmApp.Entity.GetHeaderValue("accountnumber");
        }

        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A1_Create_HealthCare\r\n";
            Helper.LogRecord(Message + "HealthCare Provider Number : " + AccountNum);
            cli.Browser.Driver.Close();
        }
    }


}

