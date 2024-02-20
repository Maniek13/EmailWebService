using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public readonly record struct ServicesPermisionsModel : IServicesPermisionsModel
    {
        public int Id { get; init; }
        public string ServiceName { get; init; }
    }
}
