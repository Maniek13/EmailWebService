using EmailWebServiceLibrary.Interfaces.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public record struct EmailFooterModel : IEmailFooterModel
    {
        public int Id { get; init; }
        public int EmailSchemaId { get; init; }
        public string TextHtml { get; init; }
        public LogoModel Logo { get; init; }
    }
}
