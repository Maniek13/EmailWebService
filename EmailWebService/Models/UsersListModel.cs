using System.ComponentModel.DataAnnotations;

namespace EmailWebService.Interfaces
{
    public readonly struct UsersListModel : IUsersListModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public List<string> UsserList { get; init; }
    }
}
