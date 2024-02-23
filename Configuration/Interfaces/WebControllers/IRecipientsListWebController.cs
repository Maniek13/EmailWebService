using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IRecipientsListWebController
    {

        #region user list
        IResponseModel<EmailRecipientsListModel> GetRecipientsList(string serviceName, HttpContext context);
        Task<IResponseModel<bool>> AddRecipientsListAsync(string serviceName, EmailRecipientsListModel emailUsersListModel, HttpContext context);
        Task<IResponseModel<bool>> EditRecipientsListAsync(string serviceName, EmailRecipientsListModel emailUsersListModel, HttpContext context);
        Task<IResponseModel<bool>> DeleteRecipientsListAsync(string serviceName, int id, HttpContext context);
        #endregion

    }
}
