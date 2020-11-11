using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Build_Sanity_Suit
{
     [TestClass]
    public class A1_Create_HealthCare:TestBase
    {
        public static WebClient cli;
        [TestMethod, TestCategory("Sanity")]
        public void A1_CreateProvider()
        {

            WebClient client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);

            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);

            CreateMethod.Provider(xrmApp, client);

            Variables.AccountNum = xrmApp.Entity.GetHeaderValue("accountnumber");
        }

        [TestCleanup]
        public void Teardown()
        {
            Cleanup("HealthCare Number:" + Variables.AccountNum + "\r\n",cli);
         
        }
    }


}

