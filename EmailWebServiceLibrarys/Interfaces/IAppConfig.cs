﻿namespace EmailWebServiceLibrarys.Interfaces
{
    public interface IAppConfig
    {
        static abstract string ConnectionString { get; set; }
        static abstract string ConnectionStringRO { get; set; }
    }
}
