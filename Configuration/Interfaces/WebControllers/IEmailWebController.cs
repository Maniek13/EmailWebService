using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrarys.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailWebController
    {
        #region email config
        Task<IResponseModel<bool>> SetEmailConfigurationAsync(EmailConfigurationModel configuration, HttpContext context);

        Task<IResponseModel<bool>> UpdateEmailConfigurationAsync(EmailConfigurationModel configuration, HttpContext context);
        Task<IResponseModel<bool>> DeleteEmailConfigurationAsync(int id, HttpContext context);
        #endregion
        #region email body

        Task<IResponseModel<bool>> SetEmailBodySchemaAsync(EmailSchemaModel emailSchema, HttpContext context);
        Task<IResponseModel<bool>> UpdateEmailBodySchemaAsync(EmailSchemaModel emailSchema, HttpContext context);
        Task<IResponseModel<bool>> DeleteEmailBodySchemaAsync(int id, HttpContext context);
        #endregion
        #region user list
        Task<IResponseModel<bool>> SetUserListAsync(EmailUsersListModel emailUsersListModel, HttpContext context);
        Task<IResponseModel<bool>> UpdateUserListAsync(EmailUsersListModel emailUsersListModel, HttpContext context);
        Task<IResponseModel<bool>> DeleteUserListAsync(int id, HttpContext context);
        #endregion
    }
}
