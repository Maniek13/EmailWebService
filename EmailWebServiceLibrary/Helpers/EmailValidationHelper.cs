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
        public static void ValidateEmailSchemaVariablesModel(EmailSchemaVariablesModel emailSchemaVariables)
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
        public static void ValidateEmailSchemaModel2(IEmailSchemaModel emailSchema)
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
    }
}
