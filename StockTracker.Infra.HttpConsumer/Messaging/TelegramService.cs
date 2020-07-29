using Microsoft.Extensions.Configuration;
using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace StockTracker.Infra.HttpConsumer.Messaging
{
    public class TelegramService : IMessageService
    {
        private readonly IConfiguration _config;
        public TelegramService(IConfiguration config)
        {
            _config = config;
        }

        public string FormatMessage(News news)
        {
            return @$"<b>{news.Title}</b>

                <a href=""{news.Url}"">Go to the news</a>";
        }

        public async void SendMessage(News news)
        {
            var botClient = new TelegramBotClient(
                _config.GetValue<string>("Apis:Telegram:Key")
            );

            await botClient.SendTextMessageAsync(
              chatId: _config.GetValue<int>("Apis:Telegram:ChatId"),
              text: FormatMessage(news),
              parseMode: ParseMode.Html,
              disableNotification: false
            );
        }
    }
}
