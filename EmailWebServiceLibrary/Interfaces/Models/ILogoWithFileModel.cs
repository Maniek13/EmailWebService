using Microsoft.AspNetCore.Http;

namespace EmailWebServiceLibrary.Interfaces.Models
{
    internal interface ILogoWithFileModel
    {
        int EmailFooterId { get; init; }
        FormFile Image { get; set; }
        string Name { get; init; }
    }
}
