using MassTransit;
using NLog;
using Otus.PublicSale.Core.Abstractions.Repositories;
using Otus.PublicSale.Core.Abstractions.Services;
using Otus.PublicSale.Core.Domain.Administration;
using Otus.PublicSale.Core.Domain.AuctionManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.PublicSale.Core.Domain.Services
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

        public AuctionWorker(IAuctionRepository<Auction> auctionSpecialRepository, IServiceProvider serviceProvider, IAuctionBetRepository<AuctionBet> auctionBetRepository, IRepository<User> repositoryUsers, IRepository<Auction> auctionRepository)
        {
            _auctionSpecialRepository = auctionSpecialRepository;
            _serviceProvider = serviceProvider;
            _auctionBetRepository = auctionBetRepository;
            _repositoryUsers = repositoryUsers;
            _auctionRepository = auctionRepository;
        }

        public async Task SetWinnerAsync(DateTime endTime)
        {
            var endingList = await _auctionSpecialRepository.GetJustHaveFinnishedAsync(endTime);

            if (endingList.Count == 0)
                return;

            foreach (var endingAuction in endingList)
            {
                endingAuction.Status = 3;

                _auctionRepository.UpdateAsync(endingAuction);

                var lastBet = await _auctionBetRepository.GetLastBetAsync(endingAuction.Id);

                if (lastBet == null)
                    continue;


                //sent notification to notification service

                var user = await _repositoryUsers.GetByIdAsync(lastBet.UserId);

                await _publishEndpoint.Publish<ISendNotification>(
                    new
                    {
                        EmailFrom = "",
                        EmailTo = user.Email,
                        Subject = "",
                        Message = "",
                        Quick = true

                    });

                //to do use Signal R?
            }

        }

    }
}
