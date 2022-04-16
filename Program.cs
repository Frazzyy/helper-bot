using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Webhook;
using Discord.API;

namespace helper
{
    class Program
    {
        DiscordSocketClient client;
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "my token";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage arg)
        {

            if (!arg.Author.IsBot)
            {
                switch (arg.Content)
                {
                    case "!рандом":
                        {
                            Random rnd = new Random();
                            arg.Channel.SendMessageAsync($"Выпало число {rnd.Next(-1000, 1000)}.");

                            break;
                        }
                    case "!привет":
                        {
                            arg.Channel.SendMessageAsync($"Привет, {arg.Author.Username}");

                            break;
                        }
                    case "!дата и время":
                        {
                            arg.Channel.SendMessageAsync($"Сегодня, {arg.Timestamp.DateTime}");

                            break;
                        }
                    case "!айди":
                        {
                            arg.Channel.SendMessageAsync($"{arg.Id}");

                            break;
                        }
                    case "!help":
                        {
                            arg.Channel.SendMessageAsync($"**На данный момент я имею данные команды:\n\n*!привет* - сообщение с приветствием вас\n\n*!рандом* - выведет рандомное число от -1000 до 1000\n\n*!дата и время* - выведет текущую дату и время\n\n*!айди* - выведет ваш уникальный ID\n\nЕсли у вас есть предложения по улучшению, то прошу вас связаться с моим разработчиком! Его discord: *Frazzy#7011* **");

                            break;
                        }

                }
            }
                //arg.Channel.SendMessageAsync(arg.Content);
            return Task.CompletedTask;
        }
    }
}
