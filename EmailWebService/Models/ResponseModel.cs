namespace EmailWebService.Models
{
    public class ResponseModel<T> : IResponseModel<T>
    {
        public T Data { get; set; }
        public int ResultCode { get; set; }
        public string Message { get; set; }
    }
}
