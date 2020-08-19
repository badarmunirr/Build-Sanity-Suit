using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class Create_Patient
    {
        [TestMethod, TestCategory("BuildAutomation")]


        public void CreatePatient()
        {
            WebDriverWait wait = new WebDriverWait(global.client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();
            LOGIN loginobj = new LOGIN();
            loginobj.Login2();
            global.xrmApp.ThinkTime(4000);
            global.xrmApp.Navigation.OpenSubArea("Customers", "Patients");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.CommandBar.ClickCommand("New");
            Lookupobj.Lookup("mzk_title", Patientdata.title);

            global.xrmApp.Entity.SetValue("firstname", Patientdata.name);

            global.xrmApp.Entity.SetValue("lastname", Patientdata.lname);

            Lookupobj.Lookup("mzk_gender", Patientdata.gender);

            global.xrmApp.Entity.SetValue("mzk_preferredname", Patientdata.preferredname);// Optional

            DateTime birthday = new DateTime(1995, 3, 1);

            global.xrmApp.Entity.SetValue("birthdate", birthday, "dd/MM/yyyy");

            global.xrmApp.Entity.SetValue("mzk_mothersidentifier", Patientdata.motherifentification);//optional

            global.xrmApp.Entity.SetValue(new OptionSet { Name = "familystatuscode", Value = Patientdata.familystatuscode });//optional
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_nationality", Patientdata.nationality);
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_ethnicity", Patientdata.ethnicity);
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_race", Patientdata.race);

            Lookupobj.Lookup("mzk_patientlanguage", Patientdata.language);
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_disability", Patientdata.disability);//optional
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_carerresponsibility", "Vision Impairment");//optional

            global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_vippatient", Value = true });//optional

            global.xrmApp.Entity.SetValue("mzk_patientinstructions", Patientdata.patientinstruction);//optional

            global.xrmApp.Entity.SetValue("mzk_medicalhistory", Patientdata.medicalhistroy);//optional
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_selffundingaccount", "Payer");
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_gpname", "Mark Hyman");
            //global.xrmApp.ThinkTime(1000);
            //Lookupobj.Lookup("mzk_gpsurgeryname", "Ramsey Hospital");
            //Identification
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_legacyhahnumber", Patientdata.legacyhahnumber);
            global.xrmApp.ThinkTime(1000);
            string[] identificationtype = { "National ID", "Passport", "Work Permit", "Driver's License Number", "Other", "National Health Care ID" };
            foreach (string idtype in identificationtype)
            {
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_patientidentificationtype", Value = idtype });
                Field primaryfield = global.xrmApp.Entity.GetField("mzk_primaryidentificationnumber");
                Assert.IsTrue(primaryfield.IsRequired);
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_secondaryidentificationtype", Value = idtype });
                Field secondryfield = global.xrmApp.Entity.GetField("mzk_secondaryidentificationnumber");
                Assert.IsTrue(secondryfield.IsRequired);
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_otheridentificationtype", Value = idtype });
                Field otherField = global.xrmApp.Entity.GetField("mzk_otheridentificationnumber");
                Assert.IsTrue(otherField.IsRequired);
            }

            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_patientidentificationtype", Value = "National ID" });
            global.xrmApp.ThinkTime(1000);
            Random random = new Random();
            int randomnumber = random.Next(0111111111, 0999999999);
            global.xrmApp.Entity.SetValue("mzk_primaryidentificationnumber", randomnumber.ToString());

            DateTime mzk_primaryidentificationexpirationdate = DateTime.Today.AddDays(1);

            global.xrmApp.Entity.SetValue("mzk_primaryidentificationexpirationdate", mzk_primaryidentificationexpirationdate, "dd/MM/yyyy");
;
            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_secondaryidentificationtype", Value = "Passport" });

            global.xrmApp.Entity.SetValue("mzk_secondaryidentificationnumber", "0123456");
            DateTime mzk_secondaryidentificationexpirationdate = DateTime.Today.AddDays(10);

            global.xrmApp.Entity.SetValue("mzk_secondaryidentificationexpirationdate", mzk_secondaryidentificationexpirationdate, "dd/MM/yyyy");

            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_otheridentificationtype", Value = "Other" });

            global.xrmApp.Entity.SetValue("mzk_otheridentificationnumber", "012345");
            DateTime mzk_otheridentificationexpirationdate = DateTime.Today.AddDays(10);
            global.xrmApp.Entity.SetValue("mzk_otheridentificationexpirationdate", mzk_otheridentificationexpirationdate, "dd/MM/yyyy");
            //CONTACT DETAILS
            global.xrmApp.Entity.SetValue("telephone1", Patientdata.telephone1);
            global.xrmApp.Entity.SetValue("telephone2", Patientdata.telephone2);
            global.xrmApp.Entity.SetValue("telephone3", Patientdata.telephone3);
            global.xrmApp.Entity.SetValue("mobilephone", Patientdata.mobilephone);
            global.xrmApp.Entity.SetValue("emailaddress1", "abc@mazikglobal.com");
            global.xrmApp.ThinkTime(2000);
            if (global.client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@data-countrycode,'GB')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//*[contains(@data-countrycode,'GB')]")).Click();

                global.xrmApp.Entity.SetValue("address1_name", Patientdata.address1name);

                global.xrmApp.Entity.SetValue("address1_line1", Patientdata.fulladdress);
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

                global.xrmApp.Entity.SetValue("address2_name", Patientdata.address2name);
 
                global.xrmApp.Entity.SetValue("address2_line1", Patientdata.fulladdress);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")).Click();
            }
            else
            {
                Console.WriteLine("No Element found");
            }
            global.xrmApp.ThinkTime(2000);
            if (global.client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address3_line1.fieldControl_container')]")))
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address3_line1.fieldControl_container')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address3_line1.fieldControl_container')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")).Click();
    
                global.xrmApp.Entity.SetValue("address3_name", Patientdata.address3name);
    
                global.xrmApp.Entity.SetValue("address3_line1", Patientdata.fulladdress);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")));
                global.client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")).Click();
            }
            else
            {
                Console.WriteLine("No Element found");
            }
            //Contact Methods

            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_emailpreferences", Value = Patientdata.emailpreferences });

            global.xrmApp.Entity.SetValue(new BooleanItem { Name = "donotphone", Value = true });
            global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_smstextingpreferences", Value = false });
            global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_letterpreferences", Value = false });

            //global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_contactpreferredtime", Value = "12:00 AM" });
            //global.xrmApp.ThinkTime(500);
            //global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_contactpreferredtimeto", Value = "12:00 AM" });
            //global.xrmApp.ThinkTime(500);
            //global.xrmApp.Entity.SetValue(new OptionSet { Name = "preferredcontactmethodcode", Value = Patientdata.preferdcontactmethod });
            //global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_survey", Value = Patientdata.survey });
            ////Shipping

            ////Scheduling Preference
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SelectTab("Scheduling Preference");
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencemonday", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencetuesday", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencewednesday", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencethursday", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencefriday", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencesaturday", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencesunday", Value = true });
            //global.xrmApp.ThinkTime(5000);
            
            string mzk_address1countrycodeiso = global.xrmApp.Entity.GetValue("mzk_address1countrycodeiso");
            Assert.IsTrue(mzk_address1countrycodeiso.StartsWith("GB"));
            global.xrmApp.ThinkTime(1000);
            string mzk_address2countrycodeiso = global.xrmApp.Entity.GetValue("mzk_address2countrycodeiso");
            Assert.IsTrue(mzk_address2countrycodeiso.StartsWith("GB"));
            global.xrmApp.ThinkTime(1000);
            string mzk_address3countrycodeiso = global.xrmApp.Entity.GetValue("mzk_address3countrycodeiso");
            Assert.IsTrue(mzk_address3countrycodeiso.StartsWith("GB"));

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
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Save & Close')]")));
            global.xrmApp.ThinkTime(1000);
            string mzk_pincode = global.xrmApp.Entity.GetValue("mzk_pincode");
            Assert.IsNotNull(mzk_pincode);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.CommandBar.ClickCommand("Save & Close");

        }
        [TestCleanup]
        public void teardown()
        {
            global.xrmApp.Navigation.SignOut();
            //global.client.Browser.Driver.Quit();
        }
    }

}

