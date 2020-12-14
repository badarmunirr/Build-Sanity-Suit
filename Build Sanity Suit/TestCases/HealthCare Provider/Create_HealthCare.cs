using AventStack.ExtentReports;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class A1_Create_HealthCare : TestBase
    {
        public  string AccountNum;
        public WebClient client = null;
        [TestMethod, TestCategory("Sanity")]
        public void A1_CreateProvider()
        {

            client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
            XrmApp xrmApp = new XrmApp(client);
            CreateMethod.Provider(xrmApp, client);
            AccountNum = xrmApp.Entity.GetHeaderValue("accountnumber");
          //  LoginFinops.CheckFinopsAccounts(AccountNum);
        }
       
        [TestCleanup]
        public void Teardown()
        {
            if (TestContext.CurrentTestOutcome.ToString() == "Passed")
            {

                test.Log(Status.Info, "Test Ended");
                test.Log(Status.Pass, "Test Passed");
                Screenshot ss = ((ITakesScreenshot)client.Browser.Driver).GetScreenshot();
                string path = Directory.GetCurrentDirectory() + TestContext.TestName;
                ss.SaveAsFile(path);
                this.TestContext.AddResultFile(path);

            }
            else if (TestContext.CurrentTestOutcome.ToString() == "Failed")
            {
                test.Log(Status.Info, "Test Ended");
                test.Log(Status.Fail, "Test Failed");
                Screenshot ss = ((ITakesScreenshot)client.Browser.Driver).GetScreenshot();
                string path = Directory.GetCurrentDirectory() + TestContext.TestName;
                ss.SaveAsFile(path);
                this.TestContext.AddResultFile(path);
            }
            Cleanup("HealthCare Number:" + AccountNum + "\r\n");
            client.Browser.Driver.Close();

        }
    }


}

