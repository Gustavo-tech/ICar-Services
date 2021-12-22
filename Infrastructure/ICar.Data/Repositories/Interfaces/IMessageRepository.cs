using ICar.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetMessagesByEmail(string email);
        Task<List<Message>> GetMessagesWith(string ownerEmail, string talkedEmail);
        Task<Message> GetLastMessageWith(string person, string anotherPerson);
    }
}
