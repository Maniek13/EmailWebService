using EmailWebService.Interfaces;

namespace EmailWebService.Models
{
    public struct EmailBody : IEmailBody
    {
        public string SchemaName { get; init; }
        public string Body { get; init; }
        public List<(string Name, string Value)> VariablesList { get; init; }
    }
}
