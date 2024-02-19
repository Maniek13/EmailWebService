namespace EmailWebService.Interfaces
{
    public interface IEmailBodySchema
    {
        int Id { get; set; }
        string SchemaName { get; init; }
        string Body { get; init; }
        List<(string Name, string Value)> VariablesList { get; init; }
    }
}
