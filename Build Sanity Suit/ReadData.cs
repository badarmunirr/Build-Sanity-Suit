using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Sanity_Suit
{
    public class ReadData
    {
        public PatientData PatientData { get; set; }
        public HealthCareProviderData HealthCareProviderData { get; set; }
        public PayerData PayerData { get; set; }
        public ReferraltodeliviryOrderData ReferraltodeliviryOrderData { get; set; }
        public ReferralstoNurseOrderData ReferralstoNurseOrderData { get; set; }
        public ResourceData ResourceData { get; set; }
        public WholesaleOrderData WholesaleOrderData{ get; set; }
        public EmployeeOrderData EmployeeOrderData { get; set; }
        public TstManualInvoice19273Data TstManualInvoice_19273Data { get; set; }
        public TstManualInvoice19346Data TstManualInvoice_19346Data { get; set; }
        public TstManualInvoice19347Data TstManualInvoice_19347Data { get; set; }
        public TstManualInvoice19348Data TstManualInvoice_19348Data { get; set; }
        //public ReferralData referralData { get; set; }
        //public VisitRuleData visitRuleData { get; set; }
        //public WorkOrderData workOrderData { get; set; }
        //public WorkOrderProductData workOrderProductData { get; set; }
        //public WorkOrderServiceData workOrderServiceData { get; set; }
        //public WorkOrderStatusManagementData workOrderStatusManagementData { get; set; }
    }
}
