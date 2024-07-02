using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationLibrary;
using Logic.Entities;
using Logic;
using Moq;

namespace UnitTesting
{
    public class UserAdministrationTests
    {
        private const string TestUser = "John";
        private const string TestEmail = "john@gmail.com";
        private const string TestPassword = "123";

        [Fact]
        public void VerifyUser_ShouldReturnNullForInvalidInput()
        {
            var mockDbHelper = new Mock<IUserDBHelper>();
            var userAdmin = new UserAdministration(mockDbHelper.Object);

            Assert.Null(userAdmin.VerifyUser("", "password"));
            Assert.Null(userAdmin.VerifyUser("username", ""));
        }

        [Fact]
        public void SaveUser_ShouldReturnFalseWhenUserIsNull()
        {
            var mockDbHelper = new Mock<IUserDBHelper>();
            var userAdmin = new UserAdministration(mockDbHelper.Object);

            Assert.False(userAdmin.SaveUser(null));
        }

        [Fact]
        public void SaveUser_ShouldReturnFalseWhenSaveFails()
        {
            var mockDbHelper = new Mock<IUserDBHelper>();
            var userAdmin = new UserAdministration(mockDbHelper.Object);
            var newUser = new User("1", "testUser", "testEmail", "testPassword");

            mockDbHelper.Setup(db => db.SaveUser(It.IsAny<User>())).Throws<Exception>();

            Assert.False(userAdmin.SaveUser(newUser));
        }

        [Fact]
        public void VerifyUser_ShouldReturnCorrectUser()
        {
            var mockDbHelper = new Mock<IUserDBHelper>();
            mockDbHelper.Setup(db => db.VerifyUser(TestUser, TestPassword)).Returns(new User("1", TestUser, TestPassword, TestEmail));

            var userAdmin = new UserAdministration(mockDbHelper.Object);

            var user = userAdmin.VerifyUser(TestUser, TestPassword);

            Assert.NotNull(user);
            Assert.Equal(TestUser, user.GetUsername());
        }

        [Fact]
        public void SaveUser_ShouldSaveUser()
        {
            var mockDbHelper = new Mock<IUserDBHelper>();
            var userAdmin = new UserAdministration(mockDbHelper.Object);

            var user = new User("1", TestUser, TestPassword, TestEmail);

            var result = userAdmin.SaveUser(user);

            Assert.True(result);
            mockDbHelper.Verify(db => db.SaveUser(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void GetUserById_ShouldReturnCorrectUser()
        {
            var mockDbHelper = new Mock<IUserDBHelper>();
            mockDbHelper.Setup(db => db.GetUserById("1")).Returns(new User("1", TestUser, TestPassword, TestEmail));

            var userAdmin = new UserAdministration(mockDbHelper.Object);

            var user = userAdmin.GetUserById("1");

            Assert.NotNull(user);
            Assert.Equal("1", user.GetId());
        }
    }
}
