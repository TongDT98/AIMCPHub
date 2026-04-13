using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class ApplicationUser : BaseEntity
    {
        [Description("Mã tài khoản hệ thống")]
        public string Code { get; set; }

        [Description("Ten nguoi dung")]
        public string FirstName { get; set; }
        [Description("Ten nguoi dung")]
        public string? LastName { get; set; }

        [Description("Hình ảnh lớn đại diện của tài khoản người dùng")]
        public string? AvatarPath { get; set; }

        [Description("Hình ảnh thumbnail đại diện của tài khoản người dùng")]
        public string? AvatarThumbnailPath { get; set; }

        [Description("Số điện thoại người dùng")]
        public string Mobile { get; set; }

        [Description("Email của người dùng")]
        public string Email { get; set; }

        [Description("Tên đăng nhập")]
        public string? UserName { get; set; }

        [Description("Quyền")]
        public Guid RoleId { get; set; }
        [Description("Phòng Ban")]
        public Guid? DepartmentId { get; set; }
        [Description("Mật khẩu đã mã hóa")]
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }

        [Description("Lần đăng nhập cuối cùng")]
        public DateTime? LastLogin { get; set; }

        [Description("Refresh token")]
        public string? RefreshToken { get; set; }

        [Description("Thời gian hết hạn của refresh token")]
        public DateTime RefreshTokenExpiryTime { get; set; }

        [Description("Số lần đăng nhập sai")]
        public int UserLoginFailCount { get; set; }

        [Description("Lần đăng nhập sai cuối cùng")]
        public DateTime? LastTimeLoginFail { get; set; }

        [Description("Yêu cầu quên mật khẩu")]
        public bool IsRequestForgetPassword { get; set; }

        [Description("Dữ liệu lấy bên bảng AppKeyConfig, keyName: user_status")]
        public string? StatusCode { get; set; }

        [Description("Mô tả")]
        public string? Description { get; set; }

        [Description("Nhóm người dùng")]
        public Guid? UserGroupId { get; set; }
    }
}
