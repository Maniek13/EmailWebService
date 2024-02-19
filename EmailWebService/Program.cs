using EmailWebService.Controllers;
using EmailWebService.Data;
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
AppConfig.ServiceName = "EmailService";


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


EmailConfigurationController emailConfigurationionController = new(new EmailDbROController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));

app.MapPost("/GetEmailConfiguration", emailConfigurationionController.GetEmailConfiguration)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapPost("/SetEmailConfiguration", emailConfigurationionController.SetEmailConfigurationAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();

app.MapPut("/UpdateEmailConfiguration", emailConfigurationionController.UpdateEmailConfigurationAsync)
    .WithDescription("Update email configurations")
    .WithOpenApi();

EmailServiceController emailServiceController = new(new EmailDbROController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));

app.MapPost("/SendEmail", emailServiceController.SendEmailAsync)
    .WithDescription("Send email")
    .WithOpenApi()
    .DisableAntiforgery();

app.MapPost("/SetEmailBody", emailServiceController.SetEmailBodyAsync)
    .WithDescription("Set email body")
    .WithOpenApi();

app.MapPost("/GetEmailBody", emailServiceController.GetEmailBody)
    .WithDescription("Get email body")
    .WithOpenApi();

app.MapPut("/UpdateEmailBody", emailServiceController.UpdateEmailBodyAsync)
    .WithDescription("Update email body")
    .WithOpenApi();


app.Run();
