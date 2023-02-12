using UserSearchProject.Data;
using UserSearchProject.Db;

namespace UserSearchProject.Services
{
    public class UserService : IUserService
    {
        private IDbRepository _dbRepository;

        public UserService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        /// <summary>
        /// Returns a list of User where the given criteria matches directly.
        /// Can search by first name, last name or email separately, or by a combination of first and last name together.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <returns>List of User</returns>

        public IEnumerable<User> GetUsers(string? firstName = null, string? lastName = null, string? email = null)
        {
            firstName = firstName?.ToLower(System.Globalization.CultureInfo.CurrentCulture);
            lastName = lastName?.ToLower(System.Globalization.CultureInfo.CurrentCulture);
            email = email?.ToLower(System.Globalization.CultureInfo.CurrentCulture);

            IEnumerable<User> users;

            // Thought about making this match with "contains" rather than a direct match, but the requirements didn't specify, so I went with direct match.
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                users = _dbRepository.GetUsers()
                .Where(u => u.FirstName?.ToLower(System.Globalization.CultureInfo.CurrentCulture) == firstName)
                .Where(u => u.LastName?.ToLower(System.Globalization.CultureInfo.CurrentCulture) == lastName);
            }
            else
            {
                users = _dbRepository.GetUsers()
               .Where(u => u.FirstName?.ToLower(System.Globalization.CultureInfo.CurrentCulture) == firstName
               || u.LastName?.ToLower(System.Globalization.CultureInfo.CurrentCulture) == lastName
               || u.Email?.ToLower(System.Globalization.CultureInfo.CurrentCulture) == email);
            }

            return users;
        }
    }
}
