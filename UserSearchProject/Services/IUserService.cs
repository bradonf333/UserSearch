using UserSearchProject.Data;

namespace UserSearchProject.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Returns a list of User where the given criteria matches directly.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <returns>List of User</returns>
        IEnumerable<User> GetUsers(string firstName, string lastName, string email);
    }
}
