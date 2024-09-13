using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetCare_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InsertDataInUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 3, 27), "z6yb0q7lch", 136, "Ettie.Green7@hotmail.com", "Morar", "Ora", "_GecPSCeV5", "514 514 88 21", 48 },
                    { 2, new DateOnly(2024, 5, 26), "hr7hb8yvh1", 82, "Vesta10@gmail.com", "Schiller", "Alfredo", "1jnmtHKbcV", "897 871 28 15", 121 },
                    { 3, new DateOnly(2023, 12, 19), "fo7ul3jc01", 197, "Obie_Strosin46@gmail.com", "McLaughlin", "Shawna", "jWepjNWwIf", "533 787 37 66", 254 },
                    { 4, new DateOnly(2024, 1, 12), "rj0me3egmt", 89, "Tara9@hotmail.com", "Mayer", "Jack", "mHvwLQJrLU", "721 237 82 10", 229 },
                    { 5, new DateOnly(2024, 5, 4), "zy4ah7s136", 182, "Loraine_Fay91@gmail.com", "Stamm", "Jewell", "t7FsnAvREY", "090 595 80 81", 71 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
