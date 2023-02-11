using UserSearchProject.Data;

namespace UserSearchProject.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
    }
}
