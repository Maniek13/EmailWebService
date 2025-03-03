﻿using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailRecipientsListWebController
    {
        IResponseModel<EmailRecipientsListModel> GetRecipientsList(string serviceName, HttpContext context);
        Task<IResponseModel<bool>> AddRecipientsListAsync(string serviceName, EmailRecipientsListModel emailUsersListModel, HttpContext context);
        Task<IResponseModel<bool>> EditRecipientsListAsync(string serviceName, EmailRecipientsListModel emailUsersListModel, HttpContext context);
        Task<IResponseModel<bool>> DeleteRecipientsListAsync(string serviceName, int recipientListId, HttpContext context);
        Task<IResponseModel<bool>> AddRecipientToLisAsync(string serviceName, int recipientsListId, int recipientId, HttpContext context);

    }
}
