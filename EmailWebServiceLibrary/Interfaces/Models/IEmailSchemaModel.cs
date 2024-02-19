using EmailWebServiceLibrarys.Models;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailSchemaModel
    {
        int Id { get; set; }
        int ServiceId { get; set; }
        string Name { get; set; }
        string Body { get; set; }
        List<EmailSchemaVariablesModel> EmailSchemaVariablesModel { get; set; }
    }
}
