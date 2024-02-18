﻿using EmailWebService.Interfaces;
using EmailWebService.Models;
using System.Net;

namespace EmailWebService.Controllers
{
    public class EmailConfigurationController : ServiceControllerBase, IEmailConfigurationController
    {
        IEmailDbROController _emailDbControllerRO;
        IEmailDbController _emailDbController;

        public EmailConfigurationController(IEmailDbROController emailDbControllerRO, IEmailDbController emailDbController) : base(emailDbControllerRO, emailDbController)
        {
            _emailDbControllerRO = emailDbControllerRO;
            _emailDbController = emailDbController;
        }

        public IResponseModel<IEmailConfigurationModel> GetEmailConfiguration(int ConfigurationId, string IdentityCode, HttpContext Context)
        {
            try
            {
                int identityId = CheckHasPermision(IdentityCode);

                return new ResponseModel<IEmailConfigurationModel>()
                {
                    Data = ConvertToEmailConfiguration(_emailDbControllerRO.GetEmailConfiguration(identityId)),
                    ResultCode = (HttpStatusCode)200,
                    Message = "ok"
                };
            }
            catch (Exception ex)
            {
                Context.Response.StatusCode = 400;
                return new ResponseModel<IEmailConfigurationModel>()
                {
                    Data = null,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }

        public async Task<IResponseModel<bool>> SetEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration, HttpContext Context)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Context.Response.StatusCode = 400;
                return new ResponseModel<bool>()
                {
                    Data = false,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }

        public async Task<IResponseModel<bool>> UpdateEmailConfigurationAsync(string IdentityCode, IEmailConfigurationModel Configuration, HttpContext Context)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Context.Response.StatusCode = 400;
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
