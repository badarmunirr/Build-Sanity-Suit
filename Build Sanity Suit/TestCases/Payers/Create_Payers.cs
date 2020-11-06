
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Build_Sanity_Suit
{
    [TestClass]
    public class A3_Create_Payers :TestBase
    {

        [TestMethod, TestCategory("Sanity")]
        public void A3_CreatePayer()
        {

            WebClient client = loginobj.RoleBasedLogin(Usersetting.OperationalManager, Usersetting.pwd);
            Variables.cli = client;
            //AddScreenShot(client, "Navigate To Payer");
            //XrmApp xrmApp = new XrmApp(client);
            //CreateMethod.Payer(xrmApp, client);
            //AddScreenShot(client, "Create Payer");
            //Variables.PayerNum = xrmApp.Entity.GetHeaderValue("accountnumber");
            //AddScreenShot(client, "Get Payer Number");

        }
        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Payer Number:" + Variables.PayerNum + "\r\n");


        }


    }
}

