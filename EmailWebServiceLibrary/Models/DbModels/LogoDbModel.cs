﻿using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using System.ComponentModel.DataAnnotations;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public record LogoDbModel : ILogoDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmailFooterId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public byte[] FileByteArray { get; set; }
        public EmailFooterDbModel EmailFooter { get; set; }
    }
}
