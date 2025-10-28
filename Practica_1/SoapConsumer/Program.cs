using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Forzar ambiente a Development para que Swagger siempre funcione
builder.Environment.EnvironmentName = "Development";

// Configurar para usar solo HTTP en puerto 5001
builder.WebHost.UseUrls("http://localhost:5001");

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "SOAP Service Consumer API",
        Version = "v1",
        Description = "API para consumir y gestionar servicios SOAP con dotnet-svcutil"
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
// Swagger siempre habilitado en esta aplicación
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// Endpoint raíz con información
app.MapGet("/", () => new
{
    titulo = "SOAP Service Consumer API",
    version = "v1",
    descripcion = "API para consumir servicios SOAP usando dotnet-svcutil",
    documentacion = "http://localhost:5001/swagger/index.html",
    endpoints = new
    {
        informacion = "GET /api/soap/info",
        instalar_herramienta = "POST /api/soap/install-tool",
        generar_proxy = "POST /api/soap/generate-proxy",
        consumir_servicio = "POST /api/soap/consume-service",
        servicios_registrados = "GET /api/soap/services"
    }
}).WithName("Info").WithOpenApi();

app.Run();

