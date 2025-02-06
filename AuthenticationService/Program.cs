using AuthenticationService;
using AuthenticationService.Infrastructure;
using CapgAppLibrary;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UsersDbContext>(options=>options.UseSqlServer(connStr));
builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection(nameof(AppSettings))
);

builder.Services.AddScoped<IUserRepository , UserRepository>();
builder.Services.AddScoped<TokenManager>();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
