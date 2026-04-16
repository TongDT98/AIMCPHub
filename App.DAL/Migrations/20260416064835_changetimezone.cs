using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changetimezone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("0cab2e03-cb2f-4c82-afa4-2584127c1889"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(5268), new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(5268) });

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("50e41743-40e5-43fe-9cc9-bf3ca57e6cc3"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(5264), new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(5264) });

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("594a3515-a34c-42fa-8b9f-649536330f57"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(5238), new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(5245) });

            migrationBuilder.UpdateData(
                table: "ApplicationRoles",
                keyColumn: "Id",
                keyValue: new Guid("a4571b49-9174-49d7-9c1a-ba8c916b1b55"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(5272), new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(5272) });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("43ae9ab0-b5b7-42c1-a614-0914fc750514"),
                columns: new[] { "CreatedDate", "LastUpdatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(6059), new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(6060), "W9z/rq6anI3aSZUUaZvPjnXuaaqh8OmPX/Au5G2BK6k=", "GtXTz62dhU29RX8yhoww45BR6z9elYdTeXHAvuao6KU=" });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: new Guid("bc6bab7a-67ca-4e2e-bde1-a51c44e58091"),
                columns: new[] { "CreatedDate", "LastUpdatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(6095), new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(6096), "W9z/rq6anI3aSZUUaZvPjnXuaaqh8OmPX/Au5G2BK6k=", "GtXTz62dhU29RX8yhoww45BR6z9elYdTeXHAvuao6KU=" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("71822f66-6763-47cd-aea7-2269f495c733"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(6023), new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(6024) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("9e268971-e925-4825-80d3-dbb59fae2417"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(6020), new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(6021) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("e3a5878f-0a7c-4ecc-84f0-452d63a1b3e5"),
                columns: new[] { "CreatedDate", "LastUpdatedDate" },
                values: new object[] { new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(6014), new DateTime(2026, 4, 16, 6, 48, 32, 289, DateTimeKind.Utc).AddTicks(6015) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedDate", "LastUpdatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6771), new DateTime(2026, 4, 15, 10, 13, 51, 870, DateTimeKind.Local).AddTicks(6772), "Oc6lajB/2Ob4sckbeWlwHTIdJf9rHuu6+3+5P6808W0=", "k+7jWcgofEFBWMkmHdaS2ZsYvnric6+AjbfefbC9rYE=" });

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
    }
}
