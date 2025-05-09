using System.Data;
using System.Globalization;
using System.Text;
using API.Middleware;
using Application.Attributes;
using Application.IGCUnitOfWork;
using Application.UnitOfWork;
using Application.UseCase;
using Infrastructure.DBAgent.Postgre.Context;
using Infrastructure.DBAgent.Postgre.Mapper;
using Infrastructure.DBAgent.Postgre.UnitOfWork;
using Infrastructure.DBGC.SqlServer.ConnectionFactory;
using Infrastructure.DBGC.SqlServer.UnitOfWork;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add controller
builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = false;
    options.Filters.Add(typeof(ValidationFilterAttribute));
});

//Config attribute error to send error to Exception middleware
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
    options.SuppressModelStateInvalidFilter = true
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add service handle Exception global
builder.Services.AddScoped<ExceptionMiddleware>();

//Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCulturesOption =
        builder.Configuration.GetSection("SupportedCultures").Get<string[]>()
        ?? throw new Exception("No SupportedCultures found");

    var supportedCultures = supportedCulturesOption.Select(c => new CultureInfo(c)).ToList();

    options.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

//Config Serilog
builder.Host.UseSerilog(
    (context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)
);

//Postgre DB
builder.Services.AddAutoMapper(typeof(Postgre2EntityProfile));
builder.Services.AddDbContext<PostgreDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgre"))
);
builder.Services.AddTransient<IUnitOfWork, PostgreUnitOfWork>();

//MSSQL DB
builder.Services.AddTransient<IGCUnitOfWork, SqlServerUnitOfWork>();
builder.Services.AddScoped<ISqlServerConnectionFactory, SqlServerConnectionFactory>();

//Service
builder.Services.AddTransient<IMessageService, MessageService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Log Start up
Console.OutputEncoding = Encoding.UTF8;
Log.Information("Application is running now! 🚀 🚀 🚀");

// Localization
app.UseRequestLocalization();

// Use logger from Serilog
app.UseSerilogRequestLogging();

// Exception Middleware
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
