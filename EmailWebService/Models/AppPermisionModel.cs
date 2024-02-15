using EmailWebService.Interfaces;

namespace EmailWebService.Models
{
    public class AppPermisionModel : IAppPermisionModel
    {
        public long Id { get; set; }
        public string IdentityCodesId { get; set; }
        public string ServiceName { get; set; }
    }
}
