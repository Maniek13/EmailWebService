using Microsoft.AspNetCore.Http;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public record struct LogoWithFileModel : ILogoWithFileModel
    {
        public int EmailFooterId { get; init; }
        public FormFile Image { get; set; }
        public string Name { get; init; }
    }
}
