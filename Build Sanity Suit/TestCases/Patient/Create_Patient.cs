using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Build_Sanity_Suit
{

    [TestClass]
    public class A2_Create_Patient
    {

        [TestMethod, TestCategory("BuildAutomation")]
        public void A2_CreatePatient()
        {
            WebClient client = DriverInitiazation.ClientndXrmAppInitialization();
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);

            LOGIN.RoleBasedLogin(xrmApp, client, Usersetting.Admin, Usersetting.pwd);


            HelperFunctions.Patient(xrmApp, client);
            Variables.PatientNum = xrmApp.Entity.GetValue("mzk_patientmrn");


        }
        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A2_Create_Patient\r\n";
            HelperFunctions.LogRecord(Message + "Patient Number : " + Variables.PatientNum);
            Variables.cli.Browser.Driver.Close();
        }
    }
}


