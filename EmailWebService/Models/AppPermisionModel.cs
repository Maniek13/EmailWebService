using EmailWebService.Interfaces;

namespace EmailWebService.Models
{
    public class AppPermisionModel : IAppPermisionModel
    {
        public int Id { get; set; }
        public int IdentityCodeId { get; set; }
        public string ServiceName { get; set; }
    }
}
