using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace EmailWebServiceTests.Library.Helpers
{
    public class EmailHelperTests
    {
        public EmailHelperTests() 
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        [Fact]
        public async Task SendEmailTests()
        {
            try
            {
                
                var model = new EmailSchemaModel() {
                    From = "mariusz.a.szczerba@gmail.com",
                    DisplayName = "DisplayName",
                    Subject = "Subject",
                    Body = @"<p style=""color:blue;"">Body",
                    ReplyTo = "mariusz.a.szczerba@gmail.com",
                    ReplyToDisplayName = "ReplyToDisplayName"
                };
                var usserList = new List<IEmailRecipientModel>()
                {
                    new EmailRecipientModel()
                    {
                        Name = "Recipient",
                        EmailAdress = "mani3k1989@gmail.com"
                    }

                };
                var cfg = new EmailAccountConfigurationModel()
                {
                    SMTP = "smtp.gmail.com",
                    Port = 587,
                    Login = "mani3k1989@gmail.com",
                    Password = ""
                };

                using var stream = File.OpenRead(@"C:\Users\mani3\OneDrive\Pulpit\cv.pdf");
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/pdf"
                };

                var attachments = new FormFileCollection()
                    {
                        file
                    };

                await EmailHelper.SendEmail(model, usserList, cfg, attachments);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public void CreateBodyTests()
        {
            Assert.Fail("Not implement");
        }
        [Fact]
        public void CreateEmailTests()
        {
            Assert.Fail("Not implement");
        }

    }
}
