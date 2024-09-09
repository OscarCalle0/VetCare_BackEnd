using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetCare_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class CreateDataForDocumentTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
