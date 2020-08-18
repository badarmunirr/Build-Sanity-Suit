using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class Create_Payers
    {
        [TestMethod, TestCategory("BuildAutomation")]

        public void CreatePayer()
        {
            WebDriverWait wait = new WebDriverWait(global.client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();
            //LOGIN loginobj = new LOGIN();
            //loginobj.Login();
            global.xrmApp.ThinkTime(4000);
            global.xrmApp.Navigation.OpenSubArea("Customers", "Payers");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.CommandBar.ClickCommand("New");

            global.xrmApp.Entity.SetValue("name", Payerdata.name);
            global.xrmApp.Entity.SetValue("telephone1", Payerdata.telephone1);
            global.xrmApp.Entity.SetValue("emailaddress1", Payerdata.email);
            //global.xrmApp.Entity.SetValue("mzk_aeemailaddress", Payerdata.email2);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue("mzk_pqcemailaddress", Payerdata.email3);
            //global.xrmApp.Entity.SetValue("mzk_pspid", Payerdata.pspid+i);
            global.xrmApp.Entity.SetValue("mzk_vatnum", Payerdata.vatnum);//optional
            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_accountcategory", Value = Payerdata.accountcategory });
            global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_billingfrequency", Value = Payerdata.billingfrequency });
            global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_showcreditlimit", Value = true });
            // unable to set value in credit limit field 
            //global.xrmApp.Entity.SetValue("Creditlimit", "12345");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@aria-label,'Credit Limit')]")));
            global.client.Browser.Driver.FindElement(By.XPath("//input[contains(@aria-label,'Credit Limit')]")).SendKeys("5555");
            Lookupobj.Lookup("mzk_paymentterms", Payerdata.paymentterms);
            //Lookupobj.Lookup("mzk_patientlanguage", Payerdata.patientlanguage);
            DateTime mzk_dateoflastcreditcheck = DateTime.Today;
            global.xrmApp.Entity.SetValue("mzk_dateoflastcreditcheck", mzk_dateoflastcreditcheck, "dd/MM/yyyy");
            DateTime mzk_dateoflastfinancialregistrationdocuments = DateTime.Today;
            global.xrmApp.Entity.SetValue("mzk_dateoflastfinancialregistrationdocuments", mzk_dateoflastfinancialregistrationdocuments, "dd/MM/yyyy");
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

            //Lookupobj.Lookup("primarycontactid", Payerdata.primarycontactid);
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SelectTab("Details");
            //global.xrmApp.ThinkTime(1000);
            //global.xrmApp.Entity.SetValue(new OptionSet { Name = "preferredcontactmethodcode", Value = Payerdata.preferdcontactmethod });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "donotemail", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "donotbulkemail", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "donotphone", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "donotfax", Value = false });
            //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "donotpostalmail", Value = false });
            //global.xrmApp.ThinkTime(5000);
            global.xrmApp.ThinkTime(1000);
            string mzk_address1countrycodeiso = global.xrmApp.Entity.GetValue("mzk_address1countrycodeiso");
            Assert.IsTrue(mzk_address1countrycodeiso.StartsWith("GB"));
            global.xrmApp.ThinkTime(1000);
            string mzk_address2countrycodeiso = global.xrmApp.Entity.GetValue("mzk_address2countrycodeiso");
            Assert.IsTrue(mzk_address2countrycodeiso.StartsWith("GB"));
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
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Vaildate Payer')]")));
            global.xrmApp.CommandBar.ClickCommand("Vaildate Payer");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("confirmButton")));
            global.xrmApp.Dialogs.ConfirmationDialog(true);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("confirmButton")));
            global.xrmApp.Dialogs.ConfirmationDialog(true);
            global.xrmApp.ThinkTime(2000);
            global.client.Browser.Driver.FindElement(By.CssSelector("*[aria-label='Validated: Yes']")).IsVisible();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.CommandBar.ClickCommand("Save & Close");

        }
    }
}

