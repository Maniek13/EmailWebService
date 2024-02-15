namespace EmailWebService.Interfaces
{
    public interface IAppPermisionModel
    {
        public int Id { get; set; }
        public string IdentityCodesId { get; set; }
        public string ServiceName { get; set; }
    }
}
