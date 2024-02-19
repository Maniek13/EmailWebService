using System.Net;

namespace EmailWebServiceLibrarys.Interfaces
{
    public interface IResponseModel<T>
    {
        T Data { get; set; }
        HttpStatusCode ResultCode { get; set; }
        string Message { get; set; }
    }
}
