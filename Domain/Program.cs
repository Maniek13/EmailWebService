using Configuration.Data;
using Domain.Controllers.WebControllers;
using EmailWebServiceLibrary.Controllers.DbControllers;
using EmailWebServiceLibrary.Models;
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



DomainWebController emailServiceController = new(new EmailRODbController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)));

app.MapPost("/SendEmails", emailServiceController.SendEmailsAsync)
    .WithDescription("Send emails")
    .WithOpenApi()
    .DisableAntiforgery();


app.Run();
