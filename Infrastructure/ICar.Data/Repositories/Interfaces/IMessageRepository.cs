using ICar.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetMessagesByUserAsync(string userId);
        Task<List<Message>> GetMessagesWithUserAsync(string userId, string withUserId, string subjectId);
        Task<Message> GetLastMessageWithUserAsync(string userId, string withUserId, string subjectId);
    }
}
