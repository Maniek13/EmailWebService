using AutoMapper;
using Domain.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers.WebControllers
{
    public class DomainWebController(IMapper mapper, ILogger logger, IEmailRODbController emailDbControllerRO) : EmailServiceWebControllerBase(logger, emailDbControllerRO), IDomainWebController
    {
        readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly ILogger _logger = logger;
        readonly IMapper _mapper = mapper;

        public async Task<IResponseModel<bool>> SendEmailsAsync(string serviceName, [FromForm] IFormFileCollection atachments, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetServicePermision(serviceName) ?? throw new Exception("Serwis nie posiada pozwolenia");
                var emailSchema = _mapper.Map<EmailSchemaModel>(_emailDbControllerRO.GetEmailSchemaDbModel(permisions.Id));
                EmailValidationHelper.ValidateEmailSchemaModel(emailSchema);

                var variablesDb = _emailDbControllerRO.GetVariablesList(emailSchema.Id);
                var emailFooterDb = _emailDbControllerRO.GetEmailFooter(emailSchema.Id);
                var footerLogo = _emailDbControllerRO.GetEmailFooterLogo(emailFooterDb.Id);

                List<EmailSchemaVariablesModel> variables = [];
                for (int i = 0; i < variablesDb.Count; i++)
                {
                    variables.Add(_mapper.Map<EmailSchemaVariablesModel>(variablesDb[i]));
                }
                emailSchema.EmailSchemaVariables = variables;
                emailSchema.EmailFooter = _mapper.Map<EmailFooterModel>(emailFooterDb);
                emailSchema.EmailFooter.Logo = _mapper.Map<EmailLogoModel>(footerLogo);

                var configuration = _mapper.Map<EmailAccountConfigurationModel>(_emailDbControllerRO.GetEmailAccountConfiguration(permisions.Id));
                var recipments = _emailDbControllerRO.GetRecipients(permisions.Id);

                List<IEmailRecipientModel> users = [];

                for (int i = 0; i < recipments.Count; i++)
                {
                    users.Add(_mapper.Map<EmailRecipientModel>(recipments[i]));
                }
                await EmailHelper.SendEmail(emailSchema, users, configuration, atachments);

                return new ResponseModel<bool>()
                {
                    Data = true,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                return new ResponseModel<bool>()
                {
                    Data = false,
                    Message = ex.Message
                };
            }
        }
    }
}
