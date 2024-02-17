namespace EmailWebService.Interfaces
{
    public interface IEmailDbROController
    {
        long GetIdentityCodeId(string IdentityCode);
        IAppPermisionModel GetAppPermision(long IdentityCodeId, string ServiceName);
        IEmailConfigurationModel GetEmailConfiguration(long IdentityCodeId);
        string GetEmailBody(long IdentityCodesId, string SchemaName, List<(string Name, string Value)> VariablesList);
    }
}
