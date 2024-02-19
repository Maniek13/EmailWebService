using EmailWebServiceLibrary.Interfaces.Models;
using System.Net;

namespace EmailWebServiceLibrarys.Models
{
    public readonly struct ResponseModel<T> : IResponseModel<T>
    {
        public T Data { get; init; }
        public HttpStatusCode ResultCode { get; init; }
        public string Message { get; init; }
    }
}
