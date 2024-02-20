using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IUserListWebController
    {

        #region user list
        Task<IResponseModel<bool>> SetUserListAsync(EmailUsersListModel emailUsersListModel, HttpContext context);
        Task<IResponseModel<bool>> UpdateUserListAsync(EmailUsersListModel emailUsersListModel, HttpContext context);
        Task<IResponseModel<bool>> DeleteUserListAsync(int id, HttpContext context);
        #endregion
    }
}
