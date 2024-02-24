using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models.Models;

namespace EmailWebServiceLibrary.Models
{
    public record EmailFooterModel : IEmailFooterModel
    {
        public int Id { get; init; }
        public int EmailSchemaId { get; init; }
        public int EmailLogoId { get; init; }
        public string TextHtml { get; init; }
        public EmailLogoModel Logo { get; set; }
    }
}
