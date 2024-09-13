using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetCare_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class creationoffalsedataforthepetstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "pets",
                columns: new[] { "Id", "BirthDate", "Breed", "Name", "Sex", "Weight", "user_id" },
                values: new object[,]
                {
                    { 2, new DateOnly(2024, 2, 9), "yorkie", "apolo", "male", "10lbs", 1 },
                    { 3, new DateOnly(2024, 3, 12), "border colie", "princesa", "female", "7lbs", 2 },
                    { 4, new DateOnly(2024, 4, 23), "pomerania", "cookie", "male", "3lbs", 3 },
                    { 5, new DateOnly(2024, 5, 4), "bulldog", "motas", "female", "12lbs", 4 },
                    { 6, new DateOnly(2024, 6, 3), "creole", "coco", "male", "6lbs", 5 },
                    { 7, new DateOnly(2024, 7, 2), "creole", "romeo", "female", "8lbs", 6 },
                    { 8, new DateOnly(2024, 8, 1), "yorkie", "kira", "male", "9lbs", 7 }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "pets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 10, 6), "p63r9ekxnn", "Eleonore.Mosciski@yahoo.com", "Cummings", "Myles", "j4Rikt4gLK", "404 229 49 47", 4 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber" },
                values: new object[] { new DateOnly(2024, 2, 5), "9ed5076f7u", 5, "Savanah_Marquardt@yahoo.com", "Lemke", "Wendy", "Y8dO6RM4zl", "634 059 53 74" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 6, 7), "74si1odva8", 3, "Claude.Lesch66@gmail.com", "Koss", "Ben", "5tS6Q0_loz", "105 526 93 41", 2 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 2, 13), "ccgfu51fl6", 1, "Felicita_Wunsch69@hotmail.com", "Kihn", "Afton", "ZhxFy0U9Uk", "578 385 94 00", 2 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 12, 14), "c8qfsvfzmf", 5, "Rachel99@hotmail.com", "Kuhn", "Imelda", "BJOLyCy2Ec", "787 950 50 06", 3 });
        }
    }
}
