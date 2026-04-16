using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace App.DAL.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid UserId { get; set; }
        public double Amount { get; set; }
        public string? TransactionCode { get; set; }
        public string? InvoiceCode { get; set; }
        public string? Vnp_Version { get; set; }
        public string? Vnp_Command { get; set; }
        public string? Vnp_TmnCode { get; set; }
        public double? Vnp_Amount { get; set; }
        public DateTime? Vnp_CreateDate { get; set; }
        public string? Vnp_IpAddr { get; set; }
        public DateTime? Vnp_ExpireDate { get; set; }
        public string? Vnp_CurrCode { get; set; }
        public string? Vnp_Locale { get; set; }
        public string? Vnp_OrderInfo { get; set; }
        public string? Vnp_OrderType { get; set; }
        public string? Vnp_ReturnUrl { get; set; }
        public string? Vnp_TxnRef { get; set; }
        public string? Vnp_SecureHash { get; set; }
        public int Status { get; set; }
        public bool IsReturnUrl { get; set; } = false;
        public bool IsIPN { get; set; } = false;
    }
}
