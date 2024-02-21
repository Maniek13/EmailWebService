using Configuration.Controllers.WebControllers;
using Configuration.Data;
using Configuration.Interfaces.WebControllers;
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

EmailConfigurationWebController emailWebController = new(app.Logger, new EmailRODbController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));
app.MapGet("/GetEmailAccountConfiguration", emailWebController.GetEmailAccountConfiguration)
    .WithDescription("Get email configurations")
    .WithOpenApi();

app.MapPost("/SetEmailConfigurationAsync", emailWebController.SetEmailAccountConfigurationAsync)
    .WithDescription("Set email configurations")
    .WithOpenApi();

app.MapPut("/EditEmailAccountConfigurationAsync", emailWebController.EditEmailAccountConfigurationAsync)
    .WithDescription("Edit email configurations")
    .WithOpenApi();

app.MapDelete("/DeleteEmailConfigurationAsync", emailWebController.DeleteEmailAccountConfigurationAsync)
    .WithDescription("Delete email configurations")
    .WithOpenApi();


EmailBodyWebController emailBodyWebController = new(app.Logger, new EmailRODbController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));
app.MapGet("/GetEmailBodySchema", emailBodyWebController.GetEmailBodySchema)
    .WithDescription("Get body schamas")
    .WithOpenApi();

app.MapPost("/SetEmailBodySchemaAsync", emailBodyWebController.SetEmailBodySchemaAsync)
    .WithDescription("Set body schema")
    .WithOpenApi()
    .DisableAntiforgery();

app.MapPut("/EditEmailBodySchemaAsync", emailBodyWebController.EditEmailBodySchemaAsync)
    .WithDescription("Edit body schema")
    .WithOpenApi();

app.MapDelete("/DeleteEmailBodySchemaAsync", emailBodyWebController.DeleteEmailBodySchemaAsync)
    .WithDescription("Delete email schema")
.WithOpenApi();


EmailBodyVariablesWebController emailBodyVariablesWebController = new(app.Logger, new EmailRODbController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));
app.MapGet("/GetBodySchemaVariablesAsync", emailBodyVariablesWebController.GetBodySchemaVariables)
    .WithDescription("Get schemas variables")
    .WithOpenApi();

app.MapPut("/EditBodySchemaVariablesAsync", emailBodyVariablesWebController.EditBodySchemaVariablesAsync)
    .WithDescription("Edit body schema variable")
    .WithOpenApi();


RecipientsListWebController recipientsListWebController = new(app.Logger, new EmailRODbController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));
app.MapGet("/GetRecipientsLists", recipientsListWebController.GetRecipientsLists)
    .WithDescription("Get recipients lists")
    .WithOpenApi();

app.MapPost("/SetRecipientsListAsync", recipientsListWebController.SetRecipientsListAsync)
    .WithDescription("Set recipient list")
    .WithOpenApi();

app.MapPut("/EditRecipientsListAsync", recipientsListWebController.EditRecipientsListAsync)
    .WithDescription("Update recipient list")
    .WithOpenApi();

app.MapDelete("/DeleteRecipientsListAsync", recipientsListWebController.DeleteRecipientsListAsync)
    .WithDescription("Delete recipient list")
    .WithOpenApi();


RecipientsWebController recipientsWebController = new(app.Logger, new EmailRODbController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));
app.MapGet("/GetRecipients", recipientsWebController.GetRecipients)
    .WithDescription("Get recipients")
    .WithOpenApi();

app.MapPost("/AddRecipient", recipientsWebController.AddRecipient)
    .WithDescription("Set recipient")
    .WithOpenApi();

app.MapPut("/EditRecipient", recipientsWebController.EditRecipient)
    .WithDescription("Update recipient")
    .WithOpenApi();

app.MapDelete("/DeleteRecipient", recipientsWebController.DeleteRecipient)
    .WithDescription("Delete recipient")
    .WithOpenApi();


EmailFooterWebController emailFooterWebController = new(app.Logger, new EmailRODbController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));
app.MapGet("/GetEmailFooters", emailFooterWebController.GetEmailFooters)
    .WithDescription("Get footers")
    .WithOpenApi();

app.MapPut("/EditEmailFooterAsync", emailFooterWebController.EditEmailFooterAsync)
    .WithDescription("Update recipient")
    .WithOpenApi();


EmailLogoWebController emailLogoWebController = new(app.Logger, new EmailRODbController(new EmailServiceContextRO(AppConfig.ConnectionStringRO)), new EmailDbController(new EmailServiceContext(AppConfig.ConnectionString)));
app.MapGet("/GetEmailLogos", emailLogoWebController.GetEmailLogos)
    .WithDescription("Get logos")
    .WithOpenApi();

app.MapPut("/EditEmailLogoAsync", emailLogoWebController.EditEmailLogoAsync)
    .WithDescription("Update logo")
    .WithOpenApi();


app.Run();
