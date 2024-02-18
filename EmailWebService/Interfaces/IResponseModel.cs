namespace EmailWebService.Models
{
    public interface IResponseModel<T>
    {
        T Data { get; set; }
        int ResultCode { get; set; }
        string Message { get; set; }
    }
}
