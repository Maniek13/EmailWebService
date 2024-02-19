using EmailWebServiceLibrarys.Interfaces;

namespace EmailWebServiceLibrarys.Models
{
    public class RequestModel<T> : IRequestModel<T>
    {
        public string IdentityCode { get; init; }

        public T RequestBody { get; init; }
    }
}
