using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassStatusUploader.Hubs;
using ClassStatusUploader.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassStatusUploader
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        readonly IHubContext<TeamHub> hub;
        public TeamController(IHubContext<TeamHub> hub)
        {
            this.hub = hub;
        }
        
        [HttpPost]
        [Route("TeamAdded")]
        public async Task Post([FromBody]TeamAddedMessage value)
        {
            await hub.Clients.All.SendAsync("TeamAdded", value);
        }
        [HttpPost]
        [Route("Help")]
        public async Task Help([FromBody]TeamStatusChange value)
        {
            await hub.Clients.All.SendAsync("Help", value);
        }
        [HttpPost]
        [Route("Done")]
        public async Task Done([FromBody]TeamStatusChange value)
        {
            await hub.Clients.All.SendAsync("Done", value);
        }
    }
}
