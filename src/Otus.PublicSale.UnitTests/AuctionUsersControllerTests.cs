using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using Otus.PublicSale.WebApi.Controllers;
using Otus.PublicSale.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Otus.PublicSale.UnitTests
{
    /// <summary>
    /// AuctionUser Bets Controller Tests
    /// </summary>
    public class AuctionUsersControllerTests : IClassFixture<ControllerFixture>
    {
        /// <summary>
        /// Controller
        /// </summary>
        private AuctionUsersController _auctionUserController;

        /// <summary>
        /// Mocks
        /// </summary>
        private readonly Mock<IRepository<AuctionUser>> _repositoryAuctionUserMock = new Mock<IRepository<AuctionUser>>();
        private readonly Mock<IRepository<Auction>> _repositoryAuctionMock = new Mock<IRepository<Auction>>();
        private readonly Mock<IRepository<User>> _repositoryUserMock = new Mock<IRepository<User>>();
        private Mock<IDistributedCache> _cache = new Mock<IDistributedCache>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controllerFixture"></param>
        public AuctionUsersControllerTests(ControllerFixture controllerFixture)
        {
            var provider = controllerFixture.ServiceProvider;

            _auctionUserController = new AuctionUsersController(_repositoryAuctionUserMock.Object, _repositoryUserMock.Object,_repositoryAuctionMock.Object, _cache.Object);
        }

        #region GetAuctionUsersAsync


        /// <summary>
        /// Test method for GetAllAsync that checks if method returns list of AuctionUserDtos
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAuctionUsersAsync_Returns_AuctionUserDtos()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var actionId = 1;
            var auctionUsers = new List<AuctionUser>();
            fixture.AddManyTo(auctionUsers);
            auctionUsers.ForEach(x => x.AuctionId = actionId);

            var auctionUserDtos = auctionUsers.Select(entity => new AuctionUserDto(entity)).ToList();

            _repositoryAuctionUserMock.Setup(m =>
                m.GetAllAsync(It.IsAny<Expression<Func<AuctionUser, bool>>>()))
                .ReturnsAsync(auctionUsers);

            //Act
            var result = await _auctionUserController.GetAuctionUsersAsync(actionId);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var resultData = (result.Result as OkObjectResult).Value;
            Assert.Equal(auctionUserDtos, resultData);
        }

        #endregion

        #region GetActionAsync

        /// <summary>
        /// Test method for GetOneAsync that checks if method returns BadRequest in case of Id is less or equal to zero
        /// </summary>
        /// <returns></returns>
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetAuctionUserAsync_If_Id_Is_Less_Or_Equal_Zero_Returns_BadRequest(int id)
        {
            //Arrange

            //Act
            var result = await _auctionUserController.GettAuctionUserAsync(id);

            //Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        /// <summary>
        /// Test method for GetOneAsync that checks if method returns NotFound 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAuctionUserAsync_Returns_NotFound()
        {
            //Arrange
            int id = 1;
            AuctionUser auctionUser = null;
            _repositoryAuctionUserMock.Setup(m =>
                m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(auctionUser);

            //Act
            var result = await _auctionUserController.GettAuctionUserAsync(id);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        /// <summary>
        /// Test method for GetOneAsync that checks if method returns AuctionUserBetDto
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAuctionUserAsync_Returns_AuctionUserDto()
        {
            //Arrange
            var id = 1;

            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var auctionUser = fixture.Create<AuctionUser>();
            var auctionUserDto = new AuctionUserDto(auctionUser);
            _repositoryAuctionUserMock.Setup(m =>
                m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(auctionUser);

            //Act
            var result = await _auctionUserController.GettAuctionUserAsync(id);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var resultData = (result.Result as OkObjectResult).Value;
            Assert.Equal(auctionUserDto, resultData);
        }

        #endregion
    }
}
