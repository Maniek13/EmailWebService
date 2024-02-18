namespace EmailWebService.Interfaces
{
    public interface IEmailDbROController
    {
        int GetIdentityCodeId(string IdentityCode);
        IAppPermisionModel GetAppPermision(int IdentityCodeId, string ServiceName);
        IEmailConfigurationModel GetEmailConfiguration(int IdentityCodeId);
        string GetEmailBody(int IdentityCodesId, string SchemaName, List<(string Name, string Value)> VariablesList);
    }
}
