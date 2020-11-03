
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{
    [TestClass]
    public class B11_Create_Resource
    {

        [TestMethod, TestCategory("BuildAutomation")]
        public void B11_CreateResourcetoAccountTypeEmployee()
        {

            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);

            CreateMethod.Resource(xrmApp,client);

        }

        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - B11_Create_Resource---";
            Helper.LogRecord(Message);
            Variables.cli.Browser.Driver.Close();

        }

    }
}

