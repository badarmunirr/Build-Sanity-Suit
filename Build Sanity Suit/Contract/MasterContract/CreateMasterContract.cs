using System;

using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Build_Sanity_Suit
{
    //[TestClass]
    public class A4_CreateMasterContract
    {
        public static WebClient cli;

        [TestMethod]
        public void A4_CreateMaster()
        {
            LOGIN loginobj = new LOGIN();
            WebClient client = loginobj.Login();
            cli = client;
            XrmApp xrmApp = new XrmApp(client);
            WebDriverWait wait = new WebDriverWait(client.Browser.Driver, TimeSpan.FromSeconds(120000));
            HelperFunction Lookupobj = new HelperFunction();

            xrmApp.ThinkTime(4000);
             xrmApp.Navigation.OpenSubArea("Referral", "Contract Management");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
             xrmApp.CommandBar.ClickCommand("New");


            var GeneralCreate = new Action(() =>
            {

                 xrmApp.ThinkTime(2000);
                 xrmApp.Entity.SelectTab("General");
                 xrmApp.ThinkTime(5000);
                 xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contracttypevalue", Value = "Master Contract Agreement" });
                 xrmApp.ThinkTime(5000);
                 xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contractstatus", Value = "Live" });

                //General form  
                //fields section
                 xrmApp.Entity.SetValue("mzk_name", MasterContractData.contractName);
                //lookup section   

                Lookupobj.Lookup("mzk_contractingparty", MasterContractData.contractingParty,xrmApp);
                Lookupobj.Lookup("mzk_service", MasterContractData.service, xrmApp);
                Lookupobj.Lookup("mzk_contractsubtype", MasterContractData.contractSubtype, xrmApp);
                //    xrmApp.Entity.SetValue("mzk_keycontractinformation", "mzk_keycontractinformation");

                 xrmApp.Entity.SetValue("mzk_startdate", MasterContractData.startdate, "dd/MM/yyyy");

                 xrmApp.Entity.SetValue("mzk_enddate", MasterContractData.enddate, "dd/MM/yyyy");

                 xrmApp.Entity.SetValue("mzk_issuedate", MasterContractData.issuedate, "dd/MM/yyyy");
                 xrmApp.ThinkTime(1000);
                //DateTime reviewdate = DateTime.Today.AddDays(1);
                // xrmApp.Entity.SetValue("mzk_reviewdate", reviewdate);
                // xrmApp.Entity.SetValue("mzk_description", "mzk_description");
                // xrmApp.Entity.SetValue("mzk_contractspecialinstructions", "mzk_contractspecialinstructions");
                // xrmApp.Entity.SetValue("mzk_frameworkreference", "mzk_frameworkreference");
                 xrmApp.Entity.Save();

            });

            /*   Master pathways
               var MasterPathwaysCreate = new Action(() =>
               {
                    xrmApp.ThinkTime(1000);
                    xrmApp.Entity.SelectTab("Master Pathways");
                    xrmApp.ThinkTime(1000);
                   // use this line to click on related grid
                    xrmApp.Entity.SubGrid.ClickCommand("MasterPathway", "New Contract Master Pathway");
                    xrmApp.ThinkTime(1000);
                   Lookupobj.LookupQuickCreate("mzk_masterpathway", "General Master Pathway");
                    xrmApp.QuickCreate.Save();
                    xrmApp.ThinkTime(1000);
                    xrmApp.Entity.Save();
               });*/

            //Contract Products and Services
            var ContractProductServicesCreate = new Action(() =>
            {

                 xrmApp.ThinkTime(1000);
                 xrmApp.Entity.SelectTab("Contract Products and Services");
                 xrmApp.ThinkTime(1000);
                 xrmApp.Entity.SubGrid.ClickCommand("ContractLines", "New Contract Line");
                Lookupobj.LookupQuickCreate("mzk_product", MasterContractData.product, xrmApp);
                //    xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_fundingorganizationtype", Value = "Master Contract Party" });
                //    xrmApp.ThinkTime(500);
                 xrmApp.QuickCreate.SetValue("mzk_quantity", MasterContractData.maxQty);
                //    xrmApp.QuickCreate.SetValue(new BooleanItem { Name = "mzk_keydrug", Value = true });
                //    xrmApp.ThinkTime(5000);
                //    xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_billingfrequency", Value = "Weekly" });
                //    xrmApp.ThinkTime(1000);
                 xrmApp.QuickCreate.SetValue("mzk_orderquantity", MasterContractData.orderQty);
                 xrmApp.ThinkTime(1000);
                 xrmApp.QuickCreate.Save();
                 xrmApp.ThinkTime(1000);
                 xrmApp.Entity.SubGrid.ClickCommand("ContractLines", "New Contract Line");
                Lookupobj.LookupQuickCreate("mzk_product", MasterContractData.serviceName, xrmApp);
                //    xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_fundingorganizationtype", Value = "Master Contract Party" });
                //    xrmApp.ThinkTime(500);
                 xrmApp.QuickCreate.SetValue("mzk_quantity", MasterContractData.maxQty);
                //    xrmApp.QuickCreate.SetValue(new BooleanItem { Name = "mzk_keydrug", Value = true });
                //    xrmApp.ThinkTime(5000);
                //    xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_billingfrequency", Value = "Weekly" });
                //    xrmApp.ThinkTime(1000);
                 xrmApp.QuickCreate.SetValue("mzk_orderquantity", MasterContractData.orderQty);
                 xrmApp.ThinkTime(1000);
                 xrmApp.QuickCreate.Save();

            });

            ///Contract SLA
            var ContractSLA = new Action(() =>
            {

                 xrmApp.Entity.SelectTab("Contract SLA");
                 xrmApp.ThinkTime(3000);
                //handling flipswitches 
                var allTextBoxes =  client.Browser.Driver.FindElements(By.XPath("//*[contains(@class,'ui-flipswitch ui-shadow-inset ui-bar-c crm-jqm-flipswitch-wrapper ui-corner-all')]"));
                 xrmApp.ThinkTime(2000);
                for (int i = 0; i < allTextBoxes.Count; i++)
                {
            
                    allTextBoxes[i].Click();
                }

                if ( client.Browser.Driver.HasElement(By.XPath("//*[contains(@aria-label,'PMI Reference Required?')]")))
                {
                     client.Browser.Driver.FindElement(By.XPath("//*[contains(@aria-label,'PMI Reference Required?')]")).Click();
                }

                 xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_deliveryconfirmationmethod", Value = "PIN" });
                // xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_capturegppracticedetailsatregistration", Value = true });

                //Lookupobj.Lookup("mzk_purchaseordernumberonholdprescription", "A");
                // xrmApp.ThinkTime(2000);
                 xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_deliverypurchaseordersource", Value = "Delivery Date" });
                 xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_accountmanagementchargings", Value = "Yes" });
                 xrmApp.Entity.SetValue("mzk_bufferstockdays", MasterContractData.bufferstockdays);
                Lookupobj.Lookup("mzk_returnsresponsibility", MasterContractData.returnsresponsibility, xrmApp);
                Lookupobj.Lookup("mzk_telephonecallschargingmodel", MasterContractData.telephonecallschargingmodel, xrmApp);
                Lookupobj.Lookup("mzk_textmessagechargingmodel", MasterContractData.textmessagechargingmodel, xrmApp);
                Lookupobj.Lookup("mzk_nonstandardvisitdaycharging", MasterContractData.nonstandardvisitdaycharging, xrmApp);
                Lookupobj.Lookup("mzk_pvreportcharging", MasterContractData.pvreportcharging, xrmApp);
                Lookupobj.Lookup("mzk_pqcreturnmodel", MasterContractData.pqcreturnmodel, xrmApp);
                ////Lookupobj.Lookup("mzk_prescriptionportalapprovalmethod", "HaH Collect and dispose");
                // xrmApp.ThinkTime(1000);
                Lookupobj.Lookup("mzk_methodofpayment", MasterContractData.methodofpayment, xrmApp);
                 xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_manualbillingreleases", Value = "Yes" });
                Lookupobj.Lookup("mzk_patientculpabledeliveryfailurecharging", MasterContractData.patientculpabledeliveryfailurecharging, xrmApp);
                Lookupobj.Lookup("mzk_patientregistrationcharging", MasterContractData.patientregistrationcharging, xrmApp);
                Lookupobj.Lookup("mzk_pvreportchargingmodel", MasterContractData.pvreportchargingmodel, xrmApp);
                Lookupobj.Lookup("mzk_contractreportingchargingmodel", MasterContractData.contractreportingchargingmodel, xrmApp);
                 xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_printcreditreasononcreditnote", Value = "Yes" });
                 xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_invoiceconsolidationtype", Value = "Patient" });
                 xrmApp.Entity.SetValue(new BooleanItem { Name = "mzk_billingreferencenumber", Value = true });
                //Lookupobj.Lookup("mzk_pharmacistscreeningonholdprescription", "Archive prescription");
                // xrmApp.ThinkTime(2000);
                 xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_invoicedeliverymethod", Value = "Email" });
                Lookupobj.Lookup("mzk_invoicecurrency", MasterContractData.invoicecurrency, xrmApp);
                Lookupobj.Lookup("mzk_ancillaryitemscharging", MasterContractData.ancillaryitemscharging, xrmApp);
                Lookupobj.Lookup("mzk_carebureaucallschargingmodel", MasterContractData.carebureaucallschargingmodel, xrmApp);
                Lookupobj.Lookup("mzk_nonstandarddeliverydaycharging", MasterContractData.nonstandarddeliverydaycharging, xrmApp);
                Lookupobj.Lookup("mzk_patientculpablevisitfailurecharging", MasterContractData.patientculpabledeliveryfailurecharging, xrmApp);
                Lookupobj.Lookup("mzk_pqcreimbursementmodel", MasterContractData.pqcreimbursementmodel, xrmApp);
                Lookupobj.Lookup("mzk_medicaldevicechargingmodel", MasterContractData.medicaldevicechargingmodel, xrmApp);
                 xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_printcommentlinesoninvoice", Value = "Yes" });
                 xrmApp.ThinkTime(1000);


                 xrmApp.Entity.SubGrid.ClickCommand("VisitRules", "New Contract Visit Rule");
                 xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_type", Value = "Wholesale Order" });
                Lookupobj.LookupQuickCreate("mzk_visittype", MasterContractData.visittype, xrmApp);
                 xrmApp.QuickCreate.SetValue("mzk_allowedvisits", MasterContractData.allowedvisits);
                 xrmApp.ThinkTime(500);
                 xrmApp.QuickCreate.Save();
                 xrmApp.ThinkTime(1000);


                 xrmApp.Entity.SubGrid.ClickCommand("DeliveryFrequency", "New Contract Delivery Frequency");
                 xrmApp.Entity.SetValue("mzk_frequency", MasterContractData.frequency);
                 xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_unit", Value = "Days" });
                 xrmApp.ThinkTime(1000);
                 xrmApp.CommandBar.ClickCommand("Save & Close");
                 xrmApp.ThinkTime(2000);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@aria-label,'New')]")));
                

                 xrmApp.Entity.SubGrid.ClickCommand("PurchaseOrderRules", "New Purchase Order Rule");
                 xrmApp.QuickCreate.SetValue(new OptionSet { Name = "mzk_criteria", Value = "Blank" });
                 xrmApp.QuickCreate.SetValue("mzk_format", MasterContractData.format);
                 xrmApp.QuickCreate.SetValue("mzk_description", MasterContractData.description);
                //DateTime mzk_effectivestartdate = DateTime.Today.AddDays(1);
                // xrmApp.QuickCreate.SetValue("mzk_effectivestartdate", mzk_effectivestartdate);
                // xrmApp.ThinkTime(1000);
                //DateTime mzk_effectiveenddate = DateTime.Today.AddDays(2);
                // xrmApp.QuickCreate.SetValue("mzk_effectiveenddate", mzk_effectiveenddate);
                 xrmApp.ThinkTime(1000);
                 xrmApp.QuickCreate.Save();
                 xrmApp.ThinkTime(1000);

                 xrmApp.Entity.SubGrid.ClickCommand("ContractualKPICriterias", "New Contractual KPI Criteria");
                Lookupobj.LookupQuickCreate("mzk_kpi", MasterContractData.kpi, xrmApp);
                 xrmApp.QuickCreate.SetValue("mzk_performancevalue", MasterContractData.performancevalue);
                Lookupobj.LookupQuickCreate("mzk_kpiunit", MasterContractData.kpiunit, xrmApp);
                 xrmApp.ThinkTime(1000);
                 xrmApp.QuickCreate.Save();
                 xrmApp.ThinkTime(1000);

                 xrmApp.Entity.SubGrid.ClickCommand("DeliveryMethod", "New Contract Delivery Method");
                Lookupobj.Lookup("mzk_deliverymethod", MasterContractData.deliverymethod, xrmApp);
                 xrmApp.ThinkTime(1000);
                 xrmApp.CommandBar.ClickCommand("Save & Close");

            });

            // Contract Diagnosis Group
            var ContractDignosisCreate = new Action(() =>
            {
                 xrmApp.Entity.SelectTab("Contract Diagnosis Group");
                 xrmApp.ThinkTime(1000);
                // use this line to click on related grid
                 xrmApp.Entity.SubGrid.ClickCommand("ContractDiagnosisGroup_new_Grid", "New Contract Diagnosis Group");
                Lookupobj.LookupQuickCreate("mzk_operationaldiagnosisgroup", MasterContractData.operationaldiagnosisgroup, xrmApp);
                 xrmApp.ThinkTime(1000);
                 xrmApp.QuickCreate.Save();
                //   xrmApp.CommandBar.ClickCommand("Save & Close");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SelectTab("General");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SubGrid.ClickCommand("BillingAddress", "New Contract Billing Address");
                // xrmApp.ThinkTime(1500);
                ////Lookupobj.LookupQuickCreate("mzk_diagnosisgroup","aHus");
                //// xrmApp.ThinkTime(3000);
                ////Lookupobj.LookupQuickCreate("mzk_address", "Default address");
                // xrmApp.QuickCreate.Save();

            });
            // Contract Price List
            var ContractPriceListCreate = new Action(() =>
            {
                 xrmApp.Entity.SelectTab("Contract Price Lists");
                 xrmApp.ThinkTime(1000);
                // use this line to click on related grid
                 xrmApp.Entity.SubGrid.ClickCommand("ContractPriceList", "New Contract Price List");
                Lookupobj.LookupQuickCreate("mzk_contractpricelist", MasterContractData.contractpricelist, xrmApp);
                Lookupobj.LookupQuickCreate("mzk_reducedpricelist", MasterContractData.reducedpricelist, xrmApp);
                Lookupobj.LookupQuickCreate("mzk_contractdiagnosisgroup", MasterContractData.contractdiagnosisgroup, xrmApp);
                 xrmApp.ThinkTime(1000);
                 xrmApp.QuickCreate.Save();


            });


            /*     InvoiceDeliveryCreate
                 var InvoiceDeliveryCreate = new Action(() =>
                 {
                      xrmApp.Entity.SelectTab("Invoice Delivery");
                      xrmApp.ThinkTime(3000);


                     // xrmApp.Entity.SetValue(new MultiValueOptionSet
                     //{
                     //    Name = "mzk_invoice",
                     //    Values = new string[] {"Egress","Trust SFTP"},
                     //});

                     // xrmApp.ThinkTime(1000);
                     // xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_pod", Value = "Egress" });
                     // xrmApp.ThinkTime(1000);
                     // xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_posd", Value = "Egress" });
                     // xrmApp.Entity.SetValue("mzk_workspacename", "mzk_workspacename");
                     // xrmApp.ThinkTime(1000);
                     // xrmApp.Entity.Save();

                 });*/

            // Other Information
            var OtherInformation = new Action(() =>
            {
                 xrmApp.Entity.SelectTab("Other Information");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_serviceoverview", "mzk_serviceoverview");
                //DateTime mzk_contractrenewaldate = DateTime.Today.AddDays(1);
                // xrmApp.Entity.SetValue("mzk_contractrenewaldate", mzk_contractrenewaldate);
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.ClearValue("mzk_contractedkpissummary");
                // xrmApp.Entity.SetValue("mzk_contractedkpissummary", "mzk_contractedkpissummary");
                // xrmApp.ThinkTime(500);
                // xrmApp.Entity.SetValue("mzk_operationalkpissummary", "mzk_operationalkpissummary");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_stockterms", "mzk_stockterms");
                // xrmApp.Entity.SetValue("mzk_productcountryoforiginmanufacturer", "mzk_productcountryoforiginmanufacturer");
                // xrmApp.ThinkTime(1000);

                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_productsupplyroute", "mzk_productsupplyroute");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_logisticstermssummary", "mzk_logisticstermssummary");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_compoundingstorageneeds", "mzk_compoundingstorageneeds");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_pasterms", "mzk_pasterms");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_terminationterms", "mzk_terminationterms");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_tuperecruitment", "mzk_tuperecruitment");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_pvterms", "mzk_pvterms");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_paymentterms", "mzk_paymentterms");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_workingcapitalmanagementcreditordays", "2145");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_changeofcontrol", "mzk_changeofcontrol");
                // xrmApp.ThinkTime(1000);
                // xrmApp.Entity.SetValue("mzk_debtreviewprocess", "mzk_debtreviewprocess");
                Lookupobj.Lookup("mzk_dispensinglocationwarehouse", "107", xrmApp);
                Lookupobj.Lookup("mzk_orderreleasetype", "BULK", xrmApp);
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

            });

            //childcontractgeneral
            /*  var childcontractgeneral = new Action(() =>
              {
                   xrmApp.ThinkTime(2000);
                   xrmApp.Entity.SelectTab("General");
                   xrmApp.ThinkTime(5000);
                   xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contracttypevalue", Value = "Sub-Contract" });
                   xrmApp.ThinkTime(5000);
                   xrmApp.Entity.SetHeaderValue(new OptionSet { Name = "mzk_contractstatus", Value = "Live" });
                   xrmApp.ThinkTime(1000);
                   xrmApp.Entity.SetValue("mzk_name", "sub contract");
                   xrmApp.ThinkTime(500);
                  Lookupobj.Lookup("mzk_payer", "AKU Trust");
                   xrmApp.ThinkTime(500);
                  Lookupobj.Lookup("mzk_service", "Ajovy");
                   xrmApp.ThinkTime(500);
                  Lookupobj.Lookup("mzk_contractsubtype", "MC - NHS Funded");
                   xrmApp.ThinkTime(500);
                   xrmApp.Entity.SetValue("mzk_keycontractinformation", "mzk_keycontractinformation");
                   xrmApp.ThinkTime(500);
                  DateTime startdate = DateTime.Today.AddDays(1);
                   xrmApp.Entity.SetValue("mzk_startdate", startdate);
                   xrmApp.ThinkTime(500);
                  DateTime enddate = startdate.AddDays(2);
                   xrmApp.Entity.SetValue("mzk_enddate", enddate);
                   xrmApp.ThinkTime(500);
                  DateTime issuedate = DateTime.Today.AddDays(1);
                   xrmApp.Entity.SetValue("mzk_issuedate", issuedate);
                   xrmApp.ThinkTime(500);
                  DateTime reviewdate = DateTime.Today.AddDays(1);
                   xrmApp.Entity.SetValue("mzk_reviewdate", reviewdate);
                   xrmApp.ThinkTime(5000);
                   xrmApp.Entity.SetValue(new OptionSet { Name = "mzk_inherit", Value = "Yes" });
                   xrmApp.ThinkTime(500);
                   xrmApp.Entity.SetValue("mzk_description", "mzk_description");
                   xrmApp.ThinkTime(500);
                   xrmApp.Entity.SetValue("mzk_contractspecialinstructions", "mzk_contractspecialinstructions");
                   xrmApp.ThinkTime(500);
                   xrmApp.Entity.SetValue("mzk_frameworkreference", "mzk_frameworkreference");
                   xrmApp.Entity.Save();
                   xrmApp.ThinkTime(1000);
                   xrmApp.Dialogs.ConfirmationDialog(true);
              });*/

            //ChildContractCreate
            /*   var ChildContractCreate = new Action(() =>
               {
                    xrmApp.Entity.SelectTab("Child Contracts");
                    xrmApp.ThinkTime(4000);
                    xrmApp.Entity.SubGrid.ClickCommand("ChildContracts", "New Contract Management");
                    xrmApp.ThinkTime(1000);
                   childcontractgeneral();
                   ContractPriceListCreate();
                   ContractProductServicesCreate();
                   ContractDignosisCreate();
                   OtherInformation();
                    xrmApp.ThinkTime(1000);
                    client.Browser.Driver.Navigate().Back();
                    xrmApp.ThinkTime(1000);
                    client.Browser.Driver.Navigate().Back();
                    xrmApp.ThinkTime(1000);
                    client.Browser.Driver.Navigate().Back();
                    xrmApp.ThinkTime(1000);
                    client.Browser.Driver.Navigate().Back();
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
        [TestCleanup]
        public void Teardown()
        {
            cli.Browser.Driver.Close();
        }
    }
}

