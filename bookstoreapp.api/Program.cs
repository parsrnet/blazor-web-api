using bookstoreapp.api.Configurations;
using bookstoreapp.api.Data;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Serilog;

const string CORS_POLICY_ALLOW_ALL = "AllowAll";

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("BookStoreAppDbConnection");
builder.Services.AddDbContext<BookStoreDBContext>(options =>
{
    options.UseSqlServer(connString);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Host.UseSerilog((context, lc) =>
{
    lc.WriteTo.Console().ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(CORS_POLICY_ALLOW_ALL, b =>
    {
        b.AllowAnyMethod()
         .AllowAnyHeader()
         .AllowAnyOrigin();
    });
});

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CORS_POLICY_ALLOW_ALL);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
