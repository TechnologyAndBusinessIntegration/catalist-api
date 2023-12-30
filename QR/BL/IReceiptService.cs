using QR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QR.Models.CallAPI;

namespace QR.BL
{
    public interface IReceiptService
    {
         List<Invoice> GetReceiptsListFromJson(string JSON); 
         ValidateAndUnValidateReceipts GetValidReceipts(List<Invoice> Receipts); 
         void SaveValidInvoices(List<Invoice> Receipt);
         void SaveFailedInvoices(List<Invoice> Receipt);
        BillResponseVM GetBillResponse (string BillNo, string DocType);
        string GetReceiptuuidbyBillNo(string BillNo, string DocType);
        Response<ReceiptResult> GetReceiptByBillNo(string BillNo);
    }
}
