using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Env.Load();
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var conectionDB = $"server={dbHost};port={dbPort};database={dbDatabaseName};uid={dbUser};password={dbPassword}";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(conectionDB, ServerVersion.Parse("8.0.20-mysql")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
// // Endpoint para verificar la conexión con la base de datos
// app.MapGet("/check-db", async (ApplicationDbContext dbContext) =>
// {
//     try
//     {
//         // Intenta realizar una consulta simple para verificar la conexión
//         var canConnect = await dbContext.Database.CanConnectAsync();
//         if (canConnect)
//         {
//             return Results.Ok("La conexión a la base de datos es exitosa.");
//         }
//         else
//         {
//             return Results.Problem("La conexión a la base de datos falló.", statusCode: StatusCodes.Status500InternalServerError);
//         }
//     }
//     catch (Exception ex)
//     {
//         // Manejar excepciones de conexión
//         return Results.Problem($"La conexión a la base de datos falló: {ex.Message}", statusCode: StatusCodes.Status500InternalServerError);
//     }
// });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//mi primer comentario practica