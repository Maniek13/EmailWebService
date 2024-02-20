using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrarys.Models
{
    public record struct ServicesPermisionsModel : IServicesPermisionsModel
    {
        public int Id { get; init; }
        public string ServiceName { get; init; }
    }
}
