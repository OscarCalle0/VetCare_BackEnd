using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetCare_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class CreationofthecolumnDeleteHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "documentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "documentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "documentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "documentTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "documentTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "documentTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "documentTypes",
                keyColumn: "Id",
                keyValue: 7);

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

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "documentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cédula de Ciudadanía" },
                    { 2, "Tarjeta de Identidad" },
                    { 3, "Pasaporte" },
                    { 4, "Número de Identificación Tributaria" },
                    { 5, "Cédula de Extranjería" },
                    { 6, "Registro Civil" },
                    { 7, "Permiso Especial de Permanencia" }
                });

            migrationBuilder.InsertData(
                table: "pets",
                columns: new[] { "Id", "BirthDate", "Breed", "ImagePath", "Name", "Sex", "Weight", "user_id" },
                values: new object[,]
                {
                    { 2, new DateOnly(2024, 2, 9), "yorkie", null, "apolo", "male", "10lbs", 1 },
                    { 3, new DateOnly(2024, 3, 12), "border colie", null, "princesa", "female", "7lbs", 2 },
                    { 4, new DateOnly(2024, 4, 23), "pomerania", null, "cookie", "male", "3lbs", 3 },
                    { 5, new DateOnly(2024, 5, 4), "bulldog", null, "motas", "female", "12lbs", 4 },
                    { 6, new DateOnly(2024, 6, 3), "creole", null, "coco", "male", "6lbs", 5 },
                    { 7, new DateOnly(2024, 7, 2), "creole", null, "romeo", "female", "8lbs", 6 },
                    { 8, new DateOnly(2024, 8, 1), "yorkie", null, "kira", "male", "9lbs", 7 }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "BirthDate", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 12, 11), "obnlia8eyh", 2, "Myrl51@yahoo.com", "Botsford", "Garnett", "AzqlRdErLu", "711 597 49 32", 5 },
                    { 2, new DateOnly(2024, 2, 25), "v518o2o2ja", 1, "Gianni_Beahan56@hotmail.com", "Crist", "Tracy", "6xzTe1OvO8", "684 785 47 69", 1 },
                    { 3, new DateOnly(2023, 12, 24), "uuhaq4wn9c", 5, "Ellie_West@gmail.com", "MacGyver", "Carlee", "GXoC57lCI8", "522 747 54 13", 3 },
                    { 4, new DateOnly(2023, 11, 8), "5t8zuoicgt", 1, "Omer.Will30@yahoo.com", "Littel", "Mose", "na_5zmuOVv", "979 031 20 76", 3 },
                    { 5, new DateOnly(2023, 11, 22), "32mth3ofqk", 2, "Jasen_Mayer@hotmail.com", "Gleason", "Albertha", "7ru59G7Wh1", "680 393 16 91", 4 }
                });
        }
    }
}
