using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.DTOS.Request.Transaction
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public string OrderInfo { get; set; }
       // public string OrderId { get; set; }
    }
}
