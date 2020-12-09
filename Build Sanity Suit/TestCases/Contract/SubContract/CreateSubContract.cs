﻿using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
   // [TestClass]
    public class A5_CreateSubContract:TestBase
    {
        public static WebClient client;
        [TestMethod]
        public void A5_CreateSub()
        {

            client = loginobj.RoleBasedLogin(Usersetting.contractManager, Usersetting.pwd);
            XrmApp xrmApp = new XrmApp(client);

            ContractHelper.OtherInformation(xrmApp, client);
            ContractHelper.SubGeneral(xrmApp, client);
            ContractHelper.ContractDignosis(xrmApp, client);
            ContractHelper.ContractPriceList(xrmApp, client);

        }

        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Sub Contract:" + "\r\n");
            client.Browser.Driver.Close();
        }
    }
}

