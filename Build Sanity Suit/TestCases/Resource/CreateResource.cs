using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{
    [TestClass]
    public class B11_Create_Resource:TestBase
    {
        public static WebClient client;
        [TestMethod, TestCategory("Sanity")]
        public void B11_CreateResourcetoAccountTypeEmployee()
        {

            LOGIN loginobj = new LOGIN();
            client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);

            XrmApp xrmApp = new XrmApp(client);

            CreateMethod.Resource(xrmApp,client);

        }

        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Bookable Resource");
            client.Browser.Driver.Close();
          
        }
    }
}

