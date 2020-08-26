using System;

namespace Build_Sanity_Suit
{

    public class Patientdata
    {
        public static int Noofrecords = 1;
        public static string title = "MR";
        public static string name = "Jake";
        public static string lname = "Hughes";
        public static string gender = "Male";
        public static string preferredname = "mzk_preferredname ";
        public static string motherifentification = "123";
        public static string familystatuscode = "Married";
        //public static string nationality = "USA";
        //public static string ethnicity = "White";
        //public static string race = "White";
        public static string language = "en-GB";
        public static string disability = "Vision Impairment";
        public static string patientinstruction = "Instruction";
        public static string medicalhistroy = "histroy";
        public static string legacyhahnumber = "123";
        public static string telephone1 = "123";
        public static string telephone2 = "124";
        public static string telephone3 = "125";
        public static string mobilephone = "126";
        public static string address1name = "home";
        public static string address2name = "Delivery";
        public static string address3name = "Treatment";
        public static string fulladdress = "10 Bridge Close ,BRISTOL, BS14";
        public static string emailpreferences = "Follow";
        public static string preferdcontactmethod = "Email";
        public static string survey = "Email";
    }
    public class Healthcareproviderdata
    {
        public static int Noofrecords = 1;
        public static string name = "HealthCare Provider ";
        public static string accountnumber = "acn12345";
        public static string telephone1 = "tp123";
        public static string fax = "fx123";
        public static string email = "abc@mazikglobal.com";
        public static string payer = "AKU Trust";
        public static string taxid = "123456";
        public static string category = "*a";
        public static string hospitalid = "hosID _123";
        public static string paymentterms = "E1";
        public static string patientlanguage = "en-GB";
        public static string address1name = "Default";
        public static string address2name = "Other";
        public static string fulladdress = "10 Bridge Close ,BRISTOL, BS14";
        //public static string primarycontactid = "Adam";
        public static string preferdcontactmethod = "Email";
        public static string priscriber = "*a";
        public static string multiplewards = "mzk_multiplewards";
        public static string sites = "mzk_sites";
        public static string department = "mzk_department";
    }
    public class Payerdata
    {
        public static int Noofrecords = 1;
        public static string name = "Payer Orgnization";
        public static string accountnumber = "12345";
        public static string telephone1 = "123";
        public static string email = "abc@mazikglobal.com";
        //public static string email2 = "mzk_aeemailaddress@mazikglobal.com";
        //public static string email3 = "mzk_pqcemailaddress@mazikglobal.com";
        public static string pspid = "123456";
        public static string vatnum = "123456";
        public static string accountcategory = "Organization";
        public static string billingfrequency = "Weekly Consolidated";
        public static string paymentterms = "E1";
        public static string patientlanguage = "en-GB";
        public static string address1name = "Default";
        public static string address2name = "Other";
        public static string fulladdress = "10 Bridge Close ,BRISTOL, BS14";
        public static string primarycontactid = "(Enegihoqv) Rajaeq Natgih";
        public static string preferdcontactmethod = "Email";
    }
    public class ReferraltodeliviryOrderdata
    {
        public static int Noofrefferal = 1;
        public static int NoofdeliveryOrder = 1;
        public static string PatientName = "Jake Hughes";
        public static string patientswitchstatus = "New Patient";
        public static string anonymousreference = "ARN -123";
        public static string hospitalreferencenumber = "HRN -123";
        public static string ReferalName = "Referral ";
        public static string diagnosisgroup = "Ankylosing Spondylitis";
        public static string nursingstatus = "Nursing completed";
        public static string PriceList = "PLMC000118";
        public static string ServiceAgreement = "BMA Service Agreement";
        //public static string MasterPathway = "General Master Pathway";
        public static string pmireferencenumber = "PMI _123";
        public static string billingreferencenumber = "BRN _123";
        public static string pmipolicynumber = "PPN _1234";
        public static string legacyreferralnumber = "LRN _1234";
        public static string workordertype = "Routine Delivery";
        public static string serviceterritory = "Scotland";
        public static string region = "North";
        public static string district = "North";
        public static string deliverymethods = "INT";
        public static string deliveryroute = "0102";
        public static string productname = "STERILE C/WOOL BALLS   D279";
        public static string unit = "EA";
        public static string qunantity = "1";
        //public static string servicename = "Clinical Call";
        //public static string casenumber = "CAS-197156-Q3Q5";
        public static string legacyordernumber = "LON-110";
        public static string contractdeliveryfrequency = "5 Days";
    }
    public class Wholesaleorderdata
    {
        public static int noofwholesaleorder = 7;
        public static string wholesaleordertype = "Wholesale Delivery";
        public static string prescriptionponumber = "PO-124";
        public static string district = "North";
        public static string contractname = "CON-SA-007011";
        public static string deliveryfrequency = "5 Days";
        public static string deliverymethods = "INT";
        public static string deliveryroute = "0101";
        public static string drivername = "James";
        public static string vanid = "1234";
        public static string visitnotes = "mzk_visitnotes";
        public static string drivercomments = "mzk_drivercomments";
        public static string productname = "IMRALDI PEN SINGLE REPLACEMENT";
        public static string unit = "EA";
        public static string qunantity = "5";
        public static string servicename = "Clinical Call";
    }
    public class ReferraltoNurseOrderdata
    {
        public static int Noofrefferal = 1;
        public static int NoofnurseOrder = 1;
        public static string PatientName = "Jake Hughes";
        public static string patientswitchstatus = "New Patient";
        public static string anonymousreference = "ARN -123";
        public static string hospitalreferencenumber = "HRN -123";
        public static string ReferalName = "Referral ";
        public static string diagnosisgroup = "Ankylosing Spondylitis";
        public static string nursingstatus = "Nursing completed";
        public static string PriceList = "PLMC000118";
        public static string ServiceAgreement = "BMA Service Agreement";
        //public static string MasterPathway = "General Master Pathway";
        public static string pmireferencenumber = "PMI _123";
        public static string billingreferencenumber = "BRN _123";
        public static string pmipolicynumber = "PPN _1234";
        public static string legacyreferralnumber = "LRN _1234";
        public static string workordertype = "5FU Pump Needle Change";
        public static string district = "North";
        public static string servicename = "Delivery Fee";
        public static string unit = "EA";
        public static string qunantity = "1";

    }
    public class MasterContractData
    {
        //Date
        public static DateTime startdate = DateTime.Today.AddDays(1);
        public static DateTime enddate = startdate.AddDays(365);
        public static DateTime issuedate = DateTime.Today.AddDays(1);
        //General
        public static string contractName = "Master Contract";
        public static string contractingParty = "AbbVie UK";
        public static string service = "Aspergillosis";
        public static string contractSubtype = "MC - HAH Funded";

        //Contract Products and Services
        public static string product = "PRO-001178";
        public static string serviceName = "Delivery Fee";

        public static string maxQty = "2";
        public static string orderQty = "100";
        //SLA
        public static string bufferstockdays = "2";
        public static string returnsresponsibility = "HaH";
        public static string telephonecallschargingmodel = "Flat Rate";
        public static string textmessagechargingmodel = "Flat Rate";
        public static string nonstandardvisitdaycharging = "Yes";
        public static string pvreportcharging = "Flat Rate";
        public static string pqcreturnmodel = "HaH Collect and dispose";
        public static string methodofpayment = "BACS";
        public static string patientculpabledeliveryfailurecharging = "Yes";
        public static string patientregistrationcharging = "Yes";
        public static string pvreportchargingmodel = "Flat Rate";
        public static string contractreportingchargingmodel = "Flat Rate";

        public static string invoicecurrency = "Pound Sterling";
        public static string ancillaryitemscharging = "Yes";
        public static string carebureaucallschargingmodel = "Activity Based";
        public static string nonstandarddeliverydaycharging = "Yes";
        public static string patientculpablevisitfailurecharging = "Yes";

        public static string pqcreimbursementmodel = "Supplier Credit";
        public static string medicaldevicechargingmodel = "Activity Based";

        public static string visittype = "5FU Visit";
        public static string allowedvisits = "2";

        public static string frequency = "2";
        public static string format = "mzk_format";
        public static string description = "mzk_description";

        public static string performancevalue = "2";
        public static string kpi = "Credits Issued";
        public static string kpiunit = "Days";
        public static string deliverymethod = "INT";


        // Contract Diagnosis Group
        public static string operationaldiagnosisgroup = "aHUS";
        // Contract Price List
        public static string contractpricelist = "ESD Rate Card";
        public static string reducedpricelist = "ESD Rate Card";
        public static string contractdiagnosisgroup = operationaldiagnosisgroup;

        // Other Information
        public static string mzk_dispensinglocationwarehouse = "107";
        public static string mzk_orderreleasetype = "BULK";

    }
    public class SubContractData
    {
        //General
        public static string SubContract = "Sub Contract";
        public static string payer = "1st Assist Group Limited";
        public static string mastercontractagreement = MasterContractData.contractName;
        public static string contractsubtype = "MC - NHS Funded";
        // Other Information
        public static string dispensinglocationwarehouse = "107";
        public static string orderreleasetype = "BULK";


    }
    public class ServiceAgreementData
    {
        //General
        public static bool WholeSale = false;

        public static string name = "Service Agreement";
        public static string payer = "1st Assist Group Limited";

        public static string provider = "1 Harley Street";
        public static string mastercontractagreement = MasterContractData.contractName;

        public static string subcontract = SubContractData.SubContract;
        public static string service = "Adempas";

        public static string contractsubtype = "MC - NHS Funded";


        // Other Information
        public static string dispensinglocationwarehouse = "107";
        public static string orderreleasetype = "BULK";


    }
    public class ServiceAgreementWholeSaleData
    {
        //General
        public static bool WholeSale = true;

        public static string name = "Service Agreement Wholesale";
        public static string payer = "1st Assist Group Limited";

        public static string provider = "1 Harley Street";
        public static string mastercontractagreement = MasterContractData.contractName;

        public static string subcontract = SubContractData.SubContract;
        public static string service = "Adempas";

        public static string contractsubtype = "MC - NHS Funded";


        // Other Information
        public static string dispensinglocationwarehouse = "107";
        public static string orderreleasetype = "BULK";


    }
}
