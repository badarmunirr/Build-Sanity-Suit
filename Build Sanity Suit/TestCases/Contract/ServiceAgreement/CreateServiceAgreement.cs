using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
   // [TestClass]
    public class A4_CreateServiceAgreements:TestBase
    {


        [TestMethod]
        public void A4_CreateService()
        {
           RoleBasedLogin(contractManager, pwd);

            ContractHelper.OtherInformation(xrmApp, client);
            ContractHelper.ServiceGeneral(xrmApp, client);
            ContractHelper.ContractDignosis(xrmApp, client);
            ContractHelper.ContractPriceList(xrmApp, client);

        }
        [TestMethod]
        public void A5_CreateWholesaleService()
        {
            RoleBasedLogin(contractManager, pwd);

            ContractHelper.OtherInformation(xrmApp, client);
            ContractHelper.WholesaleServiceGeneral(xrmApp, client);
            ContractHelper.ContractDignosis(xrmApp, client);
            ContractHelper.ContractPriceList(xrmApp, client);

        }
        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Service Agreement:" + "\r\n");
           
        }
    }
}

