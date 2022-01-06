using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Chat.Hubs.Interfaces
{
    public interface IChatHub
    {
        public Task ReceiveMessage(Message message);
        public Task MessageSent(Message message);
    }
}
