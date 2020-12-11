using System;

using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    //[TestClass]
    public class A6_CreateMasterContract: TestBase
    {
        public static WebClient client;

        [TestMethod]
        public void A6_CreateMaster()
        {
            client = loginobj.RoleBasedLogin(Usersetting.contractManager, Usersetting.pwd);
            XrmApp xrmApp = new XrmApp(client);
            ContractHelper.OtherInformation(xrmApp, client);
            ContractHelper.MasterGeneral(xrmApp, client);
            ContractHelper.ContractProductService(xrmApp, client);
            ContractHelper.ContractSLA(xrmApp, client);
            ContractHelper.ContractDignosis(xrmApp, client);
            ContractHelper.ContractPriceList(xrmApp, client);

        }

        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Master Contract:" + "\r\n");
            client.Browser.Driver.Close();
        }
    }
}

