using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{

    [TestClass]
    public class A2_Create_Patient
    {
        public static WebClient cli;

        [TestMethod, TestCategory("BuildAutomation")]
        public void A2_CreatePatient()
        {
            try
            {
                LOGIN loginobj = new LOGIN();
                WebClient client = loginobj.Login();
                cli = client;
                XrmApp xrmApp = new XrmApp(client);
                WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
                HelperFunction Lookupobj = new HelperFunction();


                xrmApp.ThinkTime(4000);
                xrmApp.Navigation.OpenSubArea("Customers", "Patients");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                xrmApp.CommandBar.ClickCommand("New");
                Lookupobj.Lookup("mzk_title", Patientdata.title, xrmApp);

                xrmApp.Entity.SetValue("firstname", Patientdata.name);

                xrmApp.Entity.SetValue("lastname", Patientdata.lname);

                Lookupobj.Lookup("mzk_gender", Patientdata.gender, xrmApp);

                xrmApp.Entity.SetValue("mzk_preferredname", Patientdata.preferredname);// Optional

                DateTime birthday = new DateTime(1995, 3, 1);

                xrmApp.Entity.SetValue("birthdate", birthday, "dd/MM/yyyy");

                //  xrmApp.Entity.SetValue("mzk_mothersidentifier", Patientdata.motherifentification);//optional

                xrmApp.Entity.SetValue(new OptionSet { Name = "familystatuscode", Value = Patientdata.familystatuscode });
                //optional
                // xrmApp.ThinkTime(1000);
                //Lookupobj.Lookup("mzk_nationality", Patientdata.nationality);
                // xrmApp.ThinkTime(1000);
                //Lookupobj.Lookup("mzk_ethnicity", Patientdata.ethnicity);
                // xrmApp.ThinkTime(1000);
                //Lookupobj.Lookup("mzk_race", Patientdata.race);

                Lookupobj.Lookup("mzk_patientlanguage", Patientdata.language, xrmApp);
                // xrmApp.ThinkTime(1000);
                //Lookupobj.Lookup("mzk_disability", Patientdata.disability);//optional
                // xrmApp.ThinkTime(1000);
                //Lookupobj.Lookup("mzk_carerresponsibility", "Vision Impairment");//optional

                // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_vippatient", Value = true });//optional

                xrmApp.Entity.SetValue("mzk_patientinstructions", Patientdata.patientinstruction);//optional

                xrmApp.Entity.SetValue("mzk_medicalhistory", Patientdata.medicalhistroy);
                //optional
                // xrmApp.ThinkTime(1000);
                //Lookupobj.Lookup("mzk_selffundingaccount", "Payer");
                // xrmApp.ThinkTime(1000);
                //Lookupobj.Lookup("mzk_gpname", "Mark Hyman");
                // xrmApp.ThinkTime(1000);
                //Lookupobj.Lookup("mzk_gpsurgeryname", "Ramsey Hospital");
                //Identification
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_legacyhahnumber", Patientdata.legacyhahnumber);


                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_patientidentificationtype", Value = "National ID" });
                xrmApp.ThinkTime(1000);
                Random random = new Random();
                int randomnumber = random.Next(0111111111, 0999999999);
                xrmApp.Entity.SetValue("mzk_primaryidentificationnumber", randomnumber.ToString());

                DateTime mzk_primaryidentificationexpirationdate = DateTime.Today.AddDays(1);

                xrmApp.Entity.SetValue("mzk_primaryidentificationexpirationdate", mzk_primaryidentificationexpirationdate, "dd/MM/yyyy");
                ;
                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_secondaryidentificationtype", Value = "Passport" });

                xrmApp.Entity.SetValue("mzk_secondaryidentificationnumber", "0123456");
                DateTime mzk_secondaryidentificationexpirationdate = DateTime.Today.AddDays(10);

                xrmApp.Entity.SetValue("mzk_secondaryidentificationexpirationdate", mzk_secondaryidentificationexpirationdate, "dd/MM/yyyy");

                xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_otheridentificationtype", Value = "Other" });

                xrmApp.Entity.SetValue("mzk_otheridentificationnumber", "012345");
                DateTime mzk_otheridentificationexpirationdate = DateTime.Today.AddDays(10);
                xrmApp.Entity.SetValue("mzk_otheridentificationexpirationdate", mzk_otheridentificationexpirationdate, "dd/MM/yyyy");
                //CONTACT DETAILS
                xrmApp.Entity.SetValue("telephone1", Patientdata.telephone1);
                xrmApp.Entity.SetValue("telephone2", Patientdata.telephone2);
                xrmApp.Entity.SetValue("telephone3", Patientdata.telephone3);
                xrmApp.Entity.SetValue("mobilephone", Patientdata.mobilephone);
                xrmApp.Entity.SetValue("emailaddress1", "abc@mazikglobal.com");
                xrmApp.ThinkTime(2000);
                if (client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")));
                    client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                    client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@data-countrycode,'GB')]")));
                    client.Browser.Driver.FindElement(By.XPath("//*[contains(@data-countrycode,'GB')]")).Click();

                    xrmApp.Entity.SetValue("address1_name", Patientdata.address1name);

                    xrmApp.Entity.SetValue("address1_line1", Patientdata.fulladdress);

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")));
                    client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")).Click();
                }
                else
                {
                    Console.WriteLine("No Element found");
                }
                xrmApp.ThinkTime(5000);
                if (client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")))
                {
                    xrmApp.ThinkTime(5000);
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")));
                    client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                    client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")));
                    client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")).Click();

                    xrmApp.Entity.SetValue("address2_name", Patientdata.address2name);

                    xrmApp.Entity.SetValue("address2_line1", Patientdata.fulladdress);
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")));
                    client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")).Click();
                }
                else
                {
                    Console.WriteLine("No Element found");
                }
                xrmApp.ThinkTime(2000);
                if (client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address3_line1.fieldControl_container')]")))
                {
                    xrmApp.ThinkTime(5000);
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address3_line1.fieldControl_container')]")));
                    client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address3_line1.fieldControl_container')]")).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                    client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")));
                    client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")).Click();

                    xrmApp.Entity.SetValue("address3_name", Patientdata.address3name);

                    xrmApp.Entity.SetValue("address3_line1", Patientdata.fulladdress);
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")));
                    client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")).Click();
                }
                else
                {
                    Console.WriteLine("No Element found");
                }

                //Contact Methods

                // xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_emailpreferences", Value = Patientdata.emailpreferences });

                // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotphone", Value = true });
                // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_smstextingpreferences", Value = false });
                // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_letterpreferences", Value = false });

                //// xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_contactpreferredtime", Value = "12:00 AM" });
                //// xrmApp.ThinkTime(500);
                //// xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_contactpreferredtimeto", Value = "12:00 AM" });
                // xrmApp.ThinkTime(500);
                // xrmApp.Entity.SetValue(new OptionSet { Name = "preferredcontactmethodcode", Value = Patientdata.preferdcontactmethod });
                // xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_survey", Value = Patientdata.survey });
                ////Shipping

                ////Scheduling Preference
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SelectTab("Scheduling Preference");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencemonday", Value = false });
                // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencetuesday", Value = false });
                // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencewednesday", Value = false });
                // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencethursday", Value = false });
                // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencefriday", Value = false });
                // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencesaturday", Value = false });
                // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_schedulepreferencesunday", Value = true });


                xrmApp.ThinkTime(5000);
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
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Save & Close')]")));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));

                xrmApp.ThinkTime(1000);

                string mzk_address1countrycodeiso = xrmApp.Entity.GetValue("mzk_address1countrycodeiso");
                Assert.IsTrue(mzk_address1countrycodeiso.StartsWith("GB"));
                xrmApp.ThinkTime(1000);
                string mzk_address2countrycodeiso = xrmApp.Entity.GetValue("mzk_address2countrycodeiso");
                Assert.IsTrue(mzk_address2countrycodeiso.StartsWith("GB"));
                xrmApp.ThinkTime(1000);
                string mzk_address3countrycodeiso = xrmApp.Entity.GetValue("mzk_address3countrycodeiso");
                Assert.IsTrue(mzk_address3countrycodeiso.StartsWith("GB"));
                string[] identificationtype = { "National ID", "Passport", "Work Permit", "Driver's License Number", "Other", "National Health Care ID" };
                foreach (string idtype in identificationtype)
                {
                    xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_patientidentificationtype", Value = idtype });
                    Field primaryfield = xrmApp.Entity.GetField("mzk_primaryidentificationnumber");
                    Assert.IsTrue(primaryfield.IsRequired);
                    xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_secondaryidentificationtype", Value = idtype });
                    Field secondryfield = xrmApp.Entity.GetField("mzk_secondaryidentificationnumber");
                    Assert.IsTrue(secondryfield.IsRequired);
                    xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_otheridentificationtype", Value = idtype });
                    Field otherField = xrmApp.Entity.GetField("mzk_otheridentificationnumber");
                    Assert.IsTrue(otherField.IsRequired);
                }
                //Field address1_line1 =  xrmApp.Entity.GetField("address1_line1");
                //Assert.IsTrue(address1_line1.IsRequired);
                //Field address2_line1 =  xrmApp.Entity.GetField("address2_line1");
                //Assert.IsTrue(address2_line1.IsRequired);
                //Field address3_line1 =  xrmApp.Entity.GetField("address3_line1");
                //Assert.IsTrue(address3_line1.IsRequired);

                string mzk_patientmrn = xrmApp.Entity.GetValue("mzk_patientmrn");
                string mzk_agecalculated = xrmApp.Entity.GetValue("mzk_agecalculated");
                string mzk_pincode = xrmApp.Entity.GetValue("mzk_pincode");
                string mzk_failedpincode = xrmApp.Entity.GetValue("mzk_failedpincode");
                //Assert.IsNotNull(mzk_agecalculated);
                //Assert.IsNotNull(mzk_patientmrn);
                //Assert.IsNotNull(mzk_failedpincode);
                ////Assert.IsNotNull(mzk_pincode);

                Assert.IsFalse(mzk_patientmrn.StartsWith("---"));
                Assert.IsFalse(mzk_agecalculated.StartsWith("---"));
                Assert.IsFalse(mzk_pincode.StartsWith("---"));
                Assert.IsFalse(mzk_failedpincode.StartsWith("---"));
            }
            catch (Exception ex)
            {
                string Message = ex.Message.ToString() + "  " + "Patient";
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

