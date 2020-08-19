using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Build_Sanity_Suit
{
    //[TestClass]
    public class TestSuiteAzure
    {
        [TestMethod, TestCategory("BuildAutomation")]
        public void Executetest()
        {

            LOGIN loginobj = new LOGIN();
            Create_HealthCare newprovider = new Create_HealthCare();
            Create_Patient newpatient = new Create_Patient();
            Create_Payers newpayer = new Create_Payers();
            Create_ReferralstoDeliveryOrder newreferraltodelivry = new Create_ReferralstoDeliveryOrder();
            Create_WholesaleOrders newwholesaleorder = new Create_WholesaleOrders();
            Create_ReferralstoNurseOrder newreferraltonurseorder = new Create_ReferralstoNurseOrder();

            //Sanity 
            loginobj.Login();
            //newpatient.CreatePatient();
            //newprovider.CreateProvider();
            //newpayer.CreatePayer();
            //newwholesaleorder.CreateWholesaleOrder();
            //newreferraltodelivry.CreateReferral();
            //newreferraltonurseorder.CreateReferraltoNurseOrder();







        }
    }
}
