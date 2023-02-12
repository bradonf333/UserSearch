using Moq;
using UserSearchProject.Data;
using UserSearchProject.Db;
using UserSearchProject.Services;

namespace UserSearchTests
{
    public class UserServiceTests
    {
        public List<User> _users;

        [SetUp]
        public void SetUp()
        {
            _users = new List<User>
            {
                new User { Id = 1, ClientId= 123, FirstName = "Sarah",  LastName = "Adkins", Email = "saraad@123.com"},
                new User { Id = 2, ClientId= 223, FirstName = "Cyrus",  LastName = "Bates", Email = "cyBates@123.com"},
                new User { Id = 3, ClientId= 323, FirstName = "Cypress",  LastName = "Johnson", Email = "cyJohns@123.com"},
                new User { Id = 4, ClientId= 423, FirstName = "John",  LastName = "Carney", Email = "johnc@123.com"},
                new User { Id = 5, ClientId= 523, FirstName = "Harriet",  LastName = "Barton", Email = "hbar@123.com"},
            };
        }
        [Test]
        public void ReturnsMatchingUser_WhereFirstNameMatches_SingleUser()
        {
            var expectedUser = _users[1];
            var repoMock = SetUpDbMock();
            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(firstName: expectedUser.FirstName);

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0], Is.EqualTo(expectedUser));
        }

        [Test]
        public void ReturnsMatchingUsers_WhereLastNameMatches_SingleUsersLastName()
        {
            var expectedUser = _users[3];
            var repoMock = SetUpDbMock();
            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(lastName: expectedUser.LastName);

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0], Is.EqualTo(expectedUser));
        }

        [Test]
        public void ReturnsMatchingUsers_WhereEmailMatches_SingleUsersEmail()
        {
            var expectedUser = _users[4];
            var repoMock = SetUpDbMock();
            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(email: expectedUser.Email);

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0], Is.EqualTo(expectedUser));
        }

        [Test]
        public void ReturnsMatchingUsers_WhereBothFirstAndLastNameMatch_SingleUsersFirstAndLastName()
        {
            var newUsers = new List<User>
            {
                CreateSingleUser(),
                CreateSingleUser()
            };
            newUsers[1].LastName = "Harrison";
            var repoMock = new Mock<IDbRepository>();
            repoMock.Setup(r => r.GetUsers()).Returns(newUsers);

            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(firstName: newUsers[0].FirstName, lastName: newUsers[0].LastName);

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0], Is.EqualTo(newUsers[0]));
        }

        [Test]
        public void ReturnsUsers_WhenFirstNameMatches_RegardlessOfCase()
        {
            var repoMock = new Mock<IDbRepository>();

            var newUsers = new List<User>
            {
                CreateSingleUser()
            };

            repoMock.Setup(r => r.GetUsers()).Returns(newUsers);

            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(firstName: "jOsEPH");

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0], Is.EqualTo(newUsers[0]));
        }

        [Test]
        public void ReturnsUsers_WhenLastNameMatches_RegardlessOfCase()
        {
            var repoMock = new Mock<IDbRepository>();

            var newUsers = new List<User>
            {
                CreateSingleUser()
            };

            repoMock.Setup(r => r.GetUsers()).Returns(newUsers);

            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(lastName: "stANfoRD");

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0], Is.EqualTo(newUsers[0]));
        }

        [Test]
        public void ReturnsUsers_WhenEmailMatches_RegardlessOfCase()
        {
            var repoMock = new Mock<IDbRepository>();

            var newUsers = new List<User>
            {
                CreateSingleUser()
            };

            repoMock.Setup(r => r.GetUsers()).Returns(newUsers);

            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(email: "jsTAN@123.coM");

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0], Is.EqualTo(newUsers[0]));
        }

        private Mock<IDbRepository> SetUpDbMock()
        {
            var repoMock = new Mock<IDbRepository>();
            repoMock.Setup(r => r.GetUsers()).Returns(_users);

            return repoMock;
        }

        private User CreateSingleUser()
        {
            return new User
            {
                FirstName = "Joseph",
                LastName = "Stanford",
                Email = "jstan@123.com"
            };
        }
    }
}