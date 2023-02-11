using Moq;
using UserSearchProject.Data;
using UserSearchProject.Db;
using UserSearchProject.Services;

namespace UserSearchTests
{
    public class Tests
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
            repoMock.Setup(r => r.GetUsers()).Returns(new[] { new User()});
            
            var userService = new XmlUserService(repoMock.Object);
            var user = userService.GetUsers();

            Assert.That(user, Is.Not.Null);
        }
    }
}