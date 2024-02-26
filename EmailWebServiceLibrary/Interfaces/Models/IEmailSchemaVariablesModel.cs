namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailSchemaVariablesModel
    {
        int Id { get; set; }
        int EmailSchemaId { get; set; }
        string Name { get; set; }
        string Value { get; set; }
    }
}
