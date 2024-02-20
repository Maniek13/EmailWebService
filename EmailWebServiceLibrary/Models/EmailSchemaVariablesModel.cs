using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public readonly record struct EmailSchemaVariablesModel : IEmailSchemaVariablesModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Value { get; init; }
    }
}
