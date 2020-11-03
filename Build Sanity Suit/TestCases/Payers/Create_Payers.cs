
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
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);
            CreateMethod.Payer(xrmApp, client);
            Variables.PayerNum = xrmApp.Entity.GetHeaderValue("accountnumber");

        }


        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A3_Create_Payers\r\n";
            Helper.LogRecord(Message + "Payer No : " + Variables.PayerNum);
            Variables.cli.Browser.Driver.Close();
        }
    }
}

