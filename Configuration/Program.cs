using Configuration.Controllers.WebControllers;
using Configuration.Data;
using EmailWebServiceLibrary.Controllers.DbControllers;
using EmailWebServiceLibrary.Models;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddSqlServer<EmailServiceContextBase>(AppConfig.ConnectionString);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EmailServiceContextBase>();
    db.Database.Migrate();
}

EmailWebController emailWebController = new(new EmailRODbController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));

app.MapPost("/SetEmailConfigurationAsync", emailWebController.SetEmailAccountConfigurationAsync)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapPut("/UpdateEmailConfigurationAsync", emailWebController.UpdateEmailAccountConfigurationAsync)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapDelete("/DeleteEmailConfigurationAsync", emailWebController.DeleteEmailAccountConfigurationAsync)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapPost("/SetEmailBodySchemaAsync", emailWebController.SetEmailBodySchemaAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();

app.MapPut("/UpdateEmailBodySchemaAsync", emailWebController.UpdateEmailBodySchemaAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();

app.MapDelete("/DeleteEmailBodySchemaAsync", emailWebController.DeleteEmailBodySchemaAsync)
    .WithDescription("Set email configurations")
.WithOpenApi();


UserListsWebController userListWebController = new(new EmailRODbController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));

app.MapPost("/SetUserListAsync", userListWebController.SetUserListAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();

app.MapPut("/UpdateUserListAsync", userListWebController.UpdateUserListAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();

app.MapDelete("/DeleteUserListAsync", userListWebController.DeleteUserListAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();

app.Run();
