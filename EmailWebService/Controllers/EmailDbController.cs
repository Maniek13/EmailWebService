using EmailWebService.Interfaces;
using EmailWebService.Models;
using System.Text;

namespace EmailWebService.Controllers
{
    public class EmailDbController : IEmailDbController
    {
        IEmailServiceContextBase _context;
        public EmailDbController(IEmailServiceContextBase dbContext)
        {
            _context = dbContext;
        }
        public async Task<bool> SetEmailBodySchemaAsync(EmailSchemaDbModel EmailSchema)
        {
            try
            {
                await _context.EmailSchemas.AddAsync(EmailSchema);

                var nrOf = await _context.SaveChangesAsync();

                if (nrOf == 1)
                    return true;
                else
                    throw new Exception("Internal error, data don't be added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateEmailBodySchemaAsync(EmailSchemaDbModel EmailSchema)
        {
            try
            {
                var cfg = _context.EmailSchemas.Where(el => el.Id == EmailSchema.Id).FirstOrDefault();

                if (cfg == null)
                    throw new Exception("EmailSchemas do not exist");

                cfg = EmailSchema;

                var nrOf = await _context.SaveChangesAsync();

                if (nrOf == 1)
                    return true;
                else
                    throw new Exception("Internal error, data don't be added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> SetEmailConfigurationAsync(EmailConfigurationDbModel Configuration)
        {
            try
            {
                await _context.EmailConfiguration.AddAsync(Configuration);

                var nrOf = await _context.SaveChangesAsync();

                if (nrOf == 1)
                    return true;
                else
                    throw new Exception("Internal error, data don't be added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateEmailConfigurationAsync(EmailConfigurationDbModel Configuration)
        {
            try
            {
                var cfg = _context.EmailConfiguration.Where(el => el.Id == Configuration.Id).FirstOrDefault();

                if (cfg == null)
                    throw new Exception("Configuration do not exist");

                cfg = Configuration;

                var nrOf = await _context.SaveChangesAsync();

                if (nrOf == 1)
                    return true;
                else
                    throw new Exception("Internal error, data don't be added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
