using CustomersAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
   
// Add services to the container.

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CustomersDbContext>(options => options.UseSqlServer(connStr));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

        //Run the application and hit the URLS: 
        //1. http://localhost:7001/api/customers/list
        //2. http://localhost:7001/api/customers/details/ALFKI

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
