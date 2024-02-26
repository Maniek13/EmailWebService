using EmailWebServiceLibrary.Interfaces.Models;
using EmailWebServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailWebServiceLibrary.Helpers
{
    public class EmailValidationHelper
    {
        public static void ValidateEmailSchemaVariablesModel(IEmailSchemaVariablesModel emailSchemaVariables)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailSchemaVariables.Name))
                    throw new Exception("Proszę wpisać nazwę zmienne");
                if (string.IsNullOrWhiteSpace(emailSchemaVariables.Value))
                    throw new Exception("Proszę wpisać wartość zmiennej");

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static void ValidateEmailSchemaModel(IEmailSchemaModel emailSchema)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailSchema.Name))
                    throw new Exception("Proszę wpisać nazwę schematu");
                if (string.IsNullOrWhiteSpace(emailSchema.From))
                    throw new Exception("Proszę wpisać nazwę adresata");
                if (string.IsNullOrWhiteSpace(emailSchema.Body))
                    throw new Exception("Proszę podać treść wiadomosci");
                if (string.IsNullOrWhiteSpace(emailSchema.Subject))
                    throw new Exception("Proszę wpisać temat");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static void ValidateEmailAccountConfigurationModel(IEmailAccountConfigurationModel emailAccountConfiguration)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailAccountConfiguration.SMTP))
                    throw new Exception("Proszę wpisać adres smtp");
                if (emailAccountConfiguration.Port != 0)
                    throw new Exception("Proszę podać port");
                if (string.IsNullOrWhiteSpace(emailAccountConfiguration.Login))
                    throw new Exception("Proszę podać login");
                if (string.IsNullOrWhiteSpace(emailAccountConfiguration.Password))
                    throw new Exception("Proszę wpisać hasło");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void ValidateEmailFooterModel(IEmailFooterModel emailFooter)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailFooter.TextHtml))
                    throw new Exception("Proszę wpisać treść");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public static void ValidateEmailLogoModel(IEmailLogoModel emailLogo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailLogo.Name))
                    throw new Exception("Proszę wpisać nazwę pliku, bez rozszerzenia");
                if (string.IsNullOrWhiteSpace(emailLogo.Type))
                    throw new Exception("Proszę wpisać typ: np jpg");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void ValidateEmailRecipientsListModel(IEmailRecipientsListModel emailRecipientsList)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailRecipientsList.Name))
                    throw new Exception("Proszę wpisać nazwę listy");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void ValidateEmailRecipientModel(IEmailRecipientModel emailRecipient)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailRecipient.Name))
                    throw new Exception("Proszę wpisać nazwę odbiorcy");
                if (string.IsNullOrWhiteSpace(emailRecipient.EmailAdress))
                    throw new Exception("Proszę wpisać adres email odbiorcy");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
