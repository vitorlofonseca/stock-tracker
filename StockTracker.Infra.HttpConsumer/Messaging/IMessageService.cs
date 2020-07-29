using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockTracker.Infra.HttpConsumer.Messaging
{
    public interface IMessageService
    {
        void SendMessage(News news);
    }
}
