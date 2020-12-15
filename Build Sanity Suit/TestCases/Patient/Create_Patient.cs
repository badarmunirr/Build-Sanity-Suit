using AventStack.ExtentReports;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.IO;

namespace Build_Sanity_Suit
{

    [TestClass]
    public class A2CreatePatient : TestBase
    {
        public string PatientNum;


        [TestMethod, TestCategory("Sanity")]

        public void ACreatePatient()
        {
            //Retry(() =>
            //{
                RoleBasedLogin(Admin, pwd);
                CreateMethod.Patient(xrmApp, client);
                PatientNum = xrmApp.Entity.GetValue("mzk_patientmrn");
                //AddScreenShot(client, "Create Patient");
                //AddScreenShot(client, "Navigate To Patient");
                //AddScreenShot(client, "Get Patient Number");
                //  LoginFinops.CheckFinopsAccounts(PatientNum);
            //}, 2, 1000);
        }

        [TestMethod, TestCategory("Sanity")]
        public void BPatientView()
        {
            //Retry(() =>
            //{
                RoleBasedLogin(Admin, pwd);
                xrmApp.Navigation.OpenSubArea("Customers", "Patients");
                xrmApp.Grid.SwitchView("Patient");
                xrmApp.Grid.Search("Jake Hughes");
            //}, 2, 1000);
        }
        [TestCleanup]
        public void Teardown()
        {

            Cleanup("Patient Number:" + PatientNum + "\r\n");

        }
    }
}


