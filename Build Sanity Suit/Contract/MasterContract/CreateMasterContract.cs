using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Build_Sanity_Suit
{
    [TestClass]
    public class A4_CreateMasterContract
    {
        [TestMethod]
        public void CreateMaster()
        {
            LOGIN loginobj = new LOGIN();
            loginobj.Login();
            global.xrmApp.Navigation.OpenSubArea("Referral", "Contract Management");
            global.xrmApp.ThinkTime(3000);
            global.xrmApp.CommandBar.ClickCommand("New");

            HelperFunction Lookupobj = new HelperFunction();
            var GeneralCreate = new Action(() =>
            {

                global.xrmApp.ThinkTime(2000);
                global.xrmApp.Entity.SelectTab("General");
                global.xrmApp.ThinkTime(5000);
                global.xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contracttypevalue", Value = "Master Contract Agreement" });
                global.xrmApp.ThinkTime(5000);
                global.xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contractstatus", Value = "Live" });

                //General form  
                //fields section
                global.xrmApp.Entity.SetValue("mzk_name", MasterContractData.contractName);
                //lookup section   

                Lookupobj.Lookup("mzk_contractingparty", MasterContractData.contractingParty);
                Lookupobj.Lookup("mzk_service", MasterContractData.service);
                Lookupobj.Lookup("mzk_contractsubtype", MasterContractData.contractSubtype);
                //   global.xrmApp.Entity.SetValue("mzk_keycontractinformation", "mzk_keycontractinformation");

                global.xrmApp.Entity.SetValue("mzk_startdate", MasterContractData.startdate, "dd/MM/yyyy");

                global.xrmApp.Entity.SetValue("mzk_enddate", MasterContractData.enddate, "dd/MM/yyyy");

                global.xrmApp.Entity.SetValue("mzk_issuedate", MasterContractData.issuedate, "dd/MM/yyyy");
                global.xrmApp.ThinkTime(1000);
                //DateTime reviewdate = DateTime.Today.AddDays(1);
                //global.xrmApp.Entity.SetValue("mzk_reviewdate", reviewdate);
                //global.xrmApp.Entity.SetValue("mzk_description", "mzk_description");
                //global.xrmApp.Entity.SetValue("mzk_contractspecialinstructions", "mzk_contractspecialinstructions");
                //global.xrmApp.Entity.SetValue("mzk_frameworkreference", "mzk_frameworkreference");
                global.xrmApp.Entity.Save();

            });

            /*   Master pathways
               var MasterPathwaysCreate = new Action(() =>
               {
                   global.xrmApp.ThinkTime(1000);
                   global.xrmApp.Entity.SelectTab("Master Pathways");
                   global.xrmApp.ThinkTime(1000);
                   // use this line to click on related grid
                   global.xrmApp.Entity.SubGrid.ClickCommand("MasterPathway", "New Contract Master Pathway");
                   global.xrmApp.ThinkTime(1000);
                   Lookupobj.LookupQuickCreate("mzk_masterpathway", "General Master Pathway");
                   global.xrmApp.QuickCreate.Save();
                   global.xrmApp.ThinkTime(1000);
                   global.xrmApp.Entity.Save();
               });*/

            //Contract Products and Services
            var ContractProductServicesCreate = new Action(() =>
            {

                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SelectTab("Contract Products and Services");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SubGrid.ClickCommand("ContractLines", "New Contract Line");
                Lookupobj.LookupQuickCreate("mzk_product", MasterContractData.product);
                //   global.xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_fundingorganizationtype", Value = "Master Contract Party" });
                //   global.xrmApp.ThinkTime(500);
                global.xrmApp.QuickCreate.SetValue("mzk_quantity", MasterContractData.maxQty);
                //   global.xrmApp.QuickCreate.SetValue(new BooleanItem { Name = "mzk_keydrug", Value = true });
                //   global.xrmApp.ThinkTime(5000);
                //   global.xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_billingfrequency", Value = "Weekly" });
                //   global.xrmApp.ThinkTime(1000);
                global.xrmApp.QuickCreate.SetValue("mzk_orderquantity", MasterContractData.orderQty);
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.QuickCreate.Save();
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SubGrid.ClickCommand("ContractLines", "New Contract Line");
                Lookupobj.LookupQuickCreate("mzk_product", MasterContractData.serviceName);
                //   global.xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_fundingorganizationtype", Value = "Master Contract Party" });
                //   global.xrmApp.ThinkTime(500);
                global.xrmApp.QuickCreate.SetValue("mzk_quantity", MasterContractData.maxQty);
                //   global.xrmApp.QuickCreate.SetValue(new BooleanItem { Name = "mzk_keydrug", Value = true });
                //   global.xrmApp.ThinkTime(5000);
                //   global.xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_billingfrequency", Value = "Weekly" });
                //   global.xrmApp.ThinkTime(1000);
                global.xrmApp.QuickCreate.SetValue("mzk_orderquantity", MasterContractData.orderQty);
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.QuickCreate.Save();

            });

            ///Contract SLA
            var ContractSLA = new Action(() =>
            {

                global.xrmApp.Entity.SelectTab("Contract SLA");
                global.xrmApp.ThinkTime(3000);
                //handling flipswitches 
                var allTextBoxes = global.client.Browser.Driver.FindElements(By.XPath("//*[contains(@class,'ui-flipswitch ui-shadow-inset ui-bar-c crm-jqm-flipswitch-wrapper ui-corner-all')]"));
                global.xrmApp.ThinkTime(2000);
                for (int i = 0; i < allTextBoxes.Count; i++)
                {
            
                    allTextBoxes[i].Click();
                }

                if (global.client.Browser.Driver.HasElement(By.XPath("//*[contains(@aria-label,'PMI Reference Required?')]")))
                {
                    global.client.Browser.Driver.FindElement(By.XPath("//*[contains(@aria-label,'PMI Reference Required?')]")).Click();
                }

                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_deliveryconfirmationmethod", Value = "PIN" });
                //global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_capturegppracticedetailsatregistration", Value = true });

                //Lookupobj.Lookup("mzk_purchaseordernumberonholdprescription", "A");
                //global.xrmApp.ThinkTime(2000);
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_deliverypurchaseordersource", Value = "Delivery Date" });
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_accountmanagementchargings", Value = "Yes" });
                global.xrmApp.Entity.SetValue("mzk_bufferstockdays", MasterContractData.bufferstockdays);
                Lookupobj.Lookup("mzk_returnsresponsibility", MasterContractData.returnsresponsibility);
                Lookupobj.Lookup("mzk_telephonecallschargingmodel", MasterContractData.telephonecallschargingmodel);
                Lookupobj.Lookup("mzk_textmessagechargingmodel", MasterContractData.textmessagechargingmodel);
                Lookupobj.Lookup("mzk_nonstandardvisitdaycharging", MasterContractData.nonstandardvisitdaycharging);
                Lookupobj.Lookup("mzk_pvreportcharging", MasterContractData.pvreportcharging);
                Lookupobj.Lookup("mzk_pqcreturnmodel", MasterContractData.pqcreturnmodel);
                ////Lookupobj.Lookup("mzk_prescriptionportalapprovalmethod", "HaH Collect and dispose");
                //global.xrmApp.ThinkTime(1000);
                Lookupobj.Lookup("mzk_methodofpayment", MasterContractData.methodofpayment);
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingreleases", Value = "Yes" });
                Lookupobj.Lookup("mzk_patientculpabledeliveryfailurecharging", MasterContractData.patientculpabledeliveryfailurecharging);
                Lookupobj.Lookup("mzk_patientregistrationcharging", MasterContractData.patientregistrationcharging);
                Lookupobj.Lookup("mzk_pvreportchargingmodel", MasterContractData.pvreportchargingmodel);
                Lookupobj.Lookup("mzk_contractreportingchargingmodel", MasterContractData.contractreportingchargingmodel);
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_printcreditreasononcreditnote", Value = "Yes" });
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_invoiceconsolidationtype", Value = "Patient" });
                global.xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_billingreferencenumber", Value = true });
                //Lookupobj.Lookup("mzk_pharmacistscreeningonholdprescription", "Archive prescription");
                //global.xrmApp.ThinkTime(2000);
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_invoicedeliverymethod", Value = "Email" });
                Lookupobj.Lookup("mzk_invoicecurrency", MasterContractData.invoicecurrency);
                Lookupobj.Lookup("mzk_ancillaryitemscharging", MasterContractData.ancillaryitemscharging);
                Lookupobj.Lookup("mzk_carebureaucallschargingmodel", MasterContractData.carebureaucallschargingmodel);
                Lookupobj.Lookup("mzk_nonstandarddeliverydaycharging", MasterContractData.nonstandarddeliverydaycharging);
                Lookupobj.Lookup("mzk_patientculpablevisitfailurecharging", MasterContractData.patientculpabledeliveryfailurecharging);
                Lookupobj.Lookup("mzk_pqcreimbursementmodel", MasterContractData.pqcreimbursementmodel);
                Lookupobj.Lookup("mzk_medicaldevicechargingmodel", MasterContractData.medicaldevicechargingmodel);
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_printcommentlinesoninvoice", Value = "Yes" });
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SubGrid.ClickCommand("VisitRules", "New Contract Visit Rule");
                global.xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_type", Value = "Wholesale Order" });
                Lookupobj.LookupQuickCreate("mzk_visittype", MasterContractData.visittype);
                global.xrmApp.QuickCreate.SetValue("mzk_allowedvisits", MasterContractData.allowedvisits);
                global.xrmApp.ThinkTime(500);
                global.xrmApp.QuickCreate.Save();
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SubGrid.ClickCommand("DeliveryFrequency", "New Contract Delivery Frequency");
                global.xrmApp.Entity.SetValue("mzk_frequency", MasterContractData.frequency);
                global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_unit", Value = "Days" });
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.CommandBar.ClickCommand("Save & Close");
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SubGrid.ClickCommand("PurchaseOrderRules", "New Purchase Order Rule");
                global.xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_criteria", Value = "Blank" });
                global.xrmApp.QuickCreate.SetValue("mzk_format", MasterContractData.format);
                global.xrmApp.QuickCreate.SetValue("mzk_description", MasterContractData.description);
                //DateTime mzk_effectivestartdate = DateTime.Today.AddDays(1);
                //global.xrmApp.QuickCreate.SetValue("mzk_effectivestartdate", mzk_effectivestartdate);
                //global.xrmApp.ThinkTime(1000);
                //DateTime mzk_effectiveenddate = DateTime.Today.AddDays(2);
                //global.xrmApp.QuickCreate.SetValue("mzk_effectiveenddate", mzk_effectiveenddate);
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.QuickCreate.Save();
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SubGrid.ClickCommand("ContractualKPICriterias", "New Contractual KPI Criteria");
                Lookupobj.LookupQuickCreate("mzk_kpi", MasterContractData.kpi);
                global.xrmApp.QuickCreate.SetValue("mzk_performancevalue", MasterContractData.performancevalue);
                Lookupobj.LookupQuickCreate("mzk_kpiunit", MasterContractData.kpiunit);
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.QuickCreate.Save();
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.Entity.SubGrid.ClickCommand("DeliveryMethod", "New Contract Delivery Method");
                Lookupobj.Lookup("mzk_deliverymethod", MasterContractData.deliverymethod);
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.CommandBar.ClickCommand("Save & Close");

            });

            // Contract Diagnosis Group
            var ContractDignosisCreate = new Action(() =>
            {
                global.xrmApp.Entity.SelectTab("Contract Diagnosis Group");
                global.xrmApp.ThinkTime(1000);
                // use this line to click on related grid
                global.xrmApp.Entity.SubGrid.ClickCommand("ContractDiagnosisGroup_new_Grid", "New Contract Diagnosis Group");
                Lookupobj.LookupQuickCreate("mzk_operationaldiagnosisgroup", MasterContractData.operationaldiagnosisgroup);
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.QuickCreate.Save();
                //  global.xrmApp.CommandBar.ClickCommand("Save & Close");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SelectTab("General");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SubGrid.ClickCommand("BillingAddress", "New Contract Billing Address");
                //global.xrmApp.ThinkTime(1500);
                ////Lookupobj.LookupQuickCreate("mzk_diagnosisgroup","aHus");
                ////global.xrmApp.ThinkTime(3000);
                ////Lookupobj.LookupQuickCreate("mzk_address", "Default address");
                //global.xrmApp.QuickCreate.Save();

            });
            // Contract Price List
            var ContractPriceListCreate = new Action(() =>
            {
                global.xrmApp.Entity.SelectTab("Contract Price Lists");
                global.xrmApp.ThinkTime(1000);
                // use this line to click on related grid
                global.xrmApp.Entity.SubGrid.ClickCommand("ContractPriceList", "New Contract Price List");
                Lookupobj.LookupQuickCreate("mzk_contractpricelist", MasterContractData.contractpricelist);
                Lookupobj.LookupQuickCreate("mzk_reducedpricelist", MasterContractData.reducedpricelist);
                Lookupobj.LookupQuickCreate("mzk_contractdiagnosisgroup", MasterContractData.contractdiagnosisgroup);
                global.xrmApp.ThinkTime(1000);
                global.xrmApp.QuickCreate.Save();


            });


            /*     InvoiceDeliveryCreate
                 var InvoiceDeliveryCreate = new Action(() =>
                 {
                     global.xrmApp.Entity.SelectTab("Invoice Delivery");
                     global.xrmApp.ThinkTime(3000);


                     //global.xrmApp.Entity.SetValue(new MultiValueOptionSet
                     //{
                     //    Name = "mzk_invoice",
                     //    Values = new string[] {"Egress","Trust SFTP"},
                     //});

                     //global.xrmApp.ThinkTime(1000);
                     //global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_pod", Value = "Egress" });
                     //global.xrmApp.ThinkTime(1000);
                     //global.xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_posd", Value = "Egress" });
                     //global.xrmApp.Entity.SetValue("mzk_workspacename", "mzk_workspacename");
                     //global.xrmApp.ThinkTime(1000);
                     //global.xrmApp.Entity.Save();

                 });*/

            // Other Information
            var OtherInformation = new Action(() =>
            {
                global.xrmApp.Entity.SelectTab("Other Information");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_serviceoverview", "mzk_serviceoverview");
                //DateTime mzk_contractrenewaldate = DateTime.Today.AddDays(1);
                //global.xrmApp.Entity.SetValue("mzk_contractrenewaldate", mzk_contractrenewaldate);
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.ClearValue("mzk_contractedkpissummary");
                //global.xrmApp.Entity.SetValue("mzk_contractedkpissummary", "mzk_contractedkpissummary");
                //global.xrmApp.ThinkTime(500);
                //global.xrmApp.Entity.SetValue("mzk_operationalkpissummary", "mzk_operationalkpissummary");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_stockterms", "mzk_stockterms");
                //global.xrmApp.Entity.SetValue("mzk_productcountryoforiginmanufacturer", "mzk_productcountryoforiginmanufacturer");
                //global.xrmApp.ThinkTime(1000);

                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_productsupplyroute", "mzk_productsupplyroute");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_logisticstermssummary", "mzk_logisticstermssummary");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_compoundingstorageneeds", "mzk_compoundingstorageneeds");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_pasterms", "mzk_pasterms");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_terminationterms", "mzk_terminationterms");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_tuperecruitment", "mzk_tuperecruitment");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_pvterms", "mzk_pvterms");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_paymentterms", "mzk_paymentterms");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_workingcapitalmanagementcreditordays", "2145");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_changeofcontrol", "mzk_changeofcontrol");
                //global.xrmApp.ThinkTime(1000);
                //global.xrmApp.Entity.SetValue("mzk_debtreviewprocess", "mzk_debtreviewprocess");
                Lookupobj.Lookup("mzk_dispensinglocationwarehouse", "107");
                Lookupobj.Lookup("mzk_orderreleasetype", "BULK");
                //global.xrmApp.ThinkTime(2000);
                //global.xrmApp.Entity.SetValue("mzk_contractnoticeperioddays", "2");
                //global.xrmApp.ThinkTime(2000);
                //global.xrmApp.Entity.SetValue("mzk_contractualsreportingsummary", "mzk_contractualsreportingsummary");
                //global.xrmApp.ThinkTime(2000);
                ////Lookupobj.Lookup("mzk_therapyarea", "2");
                //global.xrmApp.ThinkTime(2000);
                //global.xrmApp.Entity.SetValue("mzk_contractbreakpointsfeereviews", "mzk_contractbreakpointsfeereviews");
                //global.xrmApp.ThinkTime(2000);
                //global.xrmApp.Entity.SetValue("mzk_servicecreditdetails", "mzk_servicecreditdetails");
                global.xrmApp.Entity.Save();

            });

            //childcontractgeneral
            /*  var childcontractgeneral = new Action(() =>
              {
                  global.xrmApp.ThinkTime(2000);
                  global.xrmApp.Entity.SelectTab("General");
                  global.xrmApp.ThinkTime(5000);
                  global.xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contracttypevalue", Value = "Sub-Contract" });
                  global.xrmApp.ThinkTime(5000);
                  global.xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contractstatus", Value = "Live" });
                  global.xrmApp.ThinkTime(1000);
                  global.xrmApp.Entity.SetValue("mzk_name", "sub contract");
                  global.xrmApp.ThinkTime(500);
                  Lookupobj.Lookup("mzk_payer", "AKU Trust");
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
                  global.xrmApp.ThinkTime(5000);
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
              });*/

            //ChildContractCreate
            /*   var ChildContractCreate = new Action(() =>
               {
                   global.xrmApp.Entity.SelectTab("Child Contracts");
                   global.xrmApp.ThinkTime(4000);
                   global.xrmApp.Entity.SubGrid.ClickCommand("ChildContracts", "New Contract Management");
                   global.xrmApp.ThinkTime(1000);
                   childcontractgeneral();
                   ContractPriceListCreate();
                   ContractProductServicesCreate();
                   ContractDignosisCreate();
                   OtherInformation();
                   global.xrmApp.ThinkTime(1000);
                   global.client.Browser.Driver.Navigate().Back();
                   global.xrmApp.ThinkTime(1000);
                   global.client.Browser.Driver.Navigate().Back();
                   global.xrmApp.ThinkTime(1000);
                   global.client.Browser.Driver.Navigate().Back();
                   global.xrmApp.ThinkTime(1000);
                   global.client.Browser.Driver.Navigate().Back();
                   //InvoiceDeliveryCreate();
                   //MasterPathwaysCreate();               
                   //ContractSLA();
               });
               */



            GeneralCreate();
            ContractProductServicesCreate();
            ContractSLA();
            ContractDignosisCreate();
            ContractPriceListCreate();
            OtherInformation();
            // MasterPathwaysCreate();
            //  ChildContractCreate();
            //InvoiceDeliveryCreate();

        }
    }
}

