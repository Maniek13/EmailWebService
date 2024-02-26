using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public record EmailSchemaVariablesModel : IEmailSchemaVariablesModel
    {
        public int Id { get; set; }
        public int EmailSchemaId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
