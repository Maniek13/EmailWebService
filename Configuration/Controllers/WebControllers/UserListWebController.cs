using Configuration.Interfaces.WebControllers;
using EmailWebServiceLibrary.Controllers.WebControllers;
using EmailWebServiceLibrary.Interfaces.DbControllers;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using System.Net;

namespace Configuration.Controllers.WebControllers
{
    public class UserListsWebController(IEmailRODbController emailDbControllerRO, IEmailDbController emailDbController) : ServiceWebControllerBase(emailDbControllerRO, emailDbController), IUserListWebController
    {
        private readonly IEmailRODbController _emailDbControllerRO = emailDbControllerRO;
        readonly IEmailDbController _emailDbController = emailDbController;

        #region user list
        public async Task<IResponseModel<bool>> SetUserListAsync(EmailUsersListModel emailUsersListModel, HttpContext context)
        {
            try
            {
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
        public async Task<IResponseModel<bool>> UpdateUserListAsync(EmailUsersListModel emailUsersListModel, HttpContext context)
        {
            try
            {
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
        public async Task<IResponseModel<bool>> DeleteUserListAsync(int id, HttpContext context)
        {
            try
            {
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
        #endregion
    }
}
