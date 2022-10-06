using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;
using NiobeLabBot.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiobeLabBot
{
    public class Startup : IHostedService
    {
        private readonly int? _exitCode;
        private readonly DiscordSocketClient _client;
        public Startup(DiscordSocketClient client)
        {
            _client = client;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _client.Log += Logger.Log;
            
            await _client.LoginAsync(TokenType.Bot, "NTM4NzgzMjcwNjYyMzA3ODQx.XEyjBQ.sVDAiK8tSulrNMMcVllTsfoWxN4");
            await _client.StartAsync();
            await _client.SetGameAsync("Testing oauth!!");
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            Environment.ExitCode = _exitCode.GetValueOrDefault(-1);
            return Task.CompletedTask;
        }
    }
}
