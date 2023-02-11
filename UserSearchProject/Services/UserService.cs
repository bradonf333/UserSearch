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

        public IEnumerable<User> GetUsers(string firstName = null, string lastName = null, string email = null)
        {
            IEnumerable<User> users;
            if(!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                users = _dbRepository.GetUsers()
                .Where(u => u.FirstName == firstName)
                .Where(u => u.LastName == lastName);
            }
            else
            {
                users = _dbRepository.GetUsers()
               .Where(u => u.FirstName == firstName
               || u.LastName == lastName
               || u.Email == email);
            }

            return users;
        }
    }
}
