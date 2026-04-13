using App.Bussiness.DTOS.Request;
using App.Bussiness.DTOS.Request.User;
using App.Bussiness.DTOS.Response;
using App.Bussiness.Interfaces;
using App.DAL.Dtos;
using App.DAL.Extentions;
using App.DAL.Repositories.Interfaces;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace App.Bussiness.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;
       
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public GenericActionResult GetUSerDetail(Guid Id)
        {
            var user = _userRepository.Queryable().FirstOrDefault(x => x.Id == Id);
            if (user == null)  return new GenericActionResult { Message = "User not found"};
            var role = _roleRepository.Queryable().FirstOrDefault(y => y.Id == user.RoleId);
            return new GenericActionResult
            {
                Success = true,
                HttpStatusCode = (int)HttpStatusCode.OK,
                Data = new UserDto
                {
                    Id = user.Id,
                    Code = user.Code,
                    Name = user.FirstName,
                    UserName = user.UserName,
                    RoleId = user.RoleId,
                }
            };
        }
        public GenericActionResult GetUser(Guid id)
        {
            var user = _userRepository.Queryable().FirstOrDefault(x => x.Id == id);
            if (user == null) return new GenericActionResult() { Message = "User not found" };
            var role = _roleRepository.Queryable().FirstOrDefault(y => y.Id == user.RoleId);
            return new GenericActionResult
            {
                Success = true,
                HttpStatusCode = (int)HttpStatusCode.OK,
                Data = new UserDto
                {
                    Id = user.Id,
                    Code = user.Code,
                    Name = user.FirstName,
                    UserName = user.UserName,
                    RoleId = user.RoleId,
                }
            };
        }
        public GenericActionResult Search(FilterModel<SearchUserRequest> filter)
        {
            var data = _userRepository.Queryable()
                                              .WhereIf(!string.IsNullOrWhiteSpace(filter.Filter.Name), x => x.FirstName.Contains(filter.Filter.Name!))
                                                .WhereIf(!string.IsNullOrWhiteSpace(filter.Filter.Code), x => x.Code.Contains(filter.Filter.Code!));
                                              
            var total = data.Count();
            var res = data.OrderByDescending(x => x.CreatedDate).Skip(filter.Offset).Take(filter.PageSize);

           

            var result = new List<UserDto>();
            foreach (var item in res)
            {
               
                result.Add(new UserDto
                {
                    Id = item.Id,
                   Name = item.FirstName,
                   Code = item.Code,
                   UserName = item.UserName,
                   RoleId = item.RoleId,    
                });
            }

            return new GenericActionResult(total, result);
        }
    }

}
