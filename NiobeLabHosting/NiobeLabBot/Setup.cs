using Discord.Interactions;
using Discord.WebSocket;
using Discord;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiobeLabBot.Commands;

namespace NiobeLabBot
{
    public static class Setup
    {
        public static IServiceCollection AddHostedMyService(this IServiceCollection services)
        {
            DiscordSocketClient client = new(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose,
                MessageCacheSize = 1000,
                AlwaysDownloadUsers = true,
                GatewayIntents = GatewayIntents.AllUnprivileged
            });
            return services
                .AddHostedService<Startup>()
                .AddSingleton<DiscordSocketClient>(client)
                .AddSingleton<InteractionService>(serviceProvider =>
                {
                    var interactionService = new InteractionService(client.Rest, new InteractionServiceConfig()
                        {
                            LogLevel = LogSeverity.Error
                    });

                    interactionService.AddModuleAsync(typeof(Slashcommands), serviceProvider);

                    return interactionService;
                });
            //.AddSingleton<InteractionHandler>();
        }
    }
}
