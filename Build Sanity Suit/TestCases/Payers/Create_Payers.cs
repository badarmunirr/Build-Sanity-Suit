
using AventStack.ExtentReports;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class A3_Create_Payers : TestBase
    {
        public string PayerNum;

        [TestMethod, TestCategory("Sanity")]
        public void A3_CreatePayer()
        {
            Retry(() =>
            {
                RoleBasedLogin(Usersetting.contractManager, Usersetting.pwd);
                CreateMethod.Payer(xrmApp, client);
                PayerNum = xrmApp.Entity.GetHeaderValue("accountnumber");


                //AddScreenShot(client, "Navigate To Payer");
                //AddScreenShot(client, "Create Payer");
                //AddScreenShot(client, "Get Payer Number");
                // LoginFinops.CheckFinopsAccounts(PayerNum);
            }, 2, 1000);
        }
        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Payer Number:" + PayerNum + "\r\n");

        }


    }
}

