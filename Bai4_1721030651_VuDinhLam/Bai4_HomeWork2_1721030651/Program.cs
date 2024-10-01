using Bai4_HomeWork2_1721030651.Data;
using Bai4_HomeWork2_1721030651.Repository.Bai2.Second_Approach;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var getConnectionStr = builder.Configuration.GetConnectionString("MyConnectString");
builder.Services.AddDbContext<GenearalCatalogContext>(option => option.UseSqlServer(getConnectionStr));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
