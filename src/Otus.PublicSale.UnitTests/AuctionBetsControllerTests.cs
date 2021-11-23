using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using Otus.PublicSale.WebApi.Controllers;
using Otus.PublicSale.Core.Services.Hubs;
using Otus.PublicSale.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using MassTransit;

namespace Otus.PublicSale.UnitTests
{
    /// <summary>
    /// Auction Bets Controller Tests
    /// </summary>
    public class AuctionBetsControllerTests : IClassFixture<ControllerFixture>
    {
        /// <summary>
        /// Controller
        /// </summary>
        private AuctionBetsController _auctionBetsController;

        /// <summary>
        /// Mocks
        /// </summary>
        private Mock<IRepository<AuctionBet>> _repositoryAuctionBetsMock = new Mock<IRepository<AuctionBet>>();
        private Mock<IDistributedCache> _cache = new Mock<IDistributedCache>();
        private Mock<IHubContext<AuctionBetsHub>> _hubContext = new Mock<IHubContext<AuctionBetsHub>>();
        private Mock<IPublishEndpoint> _publishEndpoint = new Mock<IPublishEndpoint>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controllerFixture"></param>
        public AuctionBetsControllerTests(ControllerFixture controllerFixture)
        {
            var provider = controllerFixture.ServiceProvider;

            var repositoryAuctions = provider.GetService(typeof(IRepository<Auction>)) as IRepository<Auction>;

            _auctionBetsController = new AuctionBetsController(_repositoryAuctionBetsMock.Object, repositoryAuctions, _cache.Object, _hubContext.Object, _publishEndpoint.Object);
        }

        #region GetAllAsync

        /// <summary>
        /// Test method for GetAllAsync that checks if method returns BadRequest in case of AuctionId is less or equal to zero
        /// </summary>
        /// <returns></returns>
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetAllAsync_Returns_BadRequest_If_AuctionId_Is_Less_Or_Equal_Zero(int auctionId)
        {
            //Arrange

            //Act
            var result = await _auctionBetsController.GetAllAsync(auctionId);

            //Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        /// <summary>
        /// Test method for GetAllAsync that checks if method returns list of AuctionBetsDtos
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllAsync_Returns_AuctionBetsDtos()
        {
            //Arrange
            var auctionId = 1;
            var auctionBets = new List<AuctionBet> {
                    new AuctionBet() { AuctionId = auctionId, Id = 1, Amount = 1, UserId = 1, Date = DateTime.UtcNow },
                    new AuctionBet() { AuctionId = auctionId, Id = 2, Amount = 2, UserId = 2, Date = DateTime.UtcNow },
            };

            var auctionBetsDtos = auctionBets.Select(entity => new AuctionBetDto(entity)).ToList();

            _repositoryAuctionBetsMock.Setup(m => 
                m.GetAllAsync(It.IsAny<Expression<Func<AuctionBet, bool>>>()))
                .ReturnsAsync(auctionBets);

            //Act
            var result = await _auctionBetsController.GetAllAsync(auctionId);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var resultData = (result.Result as OkObjectResult).Value;
            Assert.Equal(auctionBetsDtos, resultData);
        }

        #endregion

        #region GetOneAsync

        /// <summary>
        /// Test method for GetOneAsync that checks if method returns BadRequest in case of Id is less or equal to zero
        /// </summary>
        /// <returns></returns>
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetOneAsync_Returns_BadRequest_If_Id_Is_Less_Or_Equal_Zero(int id)
        {
            //Arrange

            //Act
            var result = await _auctionBetsController.GetOneAsync(id);

            //Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        /// <summary>
        /// Test method for GetOneAsync that checks if method returns NotFound 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOneAsync_Returns_NotFound()
        {
            //Arrange
            int id = 1;
            AuctionBet auctionBet = null;
            _repositoryAuctionBetsMock.Setup(m =>
                m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(auctionBet);

            //Act
            var result = await _auctionBetsController.GetOneAsync(id);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        /// <summary>
        /// Test method for GetOneAsync that checks if method returns AuctionBetDto
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOneAsync_Returns_AuctionBetDto()
        {
            //Arrange
            var id = 1;
            var auctionBet = new AuctionBet() { AuctionId = 1, Id = id, Amount = 1, UserId = 1, Date = DateTime.UtcNow };
            var auctionBetDto = new AuctionBetDto(auctionBet);

            _repositoryAuctionBetsMock.Setup(m =>
                m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(auctionBet);

            //Act
            var result = await _auctionBetsController.GetOneAsync(id);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var resultData = (result.Result as OkObjectResult).Value;
            Assert.Equal(auctionBetDto, resultData);
        }

        #endregion
    }
}
