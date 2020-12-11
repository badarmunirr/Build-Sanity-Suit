using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Build_Sanity_Suit
{
   // [TestClass]
    public class A1_Create_HealthCare : TestBase
    {
        public  string AccountNum;
        public static WebClient client;
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
            Cleanup("HealthCare Number:" + AccountNum + "\r\n");
            client.Browser.Driver.Close();

        }
    }


}

