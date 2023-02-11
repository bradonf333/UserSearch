using UserSearchProject.Data;

namespace UserSearchProject.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(string firstName, string lastName, string email);
    }
}
