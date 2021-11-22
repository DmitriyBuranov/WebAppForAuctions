using MassTransit;
using NLog;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using Core.Domain.NotificationManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Otus.PublicSale.Core.Enums;

namespace Otus.PublicSale.Core.Services
{
    public class AuctionWorker
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IAuctionRepository<Auction> _auctionSpecialRepository;
        private readonly IRepository<Auction> _auctionRepository;
        private readonly IAuctionBetRepository<AuctionBet> _auctionBetRepository;
        private readonly IRepository<User> _repositoryUsers;
        private readonly IServiceProvider _serviceProvider;
        readonly IPublishEndpoint _publishEndpoint;

        public AuctionWorker(IAuctionRepository<Auction> auctionSpecialRepository, 
            IServiceProvider serviceProvider, 
            IAuctionBetRepository<AuctionBet> auctionBetRepository, 
            IRepository<User> repositoryUsers, 
            IRepository<Auction> auctionRepository, 
            IPublishEndpoint publishEndpoint)
        {
            _auctionSpecialRepository = auctionSpecialRepository;
            _serviceProvider = serviceProvider;
            _auctionBetRepository = auctionBetRepository;
            _repositoryUsers = repositoryUsers;
            _auctionRepository = auctionRepository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task SetWinnerAsync(DateTime endTime)
        {
            var endingList = await _auctionSpecialRepository.GetJustHaveFinnishedAsync(endTime);

            if (endingList.Count == 0)
                return;

            foreach (var endingAuction in endingList)
            {
                endingAuction.Status = (int)AuctionStatus.Finished;

                await _auctionRepository.UpdateAsync(endingAuction);

                if (!endingAuction.WinnerId.HasValue)
                    continue;

                //var lastBet = await _auctionBetRepository.GetLastBetAsync(endingAuction.Id);

                //if (lastBet == null)
                //    continue;

                //notification to notification service

                var user = await _repositoryUsers.GetByIdAsync(endingAuction.WinnerId.Value);

                await _publishEndpoint.Publish<INotificationMaket>(
                    new
                    {
                        EmailFrom = "administration@sbidu.com",
                        EmailTo = user.Email,
                        Subject = "You win auction",
                        Message = "You win auction: " + endingAuction.Name,
                        Quick = true

                    });

                //to do use Signal R?
            }

        }

    }
}
