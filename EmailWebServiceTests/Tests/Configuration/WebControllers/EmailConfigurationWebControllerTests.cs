using AutoMapper;
using Configuration.Controllers.DbControllers;
using Configuration.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Models;
using EmailWebServiceTests.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace EmailWebServiceTests.Tests.Configuration.WebControllers
{
    public class EmailConfigurationControllerTests
    {
        EmailRODbController _emailRODbController;
        EmailDbController _emailDbController;
        HttpContext _httpContext;
        EmailConfigurationWebController _controller;
        IMapper _mapper;
        ILogger _logger;

        public EmailConfigurationControllerTests()
        {
            Helper.SetConnectionStrings();
            _emailRODbController = new();
            _emailDbController = new();
            _httpContext = new DefaultHttpContext();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
                .SetMinimumLevel(LogLevel.Trace)
                .AddConsole());

            _mapper = mapperConfig.CreateMapper();
            _logger = loggerFactory.CreateLogger<Program>();

            _controller = new EmailConfigurationWebController(_mapper, _logger, _emailRODbController, _emailDbController);
        }


        [Fact]
        public async Task EmailConfiguration()
        {
            try
            {
                var cfg = new EmailAccountConfigurationModel()
                {
                    ServiceId = 1,
                    SMTP = "smtp",
                    Port = 1234,
                    Login = "login",
                    Password = "password"
                };

                await _controller.AddEmailAccountConfigurationAsync("test", cfg, _httpContext);

                var resAdd = _controller.GetEmailAccountConfiguration("test", _httpContext);

                if (resAdd.Data == null || resAdd.Data.Id == 0)
                    Assert.Fail("nie dodano");

                cfg = new EmailAccountConfigurationModel()
                {
                    Id = resAdd.Data.Id,
                    ServiceId = 1,
                    SMTP = "smtp1",
                    Port = 1231,
                    Login = "login1",
                    Password = "password1"
                };


                await _controller.EditEmailAccountConfigurationAsync("test", cfg, _httpContext);
                var resUpdate = _controller.GetEmailAccountConfiguration("test", _httpContext);


                if (resUpdate.Data.SMTP == cfg.SMTP && resUpdate.Data.Port == cfg.Port && resUpdate.Data.Password == cfg.Password && resUpdate.Data.Login == cfg.Login)
                    return;
                else
                    Assert.Fail("nie zaaktualizowano");


                await _controller.DeleteEmailAccountConfigurationAsync("test", _httpContext);

                Assert.ThrowsAsync<Exception>(async () => _controller.GetEmailAccountConfiguration("test", _httpContext));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}