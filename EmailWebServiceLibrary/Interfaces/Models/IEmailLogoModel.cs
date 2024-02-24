namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailLogoModel
    {
        int Id { get; init; }
        string Name { get; init; }
        string Type { get; init; }
        string FileBase64String { get; init; }
    }
}
