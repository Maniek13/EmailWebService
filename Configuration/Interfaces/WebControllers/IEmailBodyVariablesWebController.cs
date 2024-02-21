using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;

namespace Configuration.Interfaces.WebControllers
{
    interface IEmailBodyVariablesWebController
    {
        #region schema variables
        Task<IResponseModel<bool>> EditBodySchemaVariablesAsync(string serviceName, EmailSchemaVariablesModel variables, HttpContext context);
        #endregion
    }
}
