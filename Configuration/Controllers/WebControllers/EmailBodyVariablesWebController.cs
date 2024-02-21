using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Helpers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Configuration.Controllers.WebControllers
{
    public class EmailBodyVariablesWebController(ILogger logger, IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(logger, emailDbControllerRO, emailDbController), IEmailBodyVariablesWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;
        readonly ILogger _logger = logger;

        public IResponseModel<List<EmailSchemaVariablesModel>> GetBodySchemaVariables(string serviceName, [FromBody] EmailSchemaVariablesModel variables, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetAppPermision(serviceName) ?? throw new Exception("service don't have a permision");

                var variablesDb = _emailDbControllerRO.GetBodySchemaVariables();

                List<EmailSchemaVariablesModel> variablesList = [];
                for (int i = 0; i < variablesDb.Count; ++i)
                {
                    variablesList.Add(ConversionHelper.ConvertToEmailSchemaVariablesModel(variablesDb[i]));
                }

                return new ResponseModel<List<EmailSchemaVariablesModel>>()
                {
                    Data = variablesList,
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };

            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                return new ResponseModel<List<EmailSchemaVariablesModel>>()
                {
                    Data = null,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        public async Task<IResponseModel<bool>> EditBodySchemaVariablesAsync(string serviceName, EmailSchemaVariablesModel variables, HttpContext context)
        {
            try
            {
                var permisions = _emailDbControllerRO.GetAppPermision(serviceName) ?? throw new Exception("service don't have a permision");

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                return new ResponseModel<bool>()
                {
                    Data = false,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
    }
}
