using BancoApp.Application.Interface;
using BancoApp.Application.Mapper;
using BancoApp.Application.Services;
using BancoApp.Infrastructure;
using BancoApp.Infrastructure.Data;
using BancoApp.Infrastructure.Data.Repositories;
using BancoApp.Infrastructure.Interfaces;
using BancoApp.Infrastructure.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
  $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});
builder.Services.AddDbContext<DBContext>(options =>
    options.UseNpgsql("host=localhost;port=5432;Database=BancoLima;Username=AlexandreLima;password=12345678"));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBancoService, BancoService>();
builder.Services.AddScoped<IBoletoService, BoletoService>();

builder.Services.AddScoped<IBoletoRepository, BoletoRepository>();
builder.Services.AddScoped<IBancoRepository, BancoRepository>();
builder.Services.AddAutoMapper(typeof(BancoMapping));
builder.Services.AddAutoMapper(typeof(BoletoMapping));


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
