using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Configurations
{
    public class JwtConfiguration
    {
        public string? SecretKey { get; set; }

        /// <summary>
        /// Đơn vị phát hành JWT. Thường là tên của dịch vụ hoặc ứng dụng phát hành token.
        /// </summary>
        public string? Issuer { get; set; }

        /// <summary>
        /// Đối tượng mà JWT được phát hành cho. Thường là tên của ứng dụng hoặc dịch vụ nhận token.
        /// </summary>
        public string? Audience { get; set; }
    }
}
