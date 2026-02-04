using API.DataAccess.DataAccess;
using Backend.Domain.Model.AutoMapper;
using Console.Migration.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using StudentRegistration.API.Services;
using System.Text;
using TCI.API.DataAccess.DataAccess.CRUD.Procesos.NroSolicitudDato;


// Inicializa Logger para guardar en archivo Log
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Error("Inicio la ejecución");


try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Respeta mayúsculas/minúsculas
    });

    // Habilitar CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin() // Permitir todas las solicitudes de origen. O usa WithOrigins("http://localhost:8080") para permitir solo este dominio.
           .AllowAnyMethod() // Permitir todos los métodos HTTP (GET, POST, etc.).
           .AllowAnyHeader(); // Permitir todos los encabezados.
    });
    });

    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        serverOptions.Limits.MaxRequestBodySize = 100_000_000; // 100 MB
    });

    // Logger File
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var connectionString = builder.Configuration.GetConnectionString("Default");

    // Register the DbContext as a service of data base
    builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(connectionString));


    // Registro del Lazy<>
    builder.Services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
    builder.Services.AddScoped<IPedidosCore, PedidosCore>();
    builder.Services.AddAutoMapper(typeof(PedidoProfile));

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //Auth
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddSwaggerGen(c =>
    {
        //c.EnableAnnotations();
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Services",
            Version = "v.1.0.10",
            Description = "Web Api",
            TermsOfService = new Uri("https://github.com/brayangarzon108-hash/Backend_Syac"),
            Contact = new OpenApiContact
            {
                Name = "Contáctanos - Website",
                Url = new Uri("https://github.com/brayangarzon108-hash/Backend_Syac")
            },
            License = new OpenApiLicense
            {
                Name = "Licencia",
                Url = new Uri("https://github.com/brayangarzon108-hash/Backend_Syac")
            }
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                Array.Empty<string>()
            }
            });


    });

    builder.Services.ConfigureHttpJsonOptions(options =>
    {
        options.SerializerOptions.PropertyNamingPolicy = null;
        options.SerializerOptions.WriteIndented = false;

        // Interpretar fechas siempre con yyyy-MM-dd
        //options.SerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        //options.SerializerOptions.Converters.Add(new DateTimeJsonConverter());
    });

    var services = builder.Services;

    var app = builder.Build();

    // Configure the HTTP request pipeline.

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    app.UseHttpsRedirection();

    // Usar la política CORS configurada
    app.UseCors("CorsPolicy");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    logger.Error(e, "Error [500] Internal Server Error: Se detuvo el sistema por el siguiente error inesperado: " + e.Message);
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}

public class LazyResolver<T> : Lazy<T> where T : class
{
    public LazyResolver(IServiceProvider serviceProvider)
        : base(() => serviceProvider.GetRequiredService<T>())
    {
    }
}