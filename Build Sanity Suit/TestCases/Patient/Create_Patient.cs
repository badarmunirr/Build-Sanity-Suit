﻿using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Build_Sanity_Suit
{

    [TestClass]
    public class A2_Create_Patient : TestBase
    {

        [TestMethod, TestCategory("Sanity")]
        public void A2_CreatePatient()
        {

            WebClient client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);

            CreateMethod.Patient(xrmApp, client);
            Variables.PatientNum = xrmApp.Entity.GetValue("mzk_patientmrn");

        }
        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Patient Number:" + Variables.PatientNum + "\r\n");

        }
    }
}


