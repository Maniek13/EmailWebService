using EmailWebService.Interfaces;

namespace EmailWebService.Controllers
{
    public class EmailDbController : IEmailDbController
    {
        IEmailServiceContextBase context;
        public EmailDbController(IEmailServiceContextBase dbContext)
        {
            context = dbContext;
        }
    }
}
