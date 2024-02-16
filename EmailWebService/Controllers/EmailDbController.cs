using EmailWebService.Data;
using EmailWebService.Interfaces;
using EmailWebService.Models;

namespace EmailWebService.Controllers
{
    public class EmailDbController : IEmailDbController
    {
        EmailServiceContext context;
        public EmailDbController()
        {
            context = new(AppConfig.ConnectionString);
        }
    }
}
