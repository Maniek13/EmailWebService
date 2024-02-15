using EmailWebService.Data;
using EmailWebService.Interfaces;
using EmailWebService.Models;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;

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
