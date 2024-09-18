using DotNetEnv;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using VetCare_BackEnd.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VetCare_BackEnd.Models;
using VetCare_BackEnd.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables
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
var jwtExpireMinutes = int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRE_MINUTES") ?? "30");

// Add JwtService to the dependency container
builder.Services.AddSingleton(new JwtService(jwtKey, jwtExpireMinutes));

// Debug: verify that the JWT key has been loaded correctly
Console.WriteLine($"JWT Key Loaded: {jwtKey}");

// Configure JWT authentication services
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

// Add custom services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<JwtHelper>();
builder.Services.AddScoped<ImageHelper>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://192.168.89.167:6969", "http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

// Add HTTP context and controllers
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VetCare API", Version = "v1" });

    // Define security scheme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    // Require authentication for all endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    // Include the XML file for documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath); // This is where it gets included
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VetCare API V1");
});

// Middleware
app.UseCors("AllowSpecificOrigin");
app.UseStaticFiles();
app.UseAuthentication(); // Authentication middleware
app.UseAuthorization();

app.MapControllers();

// Configure application to listen on a specified port or default to 6969
var port = Environment.GetEnvironmentVariable("PORT") ?? "6969";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();
