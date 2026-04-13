using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Permission : BaseEntity
    {
        public Guid ModuleId { get; set; }
        public string Code { get; set; }
    }
}
