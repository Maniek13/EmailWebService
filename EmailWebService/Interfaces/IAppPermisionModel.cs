namespace EmailWebService.Interfaces
{
    public interface IAppPermisionModel
    {
        int Id { get; set; }
        int IdentityCodeId { get; set; }
        string ServiceName { get; set; }

    }
}
