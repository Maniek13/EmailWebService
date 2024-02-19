using EmailWebServiceLibrarys.Interfaces;

namespace EmailWebServiceLibrarys.Models
{
    public class EmailSchemaVariablesModel : IEmailSchemaVariablesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
