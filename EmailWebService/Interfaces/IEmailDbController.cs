namespace EmailWebService.Interfaces
{
    public interface IEmailDbController
    {
        Task<bool> SetEmailBodyAsync(string Name, string Body, List<(string Name, string Value)> VariablesList);

        Task<bool> SetEmailConfigurationAsync(IEmailConfigurationModel Configuration);

        Task<bool> UpdateEmailConfigurationAsync(IEmailConfigurationModel Configuration);
    }
}
