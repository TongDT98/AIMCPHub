using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.DAL.Migrations
{
    /// <inheritdoc />
    public partial class innit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarThumbnailPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserLoginFailCount = table.Column<int>(type: "int", nullable: false),
                    LastTimeLoginFail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRequestForgetPassword = table.Column<bool>(type: "bit", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissionModules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationRoles",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "ExtraProperties", "IsActived", "IsDeleted", "LastUpdatedBy", "LastUpdatedDate", "Name", "OrderIndex" },
                values: new object[,]
                {
                    { new Guid("0cab2e03-cb2f-4c82-afa4-2584127c1889"), "HR", null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4901), "Nhân sự", null, true, false, null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4901), "HR", 1 },
                    { new Guid("50e41743-40e5-43fe-9cc9-bf3ca57e6cc3"), "IT", null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4897), "Công nghệ thông tin", null, true, false, null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4898), "IT Service", 1 },
                    { new Guid("594a3515-a34c-42fa-8b9f-649536330f57"), "Admin", null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4869), "Quản trị viên", null, true, false, null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4883), "Administrator", 1 },
                    { new Guid("a4571b49-9174-49d7-9c1a-ba8c916b1b55"), "ACC", null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4903), "Kế toán", null, true, false, null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4903), "Accouting", 1 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "AvatarPath", "AvatarThumbnailPath", "Code", "CreatedBy", "CreatedDate", "DepartmentId", "Description", "Email", "ExtraProperties", "FirstName", "IsActived", "IsDeleted", "IsRequestForgetPassword", "LastLogin", "LastName", "LastTimeLoginFail", "LastUpdatedBy", "LastUpdatedDate", "Mobile", "OrderIndex", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpiryTime", "RoleId", "StatusCode", "UserGroupId", "UserLoginFailCount", "UserName" },
                values: new object[,]
                {
                    { new Guid("43ae9ab0-b5b7-42c1-a614-0914fc750514"), null, null, "SPX0001", null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5082), new Guid("9e268971-e925-4825-80d3-dbb59fae2417"), null, "admin@gmail.com", null, "Administrator", true, false, true, null, null, null, null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5082), "1234566798", 1, "YJoIC8eESJtkTB2FLA6M/lh/FHTW6bwLWca37zI1Ltw=", "/gAEGNuNsbKSRli0XdIUqrA3ZnKV1NDrRWESp0gf5eU=", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("594a3515-a34c-42fa-8b9f-649536330f57"), null, null, 0, "admin@gmail.com" },
                    { new Guid("bc6bab7a-67ca-4e2e-bde1-a51c44e58091"), null, null, "SPX0002", null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5165), new Guid("71822f66-6763-47cd-aea7-2269f495c733"), null, "admin@gmail.com", null, "Administrator", true, false, true, null, null, null, null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5166), "1234566798", 1, "YJoIC8eESJtkTB2FLA6M/lh/FHTW6bwLWca37zI1Ltw=", "/gAEGNuNsbKSRli0XdIUqrA3ZnKV1NDrRWESp0gf5eU=", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a4571b49-9174-49d7-9c1a-ba8c916b1b55"), null, null, 0, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "ExtraProperties", "IsActived", "IsDeleted", "LastUpdatedBy", "LastUpdatedDate", "Name", "OrderIndex" },
                values: new object[,]
                {
                    { new Guid("71822f66-6763-47cd-aea7-2269f495c733"), "D-ACC", null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5061), "Kế toán", null, true, false, null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5061), "Accouting", 1 },
                    { new Guid("9e268971-e925-4825-80d3-dbb59fae2417"), "D-HR", null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5058), "Nhân sự", null, true, false, null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5059), "HR", 1 },
                    { new Guid("e3a5878f-0a7c-4ecc-84f0-452d63a1b3e5"), "D-IT", null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5054), "Công nghệ thông tin", null, true, false, null, new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5055), "IT Service", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "PermissionModules");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "RolePermissionModules");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserPermissions");
        }
    }
}
