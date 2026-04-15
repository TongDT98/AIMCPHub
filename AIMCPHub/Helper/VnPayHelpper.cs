using App.Bussiness.DTOS.Response.Transaction;
using App.Core.Helper;

namespace AIMCPHub.Helpper
{
    public static class VnPayHelpper
    {
        public static bool ValidateSignature(IQueryCollection query,string hashSecret)
        {
          

            var data = new SortedList<string, string>();

            foreach (var key in query.Keys)
            {
                if (key.StartsWith("vnp_") && key != "vnp_SecureHash")
                {
                    data.Add(key, query[key]);
                }
            }

            var raw = string.Join("&", data.Select(x => $"{x.Key}={x.Value}"));

            var checkHash = HashSHA.HmacSHA512(hashSecret, raw);

            return checkHash == query["vnp_SecureHash"];
        }
        public static bool ValidateSignature1(IQueryCollection query, string hashSecret)
        {
            var data = new SortedList<string, string>();

            foreach (var key in query.Keys)
            {
                // VNPAY chỉ băm các field bắt đầu bằng vnp_ và bỏ qua chính cái hash
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_") && key != "vnp_SecureHash")
                {
                    data.Add(key, query[key]);
                }
            }

            // Cần UrlEncode để khớp với chuỗi gốc của VNPAY
            var raw = string.Join("&", data.Select(x =>
                $"{System.Net.WebUtility.UrlEncode(x.Key)}={System.Net.WebUtility.UrlEncode(x.Value)}"));

            var checkHash = HashSHA.HmacSHA512(hashSecret, raw);

            return checkHash.Equals(query["vnp_SecureHash"], StringComparison.InvariantCultureIgnoreCase);
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
