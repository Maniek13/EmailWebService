using EmailWebService.Interfaces;

namespace EmailWebService.Models
{
    public struct EmailBody : IEmailBodySchema
    {
        public int Id { get; set; }
        public string SchemaName { get; init; }
        public string Body { get; init; }
        public List<(string Name, string Value)> VariablesList { get; init; }
    }
}
