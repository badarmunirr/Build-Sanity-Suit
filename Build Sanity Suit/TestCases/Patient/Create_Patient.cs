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
        public  WebClient client=null;

        [TestMethod, TestCategory("Sanity")]
        public void A2_CreatePatient()
        {

            client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
            //AddScreenShot(client, "Navigate To Patient");
            XrmApp xrmApp = new XrmApp(client);
            CreateMethod.Patient(xrmApp, client);
            //AddScreenShot(client, "Create Patient");
            PatientNum = xrmApp.Entity.GetValue("mzk_patientmrn");
            //AddScreenShot(client, "Get Patient Number");
            //  LoginFinops.CheckFinopsAccounts(PatientNum);
        }

        [TestMethod, TestCategory("Sanity")]
        public void B2_PatientView()
        {
            client = loginobj.RoleBasedLogin(Usersetting.Admin, Usersetting.pwd);
            XrmApp xrmApp = new XrmApp(client);
            xrmApp.Navigation.OpenSubArea("Customers", "Patients");
            xrmApp.Grid.SwitchView("Patient");
            xrmApp.Grid.Search("Jake Hughes");

        }
        [TestCleanup]
        public void Teardown()
        {
            Screenshot ss = ((ITakesScreenshot)client.Browser.Driver).GetScreenshot();
            string path = Directory.GetCurrentDirectory() + TestContext.TestName + ".png";
            ss.SaveAsFile(path);
            this.TestContext.AddResultFile(path);
            Cleanup("Patient Number:" + PatientNum + "\r\n");
            client.Browser.Driver.Close();
            client.Browser.Driver.Quit();
        }
    }
}


