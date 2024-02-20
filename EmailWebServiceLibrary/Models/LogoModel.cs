namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public readonly record struct LogoModel : ILogoModel
    {
        public int Id { get; init; }
        public int EmailFooterId { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public byte[] FileByteArray { get; init; }
    }
}
