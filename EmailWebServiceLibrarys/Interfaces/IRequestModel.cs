namespace EmailWebServiceLibrarys.Interfaces
{
    public interface IRequestModel<T>
    {
        string IdentityCode { get; init; }
        T RequestBody { get; init; }
    }
}
