using AventStack.ExtentReports;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;

namespace Build_Sanity_Suit
{
    //[TestClass]
    public class A1_Create_HealthCare : TestBase
    {
        public string AccountNum;

        [TestMethod, TestCategory("Sanity")]
        public void A1_CreateProvider()
        {

            RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
            CreateMethod.Provider(xrmApp, client);
            AccountNum = xrmApp.Entity.GetHeaderValue("accountnumber");
          //  LoginFinops.CheckFinopsAccounts(AccountNum);
        }
       
        [TestCleanup]
        public void Teardown()
        {

            Cleanup("HealthCare Number:" + AccountNum + "\r\n");


        }
    }


}

