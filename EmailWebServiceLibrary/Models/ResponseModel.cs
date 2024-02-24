using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public readonly struct ResponseModel<T> : IResponseModel<T>
    {
        public T Data { get; init; }
        public string Message { get; init; }
    }
}
