using AutoMapper;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmailAccountConfigurationModel, EmailAccountConfigurationDbModel>().ReverseMap();
            CreateMap<EmailSchemaDbModel, EmailSchemaModel>().ReverseMap();
        }
        
    }
}
