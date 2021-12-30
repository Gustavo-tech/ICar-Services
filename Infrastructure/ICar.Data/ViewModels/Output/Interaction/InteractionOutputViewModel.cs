using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.ViewModels.Output
{
    public class InteractionOutputViewModel : Interaction
    {
        public string LastMessage { get; private set; }

        public InteractionOutputViewModel(string userId, string withUserId, string userNickname, 
            string subjectId, string lastMessage) 
            : base(userId, withUserId, userNickname, subjectId)
        {
            LastMessage = lastMessage;
        }
    }
}
