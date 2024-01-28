﻿using System.Text.Json.Serialization;
using ExampleAPI.Contexts;
using ExampleAPI.Repositories.Abstracts;
using ExampleAPI.Repositories.Concretes;
using TurkeyServices;
using static TurkeyServices.KPSPublicSoapClient;

var builder = WebApplication.CreateBuilder(args);
//using (KPSPublicSoapClient soapClient = new KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap12))
//{
//    var result = await soapClient.TCKimlikNoDogrulaAsync(55651657066, "Merve", "Avcı", 1998);
//    if (result.Body.TCKimlikNoDogrulaResult)
//    {
//        Console.WriteLine("Kimlik Bilgileri Doğru");
//    }
//    else
//    {
//        throw new Exception("Kimlik Bilgileri Hatalı");
//    }
//}
// Add services to the container.
builder.Services.AddDbContext<ExampleDbContext>();
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductTransactionRepository, ProductTransactionRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IAccountTransactionRepository, AccountTransactionRepository>();
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

