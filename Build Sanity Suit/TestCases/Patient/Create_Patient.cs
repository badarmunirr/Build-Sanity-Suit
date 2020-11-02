﻿using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Build_Sanity_Suit
{

    [TestClass]
    public class A2_Create_Patient
    {

        [TestMethod, TestCategory("BuildAutomation")]
        public void A2_CreatePatient()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);

            CreateMethod.Patient(xrmApp, client);
            Variables.PatientNum = xrmApp.Entity.GetValue("mzk_patientmrn");


        }
        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A2_Create_Patient\r\n";
            Helper.LogRecord(Message + "Patient Number : " + Variables.PatientNum);
            Variables.cli.Browser.Driver.Close();
        }
    }
}

