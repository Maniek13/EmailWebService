using System.Net;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IResponseModel<T>
    {
        T Data { get; init; }
        string Message { get; init; }
    }
}
