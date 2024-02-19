using EmailWebService.Interfaces;

namespace EmailWebService.Models
{
    public struct EmailBodySchemaModel : IEmailBodySchemaModel
    {
        public int Id { get; init; }
        public string TemplateName { get; init; }
        public string Body { get; init; }
        public List<(string Name, string Value)> VariablesList { get; init; }
    }
}
