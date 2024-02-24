using EmailWebServiceLibrary.Models.Models;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailFooterModel
    {
        int Id { get; init; }
        int EmailSchemaId { get; init; }
        int EmailLogoId { get; init; }
        string TextHtml { get; init; }
        EmailLogoModel Logo { get; set; }
    }
}
