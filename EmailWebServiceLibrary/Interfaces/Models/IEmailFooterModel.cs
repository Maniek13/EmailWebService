using EmailWebServiceLibrary.Interfaces.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    public interface IEmailFooterModel
    {    
        int Id { get; init; }
        int EmailSchemaId { get; init; }
        string TextHtml { get; init; }
        LogoModel Logo { get; init; }
    }
}
