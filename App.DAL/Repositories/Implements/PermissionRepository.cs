using App.DAL.Entities;
using App.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repositories.Implements
{
    public class PermissionRepository : GenericRepository<Permission>,IPermissionRepository
    {
        public PermissionRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
