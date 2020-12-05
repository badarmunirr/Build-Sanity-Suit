using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
   // [TestClass]
    public class A9_CreateServiceAgreementWholeSales:TestBase
    {
        public static WebClient client;

        [TestMethod]
        public void A9_CreateWholesaleService()
        {
            client = loginobj.RoleBasedLogin(Usersetting.contractManager, Usersetting.pwd);
            XrmApp xrmApp = new XrmApp(client);

            ContractHelper.OtherInformation(xrmApp, client);
            ContractHelper.WholesaleServiceGeneral(xrmApp, client);
            ContractHelper.ContractDignosis(xrmApp, client);
            ContractHelper.ContractPriceList(xrmApp, client);


        }
        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Wholesale Service Agreement:" + "\r\n");
            client.Browser.Driver.Close();
        }
    }
}

