using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrarys.Models
{
    public record struct EmailSchemaVariablesModel : IEmailSchemaVariablesModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Value { get; init; }
    }
}
