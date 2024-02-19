namespace EmailWebService.Interfaces
{
    public interface IEmailBody
    {
        string SchemaName { get; init; }
        string Body { get; init; }
        List<(string Name, string Value)> VariablesList { get; init; }
    }
}
