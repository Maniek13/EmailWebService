﻿using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models.Models;

namespace EmailWebServiceLibrary.Models
{
    public record EmailFooterModel : IEmailFooterModel
    {
        public int Id { get; init; }
        public int EmailSchemaId { get; init; }
        public string TextHtml { get; init; }
        public LogoModel Logo { get; set; }
    }
}
