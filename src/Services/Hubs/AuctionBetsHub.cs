using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Otus.PublicSale.Core.Services.Hubs
{
    /// <summary>
    /// Auction Bets Hub for SignalR
    /// </summary>
    public class AuctionBetsHub : Hub
    {
        /// <summary>
        /// Sends Data to Group 
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendGroup(string groupName, string message)
        {
            await Clients.Group(groupName).SendAsync("NewBet", $"{DateTime.UtcNow} - {message}");
        }

        /// <summary>
        /// Joins Group
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public Task JoinGroup(string groupName)
        {
            HubHandler.ConnectedIds.Add(Context.ConnectionId, groupName);
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            HubHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
