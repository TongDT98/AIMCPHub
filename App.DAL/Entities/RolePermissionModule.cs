using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class RolePermissionModule : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Guid PermissionModuleId { get; set; }
    }
}
