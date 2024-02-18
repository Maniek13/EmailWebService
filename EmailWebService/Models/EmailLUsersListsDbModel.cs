﻿using EmailWebService.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Models
{
    public class EmailLUsersListsDbModel : IEmailLUsersListsDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string UsserList { get; set; }
    }
}
