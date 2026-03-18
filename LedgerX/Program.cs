using Application.Common;
using Application.Customers;
using Application.ShopSettings;
using Application.Transactions;
using Infrastructure;
using Infrastructure.Repositories.Customers;
using Infrastructure.Repositories.ShopSettings;
using Infrastructure.Repositories.Transactions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerApplication, CustomerApplication>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<ITransactionApplication, TransactionApplication>();
builder.Services.AddTransient<IShopSettingRepository,ShopSettingRepository>();
builder.Services.AddTransient<IShopSettingApplication, ShopSettingApplication>();

builder.Services.AddAutoMapper(typeof(mapping));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
