using Microsoft.Extensions.Options;
using Wolt.Core;
using Wolt.Core.Repositories;
using Wolt.Core.Services;
using Wolt.Data;
using Wolt.Data.Repositories;
using Wolt.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrdersRepository>();

builder.Services.AddScoped<ISupply_companyService, Supply_companyService>();
builder.Services.AddScoped<ISupply_companyRepository, Supply_companyRepository>();

builder.Services.AddDbContext<DataContext>();
//builder.Services.AddSingleton<DataContext>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
