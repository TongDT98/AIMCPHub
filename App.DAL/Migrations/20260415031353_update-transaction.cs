using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatetransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionCode",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceCode",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsIPN",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReturnUrl",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Vnp_Amount",
                table: "Transactions",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vnp_Command",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Vnp_CreateDate",
                table: "Transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vnp_CurrCode",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Vnp_ExpireDate",
                table: "Transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vnp_IpAddr",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vnp_Locale",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vnp_OrderInfo",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vnp_OrderType",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vnp_ReturnUrl",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vnp_SecureHash",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vnp_TmnCode",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vnp_TxnRef",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vnp_Version",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "vnpIpnLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vnp_TmnCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_BankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_BankTranNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_CardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_PayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Vnp_OrderInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_ResponseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_TxnRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_SecureHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_vnpIpnLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VnpReturnUrlLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vnp_TmnCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_BankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_BankTranNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_CardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_PayDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Vnp_OrderInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_TransactionNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_ResponseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_TxnRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vnp_SecureHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_VnpReturnUrlLogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("0cab2e03-cb2f-4c82-afa4-2584127c1889"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6545), new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6545) });

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("50e41743-40e5-43fe-9cc9-bf3ca57e6cc3"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6542), new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6542) });

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("594a3515-a34c-42fa-8b9f-649536330f57"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6518), new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6530) });

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("a4571b49-9174-49d7-9c1a-ba8c916b1b55"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6548), new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6548) });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("43ae9ab0-b5b7-42c1-a614-0914fc750514"),
                columns: new[] { "CreatedDate", "LastUpdatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6756), new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6757), "Oc6lajB/2Ob4sckbeWlwHTIdJf9rHuu6+3+5P6808W0=", "k+7jWcgofEFBWMkmHdaS2ZsYvnric6+AjbfefbC9rYE=" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc6bab7a-67ca-4e2e-bde1-a51c44e58091"),
                columns: new[] { "CreatedDate", "Email", "FirstName", "LastUpdatedDate", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6771), "accounting@gmail.com", "Accounting", new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6772), "Oc6lajB/2Ob4sckbeWlwHTIdJf9rHuu6+3+5P6808W0=", "k+7jWcgofEFBWMkmHdaS2ZsYvnric6+AjbfefbC9rYE=", "accounting@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("71822f66-6763-47cd-aea7-2269f495c733"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6728), new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6728) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("9e268971-e925-4825-80d3-dbb59fae2417"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6725), new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6726) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("e3a5878f-0a7c-4ecc-84f0-452d63a1b3e5"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6722), new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6722) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vnpIpnLogs");

            migrationBuilder.DropTable(
                name: "VnpReturnUrlLogs");

            migrationBuilder.DropColumn(
                name: "IsIPN",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsReturnUrl",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_Amount",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_Command",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_CreateDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_CurrCode",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_ExpireDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_IpAddr",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_Locale",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_OrderInfo",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_OrderType",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_ReturnUrl",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_SecureHash",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_TmnCode",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_TxnRef",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Vnp_Version",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "TransactionCode",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceCode",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("0cab2e03-cb2f-4c82-afa4-2584127c1889"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4901), new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4901) });

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("50e41743-40e5-43fe-9cc9-bf3ca57e6cc3"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4897), new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4898) });

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("594a3515-a34c-42fa-8b9f-649536330f57"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4869), new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4883) });

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("a4571b49-9174-49d7-9c1a-ba8c916b1b55"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4903), new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(4903) });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("43ae9ab0-b5b7-42c1-a614-0914fc750514"),
                columns: new[] { "CreatedDate", "LastUpdatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5082), new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5082), "YJoIC8eESJtkTB2FLA6M/lh/FHTW6bwLWca37zI1Ltw=", "/gAEGNuNsbKSRli0XdIUqrA3ZnKV1NDrRWESp0gf5eU=" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc6bab7a-67ca-4e2e-bde1-a51c44e58091"),
                columns: new[] { "CreatedDate", "Email", "FirstName", "LastUpdatedDate", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5165), "admin@gmail.com", "Administrator", new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5166), "YJoIC8eESJtkTB2FLA6M/lh/FHTW6bwLWca37zI1Ltw=", "/gAEGNuNsbKSRli0XdIUqrA3ZnKV1NDrRWESp0gf5eU=", "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("71822f66-6763-47cd-aea7-2269f495c733"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5061), new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5061) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("9e268971-e925-4825-80d3-dbb59fae2417"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5058), new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5059) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("e3a5878f-0a7c-4ecc-84f0-452d63a1b3e5"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5054), new DateTime(2026, 4, 9, 16, 56, 43, 128, DateTimeKind.Local).AddTicks(5055) });
        }
    }
}
