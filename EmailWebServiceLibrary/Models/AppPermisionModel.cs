using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrarys.Models
{
    public record AppPermisionModel : IAppPermisionModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
    }
}
