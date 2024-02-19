using Configuration.Data;
using Domain.Controllers;
using EmailWebServiceLibrarys.Controllers;
using EmailWebServiceLibrarys.Models;
using System.Net;

ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

var configuration = new ConfigurationBuilder()
     .AddJsonFile($"appsettings.json");
var config = configuration.Build();

AppConfig.ConnectionString = config.GetSection("AppConfig").GetSection("Connection").Value;
AppConfig.ConnectionStringRO = config.GetSection("AppConfig").GetSection("ReadOnlyConnection").Value;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();



DomainController emailServiceController = new(new EmailDbROController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)));

app.MapPost("/SendEmail", emailServiceController.SendEmailAsync)
    .WithDescription("Send email")
    .WithOpenApi()
    .DisableAntiforgery();


app.Run();
