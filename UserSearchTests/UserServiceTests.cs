using Moq;
using UserSearchProject.Data;
using UserSearchProject.Db;
using UserSearchProject.Services;

namespace UserSearchTests
{
    public class UserServiceTests
    {
        [Test]
        public void UserService_ReturnsUsers_WhereFirstNameMatchesSingleUsersFirstName()
        {
            var expectedName = "Cyrus";
            var repoMock = SetUpDbMock();
            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(firstName: expectedName);

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0].FirstName, Is.EqualTo(expectedName));
        }

        [Test]
        public void UserService_ReturnsUsers_WhereLastNameMatchesSingleUsersLastName()
        {
            var expectedLastName = "Carney";
            var repoMock = SetUpDbMock();
            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(lastName: expectedLastName);

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0].LastName, Is.EqualTo(expectedLastName));
        }

        [Test]
        public void UserService_ReturnsUsers_WhereEmailMatchesSingleUsersEmail()
        {
            var expectedEmail = "hbar@123.com";
            var repoMock = SetUpDbMock();
            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(email: expectedEmail);

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0].Email, Is.EqualTo(expectedEmail));
        }


        [Test]
        public void UserService_ReturnsUsers_WhereBothFirstAndLastNameMatchSingleUsersFirstAndLastName()
        {
            var expectedFirstName = "Jo";
            var expectedLastName = "Stanford";
            var repoMock = new Mock<IDbRepository>();
            repoMock.Setup(r => r.GetUsers()).Returns(new List<User> {
                new User { Id = 1, ClientId= 1, FirstName = expectedFirstName,  LastName = "Harrison", Email = "testemail@123.com"},
                new User { Id = 2, ClientId= 2, FirstName = expectedFirstName,  LastName = expectedLastName, Email = "test2@123.com"},
            }.AsQueryable);

            var userService = new UserService(repoMock.Object);
            var users = userService.GetUsers(firstName: expectedFirstName, lastName:expectedLastName);

            Assert.That(users, Is.Not.Null);
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.ToList()[0].FirstName, Is.EqualTo(expectedFirstName));
            Assert.That(users.ToList()[0].LastName, Is.EqualTo(expectedLastName));
        }

        private static Mock<IDbRepository> SetUpDbMock()
        {
            var repoMock = new Mock<IDbRepository>();
            repoMock.Setup(r => r.GetUsers()).Returns(new List<User> {
                new User { Id = 1, ClientId= 123, FirstName = "Sarah",  LastName = "Adkins", Email = "saraad@123.com"},
                new User { Id = 2, ClientId= 223, FirstName = "Cyrus",  LastName = "Bates", Email = "cyBates@123.com"},
                new User { Id = 3, ClientId= 323, FirstName = "John",  LastName = "Carney", Email = "johnc@123.com"},
                new User { Id = 4, ClientId= 423, FirstName = "Harriet",  LastName = "Barton", Email = "hbar@123.com"},
            });

            return repoMock;
        }
    }
}