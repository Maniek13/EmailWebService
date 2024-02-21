using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IRecipientsListWebController
    {

        #region user list
        IResponseModel<List<EmailRecipientsListModel>> GetRecipientsLists(string serviceName, HttpContext context);
        Task<IResponseModel<bool>> SetRecipientsListAsync(string serviceName, EmailRecipientsListModel emailUsersListModel, HttpContext context);
        Task<IResponseModel<bool>> EditRecipientsListAsync(string serviceName, EmailRecipientsListModel emailUsersListModel, HttpContext context);
        Task<IResponseModel<bool>> DeleteRecipientsListAsync(string serviceName, int id, HttpContext context);
        #endregion

    }
}
