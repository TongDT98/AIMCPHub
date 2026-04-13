using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class UserPermission : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PerissionId { get; set; }
    }
}
