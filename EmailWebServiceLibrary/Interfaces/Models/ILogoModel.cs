namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public interface ILogoModel
    {
        int Id { get; init; }
        int EmailFooterId { get; init; }
        string Name { get; init; }
        string Type { get; init; }
        string Base64String { get; init; }
    }
}
