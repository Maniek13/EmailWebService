using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class AppPermisionModel : IAppPermisionModel
    {
        public int Id { get; set; }
        public string IdentityCodesId { get; set; }
        public string ServiceName { get; set; }
    }
}
