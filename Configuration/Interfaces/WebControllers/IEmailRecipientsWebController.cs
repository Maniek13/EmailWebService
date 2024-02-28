using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailRecipientsWebController
    {
        #region recipients 
        IResponseModel<List<EmailRecipientModel>> GetRecipients(string serviceName, HttpContext context);
        Task<IResponseModel<bool>> AddRecipient(string serviceName, EmailRecipientModel recipient, HttpContext context);
        Task<IResponseModel<bool>> EditRecipient(string serviceName, EmailRecipientModel recipient, HttpContext context);
        Task<IResponseModel<bool>> DeleteRecipient(string serviceName, int recipientId, HttpContext context);
        IResponseModel<List<EmailRecipientModel>> GetAllRecipients(string serviceName, HttpContext context);
        #endregion
    }
}
