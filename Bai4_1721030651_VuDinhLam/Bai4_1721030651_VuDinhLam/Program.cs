using Bai4_1721030651_VuDinhLam.Data;
using Bai4_1721030651_VuDinhLam.Services;
using Microsoft.EntityFrameworkCore;
using Bai4_1721030651_VuDinhLam.Repository;
using Bai4_1721030651_VuDinhLam.Repository.Generic;
using FluentAssertions.Common;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var getConnectionStr = builder.Configuration.GetConnectionString("MyConnectString");
builder.Services.AddDbContext<ApiteachingContext>(option => option.UseSqlServer(getConnectionStr));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
