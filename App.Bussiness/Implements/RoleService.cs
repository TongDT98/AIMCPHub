using App.Bussiness.DTOS.Request.User;
using App.Bussiness.DTOS.Request;
using App.Bussiness.DTOS.Response;
using App.Bussiness.Interfaces;
using App.DAL.Dtos;
using App.DAL.Repositories.Implements;
using App.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL.Extentions;

namespace App.Bussiness.Implements
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public GenericActionResult ListRole()
        {
            {
                var data = _roleRepository.AsNoTracking();
                var total = data.Count();
                return new GenericActionResult(total, data);
            }
        } 
    }
}
