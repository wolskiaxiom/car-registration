using NUnit.Framework;
using CarRegistrationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRegistrationLibrary.Services;
using CarRegistrationLibrary.Domain;

namespace CarRegistrationLibrary.Tests
{
    [TestFixture]
    public class UserServiceTests
    {

        private UserService service;

        [OneTimeSetUp]
        public void SetUp()
        {
            service = new UserService();
        }

        [Test]
        public void CheckLoginTestNonExisting()
        {
            var result = service.CheckLogin("foo", "bar");
            Assert.IsNull(result);
        }

        [Test]
        public void CheckLoginTestExisting()
        {
            var result = service.CheckLogin("producent", "admin1");
            Assert.AreEqual(Role.Producer, result);
        }

        [Test]
        public void AddNewUserTest()
        {
            var login = Guid.NewGuid().ToString("n").Substring(0, 8);
            var before = service.GetAllUsers();

            service.AddNewUser(login, "passwd", Role.Mechanic);

            var after = service.GetAllUsers();

            Assert.AreEqual(before.Count + 1, after.Count);
            Assert.IsTrue(after.Contains(login));
        }
    }
}