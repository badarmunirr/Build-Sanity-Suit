using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Build_Sanity_Suit
{

    public class CreateSubContract
    {

        public void Create(string contractname, string productname)
        {


            HelperFunction Lookupobj = new HelperFunction();
            global.xrmApp.Navigation.OpenSubArea("Referral", "Contract Management");
            global.xrmApp.ThinkTime(2000);
            global.xrmApp.CommandBar.ClickCommand("New");
            global.xrmApp.ThinkTime(2000);

            var GeneralCreate = new Action(() =>
            {
                global.xrmApp.Entity.SelectTab("General");
                global.xrmApp.ThinkTime(5000);
                global.xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contracttypevalue", Value = "Sub-Contract" });
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contractstatus", Value = "Live" });
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_name", contractname);
                global.xrmApp.ThinkTime(500);
                Lookupobj.Lookup("mzk_payer", "AKU Trust");
                global.xrmApp.ThinkTime(500);
                Lookupobj.Lookup("mzk_mastercontractagreement", "CON");
                global.xrmApp.ThinkTime(500);
                Lookupobj.Lookup("mzk_service", "Ajovy");
                global.xrmApp.ThinkTime(500);
                Lookupobj.Lookup("mzk_contractsubtype", "MC - NHS Funded");
                global.xrmApp.ThinkTime(500);
                global.xrmApp.Entity.SetValue("mzk_keycontractinformation", "mzk_keycontractinformation");
                global.xrmApp.ThinkTime(500);
                DateTime startdate = DateTime.Today.AddDays(1);
                global.xrmApp.Entity.SetValue("mzk_startdate", startdate);
                global.xrmApp.ThinkTime(500);
                DateTime enddate = startdate.AddDays(2);
                global.xrmApp.Entity.SetValue("mzk_enddate", enddate);
                global.xrmApp.ThinkTime(500);
                DateTime issuedate = DateTime.Today.AddDays(1);
                global.xrmApp.Entity.SetValue("mzk_issuedate", issuedate);
                global.xrmApp.ThinkTime(500);
                DateTime reviewdate = DateTime.Today.AddDays(1);
                global.xrmApp.Entity.SetValue("mzk_reviewdate", reviewdate);
                global.xrmApp.ThinkTime(500);
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_inherit", Value = "Yes" });
                global.xrmApp.ThinkTime(500);
                global.xrmApp.Entity.SetValue("mzk_description", "mzk_description");
                global.xrmApp.ThinkTime(500);
                global.xrmApp.Entity.SetValue("mzk_contractspecialinstructions", "mzk_contractspecialinstructions");
                global.xrmApp.ThinkTime(500);
                global.xrmApp.Entity.SetValue("mzk_frameworkreference", "mzk_frameworkreference");
                global.xrmApp.Entity.Save();
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Dialogs.ConfirmationDialog(true);
            });

            // Other Information
            var OtherInformation = new Action(() =>
            {
                global.xrmApp.ThinkTime(2000);
                global.xrmApp.Entity.SelectTab("Other Information");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_serviceoverview", "mzk_serviceoverview");
                global.xrmApp.ThinkTime(1000);
                DateTime mzk_contractrenewaldate = DateTime.Today.AddDays(1);
                global.xrmApp.Entity.SetValue("mzk_contractrenewaldate", mzk_contractrenewaldate);
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.ClearValue("mzk_contractedkpissummary");
                global.xrmApp.Entity.SetValue("mzk_contractedkpissummary", "mzk_contractedkpissummary");
                global.xrmApp.ThinkTime(500);
                global.xrmApp.Entity.SetValue("mzk_operationalkpissummary", "mzk_operationalkpissummary");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_stockterms", "mzk_stockterms");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_productcountryoforiginmanufacturer", "mzk_productcountryoforiginmanufacturer");
                global.xrmApp.ThinkTime(1000);
                Lookupobj.Lookup("mzk_dispensinglocationwarehouse", "107");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_productsupplyroute", "mzk_productsupplyroute");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_logisticstermssummary", "mzk_logisticstermssummary");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_compoundingstorageneeds", "mzk_compoundingstorageneeds");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_pasterms", "mzk_pasterms");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_terminationterms", "mzk_terminationterms");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_tuperecruitment", "mzk_tuperecruitment");
                global.xrmApp.ThinkTime(2000);
                global.xrmApp.Entity.SetValue("mzk_pvterms", "mzk_pvterms");
                global.xrmApp.ThinkTime(2000);
                global.xrmApp.Entity.SetValue("mzk_paymentterms", "mzk_paymentterms");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_workingcapitalmanagementcreditordays", "2145");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_changeofcontrol", "mzk_changeofcontrol");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SetValue("mzk_debtreviewprocess", "mzk_debtreviewprocess");
                global.xrmApp.ThinkTime(1000);
                Lookupobj.Lookup("mzk_orderreleasetype", "BULK");
                global.xrmApp.ThinkTime(2000);
                global.xrmApp.Entity.SetValue("mzk_contractnoticeperioddays", "2");
                global.xrmApp.ThinkTime(2000);
                global.xrmApp.Entity.SetValue("mzk_contractualsreportingsummary", "mzk_contractualsreportingsummary");
                global.xrmApp.ThinkTime(2000);
                //Lookupobj.Lookup("mzk_therapyarea", "2");
                global.xrmApp.ThinkTime(2000);
                global.xrmApp.Entity.SetValue("mzk_contractbreakpointsfeereviews", "mzk_contractbreakpointsfeereviews");
                global.xrmApp.ThinkTime(2000);
                global.xrmApp.Entity.SetValue("mzk_servicecreditdetails", "mzk_servicecreditdetails");
                global.xrmApp.Entity.Save();
            });
            
            
            ////Master pathways
            //var MasterPathwaysCreate = new Action(() =>
            //{
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.Entity.SelectTab("Master Pathways");
            //    global.xrmApp.ThinkTime(1000);
            //    // use this line to click on related grid
            //    global.xrmApp.Entity.SubGrid.ClickCommand("MasterPathway", "New Contract Master Pathway");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_masterpathway", "General Master Pathway");
            //    global.xrmApp.QuickCreate.Save();
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.Entity.Save();
            //});

            ////Contract Products and Services
            //var ContractProductServicesCreate = new Action(() =>
            //{
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.Entity.SelectTab("Contract Products and Services");
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.Entity.SubGrid.ClickCommand("ContractLines", "New Contract Line");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_product", productname);
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_fundingorganizationtype", Value = "Master Contract Party" });
            //    global.xrmApp.ThinkTime(500);
            //    global.xrmApp.QuickCreate.SetValue("mzk_quantity", "100");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.QuickCreate.SetValue(new BooleanItem { Name = "mzk_keydrug", Value = true });
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_billingfrequency", Value = "Weekly" });
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.QuickCreate.SetValue("mzk_orderquantity", "2");
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.QuickCreate.Save();
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.Entity.Save();
            //});
            /////Contract SLA
            //var ContractSLA = new Action(() =>
            //{
            //    global.xrmApp.Entity.SelectTab("Contract SLA");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_deliveryconfirmationmethod", Value = "PIN" });
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_capturegppracticedetailsatregistration", Value = true });
            //    global.xrmApp.ThinkTime(5000);
            //    Lookupobj.Lookup("mzk_purchaseordernumberonholdprescription", "A");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_deliverypurchaseordersource", Value = "Delivery Date" });
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_accountmanagementchargings", Value = "Yes" });
            //    global.xrmApp.Entity.SetValue("mzk_bufferstockdays", "2");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_returnsresponsibility", "HaH");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_telephonecallschargingmodel", "Flat Rate");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_textmessagechargingmodel", "Flat Rate");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_nonstandardvisitdaycharging", "Yes");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_pvreportcharging", "Flat Rate");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_pqcreturnmodel", "HaH Collect and dispose");
            //    global.xrmApp.ThinkTime(1000);
            //    //Lookupobj.Lookup("mzk_prescriptionportalapprovalmethod", "HaH Collect and dispose");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_methodofpayment", "BACS");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingreleases", Value = "Yes" });
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_patientculpabledeliveryfailurecharging", "Yes");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_patientregistrationcharging", "Yes");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_pvreportchargingmodel", "Flat Rate");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_contractreportingchargingmodel", "Flat Rate");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_printcreditreasononcreditnote", Value = "Yes" });
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_invoiceconsolidationtype", Value = "Patient" });
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_billingreferencenumber", Value = true });
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_pharmacistscreeningonholdprescription", "Archive prescription");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_invoicedeliverymethod", Value = "Email" });
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_invoicecurrency", "Pound Sterling");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_ancillaryitemscharging", "Yes");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_carebureaucallschargingmodel", "Activity Based");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_nonstandarddeliverydaycharging", "Yes");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_patientculpablevisitfailurecharging", "Yes");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_pqcreimbursementmodel", "Supplier Credit");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_medicaldevicechargingmodel", "Activity Based");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_printcommentlinesoninvoice", Value = "Yes" });
            //    global.xrmApp.ThinkTime(3000);
            //    global.xrmApp.Entity.SubGrid.ClickCommand("VisitRules", "New Contract Visit Rule");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_type", Value = "Wholesale Order" });
            //    global.xrmApp.ThinkTime(2000);
            //    Lookupobj.LookupQuickCreate("mzk_visittype", "Employee Visit type");
            //    global.xrmApp.ThinkTime(2000);
            //    global.xrmApp.QuickCreate.SetValue("mzk_allowedvisits", "2");
            //    global.xrmApp.ThinkTime(500);
            //    global.xrmApp.QuickCreate.Save();
            //    global.xrmApp.ThinkTime(3000);
            //    global.xrmApp.Entity.SubGrid.ClickCommand("DeliveryFrequency", "New Contract Delivery Frequency");
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.Entity.SetValue("mzk_frequency", "2");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_unit", Value = "Days" });
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.CommandBar.ClickCommand("Save & Close");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SubGrid.ClickCommand("PurchaseOrderRules", "New Purchase Order Rule");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_criteria", Value = "Blank" });
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.QuickCreate.SetValue("mzk_format", "mzk_format");
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.QuickCreate.SetValue("mzk_description", "mzk_description");
            //    //global.xrmApp.ThinkTime(1000);
            //    //DateTime mzk_effectivestartdate = DateTime.Today.AddDays(1);
            //    //global.xrmApp.QuickCreate.SetValue("mzk_effectivestartdate", mzk_effectivestartdate);
            //    //global.xrmApp.ThinkTime(1000);
            //    //DateTime mzk_effectiveenddate = DateTime.Today.AddDays(2);
            //    //global.xrmApp.QuickCreate.SetValue("mzk_effectiveenddate", mzk_effectiveenddate);
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.QuickCreate.Save();
            //    global.xrmApp.ThinkTime(3000);
            //    global.xrmApp.Entity.SubGrid.ClickCommand("ContractualKPICriterias", "New Contractual KPI Criteria");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_kpi", "A");
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.QuickCreate.SetValue("mzk_performancevalue", "2");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_kpiunit", "Number");
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.QuickCreate.Save();
            //    global.xrmApp.ThinkTime(3000);
            //    global.xrmApp.Entity.SubGrid.ClickCommand("DeliveryMethod", "New Contract Delivery Method");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_deliverymethod", "INT");
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.CommandBar.ClickCommand("Save & Close");
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.Entity.Save();
            //    global.xrmApp.ThinkTime(1000);
            //});

            //// Contract Price List
            //var ContractPriceListCreate = new Action(() =>
            //{
            //    global.xrmApp.Entity.SelectTab("Contract Price Lists");
            //    global.xrmApp.ThinkTime(1000);
            //    // use this line to click on related grid
            //    global.xrmApp.Entity.SubGrid.ClickCommand("ContractPriceList", "New Contract Price List");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_contractpricelist", "Price01");
            //    global.xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_reducedpricelist", "Price01");
            //    //Lookupobj.LookupQuickCreate("mzk_contractdiagnosisgroup", "A010");
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.QuickCreate.Save();
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.Entity.Save();

            //});

            //// Contract Diagnosis Group
            //var ContractDignosisCreate = new Action(() =>
            //{
            //    global.xrmApp.Entity.SelectTab("Contract Diagnosis Group");
            //    global.xrmApp.ThinkTime(1000);
            //    // use this line to click on related grid
            //    global.xrmApp.Entity.SubGrid.ClickCommand("ContractDiagnosisGroup_new_Grid", "New Contract Diagnosis Group");
            //    global.xrmApp.ThinkTime(1500);
            //    Lookupobj.Lookup("mzk_operationaldiagnosisgroup", "aHUS");
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.CommandBar.ClickCommand("Save & Close");
            //    global.xrmApp.ThinkTime(1000);
            //    //global.xrmApp.ThinkTime(1000);
            //    //global.xrmApp.Entity.SelectTab("General");
            //    //global.xrmApp.ThinkTime(1000);
            //    //global.xrmApp.Entity.SubGrid.ClickCommand("BillingAddress", "New Contract Billing Address");
            //    //global.xrmApp.ThinkTime(1500);
            //    ////Lookupobj.LookupQuickCreate("mzk_diagnosisgroup","aHus");
            //    ////global.xrmApp.ThinkTime(3000);
            //    ////Lookupobj.LookupQuickCreate("mzk_address", "Default address");
            //    //global.xrmApp.QuickCreate.Save();
            //    global.xrmApp.ThinkTime(1500);

            //});

            ////InvoiceDeliveryCreate
            //var InvoiceDeliveryCreate = new Action(() =>
            //{
            //    global.xrmApp.Entity.SelectTab("Invoice Delivery");
            //    global.xrmApp.ThinkTime(3000);


            //    //global.xrmApp.Entity.SetValue(new MultiValueOptionSet
            //    //{
            //    //    Name = "mzk_invoice",
            //    //    Values = new string[] {"Egress","Trust SFTP"},
            //    //});

            //    //global.xrmApp.ThinkTime(1000);
            //    //global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_pod", Value = "Egress" });
            //    //global.xrmApp.ThinkTime(1000);
            //    //global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_posd", Value = "Egress" });
            //    //global.xrmApp.Entity.SetValue("mzk_workspacename", "mzk_workspacename");
            //    //global.xrmApp.ThinkTime(1000);
            //    //global.xrmApp.Entity.Save();

            //});



            ////childcontractgeneral
            //var childcontractgeneral = new Action(() =>
            //{
            //    global.xrmApp.ThinkTime(2000);
            //    global.xrmApp.Entity.SelectTab("General");
            //    global.xrmApp.ThinkTime(5000);
            //    global.xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contracttypevalue", Value = "Service Agreement" });
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contractstatus", Value = "Live" });
            //    global.xrmApp.ThinkTime(1000);
            //    //General form  
            //    //fields section
            //    global.xrmApp.Entity.SetValue("mzk_name", "Service Agreement");
            //    global.xrmApp.ThinkTime(500);
            //    Lookupobj.Lookup("mzk_payer", "B");
            //    global.xrmApp.ThinkTime(500);
            //    Lookupobj.Lookup("mzk_provider", "A");
            //    global.xrmApp.ThinkTime(500);
            //    Lookupobj.Lookup("mzk_mastercontractagreement", "CON");
            //    global.xrmApp.ThinkTime(500);
            //    global.xrmApp.ThinkTime(500);
            //    Lookupobj.Lookup("mzk_service", "Adempas");
            //    global.xrmApp.ThinkTime(500);
            //    Lookupobj.Lookup("mzk_contractsubtype", "MC - NHS Funded");
            //    global.xrmApp.ThinkTime(500);
            //    global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_pediatric", Value = "Yes" });
            //    global.xrmApp.Entity.SetValue("mzk_keycontractinformation", "mzk_keycontractinformation");

            //    //date section
            //    DateTime startdate = DateTime.Today.AddDays(1);
            //    global.xrmApp.Entity.SetValue("mzk_startdate", startdate);
            //    DateTime enddate = startdate.AddDays(2);
            //    global.xrmApp.Entity.SetValue("mzk_enddate", enddate);
            //    DateTime issuedate = DateTime.Today.AddDays(1);
            //    global.xrmApp.Entity.SetValue("mzk_issuedate", issuedate);
            //    DateTime reviewdate = DateTime.Today.AddDays(1);
            //    global.xrmApp.Entity.SetValue("mzk_reviewdate", reviewdate);
            //    global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_inherit", Value = "Yes" });
            //    global.xrmApp.Entity.SetValue("mzk_description", "mzk_description");
            //    global.xrmApp.Entity.SetValue("mzk_contractspecialinstructions", "mzk_contractspecialinstructions");
            //    global.xrmApp.Entity.SetValue("mzk_frameworkreference", "mzk_frameworkreference");
            //    global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_wholesalecontract", Value = true });
            //    global.xrmApp.Entity.Save();
            //    global.xrmApp.ThinkTime(1000);
            //    global.xrmApp.Dialogs.ConfirmationDialog(true);
            //});

            ////ChildContractCreate
            //var ChildContractCreate = new Action(() =>
            //{
            //    global.xrmApp.Entity.SelectTab("Child Contracts");
            //    global.xrmApp.ThinkTime(4000);
            //    global.xrmApp.Entity.SubGrid.ClickCommand("ChildContractsSub", "New Contract Management");
            //    global.xrmApp.ThinkTime(1000);
            //    childcontractgeneral();
            //    ContractPriceListCreate();
            //    ContractDignosisCreate();
            //    OtherInformation();
            //    ContractProductServicesCreate();
            //    global.xrmApp.ThinkTime(1000);
            //    global.client.Browser.Driver.Navigate().Back();
            //    global.xrmApp.ThinkTime(1000);
            //    global.client.Browser.Driver.Navigate().Back();
            //    global.xrmApp.ThinkTime(1000);
            //    global.client.Browser.Driver.Navigate().Back();
            //    global.xrmApp.ThinkTime(1000);
            //    global.client.Browser.Driver.Navigate().Back();                
            //    //InvoiceDeliveryCreate();
            //    //MasterPathwaysCreate();
            //    //ContractSLA();
            //});

            GeneralCreate();
            OtherInformation();
            //MasterPathwaysCreate();
            //ContractProductServicesCreate();
            //ContractSLA();
            //ContractPriceListCreate();
            //ContractDignosisCreate();
            //ChildContractCreate();
            ////InvoiceDeliveryCreate();

        }
    }
}

