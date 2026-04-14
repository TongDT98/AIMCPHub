using App.Bussiness.DTOS.Request.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.Interfaces
{
   public interface ITransactionService
    {
        string CreatePaymentUrl(PaymentRequest payment, string ip);
    }
}
