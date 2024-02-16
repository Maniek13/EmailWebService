namespace EmailWebService.Interfaces
{
    public interface IEmailDbControllerRO
    {
        long GetIdentityCodeId(string IdentityCode);
        IAppPermisionModel GetAppPermision(string IdentityCodeId);
        IEmailConfigurationModel GetEmailConfiguration(long IdentityCodeId);
        string GetEmailBody(long IdentityCodesId, string SchemaName, List<(string Name, string Value)> VariablesList);
    }
}
