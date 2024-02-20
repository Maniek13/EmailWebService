using EmailWebServiceLibrary.Interfaces.DbModels;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailFooterModel
    {
        int Id { get; init; }
        int EmailSchemaId { get; init; }
        string TextHtml { get; init; }
        LogoModel Logo { get; init; }
    }
}
