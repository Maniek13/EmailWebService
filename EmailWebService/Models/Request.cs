using EmailWebService.Interfaces;

namespace EmailWebService.Models
{
    public class Request<T> : IRequest<T>
    {
        public string IdentityCode { get; init; }

        public T RequestBody { get; init; }
    }
}
