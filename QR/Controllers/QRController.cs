using Newtonsoft.Json;
using QR.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using static QR.Models.CallAPI;
using QR.Helpers;
using E_Inv_IntegrationLibrary_v2;

namespace QR.Controllers
{
    public class QRController : ApiController
    {
        E_Inv_IntegrationLibrary_v2.ConnectETA fun2 = new E_Inv_IntegrationLibrary_v2.ConnectETA();
        MyFunctions fun = new MyFunctions();
        DataTable dt = new DataTable();
        DataTable dtcom = new DataTable();
        Integrate_setup_tbl_New integration;
        string CustConn = "Data Source=A2NWPLSK14SQL-v03.shr.prod.iad2.secureserver.net;Initial Catalog=Scopos_Customers_DB;Persist Security Info=True;User ID=Tbi_Team ;Password=T81#t@M2022";
        [HttpPost]
        [Route("api/QR/Create")]
        public IHttpActionResult CreateQR([FromBody] API_Root callAPI)
        {
            var comTaxNO = int.Parse(Thread.CurrentPrincipal.Identity.Name);
            string rNum = CalAPI(callAPI);
            var q = $"Select * from com_tbl where id = {comTaxNO}";
            dtcom = fun.fireDataTable(q, CustConn, 3);
            string link = fun2.CreateQr_offline(int.Parse(dtcom.Rows[0]["Recourd_ID"].ToString()), 0, "", rNum, CustConn);
            fun2.SendToEta_request(1000, int.Parse(dtcom.Rows[0]["Recourd_ID"].ToString()), 0, 4, CustConn);
            return Ok(new { QRLink = link });
        }
        string CalAPI(API_Root callAPI)
        {
            var comTaxNO = int.Parse(Thread.CurrentPrincipal.Identity.Name);
            var q = $"Select * from Integrate_setup_tbl_New where Com_Tax_No = {comTaxNO}";
            dt = fun.fireDataTable(q, CustConn, 3);
            integration = Converter.GetItem<Integrate_setup_tbl_New>(dt.Rows[0]);
            string SetResponseDB_conn = integration.SetResponseDB;
            byte? DataResponseType = integration.DataResponseType;
            try {
                API_Root getAllInv = callAPI;
                if (getAllInv.invoices.Count > 0)
                {
                    for (int i = 0; i < getAllInv.invoices.Count; i++)
                    {

                        string document_type = getAllInv.invoices[i].document_type;
                        if (document_type == "I")
                        {
                            document_type = "S";
                        }
                        else if (document_type == "C")
                        {
                            document_type = "R";
                        }
                        string number = getAllInv.invoices[i].number;
                        string delivery_terms = getAllInv.invoices[i].delivery_terms.Replace("'", "");
                        string purchase_order_reference = getAllInv.invoices[i].purchase_order_reference.Replace("'", ""); ;
                        string purchase_order_description = getAllInv.invoices[i].purchase_order_description.Replace("'", ""); ;
                        string sales_order_reference = getAllInv.invoices[i].sales_order_reference.Replace("'", ""); ;
                        string sales_order_description = getAllInv.invoices[i].sales_order_description.Replace("'", ""); ;
                        string proforma_Invoices_number = getAllInv.invoices[i].proforma_invoice_number;
                        string currency = getAllInv.invoices[i].currency;
                        string branch_id = getAllInv.invoices[i].branch_id;
                        string taxpayer_activity_code = getAllInv.invoices[i].taxpayer_activity_code;
                        double currency_exchange_rate = getAllInv.invoices[i].currency_exchange_rate;
                        DateTime Invoices_date = DateTime.Parse(getAllInv.invoices[i].invoice_date);
                        string comments = ""; //getAllInv.Invoicess[i].comments;
                        string Invoices_due_date = getAllInv.invoices[i].invoice_due_date;
                        string submission_user_id = getAllInv.invoices[i].submission_user_id;
                        //Cus
                        string R_name = getAllInv.invoices[i].customer.name.Replace("'", "");
                        string R_tax_id = getAllInv.invoices[i].customer.tax_id.Replace("-", "").Trim();
                        string R_type = getAllInv.invoices[i].customer.type;
                        string R_country = getAllInv.invoices[i].customer.country.Replace("'", ""); ;
                        string R_state = getAllInv.invoices[i].customer.state.Replace("'", ""); ;
                        string R_city = getAllInv.invoices[i].customer.city.Replace("'", ""); ;
                        string R_street = getAllInv.invoices[i].customer.street.Replace("'", ""); ;
                        string R_building_number = getAllInv.invoices[i].customer.building_number.Replace("'", ""); ;
                        string R_postal_code = getAllInv.invoices[i].customer.postal_code;
                        string R_governate = getAllInv.invoices[i].customer.governate.Replace("'", ""); ;
                        string R_region_city = getAllInv.invoices[i].customer.region_city.Replace("'", ""); ;
                        string R_floor = getAllInv.invoices[i].customer.floor.Replace("'", ""); ;
                        string R_room = getAllInv.invoices[i].customer.room.Replace("'", ""); ;
                        string R_landmark = getAllInv.invoices[i].customer.landmark.Replace("'", ""); ;
                        string R_additional_information = getAllInv.invoices[i].customer.additional_information.Replace("'", ""); ;
                        //Bank
                        string bank_name = getAllInv.invoices[i].bank.bank_name.Replace("'", ""); ;
                        string bank_account_number = getAllInv.invoices[i].bank.bank_account_number;
                        string swift_code = getAllInv.invoices[i].bank.swift_code;
                        string iban = getAllInv.invoices[i].bank.iban;
                        string bank_address = getAllInv.invoices[i].bank.bank_address.Replace("'", ""); ;
                        // items
                        if (currency == "EGP" && R_type == "P")
                        {
                            currency_exchange_rate = 0;
                        }
                        string ins_H = "INSERT INTO [INV_H_Temp_TBL] ([document_type],[number],[purchase_order_reference],[purchase_order_description],[sales_order_reference],[sales_order_description],[proforma_Invoice_number],[currency],[branch_id],[taxpayer_activity_code],[currency_exchange_rate],[Invoice_date],[R_name],[R_tax_id],[R_type],[R_country],[R_state],[R_city],[R_street],[R_building_number],[R_postal_code],[R_governate],[R_region_city],[R_floor],[R_room],[R_landmark],[R_additional_information],PCAccount,UpdateDate,comments,Invoice_due_date,bank_name,bank_account_number,swift_code,iban,bank_address,delivery_terms,pageNo,submission_user_id)  VALUES ('"
                            + document_type + "','" + number + "',N'" + purchase_order_reference + "',N'" +
                            purchase_order_description + "',N'" + sales_order_reference + "',N'" + sales_order_description + "','" +
                            proforma_Invoices_number + "','" + currency + "','" + branch_id + "','" + taxpayer_activity_code + "','" +
                            currency_exchange_rate + "','" + Invoices_date.ToString("dd/MMM/yyyy") + "',N'" + R_name + "','" + R_tax_id + "','"
                            + R_type + "',N'" + R_country + "',N'" + R_state + "',N'" + R_city + "',N'" + R_street +
                            "',N'" + R_building_number + "','" + R_postal_code + "',N'" + R_governate + "',N'" + R_region_city +
                            "','" + R_floor + "','" + R_room + "','" + R_landmark + "',N'" + R_additional_information +
                            "','api',N'" + DateTime.Now.ToString("dd/MMM/yyyy HH:mm ") + "',N'" + comments + "','" + Invoices_due_date
                            + "',N'" + bank_name + "','" + bank_account_number + "','" + swift_code
                            + "','" + iban + "','" + bank_address + "',N'" + delivery_terms + "',0, '"+submission_user_id+"')";
                        if (R_type == "P")
                        {
                            fun.fireDB(ins_H, SetResponseDB_conn, (int)DataResponseType);

                        }
                        for (int ix = 0; ix < getAllInv.invoices[i].items.Count; ix++)
                        {
                            string Item_descriptionget = getAllInv.invoices[i].items[ix].description.Replace("'", ""); ;
                            string Item_type = getAllInv.invoices[i].items[ix].type;
                            string Item_code = getAllInv.invoices[i].items[ix].code;
                            double Item_tax_rate = getAllInv.invoices[i].items[ix].tax_rate;
                            string Item_tax_type = getAllInv.invoices[i].items[ix].tax_type;
                            string Item_tax_sub_type = getAllInv.invoices[i].items[ix].tax_sub_type;
                            double Item_quantity = getAllInv.invoices[i].items[ix].quantity;
                            string Item_internal_code = getAllInv.invoices[i].items[ix].internal_code;
                            double Item_total_price = getAllInv.invoices[i].items[ix].total_price;
                            double Item_discount_amount = getAllInv.invoices[i].items[ix].discount_amount;
                            double Item_discount_rate = getAllInv.invoices[i].items[ix].discount_rate;
                            string Item_unit_type = getAllInv.invoices[i].items[ix].unit_type;
                            string unit_price = getAllInv.invoices[i].items[ix].unit_price.ToString();
                            double Item_unit_price = double.Parse(unit_price);
                            string Item_name = getAllInv.invoices[i].items[ix].name.Replace("'", ""); ;
                            string ins_D = "INSERT INTO [INV_D_Temp_TBL]([Item_type],[Item_code],[Item_tax_rate],[Item_tax_type],[Item_tax_sub_type],[Item_quantity],[Item_internal_code],[Item_total_price],[Item_discount_amount],[Item_discount_rate],[Item_unit_type],[Item_unit_price],[Item_name],[INV_no] ,[document_type],Item_descriptionget)  VALUES ('"
                                + Item_type + "','" + Item_code + "','" + Item_tax_rate + "','" + Item_tax_type +
                                "','" + Item_tax_sub_type + "','" + Item_quantity + "','" + Item_internal_code +
                                "','" + Item_total_price + "','" + Item_discount_amount + "','" +
                                Item_discount_rate + "','" + Item_unit_type + "'," + Item_unit_price + ",N'" +
                                Item_name + "','" + number + "','" + document_type + "',N'" + Item_descriptionget + "')";
                            if (R_type == "P")
                            {
                                fun.fireDB(ins_D, SetResponseDB_conn, (int)DataResponseType); 
                            }
                        }
                        if (R_type == "P")
                        {
                            fun.fireDB("UpdateINV_pro", SetResponseDB_conn, (int)DataResponseType); 
                        }
                    } 
                }
                return getAllInv.invoices[0].number;
            }
            catch (Exception)
            {
                throw;
            }

        }
        /* 
         * string base64String = "This is an QR Code";
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            var image = qrcode.Draw(qr, 50);
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, ImageFormat.Jpeg);
                byte[] imageBytes = m.ToArray();
                base64String = Convert.ToBase64String(imageBytes);
            }
         */


    }
}
