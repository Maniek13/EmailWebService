namespace EmailWebService.Interfaces
{
    public interface IAppConfig
    {
        static abstract string ConnectionString { get; set; }
        static abstract string ConnectionStringRO { get; set; }
        static abstract string ServiceName { get; set; }
    }
}
