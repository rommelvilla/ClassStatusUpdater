using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassStatusUploader.Hubs;
using ClassStatusUploader.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassStatusUploader
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        readonly IHubContext<TeamHub> hub;
        public TestController(IHubContext<TeamHub> hub)
        {
            this.hub = hub;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            await hub.Clients.All.SendAsync("TeamAdded", new TeamAddedMessage { Id = Guid.NewGuid(), Name = "yeah" });
            return new[] { "value1", "value2" };
        }

        
    }
}
