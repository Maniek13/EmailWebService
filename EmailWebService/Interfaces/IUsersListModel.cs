using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public interface IUsersListModel
    {
        int Id { get; init; }
        string Name { get; init; }
        string Type { get; init; }
        List<string> UsserList { get; init; }
    }
}
