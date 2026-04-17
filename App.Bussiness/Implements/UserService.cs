using App.Bussiness.DTOS.Request;
using App.Bussiness.DTOS.Request.User;
using App.Bussiness.DTOS.Response;
using App.Bussiness.DTOS.Response.Users;
using App.Bussiness.Interfaces;
using App.Core.Helper;
using App.DAL.Dtos;
using App.DAL.Entities;
using App.DAL.Extentions;
using App.DAL.Repositories.Interfaces;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Bussiness.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;
       
        public UserService(IUserRepository userRepository,IUnitOfWork unitOfWork,IRoleRepository rolerepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _roleRepository = rolerepository;
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
        public GenericActionResult CreateUser(CreateUSerRequest request)
        {
            try
            {
                var uservalid = _userRepository.AsNoTracking().FirstOrDefault(x => x.Email == request.Email);
                if (uservalid != null) return new GenericActionResult("409", "Email already exist", (int)HttpStatusCode.Conflict);
                var role_vallid = _roleRepository.AsNoTracking().FirstOrDefault(x => x.Id == request.RoleId);
                if (role_vallid == null) return new GenericActionResult("400", "Role not found", (int)HttpStatusCode.BadRequest);

                var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); // ms
                var random = new Random().Next(100, 999); // 3 số random
                var code = $"{timestamp}{random}";
                var passdefault = new Random().Next(100000, 999999);
                byte[] salt;
                string hash = PasswordHasher.HashPassword(passdefault.ToString(), out salt);
                var usernew = new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.FirstName,
                    Mobile = request.PhoneNumber,
                    Email = request.Email,
                    UserName = request.Email,
                    RoleId = request.RoleId,
                    PasswordSalt = Convert.ToBase64String(salt),
                    PasswordHash = hash,
                    Code = code,
                    UserLoginFailCount = 0,
                    IsRequestForgetPassword = true
                };
                var userCreated = new NewUserResponse
                {
                    Id = usernew.Id,
                    Code = code,
                    UserName = request.Email,
                    DefaultPassword = passdefault.ToString(),
                    Role = role_vallid.Name
                };
                _userRepository.Add(usernew);
                _userRepository.SaveChange();
                return new GenericActionResult(userCreated);
            }
            catch(Exception ex)
            {
                return new GenericActionResult("500", $"{ex.Message}", 500);
            }

        }
        public GenericActionResult ChangePassword(ChangePasswordRequest request,Guid CurentId)
        {
            try
            {


                var user = _userRepository.Queryable().FirstOrDefault(x => x.Id == CurentId);
                if (user == null) return new GenericActionResult("User has been Blocked");
                byte[] saltBytes = Convert.FromBase64String(user.PasswordSalt);
                var pass = PasswordHasher.VerifyPassword(request.OldPassword, user.PasswordHash, saltBytes);
                if (!pass) return new GenericActionResult("400", "Password incorrect", 400);
                byte[] salt;
                string hash = PasswordHasher.HashPassword(request.NewPassword, out salt);
                user.PasswordHash = hash;
                user.PasswordSalt = Convert.ToBase64String(salt);
                _userRepository.Update(user);
                _userRepository.SaveChange();
                return new GenericActionResult("Change password success");
            }
            catch(Exception ex)
            {
                return new GenericActionResult("500", $"{ex.Message}", 500);
            }
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
