using ICar.Infrastructure.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Models
{
    public class Interaction : Entity
    {
        public string UserId { get; private set; }
        public string WithUserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string SubjectId { get; private set; }

        public Interaction(string userId, string withUserId, string firstName, 
            string lastName, string subjectId) : base()
        {
            UserId = userId;
            WithUserId = withUserId;
            FirstName = firstName;
            LastName = lastName;
            SubjectId = subjectId;
        }

        public InteractionOutputViewModel ToInteractionOutputViewModel(string lastMessage)
        {
            return new InteractionOutputViewModel(UserId, WithUserId, FirstName, LastName,
                SubjectId, lastMessage);
        }
    }
}
