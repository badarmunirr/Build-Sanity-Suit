using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Sanity_Suit
{
    public class PayerData
    {
        public int Noofrecords { get; set; }
        public string name { get; set; }
        public string accountnumber { get; set; }
        public string telephone1 { get; set; }
        public string emailaddress1 { get; set; }
        public string pspid { get; set; }
        public string mzk_vatnum { get; set; }
        public string mzk_accountcategory { get; set; }
        public string mzk_billingfrequency { get; set; }
        public string mzk_paymentterms { get; set; }
        public string patientlanguage { get; set; }
        public string address1_name { get; set; }
        public string address1_line1 { get; set; }
        public string address2_line1 { get; set; }
        public string primarycontactid { get; set; }
        public string preferdcontactmethod { get; set; }
        public string address2_name { get; set; }
    }
}
