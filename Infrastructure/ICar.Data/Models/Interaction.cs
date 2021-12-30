using ICar.Infrastructure.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Models
{
    public class Interaction
    {
        public string UserId { get; private set; }
        public string WithUserId { get; private set; }
        public string UserNickname { get; private set; }
        public string SubjectId { get; private set; }

        public Interaction(string userId, string withUserId, string userNickname, string subjectId)
        {
            UserId = userId;
            WithUserId = withUserId;
            UserNickname = userNickname;
            SubjectId = subjectId;
        }

        public InteractionOutputViewModel ToInteractionOutputViewModel(string lastMessage)
        {
            return new InteractionOutputViewModel(UserId, WithUserId, UserNickname,
                SubjectId, lastMessage);
        }
    }
}
