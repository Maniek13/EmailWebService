using AutoMapper;
using Configuration.Controllers.DbControllers;
using Configuration.Controllers.WebControllers;
using Configuration.Data;
using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;

ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

var configuration = new ConfigurationBuilder()
     .AddJsonFile($"appsettings.json");
var config = configuration.Build();

AppConfig.SigningKey = config.GetSection("AppConfig").GetSection("SigningKey").Value;
AppConfig.ConnectionStringRO = config.GetSection("AppConfig").GetSection("ReadOnlyConnection").Value;
AppConfig.ConnectionString = config.GetSection("AppConfig").GetSection("Connection").Value;
AppConfig.DefaultCulture = new RequestCulture(config.GetSection("AppConfig").GetSection("DefaulLocalization").Value);
AppConfig.PromotedCultures = AppConfig.GetCultureInfoArray(config.GetSection("AppConfig").GetSection("Localizations").Get<string[]>());



var builder = WebApplication.CreateBuilder(args);
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<EmailServiceContextBase>(AppConfig.ConnectionString);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppConfig.SigningKey))
        };
    });
builder.Services.AddAuthorization();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = AppConfig.DefaultCulture,
    SupportedCultures = AppConfig.PromotedCultures,
    SupportedUICultures = AppConfig.PromotedCultures
});
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EmailServiceContextBase>();
    db.Database.Migrate();
}

EmailConfigurationWebController emailWebController = new(mapper, app.Logger, new EmailRODbController(), new EmailDbController());
app.MapGet("/GetEmailAccountConfiguration", emailWebController.GetEmailAccountConfiguration)
    .WithDescription("Get email configuration")
    .WithOpenApi();

app.MapPost("/AddEmailAccountConfigurationAsync", emailWebController.AddEmailAccountConfigurationAsync)
    .WithDescription("Add email configuration")
    .WithOpenApi();

app.MapPut("/EditEmailAccountConfigurationAsync", emailWebController.EditEmailAccountConfigurationAsync)
    .WithDescription("Edit email configuration")
    .WithOpenApi();

app.MapDelete("/DeleteEmailConfigurationAsync", emailWebController.DeleteEmailAccountConfigurationAsync)
    .WithDescription("Delete email configuration")
    .WithOpenApi();


EmailBodyWebController emailBodyWebController = new(mapper, app.Logger, new EmailRODbController(), new EmailDbController());
app.MapGet("/GetEmailBodySchema", emailBodyWebController.GetEmailBodySchema)
    .WithDescription("Get body schama")
    .WithOpenApi();

app.MapPost("/AddEmailBodySchemaAsync", emailBodyWebController.AddEmailBodySchemaAsync)
    .WithDescription("Add body schema")
    .WithOpenApi()
    .DisableAntiforgery();

app.MapPut("/EditEmailBodySchemaAsync", emailBodyWebController.EditEmailBodySchemaAsync)
    .WithDescription("Edit body schema")
    .WithOpenApi();

app.MapDelete("/DeleteEmailBodySchemaAsync", emailBodyWebController.DeleteEmailBodySchemaAsync)
    .WithDescription("Delete email schema")
    .WithOpenApi();


EmailBodyVariablesWebController emailBodyVariablesWebController = new(mapper, app.Logger, new EmailRODbController(), new EmailDbController());
app.MapPut("/EditBodySchemaVariablesAsync", emailBodyVariablesWebController.EditBodySchemaVariablesAsync)
    .WithDescription("Edit body schema variable")
    .WithOpenApi();


EmailRecipientsListWebController recipientsListWebController = new(mapper, app.Logger, new EmailRODbController(), new EmailDbController());
app.MapGet("/GetRecipientsList", recipientsListWebController.GetRecipientsList)
    .WithDescription("Get recipients list")
    .WithOpenApi();

app.MapPost("/AddRecipientsListAsync", recipientsListWebController.AddRecipientsListAsync)
    .WithDescription("Add recipients list")
    .WithOpenApi();

app.MapPut("/EditRecipientsListAsync", recipientsListWebController.EditRecipientsListAsync)
    .WithDescription("Edit recipients list")
    .WithOpenApi();

app.MapDelete("/DeleteRecipientsListAsync", recipientsListWebController.DeleteRecipientsListAsync)
    .WithDescription("Delete recipients list")
    .WithOpenApi();


app.MapDelete("/AddRecipientToList", recipientsListWebController.AddRecipientToLisAsync)
    .WithDescription("Add recipient to list")
    .WithOpenApi();

EmailRecipientsWebController recipientsWebController = new(mapper, app.Logger, new EmailRODbController(), new EmailDbController());
app.MapGet("/GetSerciceRecipients", recipientsWebController.GetRecipients)
    .WithDescription("Get service recipients")
    .WithOpenApi();

app.MapGet("/GetAllRecipients", recipientsWebController.GetAllRecipients)
    .WithDescription("Get all recipients")
    .WithOpenApi();

app.MapPost("/AddRecipient", recipientsWebController.AddRecipient)
    .WithDescription("Add recipient")
    .WithOpenApi();

app.MapPut("/EditRecipient", recipientsWebController.EditRecipient)
    .WithDescription("Edit recipient")
    .WithOpenApi();

app.MapDelete("/DeleteRecipient", recipientsWebController.DeleteRecipient)
    .WithDescription("Delete recipient")
    .WithOpenApi();


EmailFooterWebController emailFooterWebController = new(mapper, app.Logger, new EmailRODbController(), new EmailDbController());
app.MapPut("/EditEmailFooterAsync", emailFooterWebController.EditEmailFooterAsync)
    .WithDescription("Edit footer")
    .WithOpenApi();


EmailLogoWebController emailLogoWebController = new(mapper, app.Logger, new EmailRODbController(), new EmailDbController());
app.MapPut("/EditEmailLogoAsync", emailLogoWebController.EditEmailLogoAsync)
    .WithDescription("Edit logo")
    .WithOpenApi();


app.Run();
