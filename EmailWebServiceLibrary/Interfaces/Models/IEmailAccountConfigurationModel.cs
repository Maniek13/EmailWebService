﻿using EmailWebServiceLibrary.Models.DbModels;
using EmailWebServiceLibrarys.Models;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public interface IEmailAccountConfigurationModel
    {
        int Id { get; init; }
        int ServiceId { get; init; }
        string SMTP { get; init; }
        int Port { get; init; }
        string Login { get; init; }
        string Password { get; init; }
        ServicesPermisionsModel ServicePermision { get; init; }
    }
}
