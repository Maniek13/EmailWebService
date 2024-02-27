using EmailWebServiceLibrary.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace EmailWebServiceLibrary.Interfaces.Data
{
    public interface IEmailServiceContextBase
    {
        virtual DbSet<ServicesPermisionsDbModel> ServicesPermisions => throw new NotImplementedException();
        virtual DbSet<EmailAccountConfigurationDbModel> EmailAccountConfiguration => throw new NotImplementedException();
        virtual DbSet<EmailSchemaDbModel> EmailSchemas => throw new NotImplementedException();
        virtual DbSet<EmailFooterDbModel> Footers => throw new NotImplementedException();
        virtual DbSet<EmailLogoDbModel> Logos => throw new NotImplementedException();
        virtual DbSet<EmailSchemaVariablesDbModel> EmailSchemaVariables => throw new NotImplementedException();
        virtual DbSet<EmailRecipientsListDbModel> RecipientsList => throw new NotImplementedException();
        virtual DbSet<EmailListRecipientDbModel> EmailListRecipients => throw new NotImplementedException();
        virtual DbSet<EmailRecipientDbModel> EmailRecipients => throw new NotImplementedException();
    }
}
