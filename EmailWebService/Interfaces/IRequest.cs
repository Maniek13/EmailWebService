﻿namespace EmailWebService.Interfaces
{
    public interface IRequest<T>
    {
        string IdentityCode { get; init; }
        T RequestBody { get; init; }
    }
}
