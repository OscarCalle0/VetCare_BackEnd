using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetCare_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class CreatingFalseDatafortheAppointmentTypesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "appointmentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "consult" },
                    { 2, "exam" },
                    { 3, "appointment" }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 12, 11), "obnlia8eyh", 2, "Myrl51@yahoo.com", "Botsford", "Garnett", "AzqlRdErLu", "711 597 49 32", 5 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber" },
                values: new object[] { new DateOnly(2024, 2, 25), "v518o2o2ja", 1, "Gianni_Beahan56@hotmail.com", "Crist", "Tracy", "6xzTe1OvO8", "684 785 47 69" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber" },
                values: new object[] { new DateOnly(2023, 12, 24), "uuhaq4wn9c", 5, "Ellie_West@gmail.com", "MacGyver", "Carlee", "GXoC57lCI8", "522 747 54 13" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 11, 8), "5t8zuoicgt", 1, "Omer.Will30@yahoo.com", "Littel", "Mose", "na_5zmuOVv", "979 031 20 76", 3 });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 11, 22), "32mth3ofqk", 2, "Jasen_Mayer@hotmail.com", "Gleason", "Albertha", "7ru59G7Wh1", "680 393 16 91", 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "appointmentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "appointmentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "appointmentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[] { new DateOnly(2023, 11, 22), "3lzfdb86d4", 1, "Calista_Bogisich80@yahoo.com", "Boyer", "Eladio", "oqCywh9jC3", "599 542 36 79", 2 });

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
                columns: new[] { "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber" },
                values: new object[] { new DateOnly(2024, 6, 15), "ydeut628ml", 4, "Trevion.Pollich@gmail.com", "Tremblay", "Zelma", "VAeus60yPS", "746 578 37 27" });

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
    }
}
