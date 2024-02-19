using EmailWebServiceLibrarys.Interfaces;
using EmailWebServiceLibrarys.Models;

namespace Configuration.Interfaces
{
    interface IEmailConfigurationController
    {
        #region email config
        Task<IResponseModel<bool>> SetEmailConfigurationAsync(EmailConfigurationModel Configuration, HttpContext Context);

        Task<IResponseModel<bool>> UpdateEmailConfigurationAsync(EmailConfigurationModel Configuration, HttpContext Context);
        Task<IResponseModel<bool>> DeleteEmailConfigurationAsync(int Id, HttpContext Context);
        #endregion
        #region email body

        Task<IResponseModel<bool>> SetEmailBodySchemaAsync(EmailSchemaModel EmailSchema, HttpContext Context);
        Task<IResponseModel<bool>> UpdateEmailBodySchemaAsync(EmailSchemaModel EmailSchema, HttpContext Context);
        Task<IResponseModel<bool>> DeleteEmailBodySchemaAsync(int Id, HttpContext Context);
        #endregion

        #region user list
        Task<IResponseModel<bool>> SetUserListAsync(EmailUsersListModel EmailUsersListModel, HttpContext Context);
        Task<IResponseModel<bool>> UpdateUserListAsync(EmailUsersListModel EmailUsersListModel, HttpContext Context);
        Task<IResponseModel<bool>> DeleteUserListAsync(int Id, HttpContext Context);
        #endregion
    }
}
