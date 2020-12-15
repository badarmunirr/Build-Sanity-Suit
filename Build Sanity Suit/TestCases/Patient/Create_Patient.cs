using AventStack.ExtentReports;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;

namespace Build_Sanity_Suit
{

    [TestClass]
    public class A2_Create_Patient : TestBase
    {
        public string PatientNum;


        [TestMethod, TestCategory("Sanity")]
        public void A2_CreatePatient()
        {

            RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
            //AddScreenShot(client, "Navigate To Patient");

            CreateMethod.Patient(xrmApp, client);
            //AddScreenShot(client, "Create Patient");
            PatientNum = xrmApp.Entity.GetValue("mzk_patientmrn");
            //AddScreenShot(client, "Get Patient Number");
            //  LoginFinops.CheckFinopsAccounts(PatientNum);
        }

        [TestMethod, TestCategory("Sanity")]
        public void B2_PatientView()
        {
            RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
           
            xrmApp.Navigation.OpenSubArea("Customers", "Patients");
            xrmApp.Grid.SwitchView("Patient");
            xrmApp.Grid.Search("Jake Hughes");

        }
        [TestCleanup]
        public void Teardown()
        {

            Cleanup("Patient Number:" + PatientNum + "\r\n");

        }
    }
}


