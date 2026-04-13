using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Helper
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password, out byte[] salt)
        {
            // Tạo một Salt ngẫu nhiên
            salt = RandomNumberGenerator.GetBytes(32);

            // Kết hợp Password và Salt
            var combinedPassword = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();

            // Băm bằng SHA256
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(combinedPassword);

            return Convert.ToBase64String(hash);
        }

        public static bool VerifyPassword(string password, string storedHash, byte[] storedSalt)
        {
            // Băm lại password nhập vào với salt đã lưu
            var combinedPassword = Encoding.UTF8.GetBytes(password).Concat(storedSalt).ToArray();

            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(combinedPassword);

            // So sánh chuỗi băm
            return storedHash == Convert.ToBase64String(hash);
        }
    }
}
