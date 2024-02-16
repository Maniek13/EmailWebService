using EmailWebService.Controllers;
using EmailWebService.Models;
using System.Net;

ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var configuration = new ConfigurationBuilder()
     .AddJsonFile($"appsettings.json");
var config = configuration.Build();


AppConfig.ConnectionString = config.GetSection("AppConfig").GetSection("Connection").Value;
AppConfig.ConnectionStringRO = config.GetSection("AppConfig").GetSection("ReadOnlyConnection").Value;



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

EmailController emailController = new(new EmailDbControllerRO(), new EmailDbController());

app.MapPost("/GetEmailConfiguration", emailController.GetEmailConfiguration)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapPost("/SetEmailConfiguration", emailController.SetEmailConfigurationAsync)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapPost("/UpdateEmailConfiguration", emailController.UpdateEmailConfigurationAsync)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapPost("/SendEmail", emailController.SendEmailAsync)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapPost("/SetEmailBody", emailController.SetEmailBodyAsync)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapPost("/GetEmailBody", emailController.GetEmailBody)
    .WithDescription("Get email configurations")
    .WithOpenApi();



app.Run();

