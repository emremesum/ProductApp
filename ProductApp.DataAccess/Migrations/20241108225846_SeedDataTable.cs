using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactForms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2354), new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2356) });

            migrationBuilder.UpdateData(
                table: "ContactForms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2358), new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2363) });

            migrationBuilder.UpdateData(
                table: "ContactForms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2365), new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2366) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 8, 22, 58, 45, 651, DateTimeKind.Utc).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContactForms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 8, 22, 49, 49, 658, DateTimeKind.Utc).AddTicks(3247), new DateTime(2024, 11, 8, 22, 49, 49, 658, DateTimeKind.Utc).AddTicks(3248) });

            migrationBuilder.UpdateData(
                table: "ContactForms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 3, 22, 49, 49, 658, DateTimeKind.Utc).AddTicks(3250), new DateTime(2024, 11, 8, 22, 49, 49, 658, DateTimeKind.Utc).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "ContactForms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 11, 6, 22, 49, 49, 658, DateTimeKind.Utc).AddTicks(3258), new DateTime(2024, 11, 8, 22, 49, 49, 658, DateTimeKind.Utc).AddTicks(3258) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 8, 22, 49, 49, 658, DateTimeKind.Utc).AddTicks(3295));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 8, 22, 49, 49, 658, DateTimeKind.Utc).AddTicks(3298));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2024, 11, 8, 22, 49, 49, 658, DateTimeKind.Utc).AddTicks(3074));
        }
    }
}
