using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrarys.Models
{
    public record struct EmailSchemaModel : IEmailSchemaModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public List<EmailSchemaVariablesModel> EmailSchemaVariablesModel { get; set; }
    }
}
