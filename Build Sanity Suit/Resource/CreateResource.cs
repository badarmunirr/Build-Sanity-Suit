
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{
   // [TestClass]
    public class B11_Create_Resource
    {
        public static WebClient cli;
        CreateMethod Create = new CreateMethod();
        //meed to update user everytime
        [TestMethod, TestCategory("BuildAutomation")]
        public void B11_CreateResourceToAccountTypeEmployee()
        {

            LOGIN loginobj = new LOGIN();

            WebClient client = loginobj.RoleBasedLogin(usersetting.Admin, usersetting.pwd);

            XrmApp xrmApp = new XrmApp(client);

            Create.Resource(xrmApp,client);

            cli = client;


        }


        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - B11_Create_Resource---";
            Helper.LogRecord(Message);
            cli.Browser.Driver.Close();

        }

    }
}

