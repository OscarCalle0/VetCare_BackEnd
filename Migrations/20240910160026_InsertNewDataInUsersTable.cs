using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetCare_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InsertNewDataInUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 2, 13), "ccgfu51fl6", 1, "Felicita_Wunsch69@hotmail.com", "Kihn", "Afton", "ZhxFy0U9Uk", "578 385 94 00", 2 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 12, 14), "c8qfsvfzmf", 5, "Rachel99@hotmail.com", "Kuhn", "Imelda", "BJOLyCy2Ec", "787 950 50 06", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 3, 27), "z6yb0q7lch", 136, "Ettie.Green7@hotmail.com", "Morar", "Ora", "_GecPSCeV5", "514 514 88 21", 48 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 5, 26), "hr7hb8yvh1", 82, "Vesta10@gmail.com", "Schiller", "Alfredo", "1jnmtHKbcV", "897 871 28 15", 121 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 12, 19), "fo7ul3jc01", 197, "Obie_Strosin46@gmail.com", "McLaughlin", "Shawna", "jWepjNWwIf", "533 787 37 66", 254 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 1, 12), "rj0me3egmt", 89, "Tara9@hotmail.com", "Mayer", "Jack", "mHvwLQJrLU", "721 237 82 10", 229 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2024, 5, 4), "zy4ah7s136", 182, "Loraine_Fay91@gmail.com", "Stamm", "Jewell", "t7FsnAvREY", "090 595 80 81", 71 });
        }
    }
}
