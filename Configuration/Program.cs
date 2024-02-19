using Configuration.Controllers;
using Configuration.Data;
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



EmailConfigurationController emailConfigurationionController = new(new EmailDbROController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));

app.MapPost("/SetEmailConfigurationAsync", emailConfigurationionController.SetEmailConfigurationAsync)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapPost("/SetUserListAsync", emailConfigurationionController.SetUserListAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();

app.MapPost("/SetEmailBodySchemaAsync", emailConfigurationionController.SetEmailBodySchemaAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();


app.MapPut("/UpdateEmailConfigurationAsync", emailConfigurationionController.UpdateEmailConfigurationAsync)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapPut("/UpdateUserListAsync", emailConfigurationionController.UpdateUserListAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();

app.MapPut("/UpdateEmailBodySchemaAsync", emailConfigurationionController.UpdateEmailBodySchemaAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();


app.MapDelete("/DeleteEmailConfigurationAsync", emailConfigurationionController.DeleteEmailConfigurationAsync)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapDelete("/DeleteUserListAsync", emailConfigurationionController.DeleteUserListAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();

app.MapDelete("/DeleteEmailBodySchemaAsync", emailConfigurationionController.DeleteEmailBodySchemaAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();

app.Run();
