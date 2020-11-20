using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Build_Sanity_Suit
{

    [TestClass]
    public static class LoginFinops
    {
        public static WebClient client;

        [TestMethod, TestCategory("Sanity")]
        public static void CheckFinopsAccounts(string AcntNumber)
        {
            By uid = By.Id("i0116");
            By pwdinput = By.Id("passwordInput");
            By submitbutton = By.Id("submitButton");
            By nextbutton = By.Id("idSIButton9");
            By redirect = By.Id("idSubmit_ProofUp_Redirect");
            By skipsteup = By.PartialLinkText("Skip setup");
            By iframe = By.CssSelector("iframe#AppLandingPage");

            client = new Microsoft.Dynamics365.UIAutomation.Api.UCI.WebClient(TestSetting.options);
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120));
            client.Browser.Driver.Navigate().GoToUrl("https://hah-finops-e2e-test.sandbox.operations.dynamics.com");
            client.Browser.Driver.WaitUntilVisible(uid);
            if (client.Browser.Driver.HasElement(uid))
            {

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(uid)).SendKeys("testuser6-d365@hah.co.uk");
                client.Browser.Driver.FindElement(uid).SendKeys(Keys.Enter);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(pwdinput)).SendKeys("Welcome20");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(submitbutton)).Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(nextbutton)).SendKeys(Keys.Enter);

                if (client.Browser.Driver.HasElement(redirect))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(redirect)).SendKeys(Keys.Enter);
                }
                else
                {
                    Console.WriteLine("No Such Element");
                }
                if (client.Browser.Driver.HasElement(skipsteup))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(skipsteup)).Click();

                }
                else
                {
                    Console.WriteLine("No Such Element");
                }
                if (client.Browser.Driver.HasElement(nextbutton))
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(nextbutton)).SendKeys(Keys.Enter);
                }
                else
                {
                    Console.WriteLine("No Such Element");
                }
                client.Browser.Driver.WaitForPageToLoad();
                //client.Browser.Driver.WaitUntilVisible(By.CssSelector("input.textbox.field")).SendKeys("Charge Entry");
                client.Browser.Driver.WaitUntilVisible(By.CssSelector("input.textbox.field")).SendKeys("All Customers");
   
                client.Browser.Driver.WaitUntilVisible(By.CssSelector("input.textbox.field")).SendKeys(Keys.Enter);
                // for charge entry

                //client.Browser.Driver.WaitUntilVisible(By.XPath("//input[@name='QuickFilter_Input']")).SendKeys("60008493");

                //client.Browser.Driver.WaitUntilVisible(By.XPath("//input[@name='QuickFilter_Input']")).SendKeys(Keys.Enter);

                //for Accounts
                client.Browser.Driver.WaitUntilVisible(By.XPath("//input[@name='QuickFilterControl_Input']")).SendKeys(AcntNumber);

                client.Browser.Driver.WaitUntilVisible(By.XPath("//input[@name='QuickFilterControl_Input']")).SendKeys(Keys.Enter);

                xrmApp.ThinkTime(5000);
                client.Browser.Driver.Close();

            }
        }
        //    [TestCleanup]
        //public void Teardown()
        //{
        //    //Cleanup("Patient Number:" + Variables.PatientNum + "\r\n");
        //    //client.Browser.Driver.Close();
        //}
    }
}


