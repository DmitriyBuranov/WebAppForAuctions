using AutoFixture;
using AutoFixture.Xunit2;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
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
    /// Auction Bets Controller Tests
    /// </summary>
    public class NotificationControllerTests : IClassFixture<ControllerFixture>
    {
        /// <summary>
        /// Controller
        /// </summary>
        private NotificationController _notificationController;

        /// <summary>
        /// Mocks
        /// </summary>
        private Mock<IRepository<User>> _repositoryUserMock = new Mock<IRepository<User>>();
        private Mock<IPublishEndpoint> _publishEndpointMock = new Mock<IPublishEndpoint>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controllerFixture"></param>
        public NotificationControllerTests(ControllerFixture controllerFixture)
        {
            var provider = controllerFixture.ServiceProvider;

            _notificationController = new NotificationController(_repositoryUserMock.Object, _publishEndpointMock.Object);
        }

        [Theory, AutoData]
        public async Task SendNotification_IfUserNotFound_Returns_NotFound(int userId, NotificationDto notification)
        {
            //Arrange
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _repositoryUserMock.Setup(m => 
                m.GetByIdAsync(userId))
                .ReturnsAsync(()=>null);

            //Act
            var result = await _notificationController.SendNotification(userId, notification);

            //Assert

            Assert.IsType<NotFoundResult>(result);
        }
 
    }
}
