using System.Net;

namespace EmailWebService.Interfaces
{
    public interface IResponseModel<T>
    {
        T Data { get; set; }
        HttpStatusCode ResultCode { get; set; }
        string Message { get; set; }
    }
}
