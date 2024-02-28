using AutoMapper;
using Configuration.Controllers.DbControllers;
using Configuration.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.Models.Models;
using EmailWebServiceLibrary.Models;
using EmailWebServiceTests.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace EmailWebServiceTests.Tests.Configuration.WebControllers
{
    public class EmailRecipientsListWebControllerTests
    {
        EmailRODbController _emailRODbController;
        EmailDbController _emailDbController;
        HttpContext _httpContext;
        EmailRecipientsListWebController _controller;
        IMapper _mapper;
        ILogger _logger;

        public EmailRecipientsListWebControllerTests()
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

            _controller = new EmailRecipientsListWebController(_mapper, _logger, _emailRODbController, _emailDbController);
        }

        [Fact]
        public async Task RecipiientListCoontrollerTest()
        {
            int recipientListId = 0;
            try
            {
                var cfg = new EmailRecipientsListModel()
                {
                    ServiceId = 1,
                    Name = "test",
                    Recipients = new List<EmailListRecipientModel>
                    {
                        new EmailListRecipientModel()
                        {
                           Recipient = new EmailRecipientModel()
                           {
                                Name = "test1",
                                EmailAdress = "test1"
                           }
                        },
                        new EmailListRecipientModel()
                        {
                           Recipient = new EmailRecipientModel()
                           {
                                Name = "test2",
                                EmailAdress = "test2"
                           }
                        },
                    }
                };

                await _controller.AddRecipientsListAsync("test", cfg, _httpContext);



                var resAdd = _controller.GetRecipientsList("test", _httpContext);



                recipientListId = resAdd.Data.Id;

                if (resAdd.Data == null && resAdd.Data.Recipients.Count != 2)
                    Assert.Fail("nie dodano");


                List<EmailListRecipientModel> newList = new()
                {
                    new EmailListRecipientModel()
                    {
                        Id = resAdd.Data.Recipients.ElementAt(0).Id,
                        Recipient = new EmailRecipientModel()
                        {
                            Id = resAdd.Data.Recipients.ElementAt(0).RecipientId,
                            Name = "zmienione",
                            EmailAdress = "test1",
                        }
                    },
                    new EmailListRecipientModel()
                    {
                        Recipient = new EmailRecipientModel()
                        {
                            Name = "test12",
                            EmailAdress = "test12"
                        }
                    }
                };



                cfg = new EmailRecipientsListModel()
                {
                    ServiceId = 1,
                    Id = resAdd.Data.Id,
                    Name = cfg.Name,
                    Recipients = newList
                };

                cfg.Id = resAdd.Data.Id;

                await _controller.EditRecipientsListAsync("test", cfg, _httpContext);
                var resUpdate = _controller.GetRecipientsList("test", _httpContext);




                if (resUpdate.Data.Recipients.Count == 2)
                    return;
                else
                    Assert.Fail("nie zaaktualizowano");


                await _controller.DeleteRecipientsListAsync("test", recipientListId, _httpContext);


                var deleted = _controller.GetRecipientsList("test", _httpContext);
                if (deleted.Data != null)
                    Assert.Fail("nie usuniêto");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                await _controller.DeleteRecipientsListAsync("test", recipientListId, _httpContext);
            }

        }
    }
}