using EmailWebServiceLibrarys.Interfaces;

namespace EmailWebServiceLibrarys.Models
{
    public class AppPermisionModel : IAppPermisionModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
    }
}
