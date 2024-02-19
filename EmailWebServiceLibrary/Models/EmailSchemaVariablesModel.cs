using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrarys.Models
{
    public record EmailSchemaVariablesModel : IEmailSchemaVariablesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
