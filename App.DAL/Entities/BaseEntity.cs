using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class BaseEntity
    {
        [Key]
        [Description("Khóa chính")]
        public Guid Id { get; set; }

        [Description("Xác định bản ghi dữ liệu đã bị xóa hay chưa, xóa mềm")]
        public bool IsDeleted { get; set; } = false;

        [Description("Xác định bản ghi dữ liệu đã có hoạt động hay không")]
        public bool IsActived { get; set; } = true;

        [Description("Thứ tự sắp xếp bản ghi")]
        public int OrderIndex { get; set; } = 1;

        [Description("Dữ liệu mở rộng, dạng json")]
        public string? ExtraProperties { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Guid? LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
    }
}
