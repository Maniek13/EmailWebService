using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IRecipientsWebController
    {
        #region recipients 
        Task<IResponseModel<bool>> AddRecipient(string serviceName, EmailRecipientModel user, HttpContext context);
        Task<IResponseModel<bool>> EditRecipient(string serviceName, EmailRecipientModel user, HttpContext context);
        Task<IResponseModel<bool>> DeleteRecipient(string serviceName, int id, HttpContext context);
        #endregion
    }
}
