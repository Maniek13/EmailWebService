using EmailWebServiceLibrary.Interfaces.Models;
using Microsoft.AspNetCore.Http;

namespace EmailWebServiceLibrary.Models
{
    public record struct LogoWithFileModel : ILogoWithFileModel
    {
        public int EmailFooterId { get; init; }
        public FormFile Image { get; set; }
        public string Name { get; init; }
    }
}
