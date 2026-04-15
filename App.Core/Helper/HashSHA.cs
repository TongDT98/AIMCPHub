using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Helper
{
    public static class HashSHA
    {
        public static string HmacSHA512(string key, string input)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var inputBytes = Encoding.UTF8.GetBytes(input);

            using var hmac = new HMACSHA512(keyBytes);
            return BitConverter.ToString(hmac.ComputeHash(inputBytes)).Replace("-", "").ToLower();
        }
        //public static string HmacSHA512(string key, string inputData)
        //{
        //    var hash = new StringBuilder();
        //    byte[] keyBytes = Encoding.UTF8.GetBytes(key);
        //    byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
        //    using (var hmac = new HMACSHA512(keyBytes))
        //    {
        //        byte[] hashValue = hmac.ComputeHash(inputBytes);
        //        foreach (var theByte in hashValue) hash.Append(theByte.ToString("x2"));
        //    }
        //    return hash.ToString();
        //}
    }
}
