using AviBL;
using AviModels;
using AviREST.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AviTests
{
    public class TestUserController
    {
        private Mock<IAviBL> _aviBLMock;

        public TestUserController()
        {
            _aviBLMock = new Mock<IAviBL>();
        }

        [Fact]
        public async Task GetUserByEmailShouldGetUser()
        {
            var userEmail = "test@example.com";
            var user = new User { Email = userEmail };
            _aviBLMock.Setup(x => x.GetUserByEmail(It.IsAny<string>())).Returns(Task.FromResult(user));
            var userController = new UsersController(_aviBLMock.Object);
            var result = await userController.GetUserByEmail(userEmail);
            Assert.Equal(userEmail, ((User)((OkObjectResult)result).Value).Email);
            _aviBLMock.Verify(x => x.GetUserByEmail(userEmail));
        }

        [Fact]
        public async Task EditUserShouldAddContributor()
        {
            var user = new User { ID = 1 };
            var pilot = new Pilot { ID = 1 };
            _aviBLMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(Task.FromResult(user));
            _aviBLMock.Setup(x => x.GetPilotByID(It.IsAny<int>())).Returns(pilot);
            _aviBLMock.Setup(x => x.GetContributorById(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<Contributor>(null));

            var userController = new UsersController(_aviBLMock.Object);
            var result = await userController.EditUser(user.ID, pilot.ID);
            Assert.Equal(user.ID, ((Contributor)((OkObjectResult)result).Value).UserID);
            Assert.Equal(pilot.ID, ((Contributor)((OkObjectResult)result).Value).PilotID);

            _aviBLMock.Verify(x => x.AddContributor(It.IsAny<Contributor>()));

        }

        [Fact]
        public async Task EditUserShouldReturnNull()
        {
            var user = new User { ID = 1 };
            var pilot = new Pilot { ID = 1 };
            var contributor = new Contributor { ID = 1, UserID = 1, PilotID = 1 };
            _aviBLMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(Task.FromResult(user));
            _aviBLMock.Setup(x => x.GetPilotByID(It.IsAny<int>())).Returns(pilot);
            _aviBLMock.Setup(x => x.GetContributorById(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<Contributor>(contributor));

            var userController = new UsersController(_aviBLMock.Object);
            var result = await userController.EditUser(user.ID, pilot.ID);
            Assert.Null((Contributor)((OkObjectResult)result).Value);

            _aviBLMock.Verify(x => x.AddContributor(It.IsAny<Contributor>()), Times.Never);

        }

        [Fact]
        public async Task EditUserShouldReturnNotFound()
        {
            var contributor = new Contributor { ID = 1, UserID = 1, PilotID = 1 };
            _aviBLMock.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(Task.FromResult<User>(null));
            _aviBLMock.Setup(x => x.GetPilotByID(It.IsAny<int>())).Returns<Pilot>(null);
            _aviBLMock.Setup(x => x.GetContributorById(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<Contributor>(contributor));

            var userController = new UsersController(_aviBLMock.Object);
            var result = await userController.EditUser(1, 1);
            Assert.IsAssignableFrom<NotFoundResult>(result);

        }

        [Fact]
        public async Task PostShouldShouldReturnNotFound()
        {
            _aviBLMock.Setup(x => x.AddUser(It.IsAny<User>())).Returns(Task.FromResult<User>(null));
            var userController = new UsersController(_aviBLMock.Object);
            var result = await userController.Post(new User());
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public async Task PostShouldShouldAddUser()
        {
            var newUser = new User();
            _aviBLMock.Setup(x => x.AddUser(It.IsAny<User>())).Returns(Task.FromResult<User>(newUser));
            var userController = new UsersController(_aviBLMock.Object);
            var result = await userController.Post(new User());
            Assert.IsAssignableFrom<OkObjectResult>(result);
            _aviBLMock.Verify(x => x.AddUser(It.IsAny<User>()));
        }
    }
}

