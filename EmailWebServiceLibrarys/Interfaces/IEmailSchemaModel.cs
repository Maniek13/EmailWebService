namespace EmailWebServiceLibrarys.Interfaces
{
    public interface IEmailSchemaModel
    {
        int Id { get; set; }
        int ServiceId { get; set; }
        string Name { get; set; }
        string Body { get; set; }
        List<IEmailSchemaVariablesModel> emailSchemaVariablesModel { get; set; }
    }
}
