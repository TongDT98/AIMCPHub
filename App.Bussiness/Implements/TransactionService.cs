using App.Bussiness.DTOS.Request.Transaction;
using App.Bussiness.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.Implements
{
    public class TransactionService : ITransactionService
    {
        private readonly IConfiguration _config;
        public TransactionService(IConfiguration config)
        {
        _config = config;
        }
    
        public string CreatePaymentUrl(PaymentRequest payment, string ip)
        {
            var vnp = new SortedList<string, string>();

            vnp.Add("vnp_Version", "2.1.0");
            vnp.Add("vnp_Command", "pay");
            vnp.Add("vnp_TmnCode", _config["VnPay:TmnCode"]);
            vnp.Add("vnp_Amount", ((long)(payment.Amount * 100)).ToString());
            vnp.Add("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnp.Add("vnp_IpAddr", ip);
            vnp.Add("vnp_ExpireDate", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss"));
            vnp.Add("vnp_CurrCode", "VND");
            vnp.Add("vnp_Locale", "vn");
            vnp.Add("vnp_OrderInfo", payment.OrderInfo);
            vnp.Add("vnp_OrderType","other");
            vnp.Add("vnp_ReturnUrl", _config["VnPay:ReturnUrl"]);
            vnp.Add("vnp_TxnRef", payment.OrderId);           
            var query = string.Join("&", vnp.Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value)}"));
            var hash = HmacSHA512(_config["VnPay:HashSecret"], query);
            return $"{_config["VnPay:BaseUrl"]}?{query}&vnp_SecureHash={hash}";
        }

        //public bool ValidateSignature(IQueryCollection query)
        //{
        //    var hashSecret = _config["VnPay:HashSecret"];

        //    var data = new SortedList<string, string>();

        //    foreach (var key in query.Keys)
        //    {
        //        if (key.StartsWith("vnp_") && key != "vnp_SecureHash")
        //        {
        //            data.Add(key, query[key]);
        //        }
        //    }

        //    var raw = string.Join("&", data.Select(x => $"{x.Key}={x.Value}"));

        //    var checkHash = HmacSHA512(hashSecret, raw);

        //    return checkHash == query["vnp_SecureHash"];
        //}

        private string HmacSHA512(string key, string input)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var inputBytes = Encoding.UTF8.GetBytes(input);

            using var hmac = new HMACSHA512(keyBytes);
            return BitConverter.ToString(hmac.ComputeHash(inputBytes)).Replace("-", "").ToLower();
        }
    }
}
