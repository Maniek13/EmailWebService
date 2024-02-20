using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public readonly struct RequestModel<T> : IRequestModel<T>
    {
        public string IdentityCode { get; init; }

        public T RequestBody { get; init; }
    }
}
