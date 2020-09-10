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
        public static WebClient cli;

        [TestMethod, TestCategory("BuildAutomation")]
        public void A1_CreateProvider()
        {
            try
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.Login();
                cli = client;
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                XrmApp xrmApp = new XrmApp(client);
                HelperFunction Lookupobj = new HelperFunction();

                xrmApp.ThinkTime(4000);
                xrmApp.Navigation.OpenSubArea("Customers", "Healthcare Providers");
     
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                xrmApp.CommandBar.ClickCommand("New");

                xrmApp.Entity.SetValue("name", Healthcareproviderdata.name);

                // xrmApp.Entity.SetValue("accountnumber", Healthcareproviderdata.accountnumber);

                xrmApp.Entity.SetValue("telephone1", Healthcareproviderdata.telephone1);

                xrmApp.Entity.SetValue("fax", Healthcareproviderdata.fax);

                xrmApp.Entity.SetValue("emailaddress1", Healthcareproviderdata.email);

                //Lookupobj.Lookup("mzk_payer", Healthcareproviderdata.payer);

                xrmApp.Entity.SetValue("mzk_taxidnumber", Healthcareproviderdata.taxid);//optional

                Lookupobj.Lookup("mzk_category", Healthcareproviderdata.category,xrmApp);

                xrmApp.Entity.SetValue("mzk_hospitalid", Healthcareproviderdata.hospitalid);

                Lookupobj.Lookup("mzk_paymentterms", Healthcareproviderdata.paymentterms,xrmApp);

                Lookupobj.Lookup("mzk_patientlanguage", Healthcareproviderdata.patientlanguage,xrmApp);

                DateTime mzk_dateoflastregulatorycheck = DateTime.Today;
                xrmApp.Entity.SetValue("mzk_dateoflastregulatorycheck", mzk_dateoflastregulatorycheck, "dd/MM/yyyy");
                // Address
                xrmApp.ThinkTime(2000);
                if (client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")));
                    client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                    client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@data-countrycode,'GB')]")));
                    client.Browser.Driver.FindElement(By.XPath("//*[contains(@data-countrycode,'GB')]")).Click();

                    xrmApp.Entity.SetValue("address1_name", Healthcareproviderdata.address1name);

                    xrmApp.Entity.SetValue("address1_line1", Healthcareproviderdata.fulladdress);
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

                    xrmApp.Entity.SetValue("address2_name", Healthcareproviderdata.address2name);

                    xrmApp.Entity.SetValue("address2_line1", Healthcareproviderdata.fulladdress);
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")));
                    client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")).Click();
                }
                else
                {
                    Console.WriteLine("No Element found");
                }
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
                // xrmApp.ThinkTime(1000);
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

                xrmApp.ThinkTime(2000);
                xrmApp.CommandBar.ClickCommand("Save & Close");
            }

            catch(Exception ex)
            {
                string Message = ex.Message.ToString() + "  " + "HealthCare PRovider"; 
                Helper.LogRecord(Message);
            }
            

        }

        

        [TestCleanup]
        public void Teardown()
        {
            cli.Browser.Driver.Close();
        }
    }


}

