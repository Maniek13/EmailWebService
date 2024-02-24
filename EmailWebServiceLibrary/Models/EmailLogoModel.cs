using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models.Models
{
    public record EmailLogoModel : IEmailLogoModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public string FileBase64String { get; init; }
    }
}
