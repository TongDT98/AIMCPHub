using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid UserId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string TransactionCode { get; set; }
        public string InvoiceCode { get; set; }
    }
}
