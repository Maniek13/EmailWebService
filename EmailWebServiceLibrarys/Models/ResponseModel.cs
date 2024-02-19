﻿using EmailWebServiceLibrarys.Interfaces;
using System.Net;

namespace EmailWebServiceLibrarys.Models
{
    public class ResponseModel<T> : IResponseModel<T>
    {
        public T Data { get; set; }
        public HttpStatusCode ResultCode { get; set; }
        public string Message { get; set; }
    }
}
