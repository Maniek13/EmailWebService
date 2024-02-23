using EmailWebServiceLibrary.Models.Models;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailFooterModel
    {
        int Id { get; init; }
        int EmailSchemaId { get; init; }
        string TextHtml { get; init; }
        LogoModel Logo { get; set; }
    }
}
