using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Department : BaseEntity
    {
        public string? Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
