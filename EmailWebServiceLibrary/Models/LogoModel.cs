using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public record struct LogoModel : ILogoModel
    {
        public int Id { get; init; }
        public int EmailFooterId { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public string FileByteArray { get; init; }
    }
}
