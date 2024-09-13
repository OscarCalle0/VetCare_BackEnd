using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetCare_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class CreatingFalseDataForTheAppointmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "appointments",
                columns: new[] { "Id", "AppointmentTypeId", "Available", "Description", "EndDate", "PetId", "StartDate" },
                values: new object[,]
                {
                    { 1, 2, false, "cardiology", new DateOnly(2023, 8, 23), 1, new DateOnly(2023, 8, 22) },
                    { 2, 1, true, null, new DateOnly(2023, 7, 23), 2, new DateOnly(2023, 7, 22) },
                    { 3, 2, false, "cardiology", new DateOnly(2023, 6, 23), 3, new DateOnly(2023, 6, 22) },
                    { 4, 1, true, null, new DateOnly(2023, 5, 23), 4, new DateOnly(2023, 5, 22) },
                    { 5, 2, false, "cardiology", new DateOnly(2023, 4, 23), 5, new DateOnly(2023, 4, 22) },
                    { 6, 1, true, null, new DateOnly(2023, 3, 23), 6, new DateOnly(2023, 3, 22) },
                    { 7, 2, false, "cardiology", new DateOnly(2023, 2, 23), 6, new DateOnly(2023, 2, 22) },
                    { 8, 1, true, null, new DateOnly(2023, 1, 23), 7, new DateOnly(2023, 1, 22) }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 11, 22), "3lzfdb86d4", "Calista_Bogisich80@yahoo.com", "Boyer", "Eladio", "oqCywh9jC3", "599 542 36 79", 2 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber" },
                values: new object[] { new DateOnly(2023, 12, 11), "6caimfrs10", 5, "Guillermo74@hotmail.com", "Collier", "Jayde", "Ql_8IqYob8", "249 284 77 90" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 6, 15), "ydeut628ml", 4, "Trevion.Pollich@gmail.com", "Tremblay", "Zelma", "VAeus60yPS", "746 578 37 27", 3 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 11, 21), "bbr6206qz5", 4, "Kitty_Senger52@gmail.com", "Nitzsche", "Braden", "LQKZayQxy5", "480 345 35 57", 2 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 11, 28), "xtap4jiltz", 1, "Claud79@hotmail.com", "Barrows", "Armand", "4um6h5hq10", "138 644 92 30", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "appointments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 5, 20), "8mrdd5ljey", "Bret67@hotmail.com", "Zieme", "Efrain", "GhSOMGIJ14", "612 105 05 95", 5 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber" },
                values: new object[] { new DateOnly(2023, 11, 22), "4xulqozcyc", 2, "Kaylin.Ruecker@gmail.com", "Gutmann", "Torrey", "0ILDYJFbnj", "278 426 51 98" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 1, 5), "8wflnq5bgr", 1, "Monte_Kutch62@gmail.com", "Kuhic", "Darrin", "TpZRUBPuRR", "532 886 98 79", 4 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 11, 15), "8gh5sfevl8", 2, "Lilliana.Toy68@hotmail.com", "Gerhold", "Trisha", "o2PtSGxbCE", "222 389 76 51", 5 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 12, 1), "93s02ixwws", 2, "Aiden.Larkin13@gmail.com", "Cruickshank", "Giovanny", "ChD9X2fewt", "189 200 28 18", 4 });
        }
    }
}
