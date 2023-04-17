using Tekus.Services;
using Tekus.UnitOfWork.Interfaces;
using Tekus.UnitOfWork.SQLSERVER;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IVendorServices, VendorServices>();
builder.Services.AddTransient<IServiceServices, ServiceServices>();
builder.Services.AddTransient<IVendorCustomsServices, VendorCustomsServices>();
builder.Services.AddTransient<IServicePortafolioServices, ServicePortafolioServices>();
builder.Services.AddTransient<ICountryServices, CountryServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
