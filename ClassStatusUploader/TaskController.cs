using System.Threading.Tasks;
using ClassStatusUploader.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassStatusUploader
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        readonly IHubContext<TeamHub> hub;
        public TaskController(IHubContext<TeamHub> hub)
        {
            this.hub = hub;
        }

        [HttpPost]
        public async Task Post([FromBody]string value)
        {
            await hub.Clients.All.SendAsync("TaskUpdated", value);
        }
    }
}
