
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Build_Sanity_Suit
{
    [TestClass]
    public class A3_Create_Payers
    {
        readonly LOGIN loginobj = new LOGIN();
        public TestContext TestContext { get; set; }
        [TestMethod, TestCategory("BuildAutomation")]

        public void A3_CreatePayer()
        {
 
            WebClient client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);

            CreateMethod.Payer(xrmApp, client);

            Variables.PayerNum = xrmApp.Entity.GetHeaderValue("accountnumber");

        }


        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\n" + TestContext.FullyQualifiedTestClassName + "\r\n" + TestContext.TestName + "\r\n" + TestContext.CurrentTestOutcome + "\r\n" + Variables.PayerNum + "\r\n ";
            Helper.LogRecord(Message + "Payer No : " + Variables.PayerNum);
          Variables.cli.Browser.Driver.Close();
        }
    }
}

