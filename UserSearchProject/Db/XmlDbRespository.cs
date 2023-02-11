using UserSearchProject.Data;

namespace UserSearchProject.Db
{
    public class XmlDbRespository : IDbRepository
    {
        public IEnumerable<User> GetUsers(string firstName)
        {
            return new[] { new User() };
        }
    }
}
