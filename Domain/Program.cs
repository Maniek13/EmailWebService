using AutoMapper;
using Configuration.Controllers.DbControllers;
using Domain.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.IdentityModel.Tokens;
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
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = false,
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


DomainWebController emailServiceController = new(mapper, app.Logger, new EmailRODbController());

app.MapPost("/SendEmails", emailServiceController.SendEmailsAsync)
    .WithDescription("Send emails")
    .WithOpenApi()
    .DisableAntiforgery();


app.Run();
