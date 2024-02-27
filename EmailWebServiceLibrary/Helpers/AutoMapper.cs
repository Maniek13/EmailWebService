using AutoMapper;
using EmailWebServiceLibrary.Interfaces.Models.Models;
using EmailWebServiceLibrary.Models;
using EmailWebServiceLibrary.Models.DbModels;
using EmailWebServiceLibrary.Models.Models;

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

            CreateMap<EmailRecipientsListModel, EmailRecipientsListDbModel>().ReverseMap();
            CreateMap<EmailListRecipientModel, EmailListRecipientDbModel>().ReverseMap();
            CreateMap<EmailRecipientModel, EmailRecipientDbModel>().ReverseMap();
        }
    }
}
