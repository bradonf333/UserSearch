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
        public void UserServiceCanCreate()
        {
            var userService = new UserService();
            Assert.That(userService, Is.Not.Null);
        }
    }
}