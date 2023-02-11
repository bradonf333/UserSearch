using Moq;
using UserSearchProject.Data;
using UserSearchProject.Db;
using UserSearchProject.Services;

namespace UserSearchTests
{
    public class UserServiceTests
    {

        [SetUp]
        public void Setup()
        {
        }

        private static Mock<IDbRepository> SetUpDbMock()
        {
            var repoMock =  new Mock<IDbRepository>();
            repoMock.Setup(r => r.GetUsers()).Returns(new[] {
                new User { Id = 1, ClientId= 1, FirstName = "Test1",  LastName = "TestLast1", Email = "test@123.com"},
                new User { Id = 2, ClientId= 2, FirstName = "Test2",  LastName = "TestLast2", Email = "test2@123.com"},
            });

            return repoMock;
        }

        [Test]
        public void UserService_ReturnsUsers_WhereFirstNameMatchesSingleUsersFirstName()
        {
            var repoMock = SetUpDbMock();

            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(firstName: "Test2");

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0].FirstName, Is.EqualTo("Test2"));
        }

        [Test]
        public void UserService_ReturnsUsers_WhereLastNameMatchesSingleUsersLastName()
        {
            var repoMock = SetUpDbMock();

            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(lastName: "TestLast2");

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0].LastName, Is.EqualTo("TestLast2"));
        }


        [Test]
        public void UserService_ReturnsUsers_WhereEmailMatchesSingleUsersEmail()
        {
            var repoMock = SetUpDbMock();

            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(email: "test2@123.com");

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0].Email, Is.EqualTo("test2@123.com"));
        }
    }
}