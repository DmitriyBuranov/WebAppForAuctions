using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using Otus.PublicSale.Core;
using Otus.PublicSale.Users.Core.Abstractions.Services;
using Otus.PublicSale.Users.Core.Domain;
using Otus.PublicSale.Users.WebApi.Controllers;
using Otus.PublicSale.Users.WebApi.Models;
using Xunit;

namespace Otus.PublicSale.Users.UnitTests
{
    /// <summary>
    /// Users Controller Tests
    /// </summary>
    public class UsersControllerTests : IClassFixture<ControllerFixture>
    {
        /// <summary>
        /// Controller
        /// </summary>
        private UsersController _usersController;

        /// <summary>
        /// Mocks
        /// </summary>
        private Mock<IUserService> _userService = new Mock<IUserService>();

        /// Mapper
        private IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controllerFixture"></param>
        public UsersControllerTests(ControllerFixture controllerFixture)
        {
            var provider = controllerFixture.ServiceProvider;

            _mapper = provider.GetService(typeof(IMapper)) as IMapper;
            var appSettings = provider.GetService(typeof(IOptions<AppSettings>)) as IOptions<AppSettings>;

            _usersController = new UsersController(_userService.Object, _mapper, appSettings);
        }

        #region Authenticate

        /// <summary>
        /// Test method for Authenticate that checks if method returns BadRequest when passed model is null
        /// </summary>        
        /// <returns></returns>
        [Fact]
        public void Authenticate_Returns_BadRequest_If_ModelNull()
        {
            //Arrange
            AuthenticateModel model = null;
            
            //Act
            var result = _usersController.Authenticate(model);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        /// <summary>
        /// Test method for Authenticate that checks if method returns BadRequest when user not found
        /// </summary>        
        [Fact]        
        public void Authenticate_Returns_BadRequest_If_UserNotFound()
        {
            //Arrange
            var model = new AuthenticateModel() { Password = "test", Username = "test" };
            User user = null;

            _userService.Setup(m => m.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

            //Act
            var result = _usersController.Authenticate(model);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        /// <summary>
        /// Test method for Authenticate that checks if method returns Ok when user not found
        /// </summary>        
        [Fact]
        public void Authenticate_Returns_Ok_If_UserFound()
        {
            //Arrange
            var model = new AuthenticateModel() { Password = "test", Username = "test" };
            var user = _mapper.Map<User>(model);

            _userService.Setup(m => m.Authenticate(It.IsAny<string>(), It.IsAny<string>())).Returns(user);

            //Act
            var result = _usersController.Authenticate(model);

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var authenticateResponse = (AuthenticateResponse)((OkObjectResult)result).Value;
            Assert.True(authenticateResponse.Username == model.Username);
        }

        #endregion
    }
}
