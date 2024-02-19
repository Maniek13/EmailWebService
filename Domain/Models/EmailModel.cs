﻿using Domain.Interfaces;

namespace Domain.Models
{
    public class EmailModel : IEmailModel
    {
        public string From { get; set; }
        public string DisplayName { get; set; }
        public List<string> To { get; set; }
        public string ReplyTo { get; set; }
        public string ReplyToName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public FormFileCollection Atachments { get; set; }
    }
}
