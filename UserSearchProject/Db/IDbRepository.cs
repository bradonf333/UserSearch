using System.Collections.Generic;
using UserSearchProject.Data;

namespace UserSearchProject.Db
{
    public interface IDbRepository
    {
        IEnumerable<User> GetUsers(string firstName);
    }
}
