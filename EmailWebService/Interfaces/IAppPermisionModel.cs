namespace EmailWebService.Interfaces
{
    public interface IAppPermisionModel
    {
        long Id { get; set; }
        long IdentityCodeId { get; set; }
        string ServiceName { get; set; }

    }
}
