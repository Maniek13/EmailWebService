namespace EmailWebService.Interfaces
{
    public interface IAppPermisionModel
    {
        long Id { get; set; }
        string IdentityCodesId { get; set; }
        string ServiceName { get; set; }
    }
}
