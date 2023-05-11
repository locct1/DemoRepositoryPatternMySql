using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using DemoRepositoryPattern.Repositories;
using DemoRepositoryPattern.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json.Serialization;
using MySqlConnector;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Enable CORS
builder.Services.AddCors(c => c.AddPolicy("AllowOrgin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
//JSON Serializer
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).
    AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DemoRepositoryPattern"));
//});
string mySqlConnectionStr = builder.Configuration.GetConnectionString("DemoRepositoryPattern");
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
#region Repositories
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IBookRepository, BookRepository>();
#endregion
#region Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
#endregion
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Enable CORS
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
