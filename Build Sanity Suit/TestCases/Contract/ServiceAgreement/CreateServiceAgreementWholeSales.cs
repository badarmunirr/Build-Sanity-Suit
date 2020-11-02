using System;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    //[TestClass]
    public class A9_CreateServiceAgreementWholeSales
    {


        [TestMethod]
        public void A9_CreateWholesaleService()
        {

            WebClient client = DriverInitiazation.ClientndXrmAppInitialization();
            Variables.cli = client;
            XrmApp xrmApp = new XrmApp(client);

            LOGIN.RoleBasedLogin(xrmApp, client, Usersetting.Admin, Usersetting.pwd);

             xrmApp.ThinkTime(4000);
             xrmApp.Navigation.OpenSubArea("Referral", "Contract Management");
             xrmApp.ThinkTime(2000);
             xrmApp.CommandBar.ClickCommand("New");
             xrmApp.ThinkTime(2000);
            var GeneralCreate = new Action(() =>
            {
                 xrmApp.Entity.SelectTab("General");
                 xrmApp.ThinkTime(5000);
                 xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contracttypevalue", Value = "Service Agreement" });
                 xrmApp.ThinkTime(5000);
                 xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contractstatus", Value = "Live" });
                 xrmApp.ThinkTime(5000);
                 xrmApp.Entity.SetValue("mzk_name", ServiceAgreementWholeSaleData.name);
                 xrmApp.ThinkTime(500);
                CreateMethod.Lookup("mzk_payer", ServiceAgreementWholeSaleData.payer, xrmApp, client);
                 xrmApp.ThinkTime(500);
                CreateMethod.Lookup("mzk_provider", ServiceAgreementWholeSaleData.provider, xrmApp, client);
                 xrmApp.ThinkTime(500);
                CreateMethod.Lookup("mzk_mastercontractagreement", ServiceAgreementWholeSaleData.mastercontractagreement, xrmApp, client);
                 xrmApp.ThinkTime(500);
                CreateMethod.Lookup("mzk_subcontract", ServiceAgreementWholeSaleData.subcontract, xrmApp, client);
                 xrmApp.ThinkTime(500);
                CreateMethod.Lookup("mzk_service", ServiceAgreementWholeSaleData.service, xrmApp, client);
                 xrmApp.ThinkTime(500);
                CreateMethod.Lookup("mzk_contractsubtype", ServiceAgreementWholeSaleData.contractsubtype, xrmApp, client);
                // xrmApp.ThinkTime(2000);
                // xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_pediatric", Value = "No" });
                // xrmApp.ThinkTime(2000);
                // xrmApp.Entity.SetValue("mzk_keycontractinformation", "mzk_keycontractinformation");
                DateTime startdate = DateTime.Today.AddDays(1);
                 xrmApp.Entity.SetValue("mzk_startdate", startdate, "dd/MM/yyyy");
                DateTime enddate = startdate.AddDays(2);
                 xrmApp.Entity.SetValue("mzk_enddate", enddate, "dd/MM/yyyy");
                DateTime issuedate = DateTime.Today.AddDays(1);
                 xrmApp.Entity.SetValue("mzk_issuedate", issuedate, "dd/MM/yyyy");
                //DateTime reviewdate = DateTime.Today.AddDays(1);
                // xrmApp.Entity.SetValue("mzk_reviewdate", reviewdate);
                 xrmApp.ThinkTime(2000);
                 xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_inherit", Value = "Yes" });
                // xrmApp.Entity.SetValue("mzk_description", "mzk_description");
                // xrmApp.Entity.SetValue("mzk_contractspecialinstructions", "mzk_contractspecialinstructions");
                // xrmApp.Entity.SetValue("mzk_frameworkreference", "mzk_frameworkreference");
                 xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_wholesalecontract", Value = ServiceAgreementWholeSaleData.WholeSale });
                 xrmApp.Entity.Save();
                 xrmApp.ThinkTime(1000);
                 xrmApp.Dialogs.ConfirmationDialog(true);
            });


            //Master pathways
            //var MasterPathwaysCreate = new Action(() =>
            //{
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.Entity.SelectTab("Master Pathways");
            //     xrmApp.ThinkTime(1000);
            //    // use this line to click on related grid
            //     xrmApp.Entity.SubGrid.ClickCommand("MasterPathway", "New Contract Master Pathway");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_masterpathway", "General Master Pathway");
            //     xrmApp.QuickCreate.Save();
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.Entity.Save();
            //});
            var OtherInformation = new Action(() =>
            {
                 xrmApp.Entity.SelectTab("Other Information");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_serviceoverview", "mzk_serviceoverview");
                //DateTime mzk_contractrenewaldate = DateTime.Today.AddDays(1);
                // xrmApp.Entity.SetValue("mzk_contractrenewaldate", mzk_contractrenewaldate);
                // xrmApp.ThinkTime(1000);

                // xrmApp.Entity.ClearValue("mzk_contractedkpissummary");
                // xrmApp.ThinkTime(500);
                // xrmApp.Entity.SetValue("mzk_contractedkpissummary", "mzk_contractedkpissummary");
                // xrmApp.Entity.SetValue("mzk_operationalkpissummary", "mzk_operationalkpissummary");
                // xrmApp.Entity.SetValue("mzk_stockterms", "mzk_stockterms");
                // xrmApp.Entity.SetValue("mzk_productcountryoforiginmanufacturer", "mzk_productcountryoforiginmanufacturer");
                 xrmApp.ThinkTime(1000);
                CreateMethod.Lookup("mzk_dispensinglocationwarehouse", ServiceAgreementWholeSaleData.dispensinglocationwarehouse, xrmApp, client);
                // xrmApp.Entity.SetValue("mzk_productsupplyroute", "mzk_productsupplyroute");
                // xrmApp.Entity.SetValue("mzk_logisticstermssummary", "mzk_logisticstermssummary");
                // xrmApp.Entity.SetValue("mzk_compoundingstorageneeds", "mzk_compoundingstorageneeds");
                // xrmApp.Entity.SetValue("mzk_pasterms", "mzk_pasterms");
                // xrmApp.Entity.SetValue("mzk_terminationterms", "mzk_terminationterms");
                // xrmApp.Entity.SetValue("mzk_tuperecruitment", "mzk_tuperecruitment");
                // xrmApp.Entity.SetValue("mzk_pvterms", "mzk_pvterms");
                // xrmApp.Entity.SetValue("mzk_paymentterms", "mzk_paymentterms");
                // xrmApp.Entity.SetValue("mzk_workingcapitalmanagementcreditordays", "2145");
                // xrmApp.Entity.SetValue("mzk_changeofcontrol", "mzk_changeofcontrol");
                // xrmApp.Entity.SetValue("mzk_debtreviewprocess", "mzk_debtreviewprocess");
                 xrmApp.ThinkTime(1000);
                CreateMethod.Lookup("mzk_orderreleasetype",ServiceAgreementWholeSaleData.orderreleasetype, xrmApp, client);
                // xrmApp.ThinkTime(2000);
                // xrmApp.Entity.SetValue("mzk_contractnoticeperioddays", "2");
                // xrmApp.ThinkTime(2000);
                // xrmApp.Entity.SetValue("mzk_contractualsreportingsummary", "mzk_contractualsreportingsummary");
                // xrmApp.ThinkTime(2000);
                ////Lookupobj.Lookup("mzk_therapyarea", "2");
                // xrmApp.ThinkTime(2000);
                // xrmApp.Entity.SetValue("mzk_contractbreakpointsfeereviews", "mzk_contractbreakpointsfeereviews");
                // xrmApp.ThinkTime(2000);
                // xrmApp.Entity.SetValue("mzk_servicecreditdetails", "mzk_servicecreditdetails");
                 xrmApp.Entity.Save();
                 xrmApp.ThinkTime(2000);
                 xrmApp.CommandBar.ClickCommand("Save & Close");
               


            });

            ////Contract Products and Services
            //var ContractProductServicesCreate = new Action(() =>
            //{
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.Entity.SelectTab("Contract Products and Services");
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.Entity.SubGrid.ClickCommand("ContractLines", "New Contract Line");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_product", productname);
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_fundingorganizationtype", Value = "Master Contract Party" });
            //     xrmApp.ThinkTime(500);
            //     xrmApp.QuickCreate.SetValue("mzk_quantity", "100");
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.QuickCreate.SetValue(new BooleanItem { Name = "mzk_keydrug", Value = true });
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_billingfrequency", Value = "Weekly" });
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.QuickCreate.SetValue("mzk_orderquantity", "2");
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.QuickCreate.Save();
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.Entity.Save();
            //});
            /////Contract SLA
            //var ContractSLA = new Action(() =>
            //{
            //     xrmApp.Entity.SelectTab("Contract SLA");
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_deliveryconfirmationmethod", Value = "PIN" });
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_capturegppracticedetailsatregistration", Value = true });
            //     xrmApp.ThinkTime(5000);
            //    Lookupobj.Lookup("mzk_purchaseordernumberonholdprescription", "A");
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_deliverypurchaseordersource", Value = "Delivery Date" });
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_accountmanagementchargings", Value = "Yes" });
            //     xrmApp.Entity.SetValue("mzk_bufferstockdays", "2");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_returnsresponsibility", "HaH");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_telephonecallschargingmodel", "Flat Rate");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_textmessagechargingmodel", "Flat Rate");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_nonstandardvisitdaycharging", "Yes");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_pvreportcharging", "Flat Rate");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_pqcreturnmodel", "HaH Collect and dispose");
            //     xrmApp.ThinkTime(1000);
            //    //Lookupobj.Lookup("mzk_prescriptionportalapprovalmethod", "HaH Collect and dispose");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_methodofpayment", "BACS");
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingreleases", Value = "Yes" });
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_patientculpabledeliveryfailurecharging", "Yes");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_patientregistrationcharging", "Yes");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_pvreportchargingmodel", "Flat Rate");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_contractreportingchargingmodel", "Flat Rate");
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_printcreditreasononcreditnote", Value = "Yes" });
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_invoiceconsolidationtype", Value = "Patient" });
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_billingreferencenumber", Value = true });
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_pharmacistscreeningonholdprescription", "Archive prescription");
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_invoicedeliverymethod", Value = "Email" });
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_invoicecurrency", "Pound Sterling");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_ancillaryitemscharging", "Yes");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_carebureaucallschargingmodel", "Activity Based");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_nonstandarddeliverydaycharging", "Yes");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_patientculpablevisitfailurecharging", "Yes");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_pqcreimbursementmodel", "Supplier Credit");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_medicaldevicechargingmodel", "Activity Based");
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_printcommentlinesoninvoice", Value = "Yes" });
            //     xrmApp.ThinkTime(3000);
            //     xrmApp.Entity.SubGrid.ClickCommand("VisitRules", "New Contract Visit Rule");
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_type", Value = "Wholesale Order" });
            //     xrmApp.ThinkTime(2000);
            //    Lookupobj.LookupQuickCreate("mzk_visittype", "Employee Visit type");
            //     xrmApp.ThinkTime(2000);
            //     xrmApp.QuickCreate.SetValue("mzk_allowedvisits", "2");
            //     xrmApp.ThinkTime(500);
            //     xrmApp.QuickCreate.Save();
            //     xrmApp.ThinkTime(3000);
            //     xrmApp.Entity.SubGrid.ClickCommand("DeliveryFrequency", "New Contract Delivery Frequency");
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.Entity.SetValue("mzk_frequency", "2");
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_unit", Value = "Days" });
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.CommandBar.ClickCommand("Save & Close");
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.Entity.SubGrid.ClickCommand("PurchaseOrderRules", "New Purchase Order Rule");
            //     xrmApp.ThinkTime(5000);
            //     xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_criteria", Value = "Blank" });
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.QuickCreate.SetValue("mzk_format", "mzk_format");
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.QuickCreate.SetValue("mzk_description", "mzk_description");
            //    // xrmApp.ThinkTime(1000);
            //    //DateTime mzk_effectivestartdate = DateTime.Today.AddDays(1);
            //    // xrmApp.QuickCreate.SetValue("mzk_effectivestartdate", mzk_effectivestartdate);
            //    // xrmApp.ThinkTime(1000);
            //    //DateTime mzk_effectiveenddate = DateTime.Today.AddDays(2);
            //    // xrmApp.QuickCreate.SetValue("mzk_effectiveenddate", mzk_effectiveenddate);
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.QuickCreate.Save();
            //     xrmApp.ThinkTime(3000);
            //     xrmApp.Entity.SubGrid.ClickCommand("ContractualKPICriterias", "New Contractual KPI Criteria");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_kpi", "A");
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.QuickCreate.SetValue("mzk_performancevalue", "2");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_kpiunit", "Number");
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.QuickCreate.Save();
            //     xrmApp.ThinkTime(3000);
            //     xrmApp.Entity.SubGrid.ClickCommand("DeliveryMethod", "New Contract Delivery Method");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.Lookup("mzk_deliverymethod", "INT");
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.CommandBar.ClickCommand("Save & Close");
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.Entity.Save();
            //     xrmApp.ThinkTime(1000);
            //});

            //// Contract Price List
            //var ContractPriceListCreate = new Action(() =>
            //{
            //     xrmApp.Entity.SelectTab("Contract Price Lists");
            //     xrmApp.ThinkTime(1000);
            //    // use this line to click on related grid
            //     xrmApp.Entity.SubGrid.ClickCommand("ContractPriceList", "New Contract Price List");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_contractpricelist", "Price01");
            //     xrmApp.ThinkTime(1000);
            //    Lookupobj.LookupQuickCreate("mzk_reducedpricelist", "Price01");
            //    //Lookupobj.LookupQuickCreate("mzk_contractdiagnosisgroup", "A010");
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.QuickCreate.Save();
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.Entity.Save();

            //});
            var ContractPriceListCreate = new Action(() =>
            {
                 xrmApp.Entity.SelectTab("Contract Price Lists");
                 xrmApp.ThinkTime(1000);
                // use this line to click on related grid
                 xrmApp.Entity.SubGrid.ClickCommand("ContractPriceList", "New Contract Price List");
                CreateMethod.LookupQuickCreate("mzk_contractpricelist", MasterContractData.contractpricelist, xrmApp);
                CreateMethod.LookupQuickCreate("mzk_reducedpricelist", MasterContractData.reducedpricelist, xrmApp);
                CreateMethod.LookupQuickCreate("mzk_contractdiagnosisgroup", MasterContractData.contractdiagnosisgroup, xrmApp);
                 xrmApp.ThinkTime(1000);
                 xrmApp.QuickCreate.Save();


                /*   xrmApp.Entity.SelectTab("Contract Price Lists");
                   xrmApp.ThinkTime(1000);
                  // use this line to click on related grid
                   xrmApp.Entity.SubGrid.ClickCommand("ContractPriceList", "New Contract Price List");
                   xrmApp.ThinkTime(1000);
                  Lookupobj.LookupQuickCreate("mzk_contractpricelist", "Price01");
                   xrmApp.ThinkTime(1000);
                  Lookupobj.LookupQuickCreate("mzk_reducedpricelist", "Price01");
                  //Lookupobj.LookupQuickCreate("mzk_contractdiagnosisgroup", "A010");
                   xrmApp.ThinkTime(1000);
                   xrmApp.QuickCreate.Save();
                   xrmApp.ThinkTime(1000);
                   xrmApp.Entity.Save();*/

            });

            // Contract Diagnosis Group
            var ContractDignosisCreate = new Action(() =>
            {
                 xrmApp.Entity.SelectTab("Contract Diagnosis Group");
                 xrmApp.ThinkTime(1000);
                // use this line to click on related grid
                 xrmApp.Entity.SubGrid.ClickCommand("ContractDiagnosisGroup_new_Grid", "New Contract Diagnosis Group");
                CreateMethod.LookupQuickCreate("mzk_operationaldiagnosisgroup", MasterContractData.operationaldiagnosisgroup, xrmApp);
                 xrmApp.ThinkTime(1000);
                 xrmApp.QuickCreate.Save();
                /*   xrmApp.Entity.SelectTab("Contract Diagnosis Group");
                   xrmApp.ThinkTime(1000);
                  // use this line to click on related grid
                   xrmApp.Entity.SubGrid.ClickCommand("ContractDiagnosisGroup_new_Grid", "New Contract Diagnosis Group");
                   xrmApp.ThinkTime(1500);
                  Lookupobj.Lookup("mzk_operationaldiagnosisgroup", "aHUS");
                   xrmApp.ThinkTime(1000);
                   xrmApp.CommandBar.ClickCommand("Save & Close");
                   xrmApp.ThinkTime(1000);
                  // xrmApp.ThinkTime(1000);
                  // xrmApp.Entity.SelectTab("General");
                  // xrmApp.ThinkTime(1000);
                  // xrmApp.Entity.SubGrid.ClickCommand("BillingAddress", "New Contract Billing Address");
                  // xrmApp.ThinkTime(1500);
                  ////Lookupobj.LookupQuickCreate("mzk_diagnosisgroup","aHus");
                  //// xrmApp.ThinkTime(3000);
                  ////Lookupobj.LookupQuickCreate("mzk_address", "Default address");
                  // xrmApp.QuickCreate.Save();
                   xrmApp.ThinkTime(1500);
                  */

            });
            //// Contract Diagnosis Group
            //var ContractDignosisCreate = new Action(() =>
            //{
            //     xrmApp.Entity.SelectTab("Contract Diagnosis Group");
            //     xrmApp.ThinkTime(1000);
            //    // use this line to click on related grid
            //     xrmApp.Entity.SubGrid.ClickCommand("ContractDiagnosisGroup_new_Grid", "New Contract Diagnosis Group");
            //     xrmApp.ThinkTime(1500);
            //    Lookupobj.Lookup("mzk_operationaldiagnosisgroup", "aHUS");
            //     xrmApp.ThinkTime(1000);
            //     xrmApp.CommandBar.ClickCommand("Save & Close");
            //     xrmApp.ThinkTime(1000);
            //    // xrmApp.ThinkTime(1000);
            //    // xrmApp.Entity.SelectTab("General");
            //    // xrmApp.ThinkTime(1000);
            //    // xrmApp.Entity.SubGrid.ClickCommand("BillingAddress", "New Contract Billing Address");
            //    // xrmApp.ThinkTime(1500);
            //    ////Lookupobj.LookupQuickCreate("mzk_diagnosisgroup","aHus");
            //    //// xrmApp.ThinkTime(3000);
            //    ////Lookupobj.LookupQuickCreate("mzk_address", "Default address");
            //    // xrmApp.QuickCreate.Save();
            //     xrmApp.ThinkTime(1500);

            //});

            ////InvoiceDeliveryCreate
            //var InvoiceDeliveryCreate = new Action(() =>
            //{
            //     xrmApp.Entity.SelectTab("Invoice Delivery");
            //     xrmApp.ThinkTime(3000);


            //    // xrmApp.Entity.SetValue(new MultiValueOptionSet
            //    //{
            //    //    Name = "mzk_invoice",
            //    //    Values = new string[] {"Egress","Trust SFTP"},
            //    //});

            //    // xrmApp.ThinkTime(1000);
            //    // xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_pod", Value = "Egress" });
            //    // xrmApp.ThinkTime(1000);
            //    // xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_posd", Value = "Egress" });
            //    // xrmApp.Entity.SetValue("mzk_workspacename", "mzk_workspacename");
            //    // xrmApp.ThinkTime(1000);
            //    // xrmApp.Entity.Save();

            //});

            // Other Information


            GeneralCreate();
            ContractDignosisCreate();
            ContractPriceListCreate();
            OtherInformation();
            // client.Browser.Driver.Navigate().Back();
            //MasterPathwaysCreate();
            //ContractProductServicesCreate();
            //ContractSLA();
            //ContractPriceListCreate();
            //ContractDignosisCreate();
            //InvoiceDeliveryCreate();


        }
        [TestCleanup]
        public void Teardown()
        {
            string Message = "\r\nTest Case ID - A9_CreateServiceAgreementWholeSales\r\n";
            Helper.LogRecord(Message + "Contract Number : ");
            Variables.cli.Browser.Driver.Close();
        }
    }
}

