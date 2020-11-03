using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Build_Sanity_Suit
{
     [TestClass]
    public class A1_Create_HealthCare
    {
        [TestMethod, TestCategory("BuildAutomation")]
        public void A1_CreateProvider()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);
            CreateMethod.Provider(xrmApp, client);
            Variables.AccountNum = xrmApp.Entity.GetHeaderValue("accountnumber");
        }

        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A1_Create_HealthCare\r\n";
            Helper.LogRecord(Message + "HealthCare Provider Number : " + Variables.AccountNum);
            Variables.cli.Browser.Driver.Close();
        }
    }


}

