﻿using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Build_Sanity_Suit
{

    [TestClass]
    public class A2_Create_Patient : TestBase
    {
        public static WebClient client;

        [TestMethod, TestCategory("Sanity")]
        public void A2_CreatePatient()
        {

            client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
            //AddScreenShot(client, "Navigate To Patient");
            XrmApp xrmApp = new XrmApp(client);
            CreateMethod.Patient(xrmApp, client);
            //AddScreenShot(client, "Create Patient");
            Variables.PatientNum = xrmApp.Entity.GetValue("mzk_patientmrn");
            //AddScreenShot(client, "Get Patient Number");
        }
        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Patient Number:" + Variables.PatientNum + "\r\n");
            client.Browser.Driver.Close();
        }
    }
}


