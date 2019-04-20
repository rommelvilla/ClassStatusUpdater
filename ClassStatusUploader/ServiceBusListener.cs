using ClassStatusUploader.Hubs;
using ClassStatusUploader.Messages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClassStatusUploader
{
    public class ServiceBusListener : IHostedService
    {

        private readonly IHubContext<TeamHub> _teamHub;
        private readonly ServiceBusConfiguration _config;
        public ServiceBusListener(IHubContext<TeamHub> teamHub, IOptions<ServiceBusConfiguration> config)
        {
            _teamHub = teamHub;
            _config = config.Value;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var receiver = new SubscriptionClient(_config.ServiceBusConnectionString,
                "messages", 
                "laptop");
            receiver.RegisterMessageHandler(async (message, ct) =>
            {
                await _teamHub.Clients.All.SendAsync("TeamAdded", new TeamAddedMessage { Id = Guid.NewGuid(), Name = "yeah" });
            },
            new MessageHandlerOptions((e) => LogMessageHandlerException(e)) { AutoComplete = false, MaxConcurrentCalls = 1 });


        }
        Task LogMessageHandlerException(ExceptionReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
