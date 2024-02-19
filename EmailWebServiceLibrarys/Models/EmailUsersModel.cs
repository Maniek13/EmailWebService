﻿using EmailWebServiceLibrarys.Interfaces;

namespace EmailWebServiceLibrarys.Models
{
    public class EmailUsersModel : IEmailUsersModel
    {
        public int Id { get; set; }
        public string UserListId { get; set; }
        public string Name { get; set; }
        public string EmailAdress { get; set; }
    }
}
