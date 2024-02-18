namespace EmailWebService.Interfaces
{
    public interface IEmailDbROController
    {
        int GetIdentityCodeId(string IdentityCode);
        IAppPermisionDbModel GetAppPermision(int IdentityCodeId, string ServiceName);
        IEmailConfigurationDbModel GetEmailConfiguration(int IdentityCodeId);
        string GetEmailBody(string SchemaName, List<(string Name, string Value)> VariablesList);
    }
}
