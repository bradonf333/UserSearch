using UserSearchProject.Data;

namespace UserSearchProject.Db
{
    public class XmlDbRespository : IDbRepository
    {
        public IEnumerable<User> GetUsers()
        {
            return new[] { new User() };
        }
    }
}
