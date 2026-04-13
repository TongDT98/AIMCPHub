using App.Core.Helper;
using App.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL
{
    public class MasterDataInnit
    {
        private readonly ModelBuilder modelBuilder;

        public MasterDataInnit(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            byte[] salt;
            string hash = PasswordHasher.HashPassword("123456aA@", out salt);
            
            modelBuilder.Entity<ApplicationRole>().HasData(
                 new ApplicationRole
                 {
                     Id = new Guid("594a3515-a34c-42fa-8b9f-649536330f57"),
                     Name = "Administrator",
                     Code = "Admin",
                     Description = "Quản trị viên",

                 },
                  new ApplicationRole
                  {
                      Id = new Guid("50e41743-40e5-43fe-9cc9-bf3ca57e6cc3"),
                      Name = "IT Service",
                      Code = "IT",
                      Description = "Công nghệ thông tin",
                  },
                  new ApplicationRole
                  {
                      Id = new Guid("0cab2e03-cb2f-4c82-afa4-2584127c1889"),
                      Name = "HR",
                      Code = "HR",
                      Description = "Nhân sự",
                  },
                   new ApplicationRole
                   {
                       Id = new Guid("a4571b49-9174-49d7-9c1a-ba8c916b1b55"),
                       Name = "Accouting",
                       Code = "ACC",
                       Description = "Kế toán",
                   }
            );
            modelBuilder.Entity<Department>().HasData(

                 new Department
                 {
                     Id = new Guid("e3a5878f-0a7c-4ecc-84f0-452d63a1b3e5"),
                     Name = "IT Service",
                     Code = "D-IT",
                     Description = "Công nghệ thông tin",
                 },
                 new Department
                 {
                     Id = new Guid("9e268971-e925-4825-80d3-dbb59fae2417"),
                     Name = "HR",
                     Code = "D-HR",
                     Description = "Nhân sự",
                 },
                  new Department
                  {
                      Id = new Guid("71822f66-6763-47cd-aea7-2269f495c733"),
                      Name = "Accouting",
                      Code = "D-ACC",
                      Description = "Kế toán",
                  }
           );
            modelBuilder.Entity<ApplicationUser>().HasData(

                new ApplicationUser
                {
                    Id = new Guid("43ae9ab0-b5b7-42c1-a614-0914fc750514"),
                    FirstName = "Administrator",
                    Mobile = "1234566798",
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    RoleId = new Guid("594a3515-a34c-42fa-8b9f-649536330f57"),
                    DepartmentId = new Guid("9e268971-e925-4825-80d3-dbb59fae2417"),
                    PasswordSalt = Convert.ToBase64String(salt),
                    PasswordHash = hash,
                    Code = "SPX0001",
                    UserLoginFailCount = 0,
                    IsRequestForgetPassword = true
                },
                 new ApplicationUser
                 {
                     Id = new Guid("bc6bab7a-67ca-4e2e-bde1-a51c44e58091"),
                     FirstName = "Administrator",
                     Mobile = "1234566798",
                     Email = "admin@gmail.com",
                     UserName = "admin@gmail.com",
                     RoleId = new Guid("a4571b49-9174-49d7-9c1a-ba8c916b1b55"),
                     DepartmentId = new Guid("71822f66-6763-47cd-aea7-2269f495c733"),
                     PasswordSalt = Convert.ToBase64String(salt),
                     PasswordHash = hash,
                     Code = "SPX0002",
                     UserLoginFailCount = 0,
                     IsRequestForgetPassword = true
                 }
            );

        }
    }

}
