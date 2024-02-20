using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Interfaces.DbModels
{
    public interface ILogoModel
    {
        int Id { get; init; }
        int EmailFooterId { get; init; }
        string Name { get; init; }
        string Type { get; init; }
        string FileByteArray { get; init; }
    }
}
