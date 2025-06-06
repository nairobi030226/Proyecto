using Proyecto.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Proyecto.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Proyecto.Application;
//using SgbdWebApi Data;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor de dependencias
// Habilita el uso de controladores para manejar solicitudes HTTP
builder.Services.AddControllers();
// Configura Swagger para documentación de la API
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<AddDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorks")));

// Configura el contexto de base de datos usando SQL Server
builder.Services.AddDbContext<AddDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        // Habilita reintentos en caso de fallos en la conexión a la base de datos
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5, // Número máximo de intentos
            maxRetryDelay: TimeSpan.FromSeconds(30), // Tiempo de espera entre intentos
            errorNumbersToAdd: null); // Lista de errores específicos que activan el reintento
    }));
// Registra la implementación del repositorio para inyección de dependencias
builder.Services.AddScoped<IPersonPhoneRepository,PersonPhoneRepository>();
builder.Services.AddScoped<IPersonPhoneOperation, PersonPhoneOperation>();
var app = builder.Build();




// Configuración del pipeline de la aplicación
if (app.Environment.IsDevelopment()) // Si está en modo desarrollo
{
    app.UseSwagger(); // Habilita Swagger
    app.UseSwaggerUI(); // Habilita la interfaz de Swagger
}

// Fuerza el uso de HTTPS en las solicitudes
app.UseHttpsRedirection();  
// Habilita la autorización en la API
app.UseAuthorization(); 
// Mapea los controladores para manejar rutas y peticiones HTTP
app.MapControllers(); 
// Ejecuta la aplicación
app.Run();