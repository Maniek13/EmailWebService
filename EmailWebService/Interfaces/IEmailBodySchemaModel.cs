namespace EmailWebService.Interfaces
{
    public interface IEmailBodySchemaModel
    {
        int Id { get; init; }
        string TemplateName { get; init; }
        string Body { get; init; }
        List<(string Name, string Value)> VariablesList { get; init; }
    }
}
