using AutoMapper;
using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Interfaces.Models.DbModels;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;
using EmailWebServiceLibrary.Models.Models;
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
            CreateMap<ServicesPermisionsModel, ServicesPermisionsDbModel>().ReverseMap();

            CreateMap<EmailAccountConfigurationModel, EmailAccountConfigurationDbModel>().ReverseMap();

            CreateMap<EmailSchemaModel, EmailSchemaDbModel>().ReverseMap();
            CreateMap<EmailSchemaVariablesModel, EmailSchemaVariablesDbModel>().ReverseMap();
            CreateMap<EmailFooterModel, EmailFooterDbModel>().ReverseMap();
            CreateMap<EmailLogoModel, EmailLogoDbModel>().ForMember(dest => dest.FileByteArray,
                opt => opt.MapFrom(src => Convert.FromBase64String(src.FileBase64String)));
            CreateMap<EmailLogoDbModel, EmailLogoModel>().ForMember(dest => dest.FileBase64String,
                opt => opt.MapFrom(src => Convert.ToBase64String(src.FileByteArray)));

            CreateMap<EmailListRecipientDbModel, EmailRecipientModel>();
            CreateMap<EmailRecipmentDbModel, EmailRecipientModel>();
            CreateMap<EmailRecipientModel, EmailListRecipientDbModel>();
            CreateMap<EmailRecipientsListModel, EmailRecipientsListDbModel>().ReverseMap();

        }
    }
}
