using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QR.Models;
using static QR.Models.CallAPI;
using Connibrary;
using System.Data;
using QR.Helpers;

namespace QR.BL
{
    public class ReceiptService : IReceiptService
    {
        public  Connibrary.MyFunctions fun = new Connibrary.MyFunctions();
        public MyFunctions ComFun = new MyFunctions();
        public List<Invoice> GetReceiptsListFromJson(string JSON)// Convert Json to invoices List 
        {
            try
            {
                API_Root api = JsonConvert.DeserializeObject<API_Root>(JSON);
                return api.invoices;
            }
            catch(Exception ex)
            {
                return new List<Invoice>();
            }
        }

        public ValidateAndUnValidateReceipts GetValidReceipts(List<Invoice> Receipts)// filter recipts 
        {
            ValidateAndUnValidateReceipts Result = new ValidateAndUnValidateReceipts();
            try
            {
                foreach(var receipt in Receipts)
                {
                    // Filter receipts (Failed or Succeded and return )
                    if (ValidateReceipt(receipt))
                        Result.SucessModels.Add(receipt);
                    else
                        Result.FailedModels.Add(receipt);
                }
                return Result;
            }
            catch (Exception ex)
            {
                return Result;
            }
        }

        public void SaveValidInvoices(List<Invoice> Receipts)// success receipts Only 
        {      
            foreach(var item in Receipts)
            {
                deleteInvalidReceipt(item.number, item.document_type);
                insertBillHead(item); // insert head 
                insertBillDetails(item); // insert details
            }
           
        }

       public void SaveFailedInvoices(List<Invoice> Receipt)
        {
            string InsertQuery = " "; 
            foreach(var item in Receipt)
            {

                InsertQuery += $@"
                                    INSERT INTO [Bill_Error_Logs]
                                               ([BillNo]
                                               ,[Date]
                                               ,[ErrorDescription])
                                         VALUES
                                               ('{item.number}'
                                               ,'{TbiServer.Now}'
                                               ,'{item.ErrorDescription}')  " + "  ";
            }

          //  fun.fireSQL(InsertQuery);
            ComFun.fireSQL(InsertQuery, UserSecurity.GetConnection());


        }

        public BillResponseVM GetBillResponse(string BillNo, string DocType)
        {
            BillResponseVM response = new BillResponseVM();
            try
            {
                string getQ = $@"select BillNo BillNo , BillDate BillDate, sendToEta Status, documentType DocymentType , Response Response  from Bill_Tbl where BillNo = N'{BillNo}' and documentType = N'{DocType}' ";
             
               // DataTable getDT = fun.fireDataTable(getQ);
                DataTable getDT = ComFun.fireDataTableSQl(getQ, UserSecurity.GetConnection());
                if(getDT.Rows.Count > 0)
                {
                    response = Helpers.Converter.ConvertDataTable<BillResponseVM>(getDT).FirstOrDefault();
                }

            }
            catch
            {

            }


            return response;
        }
        public string GetReceiptuuidbyBillNo(string BillNo, string DocType)
        {
            try
            {
             //   return (string)fun.fireDataTable($"select uuid uuid from Bill_Tbl where BillNo = N'{BillNo}' and  documenttype ='{DocType}'").Rows[0]["uuid"];
                return (string)ComFun.fireDataTableSQl($"select uuid uuid from Bill_Tbl where BillNo = N'{BillNo}' and  documenttype ='{DocType}'", UserSecurity.GetConnection()).Rows[0]["uuid"];
            }
            catch { return ""; }
        }
        public Response<ReceiptResult> GetReceiptByBillNo(string BillNo)
        {
            try{
            string Query = $"select BillNo , documentType , uuid , Response ,validation from Bill_Tbl where BillNo = N'{BillNo}'";
               // DataTable GetDT = fun.fireDataTable(Query);
                DataTable GetDT = ComFun.fireDataTableSQl(Query, UserSecurity.GetConnection());
                if(GetDT.Rows.Count > 0)
                {
                    return new Response<ReceiptResult>() { state = 1, data = Converter.ConvertDataTable<ReceiptResult>(GetDT).FirstOrDefault(), message = $"receipt {BillNo} details " };
                }
                return new Response<ReceiptResult>() { state = 1, message = $"No receipt Found with Number {BillNo}" };
            }
            catch(Exception ex )
            {
                return new Response<ReceiptResult>() { state = 500, data = new ReceiptResult(), message = "an Error Ocured when executing " };
            }
        }
        // Helper Validation Methods 
        #region Validators methods 

        // Validate 
        private bool ValidateReceipt(Invoice Rec)
        {
            try
            {
                if (Rec.currency.ToUpper() == "EG" && Rec.currency_exchange_rate != 1)
                {
                    Rec.ErrorDescription = " Currency Eg and rate is not 1 ";
                    return false;
                }
                if (Rec.number==null || Rec.number == "")
                {
                    Rec.ErrorDescription = " invalid invoice number ";
                    return false;
                }
                if (Rec.currency == null || Rec.currency == "")
                {
                    Rec.ErrorDescription = " invalid currency ";
                    return false;
                }
                if (Rec.submission_user_id == null || Rec.submission_user_id == "")
                {
                    Rec.ErrorDescription = " invalid subbmition user id  ";
                    return false;
                }
                int validBillsWithSameBillsCount = (int)ComFun.fireDataTableSQl($@"
                        select count(*) count from [dbo].[Bill_Tbl] where BillNo= N'{Rec.number}' and
                        documentType = N'{Rec.document_type}' and sendToEta in(1,3)",UserSecurity.GetConnection()).Rows[0]["count"];

                if (validBillsWithSameBillsCount > 0)
                {
                    Rec.ErrorDescription = " This Bill No Is Exist With Valid or Submitted Validation  ";
                    return false;
                }
                    // check the List of Items 
                    if (ValidateItems(Rec) == false)
                    return false;
                // get sum of the items price in receipt 

                double totalprice = Rec.items.Select(t => t.total_price).Sum();
                // check Validate Customer 
                if (ValidateCustomer(Rec, totalprice) == false)
                    return false;



               


                return true;
            }
            catch
            {
                return false;
            }

        }
        // Validate Customer 
        private bool ValidateCustomer (Invoice Rec , double TotalPrice )
        {
            Customer Cust = Rec.customer;
            try
            {
                // check if customer is null  
                if (Cust == null)
                {
                    Rec.ErrorDescription = " invalid customer";
                    return false;
                }
                // if less than 150 k  taxid must br 14 digit or null  

                // check empty Fields 
                if (Cust.name == null || Cust.name == "")
                {
                    Rec.ErrorDescription = " invalid customer name ";
                    return false;
                }
                if (Cust.country == null || Cust.country == "")
                {
                    Rec.ErrorDescription = " invalid customer country ";
                    return false;
                }
                if (Cust.state == null || Cust.state == "")
                {
                    Rec.ErrorDescription = " invalid customer state ";
                    return false;
                }
                if (Cust.city == null || Cust.city == "")
                {
                    Rec.ErrorDescription = " invalid customer city ";
                    return false;
                }
                if (Cust.street == null || Cust.street == "")
                {
                    Rec.ErrorDescription = " invalid customer street  ";
                    return false;
                }
                if (Cust.building_number == null || Cust.building_number == "")
                {
                    Rec.ErrorDescription = " invalid customer buiding number ";
                    return false;
                }
                if (Cust.governate == null || Cust.governate == "")
                {
                    Rec.ErrorDescription = " invalid customer governate";
                    return false;
                }
                // check type of customer 
                if (Cust.type.ToUpper() == "P") // Pencel 
                {
                    //if (TotalPrice < 150000)
                    //    return false;
                    if (Cust.tax_id != null)
                        Cust.tax_id = Cust.tax_id.Trim().Replace("-", "");// net tax numbere 
                    if (TotalPrice < 150000)
                    {
                        if (Cust.tax_id != null && Cust.tax_id != "")// handle null reference if tax id null will throw null reference exception 
                            if (Cust.tax_id.Length != 14 && Cust.tax_id.Length != 0)
                            {
                                Rec.ErrorDescription = " total price < 150 k and tax is not null or 14 digit";
                                return false;
                            }

                    }
                    else
                    {
                        if (Cust.tax_id.Length != 14)
                        {
                            Rec.ErrorDescription = " tatal price > 150k and tax is not 14 digit  ";
                            return false;
                        }
                    }


                    if (!Cust.country.ToUpper().Contains("EG"))
                    {
                        Rec.ErrorDescription = "Customer p must be egyptian  ";
                        return false;
                    }
                }
                else if (Cust.type.ToUpper() == "B") // Book  
                {
                    //if (TotalPrice > 150000)
                    //    return false;
                    if (Cust.tax_id != null)
                        Cust.tax_id = Cust.tax_id.Trim().Replace("-", "");// net tax numbere 
                   
                        if (Cust.tax_id != null && Cust.tax_id != "")// handle null reference if tax id null will throw null reference exception 
                            if (Cust.tax_id.Length != 9)
                        {
                            Rec.ErrorDescription = " customer B must have 9 digit tax ";
                            return false;
                        }


                    if (!Cust.country.ToUpper().Contains("EG"))
                    {
                        Rec.ErrorDescription = " Customer B must be egyptian ";
                        return false;
                    }
                }
                else if (Cust.type.ToUpper() == "F") //Foreign 
                {
                    if (Cust.tax_id != null)
                        Cust.tax_id = Cust.tax_id.Trim().Replace("-", "");// net tax numbere 
                    if (TotalPrice < 150000)
                    {
                        if (Cust.tax_id != null && Cust.tax_id != "")// handle null reference if tax id null will throw null reference exception 
                            if (Cust.tax_id.Length != 14 && Cust.tax_id.Length != 0)
                            {
                                Rec.ErrorDescription = " total price < 150 K and tax is not null or 14 digit  ";
                                return false;
                            }
                    }
                    else
                    {
                        if (Cust.tax_id.Length != 14)
                        {
                            Rec.ErrorDescription = "total price > 150 k and tax is not 14 digit  ";
                            return false;
                        }
                    }


                    if (Cust.country.ToUpper().Contains("EG"))
                    {
                        Rec.ErrorDescription = " F customer must be not egyptian ";
                        return false;
                    }
                }
                else
                {
                    
                        Rec.ErrorDescription = " invalid customer type  ";
                        return false;
                    
                }

                return true;
            }
            catch(Exception e)
            {
            return false;
            }

          
        }
        // Validate Item 
        private bool ValidateItems(Invoice Rec )
        {
            List<Item> items = Rec.items;
            try
            {
                if (items == null || items.Count == 0)
                  {
                    Rec.ErrorDescription = " invalid items  ";
                    return false;
                }
                foreach (var item in items)
                    {
                    
                    //if ((item.discount_amount == 0 || item.discount_amount <0  ) && (item.discount_rate == 0 || item.discount_rate <0) )
                    //        return false;
                    if ((item.discount_amount > 0 && item.discount_rate > 0) || (item.discount_amount < 0 && item.discount_rate < 0))
                    {
                        Rec.ErrorDescription = " discount rate and amount must at least one is 0  ";
                        return false;
                    }
                    if (item.quantity <= 0 || Decimal.Parse(item.unit_price) <= 0)
                    {
                        Rec.ErrorDescription = "price is less than 0";
                        return false;
                    }
                    if (item.code == null || item.code =="")
                    {
                        Rec.ErrorDescription = "invalid item code ";
                        return false;
                    }
                    if (item.description == null || item.description =="")
                    {
                        Rec.ErrorDescription = "invalid item description  ";
                        return false;
                    }
                    if (item.unit_type.ToUpper() != "EA")
                    {
                        Rec.ErrorDescription = " item unt is not EA ";
                        return false;
                    }
                    if (item.name == null || item.name == "")
                    {
                        Rec.ErrorDescription = "invalid item name  ";
                        return false;
                    }
                    if (item.internal_code == null || item.internal_code == "")
                    {
                        Rec.ErrorDescription = " invalid internal code  ";
                        return false;
                    }
                    if (item.total_price <=0 )
                    {
                        Rec.ErrorDescription = " total price less than 0 ";
                        return false;
                    }
                    if (item.type.ToUpper() != "GS1" && item.type.ToUpper() != "EGS" )
                    {
                        Rec.ErrorDescription = " invalid item type "+ item.type;
                        return false;
                    }
                    foreach (var ite in item.tax)
                    {
                        if(ite.tax_type == null || ite.tax_sub_type == null)
                        {
                            Rec.ErrorDescription = " invalid tax type or sub type  ";
                            return false;
                        }
                    }
                 }
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion
        #region Inserter methods 
        private void insertBillHead(Invoice c)
        {
            string insertQuery = "";
            string bill_date = DateTime.Parse(c.invoice_date).ToString("yyyy-MMM-dd hh:mm tt");
            string bill_duedate = DateTime.Parse(c.invoice_due_date).ToString("yyyy-MMM-dd hh:mm tt");
            string comid = "1";

            // check if there is receipt or invoice with same BillNumber 
            //DataTable dt = fun.fireDataTable($"select * from INV_H_TBL where number = N'{c.number}' and DocumentType = N'{c.document_type}' ");
            //if (dt.Rows.Count >= 1) // if found old item with same bill number delete it 
            //{
            //    try
            //    {
            //        fun.fireDataTable($"delete from INV_H_TBL where  number = N'{c.number}' and DocumentType = N'{c.document_type}'  ");
            //    }
            //    catch
            //    {

            //    }
            //}
            int status = 0;
            double invoiceamout = c.items.Select(s => s.total_price).Sum();
            //insertQuery += " insert into [INV_H_TBL] ( number,Currency, branch_id,R_type,taxpayer_activity_code,invoice_Date,Document_Type,CURRENCY_EXCHANGE_RATE,purchase_order_reference,purchase_order_description ," +
            //    "sales_order_reference,sales_order_description,proforma_invoice_number,status,invoice_due_date,bank_name,bank_account_number,bank_address,delivery_terms," +
            //    "branchId , DocumentType ,R_city,R_street,R_building_number,R_postal_code,R_region_city,R_governate,R_name,R_country,InvoiceAmount)" +
            //     $" values ('{c.number}','{c.currency}','{c.branch_id}','{c.document_type}',N'{c.taxpayer_activity_code}','{DateTime.Parse(c.invoice_date).ToString("yyyy-MM-dd hh:mm tt")}','{c.document_type}','{c.currency_exchange_rate}','{c.purchase_order_reference}' ,'{c.purchase_order_description}' ,  " +
            //     $"'{c.sales_order_reference}','{c.sales_order_description}' ,'{c.proforma_invoice_number}','{status}','{DateTime.Parse(c.invoice_due_date).ToString("yyyy-MM-dd hh:mm tt")}',N'{c.bank.bank_name}', '{c.bank.bank_account_number}',N'{c.bank.bank_address}',N'{c.delivery_terms}'," +
            //     $" '{c.branch_id}','{c.document_type}',N'{c.customer.city}',N'{c.customer.street}',N'{c.customer.building_number}',N'{c.customer.postal_code}',N'{c.customer.city}',N'{c.customer.city}',N'{c.customer.name}',N'{c.customer.country}','{invoiceamout}' )";

            //,N'{c.taxpayer_activity_code}','{c.purchase_order_reference}' ,'{c.purchase_order_description}' ,  " +
            //            $"'{c.sales_order_reference}','{c.sales_order_description}' ,'{c.proforma_invoice_number}','{status}','',N'{c.bank.bank_name}', '{c.bank.bank_account_number}',N'{c.bank.bank_address}',N'{}',";



            //        N'{c.customer.city}',N'{c.customer.street}',N'{c.customer.building_number}',N'{c.customer.postal_code}',N'{c.customer.city}',N'{c.customer.city}',N'{c.customer.name}',N'{c.customer.country}','{invoiceamout}' )";

            // Department_ID,
            // //	,taxSubType	,	,environment_ID	,comid	,	countryOfOrigin	,grossWeight	,netWeight	,		,	,CancelReason	,digitalSignatureFeedback,	Payment_terms	,MainGroup_ID,	Request_id,	posserial,) ";
            //c.taxpayer_activity_code
            //// ---------------------------------------------------
            insertQuery += "insert into [Bill_Tbl] (BillNo,	Customer_ID,Currency,Discount_Amt,Discount_Rate,VAT,Delivery_terms,ShipmentMod,SalesOrderNo,BillDate,	Payment_Stutes,	Bill_Stutes,Editor,Date,branchid,documentType,sendToeta,currencyExchangeRate,taxType,BankInfoID,proformaInvoiceNumber,purchaseOrderReference,purchaseOrderDescription,salesOrderReference,salesOrderDescription,editor_id,comid,";
            //"":"","":"","":"","iban":"","bank_address":""
            insertQuery += "R_state,R_type, R_tax_id ,R_name,R_city,R_street,R_building_number,R_governate,R_country,B_name,B_account_number,B_swift_code,B_iban,B_address) ";
            insertQuery += $"values (N'{c.number}' ,N'{c.customer.tax_id}' ,N'{c.currency}' ,N'0' ,N'0' ,N'0' ,N'{c.delivery_terms}' ,N'0' ,N'0' ,N'{bill_date}',N'0',N'0',N'0',N'{bill_date}',N'{c.branch_id}',N'{c.document_type}',N'0',N'{c.currency_exchange_rate}',N'{c.customer.type}',N'{c.bank.bank_account_number}',N'{c.proforma_invoice_number}',N'{c.purchase_order_reference}',N'{c.purchase_order_description}',N'{c.sales_order_reference}',N'{c.sales_order_description}',N'{c.submission_user_id}',N'{comid}' ,";
            insertQuery += $" N'{c.customer.state}' ,N'{c.customer.type}',N'{c.customer.tax_id}',N'{c.customer.name}',N'{c.customer.city}', N'{c.customer.street}', N'{c.customer.building_number}', N'{c.customer.governate}' ,N'{c.customer.country}',N'{c.bank.bank_name}',N'{c.bank.bank_account_number}',N'{c.bank.swift_code}',N'{c.bank.iban}',N'{c.bank.bank_address}')";
           // fun.fireSQL(insertQuery);
            ComFun.fireSQL(insertQuery, UserSecurity.GetConnection());
        }
        private void insertBillDetails(Invoice c)
        {
            string comid = "1";
           
            int i = 0;
            foreach (var item in c.items)
            {
                i++;
                string insertQuery = " insert into [Bill_Detiles_Tbl] (SR_No,Items,GPC_Code,unitType_Ar,IntCode,Description,UnitPrice,NumberOfUnits,ItemDiscount_amount,ItemDiscount_rate," +
                    "documentType,BillNo,comid ,TotalPrice) values ";
                insertQuery += $" ( '{i}','{item.type}','{item.code}','{item.unit_type}','{item.internal_code}',N'{item.description}','{item.unit_price}','{item.quantity}','{item.discount_amount}','{item.discount_rate}'," +
                $"'{c.document_type}','{c.number}',N'{comid}',N'{ item.total_price}')  ";
                //if (i != c.items.Count)
                //if (i != c.items.Count)SR_No
                //    insertQuery += ",";

               // fun.fireSQL(insertQuery);
                ComFun.fireSQL(insertQuery, UserSecurity.GetConnection());
                // get itemid 
                int itemId = (int)fun.fireDataTable("select  max(record_id) LastId from  Bill_Detiles_Tbl").Rows[0]["LastId"];
                insertitemtax(itemId , item, c.document_type, c.number, 0, 0);

            }
        }

        private void insertitemtax(int Itemid , Item item, string doc , string BillNo , int env , int comid  )
        {
            int taxamount = 0; 
            string query = "";
            foreach (var col in item.tax)
            {
                query += $"insert into Bill_Tax_Tbl (Item_Record_ID , TAX_Code	,TAX_SubtCode,	TAX_Rate,	BillNo,	TaxAmount	,documentType,	environment_ID,	comid ) values ";
                query += $" (N'{Itemid}' , N'{col.tax_type}',N'{col.tax_sub_type}',N'{col.tax_rate}',N'{BillNo}',N'{taxamount}',N'{doc}',N'{env}',N'{comid}' )  ";
            }
           //fun.fireSQL(query);
            ComFun.fireSQL(query, UserSecurity.GetConnection());
           
        }


        private void deleteInvalidReceipt(string BillNo , string DocType)
        {
            string q = $@"
                delete from [Bill_Tbl]where BillNo=N'{BillNo}' and documentType = '{DocType}'
                delete from [Bill_Detiles_Tbl]where BillNo=N'{BillNo}' and documentType = '{DocType}'
                delete  from [Bill_Tax_Tbl]where BillNo=N'{BillNo}' and documentType = '{DocType}'
                ";
            ComFun.fireSQL(q, UserSecurity.GetConnection());
        }
        #endregion
    }
}