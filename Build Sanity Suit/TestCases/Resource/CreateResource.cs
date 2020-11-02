
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{
    [TestClass]
    public class B11_Create_Resource
    {

        [TestMethod, TestCategory("BuildAutomation")]
        public void B11_CreateResourceToAccountTypeEmployee()
        {
            WebClient client = DriverInitiazation.ClientndXrmAppInitialization();
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);
            
            LOGIN.RoleBasedLogin(xrmApp, client, Usersetting.Admin, Usersetting.pwd);

            HelperFunctions.Resource(xrmApp,client);

        }

        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - B11_Create_Resource---";
            HelperFunctions.LogRecord(Message);
            Variables.cli.Browser.Driver.Close();

        }

    }
}

