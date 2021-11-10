using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using Otus.PublicSale.Core.Abstractions.Repositories;
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
    /// Auction Bets Controller Tests
    /// </summary>
    public class AuctionControllerTests : IClassFixture<ControllerFixture>
    {
        /// <summary>
        /// Controller
        /// </summary>
        private AuctionsController _auctionController;

        /// <summary>
        /// Mocks
        /// </summary>
        private Mock<IRepository<Auction>> _repositoryauctionMock = new Mock<IRepository<Auction>>();
        private Mock<IAuctionRepository<Auction>> _specialRepositoryauctionMock = new Mock<IAuctionRepository<Auction>>();
        private Mock<IDistributedCache> _cache = new Mock<IDistributedCache>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controllerFixture"></param>
        public AuctionControllerTests(ControllerFixture controllerFixture)
        {
            var provider = controllerFixture.ServiceProvider;

            _auctionController = new AuctionsController(_repositoryauctionMock.Object, _cache.Object, _specialRepositoryauctionMock.Object);
        }

        #region GetAuctionsAsync


        /// <summary>
        /// Test method for GetAllAsync that checks if method returns list of auctionDtos
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAuctionsAsync_Returns_auctionDtos()
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var auction = new List<Auction>();
            fixture.AddManyTo(auction);

            var auctionDtos = auction.Select(entity => new AuctionDto(entity)).ToList();

            _repositoryauctionMock.Setup(m => 
                m.GetAllAsync())
                .ReturnsAsync(auction);

            //Act
            var result = await _auctionController.GetAuctionsAsync();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var resultData = (result.Result as OkObjectResult).Value;
            Assert.Equal(auctionDtos, resultData);
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
        public async Task GetAuctionAsync_If_Id_Is_Less_Or_Equal_Zero_Returns_BadRequest(int id)
        {
            //Arrange

            //Act
            var result = await _auctionController.GetAuctionAsync(id);

            //Assert
            Assert.IsType<BadRequestResult>(result.Result);
        }

        /// <summary>
        /// Test method for GetOneAsync that checks if method returns NotFound 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAuctionAsync_Returns_NotFound()
        {
            //Arrange
            int id = 1;
            Auction auction = null;
            _repositoryauctionMock.Setup(m =>
                m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(auction);

            //Act
            var result = await _auctionController.GetAuctionAsync(id);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        /// <summary>
        /// Test method for GetOneAsync that checks if method returns AuctionBetDto
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAuctionAsync_Returns_AuctionDto()
        {
            //Arrange
            var id = 1;

            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var auction = fixture.Create<Auction>();
            var auctionDto = new AuctionDto(auction);
            _repositoryauctionMock.Setup(m =>
                m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(auction);

            //Act
            var result = await _auctionController.GetAuctionAsync(id);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var resultData = (result.Result as OkObjectResult).Value;
            Assert.Equal(auctionDto, resultData);
        }

        #endregion
    }
}
