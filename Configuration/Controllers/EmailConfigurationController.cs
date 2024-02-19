using Configuration.Interfaces;
using EmailWebServiceLibrarys.Controllers;
using EmailWebServiceLibrarys.Interfaces;
using EmailWebServiceLibrarys.Models;
using System.Net;

namespace Configuration.Controllers
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
        #region email config
        public async Task<IResponseModel<bool>> SetEmailConfigurationAsync(EmailConfigurationModel Configuration, HttpContext Context)
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

        public async Task<IResponseModel<bool>> UpdateEmailConfigurationAsync(EmailConfigurationModel Configuration, HttpContext Context)
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
        public async Task<IResponseModel<bool>> DeleteEmailConfigurationAsync(int Id, HttpContext Context)
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
        #endregion
        #region email body

        public async Task<IResponseModel<bool>> SetEmailBodySchemaAsync(EmailSchemaModel EmailSchema, HttpContext Context)
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
        public async Task<IResponseModel<bool>> UpdateEmailBodySchemaAsync(EmailSchemaModel EmailSchema, HttpContext Context)
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
        public async Task<IResponseModel<bool>> DeleteEmailBodySchemaAsync(int Id, HttpContext Context)
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
        #endregion

        #region user list
        public async Task<IResponseModel<bool>> SetUserListAsync(EmailUsersListModel EmailUsersListModel, HttpContext Context)
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
        public async Task<IResponseModel<bool>> UpdateUserListAsync(EmailUsersListModel EmailUsersListModel, HttpContext Context)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Context.Response.StatusCode = 400;
                Context.Response.StatusCode = 400;
                return new ResponseModel<bool>()
                {
                    Data = false,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        public async Task<IResponseModel<bool>> DeleteUserListAsync(int Id, HttpContext Context)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Context.Response.StatusCode = 400;
                Context.Response.StatusCode = 400;
                return new ResponseModel<bool>()
                {
                    Data = false,
                    ResultCode = (HttpStatusCode)400,
                    Message = ex.Message
                };
            }
        }
        #endregion
    }
}
