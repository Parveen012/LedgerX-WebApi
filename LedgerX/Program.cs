using Application.Common;
using Application.Customers;
using Application.Dashboard;
using Application.Services;
using Application.ShopSettings;
using Application.Transactions;
using Application.Users;
using Infrastructure;
using Infrastructure.Repositories.Customers;
using Infrastructure.Repositories.ShopSettings;
using Infrastructure.Repositories.Transactions;
using Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerApplication, CustomerApplication>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserApplication, UserApplication>();

builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<ITransactionApplication, TransactionApplication>();

builder.Services.AddTransient<IShopSettingRepository,ShopSettingRepository>();
builder.Services.AddTransient<IShopSettingApplication, ShopSettingApplication>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IDashboardApplication, DashboardApplication>();
builder.Services.AddAutoMapper(typeof(mapping));

builder.Services.AddEndpointsApiExplorer();

// For Validate Token
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
        };
    });


// For take token in header in swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter JWT Token"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
