using EmailWebService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmailWebService.Data
{
    public class EmailServiceContext : EmailServiceContextBase
    {

        public EmailServiceContext(string connectionString) : base(connectionString)
        {
            ConnectionString = connectionString;
        }

    }
}
