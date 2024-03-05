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
    public class EmailRecipientsWebControllerTests
    {
        EmailRODbController _emailRODbController;
        EmailDbController _emailDbController;
        HttpContext _httpContext;
        EmailRecipientsWebController _controller;
        IMapper _mapper;
        ILogger _logger;

        public EmailRecipientsWebControllerTests()
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

            _controller = new EmailRecipientsWebController(_mapper, _logger, _emailRODbController, _emailDbController);
        }
        [Fact]
        public async Task EmailRecipientsTests()
        {
            EmailRecipientsListWebController ctr = new EmailRecipientsListWebController(_mapper, _logger, _emailRODbController, _emailDbController);

            try
            {
                EmailRecipientModel model = new EmailRecipientModel()
                {
                    Name = "test",
                    EmailAdress = "test"
                };
                EmailRecipientModel model2 = new EmailRecipientModel()
                {
                    Name = "test1",
                    EmailAdress = "test1"
                };
                await _controller.AddRecipient("test", model, _httpContext);
                await _controller.AddRecipient("test", model2, _httpContext);



                var recList = new EmailRecipientsListModel()
                {
                    Name = "test",
                };
                await ctr.AddRecipientsListAsync("test", recList, _httpContext);
                var list = ctr.GetRecipientsList("test", _httpContext);



                await ctr.AddRecipientsListAsync("test", recList, _httpContext);
                var rec = _controller.GetAllRecipients("test", _httpContext);
                for (int i = 0; i < rec.Data.Count; i++)
                {
                    await ctr.AddRecipientToLisAsync("test", list.Data.Id, rec.Data[i].Id, _httpContext);
                }


                var recipients = _controller.GetRecipients("test", _httpContext);
                int idTests = recipients.Data[0].Id;
                if (recipients.Data.Count != 2)
                    Assert.Fail("Nie dodano");

                EmailRecipientModel model3 = new EmailRecipientModel()
                {
                    Id = idTests,
                    Name = "test3",
                    EmailAdress = "test3"
                };

                await _controller.EditRecipient("test", model3, _httpContext);
                recipients = _controller.GetRecipients("test", _httpContext);





                if (recipients.Data.Count != 2 || recipients.Data[0].Name != "test3" || recipients.Data[0].EmailAdress != "test3")
                    Assert.Fail("Nie zmieniono");

                await _controller.DeleteRecipient("test", idTests, _httpContext);

                recipients = _controller.GetRecipients("test", _httpContext);

                if (recipients.Data == null || recipients.Data.Count != 1 || recipients.Data[0].Id == idTests)
                    Assert.Fail("Nie usuniêto");

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
            finally
            {
                var recipients = _controller.GetRecipients("test", _httpContext);

                for (int i = 0; i < recipients.Data.Count; i++)
                {
                    await _controller.DeleteRecipient("test", recipients.Data[i].Id, _httpContext);
                }

            }
        }
    }
}