using App.Bussiness.DTOS.Response.Transaction;
using App.Core.Helper;
using System.Net;
using System.Text;

namespace AIMCPHub.Helpper
{
    public static class VnPayHelpper
    {
        
        public static bool ValidateSignature(IQueryCollection queryString, string secretKey)
        {
            var vnpayData = new SortedList<string, string>();
            string vnp_SecureHash = "";

            // 1. Lấy toàn bộ dữ liệu từ QueryString
            foreach (var key in queryString.Keys)
            {
                var value = queryString[key].ToString();
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    if (key == "vnp_SecureHash")
                    {
                        vnp_SecureHash = value;
                    }
                    else
                    {
                        vnpayData.Add(key, value);
                    }
                }
            }

            // 2. Tạo chuỗi dữ liệu để kiểm tra (Raw Data)
            // Chú ý: Phải dùng WebUtility.UrlEncode để khớp với cách VNPAY băm dữ liệu
            StringBuilder data = new StringBuilder();
            foreach (var kv in vnpayData)
            {
                if (!string.IsNullOrEmpty(kv.Value))
                {
                    data.Append(WebUtility.UrlEncode(kv.Key) + "=" + WebUtility.UrlEncode(kv.Value) + "&");
                }
            }

            // Xóa dấu & cuối cùng
            string rawData = data.ToString().TrimEnd('&');

            // 3. Tính toán lại mã Hash từ dữ liệu nhận được
            string checkSum = HashSHA.HmacSHA512(secretKey, rawData);

            // 4. So sánh mã vừa tính với mã VNPAY gửi sang
            return checkSum.Equals(vnp_SecureHash, StringComparison.InvariantCultureIgnoreCase);
        }
        public static VnPayCallbackDto GetDataVnpCallback(IQueryCollection query,string requestData)
        {
            try
            {
                var dto = new VnPayCallbackDto
                {
                    Vnp_TmnCode = query["vnp_TmnCode"],
                    Vnp_Amount = query["vnp_Amount"],
                    Vnp_BankCode = query["vnp_BankCode"],
                    Vnp_TransactionNo = query["vnp_TransactionNo"],
                    Vnp_CardType = query["vnp_CardType"],
                    Vnp_OrderInfo = query["vnp_OrderInfo"],
                    Vnp_TxnRef = query["vnp_TxnRef"],
                    Vnp_ResponseCode = query["vnp_ResponseCode"],
                    Vnp_BankTranNo = query["vnp_BankTranNo"],
                    Vnp_TransactionStatus = query["vnp_TransactionStatus"],
                    Vnp_SecureHash = query["vnp_SecureHash"],
                    Vnp_PayDate  = DateTime.ParseExact(query["vnp_PayDate"], "yyyyMMddHHmmss", null),
                    DataRequest = requestData,
                    // full data để verify hash
                };
                return dto;

            }
            catch (Exception ex) 
            {
                return null;
            }

        }
    }
}
