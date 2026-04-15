using App.Bussiness.DTOS.Request.Transaction;
using App.Bussiness.DTOS.Response;
using App.Bussiness.DTOS.Response.Transaction;
using App.Bussiness.Interfaces;
using App.Core.Helper;
using App.DAL.Entities;
using App.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.Implements
{
    public class TransactionService : ITransactionService
    {
        private readonly IConfiguration _config;
        private readonly ITransactionRepository _transaction;
        private readonly IUnitOfWork _uniofwork;
        private readonly IVnpIpnLogRepository _ipnRepository;
        private readonly IVnpReturnUrlLogRepository _returnUrlLogRepository;
        public TransactionService(IConfiguration config,ITransactionRepository transaction,IUnitOfWork unitofwork,IVnpReturnUrlLogRepository returnurl,IVnpIpnLogRepository ipnlog)
        {
            _config = config;
            _transaction = transaction;
            _uniofwork = unitofwork;
            _ipnRepository = ipnlog;
            _returnUrlLogRepository = returnurl;
        }
       
        public GenericActionResult CreatePaymentUrl(PaymentRequest payment, string ip)
        {
            try
            {
                var date = DateTime.Now.ToString("yyyyMMdd");
                /// oder code tạm thoi sing ngau nhien
                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); // ms
                var random = new Random().Next(100, 999); // 3 số random
                var oderID = $"{date}{timestamp}{random}";
                string version = "2.1.0";
                string paycommand = "pay";
                string tmncode = _config["VnPay:TmnCode"];
                long amount = ((long)(payment.Amount * 100));
                string curency = "VND";
                string loce = "vn";
                string ordertype = "other";
                DateTime createdate = DateTime.Now;
                DateTime ExDate = createdate.AddMinutes(10);
                var vnp = new SortedList<string, string>();
                vnp.Add("vnp_Version", version);
                vnp.Add("vnp_Command", paycommand);
                vnp.Add("vnp_TmnCode", tmncode);
                vnp.Add("vnp_Amount", amount.ToString());
                vnp.Add("vnp_CreateDate", createdate.ToString("yyyyMMddHHmmss"));
                vnp.Add("vnp_IpAddr", ip);
                vnp.Add("vnp_ExpireDate", ExDate.ToString("yyyyMMddHHmmss"));
                vnp.Add("vnp_CurrCode", curency);
                vnp.Add("vnp_Locale", loce);
                vnp.Add("vnp_OrderInfo", payment.OrderInfo);
                vnp.Add("vnp_OrderType", ordertype);
                vnp.Add("vnp_ReturnUrl", _config["VnPay:ReturnUrl"]);
                vnp.Add("vnp_TxnRef", oderID);
                var query = string.Join("&", vnp.Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value)}"));
                var hash = HashSHA.HmacSHA512(_config["VnPay:HashSecret"], query);
                var url = $"{_config["VnPay:BaseUrl"]}?{query}&vnp_SecureHash={hash}";
                var newTransaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    Vnp_Version = version,
                    Vnp_Amount = amount,
                    Vnp_Command = paycommand,
                    Vnp_CreateDate = createdate,
                    Vnp_CurrCode = curency,
                    Vnp_ExpireDate = ExDate,
                    Vnp_IpAddr = ip,
                    Vnp_Locale = loce,
                    Vnp_OrderInfo = payment.OrderInfo,
                    Vnp_OrderType = ordertype,
                    Vnp_ReturnUrl = url,
                    Vnp_SecureHash = hash,
                    Vnp_TmnCode = tmncode,
                    Vnp_TxnRef = oderID,  
                    Amount = (double)payment.Amount,
                    
                };
                _transaction.Add(newTransaction);
                _transaction.SaveChange();               
                return new GenericActionResult { Data = url };
            }
            catch (Exception ex) 
            {
                return new GenericActionResult("500",ex.Message,(int)HttpStatusCode.InternalServerError);
            }
        }
        public VnPayResponse HandlerVnpayIPN(VnPayCallbackDto request)
        {
            try
            {
                
                var transaction = _transaction.Queryable().FirstOrDefault(x=> x.Vnp_TxnRef == request.Vnp_TxnRef);
                if (transaction == null) return new VnPayResponse{ Message = "Không tìm tháy transaction"};
                transaction.IsIPN = true;
                var ipn = new VnpIpnLog
                {
                    Id = Guid.NewGuid(),
                    Vnp_PayDate = request.Vnp_PayDate,
                     ExtraProperties = request.DataRequest,
                     Vnp_Amount = request.Vnp_Amount,
                     Vnp_BankCode = request.Vnp_BankCode,
                     Vnp_BankTranNo = request.Vnp_BankTranNo,
                     Vnp_CardType = request.Vnp_CardType,
                     Vnp_OrderInfo = request.Vnp_OrderInfo,
                     Vnp_ResponseCode = request.Vnp_ResponseCode,
                     Vnp_SecureHash = request.Vnp_SecureHash,
                     Vnp_TmnCode = request.Vnp_TmnCode,
                     Vnp_TransactionNo = request.Vnp_TransactionNo,
                     Vnp_TransactionStatus = request.Vnp_TransactionStatus,
                     Vnp_TxnRef = request.Vnp_TxnRef,                    
                };
                _ipnRepository.Add(ipn);
                _ipnRepository.SaveChange();
                _transaction.SaveChange();
                return new VnPayResponse();
            }
            catch (Exception ex)
            {
                return new VnPayResponse();
            }
        }
        public VnPayResponse HandlerVnpayReturn(VnPayCallbackDto request)
        {
            try
            {

                var transaction = _transaction.Queryable().FirstOrDefault(x => x.Vnp_TxnRef == request.Vnp_TxnRef);
                if (transaction == null) return new VnPayResponse { Message = "Không tìm tháy transaction" };
                transaction.IsReturnUrl = true;
                var rtn = new VnpReturnUrlLog
                {
                    Id = Guid.NewGuid(),
                    Vnp_PayDate = request.Vnp_PayDate,
                    ExtraProperties = request.DataRequest,
                    Vnp_Amount = request.Vnp_Amount,
                    Vnp_BankCode = request.Vnp_BankCode,
                    Vnp_BankTranNo = request.Vnp_BankTranNo,
                    Vnp_CardType = request.Vnp_CardType,
                    Vnp_OrderInfo = request.Vnp_OrderInfo,
                    Vnp_ResponseCode = request.Vnp_ResponseCode,
                    Vnp_SecureHash = request.Vnp_SecureHash,
                    Vnp_TmnCode = request.Vnp_TmnCode,
                    Vnp_TransactionNo = request.Vnp_TransactionNo,
                    Vnp_TransactionStatus = request.Vnp_TransactionStatus,
                    Vnp_TxnRef = request.Vnp_TxnRef,
                };
                _returnUrlLogRepository.Add(rtn);
                _returnUrlLogRepository.SaveChange();
                _transaction.SaveChange();
                return new VnPayResponse { RspCode = "00",Message = "Success"};
            }
            catch (Exception ex)
            {
                return new VnPayResponse { RspCode = "99", Message = "Erorr" };
            }
        }




    }
}
