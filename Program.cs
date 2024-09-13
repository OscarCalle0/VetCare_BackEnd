using DotNetEnv;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VetCare_BackEnd.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Env.Load();
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var connectionDB = $"server={dbHost};port={dbPort};database={dbDatabaseName};uid={dbUser};password={dbPassword}";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionDB, ServerVersion.Parse("8.0.20-mysql")));

// Configure secret key and expiration time for JWT
var jwtKey = Environment.GetEnvironmentVariable("JWTKEY") ?? throw new InvalidOperationException("JWT Key is not configured.");
var jwtExpireMinutes = int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRE_MINUTES") ?? "30"); // Use JWT_EXPIRE_MINUTES for expiration minutes

// Add JwtService to the dependency container
builder.Services.AddSingleton(new JwtService(jwtKey, jwtExpireMinutes));

// Debug message to verify that the JWT key has been loaded correctly
Console.WriteLine($"JWT Key Loaded: {jwtKey}");

// Ensure that the key has at least 16 bytes (128 bits)
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

// Configure JWT services
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey)),
        ClockSkew = TimeSpan.Zero // No time tolerance
    };
});

// Add custom services to the collection
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddSingleton(new JwtService(jwtKey, jwtExpireMinutes));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

// // For checking if requests are arriving
// app.Use(async (context, next) =>
// {
//     Console.WriteLine($"Request received for {context.Request.Path}");
//     await next();
// });

app.UseHttpsRedirection();

app.UseAuthentication(); // Authentication middleware

app.UseAuthorization();

app.MapControllers();

app.Run();
