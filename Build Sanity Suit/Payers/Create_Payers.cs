using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class A3_Create_Payers
    {
        static string PayerNum;
        public static WebClient cli;

        [TestMethod, TestCategory("BuildAutomation")]
        public void A3_CreatePayer()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(usersetting.OperationalManager, usersetting.pwd);
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();



            xrmApp.ThinkTime(4000);
            xrmApp.Navigation.OpenSubArea("Customers", "Payers");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
            xrmApp.CommandBar.ClickCommand("New");

            xrmApp.Entity.SetValue("name", Payerdata.name);
            xrmApp.Entity.SetValue("telephone1", Payerdata.telephone1);
            xrmApp.Entity.SetValue("emailaddress1", Payerdata.email);
            // xrmApp.Entity.SetValue("mzk_aeemailaddress", Payerdata.email2);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue("mzk_pqcemailaddress", Payerdata.email3);
            // xrmApp.Entity.SetValue("mzk_pspid", Payerdata.pspid+i);
            xrmApp.Entity.SetValue("mzk_vatnum", Payerdata.vatnum);//optional
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_accountcategory", Value = Payerdata.accountcategory });
            xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_billingfrequency", Value = Payerdata.billingfrequency });
            xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_showcreditlimit", Value = true });
            // unable to set value in credit limit field 
            // xrmApp.Entity.SetValue("creditlimit", "555");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@aria-label,'Credit Limit')]")));
            xrmApp.ThinkTime(5000);
            client.Browser.Driver.FindElement(By.XPath("//input[contains(@aria-label,'Credit Limit')]")).Click();
            xrmApp.ThinkTime(5000);
            client.Browser.Driver.FindElement(By.XPath("//input[contains(@aria-label,'Credit Limit')]")).SendKeys("5555");
            Lookupobj.Lookup("mzk_paymentterms", Payerdata.paymentterms, xrmApp);
            //Lookupobj.Lookup("mzk_patientlanguage", Payerdata.patientlanguage);
            DateTime mzk_dateoflastcreditcheck = DateTime.Today;
            xrmApp.Entity.SetValue("mzk_dateoflastcreditcheck", mzk_dateoflastcreditcheck, "dd/MM/yyyy");
            DateTime mzk_dateoflastfinancialregistrationdocuments = DateTime.Today;
            xrmApp.Entity.SetValue("mzk_dateoflastfinancialregistrationdocuments", mzk_dateoflastfinancialregistrationdocuments, "dd/MM/yyyy");
            // Address
            xrmApp.ThinkTime(2000);
            if (client.Browser.Driver.HasElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")))
            {
                xrmApp.ThinkTime(5000);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")));
                client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address1_line1.fieldControl_container')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@data-countrycode,'GB')]")));
                client.Browser.Driver.FindElement(By.XPath("//*[contains(@data-countrycode,'GB')]")).Click();
                xrmApp.Entity.SetValue("address1_name", Payerdata.address1name);

                xrmApp.Entity.SetValue("address1_line1", Payerdata.fulladdress);
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
                xrmApp.ThinkTime(5000);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")));
                client.Browser.Driver.FindElement(By.XPath("//div[contains(@data-id,'address2_line1.fieldControl_container')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")));
                client.Browser.Driver.FindElement(By.XPath("//div[contains(@class,'data8-pa-countryselector data8-pa-visible')]")).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")));
                client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-countrylist data8-pa-visible']//span[contains(text(),'United Kingdom')]")).Click();
                xrmApp.Entity.SetValue("address2_name", Payerdata.address2name);

                xrmApp.Entity.SetValue("address2_line1", Payerdata.fulladdress);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")));
                client.Browser.Driver.FindElement(By.XPath("//div[@class='data8-pa-autocomplete data8-pa-visible']//div[@class='data8-pa-autocompleteitem']")).Click();
            }
            else
            {
                Console.WriteLine("No Element found");
            }

            //Lookupobj.Lookup("primarycontactid", Payerdata.primarycontactid);
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SelectTab("Details");
            // xrmApp.ThinkTime(1000);
            // xrmApp.Entity.SetValue(new OptionSet { Name = "preferredcontactmethodcode", Value = Payerdata.preferdcontactmethod });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotemail", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotbulkemail", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotphone", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotfax", Value = false });
            // xrmApp.Entity.SetValue(new BooleanItem { Name = "donotpostalmail", Value = false });
            // xrmApp.ThinkTime(5000);
            xrmApp.Entity.Save();
            if (client.Browser.Driver.HasElement(By.CssSelector("button[data-id='ignore_save']")))
            {
                client.Browser.Driver.FindElement(By.CssSelector("button[data-id='ignore_save']")).SendKeys(Keys.Enter);
            }
            else
            {
                Console.WriteLine("Update Duplicate Record");
            }
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'Vaildate Payer')]")));
            xrmApp.CommandBar.ClickCommand("Vaildate Payer");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("confirmButton")));
            xrmApp.Dialogs.ConfirmationDialog(true);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("confirmButton")));
            xrmApp.Dialogs.ConfirmationDialog(true);

            xrmApp.ThinkTime(1000);
            string mzk_address1countrycodeiso = xrmApp.Entity.GetValue("mzk_address1countrycodeiso");
            Assert.IsTrue(mzk_address1countrycodeiso.StartsWith("GB"));
            xrmApp.ThinkTime(1000);
            string mzk_address2countrycodeiso = xrmApp.Entity.GetValue("mzk_address2countrycodeiso");
            Assert.IsTrue(mzk_address2countrycodeiso.StartsWith("GB"));
            //Field address1_line1 =  xrmApp.Entity.GetField("address1_line1");
            //Assert.IsTrue(address1_line1.IsRequired);
            //Field address2_line1 =  xrmApp.Entity.GetField("address2_line1");
            //Assert.IsTrue(address2_line1.IsRequired);
            xrmApp.ThinkTime(1000);
            //string accountnumber =  xrmApp.Entity.GetHeaderValue(new OptionSet { Name = "accountnumber" });
            //Assert.IsFalse(accountnumber.StartsWith("---"));
            xrmApp.ThinkTime(2000);

            client.Browser.Driver.FindElement(By.CssSelector("*[aria-label='Validated: Yes']")).IsVisible();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));

            PayerNum = xrmApp.Entity.GetHeaderValue("accountnumber");
            xrmApp.ThinkTime(2000);


        }

        [TestCleanup]
        public void Teardown()
        {
            string Message = "Test Case ID - A3_Create_Payers\r\n";
            Helper.LogRecord(Message + "\r\nPayer No : " + PayerNum );
            cli.Browser.Driver.Close();
        }
    }
}

