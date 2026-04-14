using App.Bussiness.DTOS.Request.Transaction;
using App.Bussiness.DTOS.Response;
using App.Bussiness.DTOS.Response.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.Interfaces
{
   public interface ITransactionService
    {
        GenericActionResult CreatePaymentUrl(PaymentRequest payment, string ip);
        VnPayResponse HandlerVnpayIPN(VnPayCallbackDto request);
        VnPayResponse HandlerVnpayReturn(VnPayCallbackDto request);
    }
}
