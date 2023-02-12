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

        public IEnumerable<User> GetUsers(string? firstName = null, string? lastName = null, string? email = null)
        {
            firstName = firstName?.ToLower(System.Globalization.CultureInfo.CurrentCulture);
            lastName = lastName?.ToLower(System.Globalization.CultureInfo.CurrentCulture);
            email = email?.ToLower(System.Globalization.CultureInfo.CurrentCulture);

            IEnumerable<User> users;
            if(!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
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
