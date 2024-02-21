namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public readonly record LogoModel : ILogoModel
    {
        public int Id { get; init; }
        public int EmailFooterId { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public string FileBase64String { get; init; }
    }
}
