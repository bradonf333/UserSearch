using UserSearchProject.Data;
using UserSearchProject.Db;

namespace UserSearchProject.Services
{
    public class XmlUserService : IUserService
    {
        private IDbRepository _dbRepository;

        public XmlUserService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public IEnumerable<User> GetUsers(string firstName = null, string lastName = null)
        {
            return _dbRepository.GetUsers()
                .Where(u => u.FirstName == firstName
                || u.LastName == lastName);
        }
    }
}
