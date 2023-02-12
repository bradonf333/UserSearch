using System.Xml.Linq;
using UserSearchProject.Data;

namespace UserSearchProject.Db
{
    public class XmlDbRespository : IDbRepository
    {
        public IEnumerable<User> GetUsers()
        {
            var filename = "Users.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var usersFilePath = Path.Combine(currentDirectory, filename);
            var mainElement = XElement.Load(usersFilePath);

            var userElements = mainElement.Elements().ToList();

            List<User> users = userElements.Select(u => new User()
            {
                Id = (int)u.Attribute("id"),
                ClientId = (int)u.Element("ClientId"),
                FirstName = (string)u.Element("FirstName"),
                LastName = (string)u.Element("LastName"),
                Email = (string)u.Element("Email"),
                IsBusinessContact = (bool)u.Element("IsBusinessContact"),
                IsAccountingContact = (bool)u.Element("IsAccountingContact"),
                IsTechnicalContact = (bool)u.Element("IsTechnicalContact"),
                HasApiAccess = (bool)u.Element("HasApiAccess"),
            }).ToList();


            return users;
        }
    }
}
