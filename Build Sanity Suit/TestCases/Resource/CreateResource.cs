using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace Build_Sanity_Suit
{
   // [TestClass]
    public class B11_Create_Resource:TestBase
    {
    
        [TestMethod, TestCategory("Sanity")]
        public void B11_CreateResourcetoAccountTypeEmployee()
        {

            RoleBasedLogin(Admin, pwd);
            CreateMethod.Resource(xrmApp,client);

        }

        [TestCleanup]
        public void Teardown()
        {
            Cleanup("Bookable Resource");
            client.Browser.Driver.Close();
          
        }
    }
}

