using ClassStatusUploader.Messages;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassStatusUploader.Hubs
{
    public class TeamHub : Hub
    {
        public async Task SendTeamAddedMessage(TeamAddedMessage message)
        {
            await Clients.All.SendAsync("TeamAdded", message);
        }

        public async Task SendTeamStatusUpdatedMessage(TeamStatusUpdatedMessages message)
        {
            await Clients.All.SendAsync("TeamStatusUpdated", message);
        }

        public async Task SendWorkTaskChangedMessage(TeamStatusUpdatedMessages message)
        {
            await Clients.All.SendAsync("WorkTaskChanged", message);
        }
    }
}
