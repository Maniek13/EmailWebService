﻿using EmailWebServiceLibrary.Interfaces.Models;

namespace EmailWebServiceLibrary.Models
{
    public record EmailRecipientModel : IEmailRecipientModel
    {
        public int Id { get; init; }
        public int ServiceId { get; set; }
        public int RecipientsListId { get; init; }
        public string Name { get; init; }
        public string EmailAdress { get; init; }
    }
}
