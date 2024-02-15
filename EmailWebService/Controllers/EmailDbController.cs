using EmailWebService.Data;
using EmailWebService.Models;

namespace EmailWebService.Controllers
{
    public class EmailDbController
    {
        EmailServiceContext context;
        public EmailDbController()
        {
            context = new(AppConfig.ConnectionString);
        }
    }
}
