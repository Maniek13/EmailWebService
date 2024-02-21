namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailSchemaVariablesModel
    {
        int Id { get; init; }
        int EmailSchemaId { get; init; }
        string Name { get; init; }
        string Value { get; init; }
    }
}
