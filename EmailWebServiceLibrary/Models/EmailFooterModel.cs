using EmailWebServiceLibrary.Interfaces.DbModels;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public readonly record struct EmailFooterModel : IEmailFooterModel
    {
        public int Id { get; init; }
        public int EmailSchemaId { get; init; }
        public string TextHtml { get; init; }
        public LogoModel Logo { get; init; }
    }
}
