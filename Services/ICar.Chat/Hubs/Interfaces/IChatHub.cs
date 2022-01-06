using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Chat.Hubs.Interfaces
{
    public interface IChatHub
    {
        public Task ReceiveMessage(string fromUserId, string subjectId, string message);
    }
}
