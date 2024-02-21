using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public record ServicesPermisionsModel : IServicesPermisionsModel
    {
        public int Id { get; init; }
        public string ServiceName { get; init; }
    }
}
