using Moq;
using UserSearchProject.Data;
using UserSearchProject.Db;
using UserSearchProject.Services;

namespace UserSearchTests
{
    public class XmlUserServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserService_CanBeInstantiated()
        {
            var repoMock = new Mock<IDbRepository>();
            var userService = new XmlUserService(repoMock.Object);
            Assert.That(userService, Is.Not.Null);
        }

        [Test]
        public void UserService_HasGetUsersMethod()
        {
            var repoMock = new Mock<IDbRepository>();
            repoMock.Setup(r => r.GetUsers()).Returns(new[] { 
                new User { Id = 1, ClientId= 1, FirstName = "Test1",  LastName = "TestLast1", Email = "test@123.com"},
                new User { Id = 2, ClientId= 2, FirstName = "Test2",  LastName = "TestLast2", Email = "test2@123.com"},
            });
            
            var userService = new XmlUserService(repoMock.Object);
            var users = userService.GetUsers("some string");

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(2));
        }

        [Test]
        public void UserService_ReturnsUsers_WhereFirstNameMatchesTheGivenFirstName()
        {
            var repoMock = new Mock<IDbRepository>();
            repoMock.Setup(r => r.GetUsers()).Returns(new[] {
                new User { Id = 1, ClientId= 1, FirstName = "Test1",  LastName = "TestLast1", Email = "test@123.com"},
                new User { Id = 2, ClientId= 2, FirstName = "Test2",  LastName = "TestLast2", Email = "test2@123.com"},
            });

            var userService = new XmlUserService(repoMock.Object);
            var users = userService.GetUsers("Test1");

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.FirstOrDefault().FirstName, Is.EqualTo("Test1"));
        }
    }
}