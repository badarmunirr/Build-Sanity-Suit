﻿
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Build_Sanity_Suit
{
    [TestClass]
    public class A3_Create_Payers : TestBase
    {
        public string PayerNum;
        public static WebClient client;
        [TestMethod, TestCategory("Sanity")]
        public void A3_CreatePayer()
        {

            client = loginobj.RoleBasedLogin(Usersetting.contractManager, Usersetting.pwd);
            XrmApp xrmApp = new XrmApp(client);
            CreateMethod.Payer(xrmApp, client);
            PayerNum = xrmApp.Entity.GetHeaderValue("accountnumber");





            //AddScreenShot(client, "Navigate To Payer");
            //AddScreenShot(client, "Create Payer");
            //AddScreenShot(client, "Get Payer Number");
            // LoginFinops.CheckFinopsAccounts(PayerNum);

        }
        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Payer Number:" + PayerNum + "\r\n");
            client.Browser.Driver.Close();
        }


    }
}

