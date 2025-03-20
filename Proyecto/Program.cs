using Proyecto.Data;
using Microsoft.EntityFrameworkCore;

//using SgbdWebApi Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AddDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorks")));

/*builder.Services.AddDbContext<AddDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorks"),
    sqlServerOprionsAction: SqlCompareOptions => {

        SqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(38),
            errorNumbersToAdd: null);
    
    }));*/

var app = builder.Build();

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
