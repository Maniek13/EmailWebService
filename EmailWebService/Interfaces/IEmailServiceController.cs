﻿using EmailWebService.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailWebService.Interfaces
{
    interface IEmailServiceController
    {
        Task<IResponseModel<bool>> SendEmailAsync(string IdentityCode, [FromForm] EmailModel email, HttpContext Context);
        Task<IResponseModel<bool>> SetEmailBodyAsync(Request<EmailBody> Request, HttpContext Context);
        Task<IResponseModel<bool>> UpdateEmailBodyAsync(Request<EmailBody> Request, HttpContext Context);
        IResponseModel<string> GetEmailBody(Request<EmailBody> Request, HttpContext Context);
    }
}
