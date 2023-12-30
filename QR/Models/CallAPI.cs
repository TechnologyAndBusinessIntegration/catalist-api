using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QR.Models
{
    public class CallAPI
    {
        //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Customer
        {
            public string name { get; set; }
            public string tax_id { get; set; }
            public string type { get; set; }
            public string country { get; set; }
            public string state { get; set; }
            public string city { get; set; }
            public string street { get; set; }
            public string building_number { get; set; }
            public string postal_code { get; set; }
            public string governate { get; set; }
            public string region_city { get; set; }
            public string floor { get; set; }
            public string room { get; set; }
            public string landmark { get; set; }
            public string additional_information { get; set; }
        }

        public class Bank
        {
            public string bank_name { get; set; }
            public string bank_account_number { get; set; }
            public string swift_code { get; set; }
            public string iban { get; set; }
            public string bank_address { get; set; }
        }

  
        public class tax
        {
            public decimal tax_rate { get; set; }
            public string tax_sub_type { get; set; }
            public string tax_type { get; set; }
        }
        public class Item
        {
            public double discount_amount { get; set; }
            public double discount_rate { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public string code { get; set; }
            public double tax_rate { get; set; }
            public string tax_type { get; set; }
            public string tax_sub_type { get; set; }
            public double quantity { get; set; }
            public string internal_code { get; set; }
            public double total_price { get; set; }
            public string unit_type { get; set; }
            public string unit_price { get; set; }
            public string name { get; set; }
            public List<tax> tax{ get; set; }
    }

        public class Invoice
        {
            public string  ErrorDescription { get; set; } 
            public string document_type { get; set; }
            public string number { get; set; }
            public string delivery_terms { get; set; }
            public string purchase_order_reference { get; set; }
            public string purchase_order_description { get; set; }
            public string sales_order_reference { get; set; }
            public string sales_order_description { get; set; }
            public string proforma_invoice_number { get; set; }
            public string currency { get; set; }
            public string branch_id { get; set; }
            public string taxpayer_activity_code { get; set; }
            public double currency_exchange_rate { get; set; }
            public string invoice_date { get; set; }
            public string invoice_due_date { get; set; }
            public string submission_user_id { get; set; }
            public Customer customer { get; set; }
            public Bank bank { get; set; }
            public List<Item> items { get; set; }
        }

        public class API_Root
        {
            public int code { get; set; }
            public List<Invoice> invoices { get; set; }
        }


        


    }
}