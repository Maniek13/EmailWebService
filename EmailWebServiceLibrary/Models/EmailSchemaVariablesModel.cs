using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public record EmailSchemaVariablesModel : IEmailSchemaVariablesModel
    {
        public int Id { get; init; }
        public int EmailSchemaId { get; init; }
        public string Name { get; init; }
        public string Value { get; init; }
    }
}
