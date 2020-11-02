
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Build_Sanity_Suit
{
    [TestClass]
    public class A3_Create_Payers
    {

        [TestMethod, TestCategory("BuildAutomation")]

        public void A3_CreatePayer()
        {
            WebClient client = DriverInitiazation.ClientndXrmAppInitialization();
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);

            LOGIN.RoleBasedLogin(xrmApp, client, Usersetting.OperationalManager, Usersetting.pwd);
            
            HelperFunctions.Payer(xrmApp,client);

            Variables.PayerNum = xrmApp.Entity.GetHeaderValue("accountnumber");
            
            xrmApp.ThinkTime(2000);


        }

        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A3_Create_Payers\r\n";
            HelperFunctions.LogRecord(Message + "Payer No : " + Variables.PayerNum);
            Variables.cli.Browser.Driver.Close();
        }
    }
}

