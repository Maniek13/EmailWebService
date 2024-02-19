using EmailWebServiceLibrarys.Interfaces;

namespace EmailWebServiceLibrarys.Models
{
    public class EmailSchemaModel : IEmailSchemaModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public List<IEmailSchemaVariablesModel> emailSchemaVariablesModel { get; set; }
    }
}
