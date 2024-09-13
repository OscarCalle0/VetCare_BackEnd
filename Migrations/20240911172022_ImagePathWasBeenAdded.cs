using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetCare_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class ImagePathWasBeenAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "pets",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 4, 14), "xztndcx7od", 5, "Faustino70@gmail.com", "Denesik", "Ricardo", "bu65XjOhyv", "517 210 06 62", 5 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 8, 14), "fz8999c8um", 2, "Maddison_Kassulke65@hotmail.com", "Powlowski", "Khalid", "_hEuc66Jdu", "543 844 64 00", 5 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 11, 16), "k9tlz9yp80", 1, "Mckenzie7@hotmail.com", "Waelchi", "Alfredo", "vHX10HlrMx", "867 158 24 83", 1 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "DocumentNumber", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 5, 10), "hxmznka2z3", "Adrian_Stehr38@hotmail.com", "Effertz", "Lonzo", "qipj8BIh_I", "212 520 18 15", 3 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 11, 5), "j4aoindr0q", 1, "Kyle.Hansen59@hotmail.com", "Nienow", "Cornell", "OijPKMLEwR", "378 561 21 56", 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "pets");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 10, 6), "p63r9ekxnn", 1, "Eleonore.Mosciski@yahoo.com", "Cummings", "Myles", "j4Rikt4gLK", "404 229 49 47", 4 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 2, 5), "9ed5076f7u", 5, "Savanah_Marquardt@yahoo.com", "Lemke", "Wendy", "Y8dO6RM4zl", "634 059 53 74", 1 });

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
                columns: new[] { "BirthDate", "DocumentNumber", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 2, 13), "ccgfu51fl6", "Felicita_Wunsch69@hotmail.com", "Kihn", "Afton", "ZhxFy0U9Uk", "578 385 94 00", 2 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 12, 14), "c8qfsvfzmf", 5, "Rachel99@hotmail.com", "Kuhn", "Imelda", "BJOLyCy2Ec", "787 950 50 06", 3 });
        }
    }
}
