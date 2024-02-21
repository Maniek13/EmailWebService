namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface ILogoModel
    {
        int Id { get; init; }
        int EmailFooterId { get; init; }
        string Name { get; init; }
        string Type { get; init; }
        string FileBase64String { get; init; }
    }
}
