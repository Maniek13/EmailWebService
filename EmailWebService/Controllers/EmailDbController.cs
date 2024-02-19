using EmailWebService.Interfaces;
using EmailWebService.Models;
using System.Text;

namespace EmailWebService.Controllers
{
    public class EmailDbController : IEmailDbController
    {
        IEmailServiceContextBase context;
        public EmailDbController(IEmailServiceContextBase dbContext)
        {
            context = dbContext;
        }
        public async Task<bool> SetEmailBodyAsync(string SchemaName, string Body, List<(string Name, string Value)> VariablesList)
        {
            try
            {
                StringBuilder variables = new StringBuilder();

                for (int i = 0; i < VariablesList.Count; ++i)
                {
                    variables.Append($"{(i > 0 ? "," : "")}{VariablesList[i].Name} : {VariablesList[i].Value}");
                }

                await context.EmailSchemas.AddAsync(new EmailSchemaDbModel()
                {
                    Name = SchemaName,
                    Body = Body,
                    Variables = variables.ToString(),
                });

                var nrOf = await context.SaveChangesAsync();

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

        public async Task<bool> SetEmailConfigurationAsync(IEmailConfigurationModel Configuration)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> UpdateEmailConfigurationAsync(IEmailConfigurationModel Configuration)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
