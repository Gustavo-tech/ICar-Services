using ICar.Infrastructure.Database;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ICarContext _context;

        public MessageRepository(ICarContext context)
        {
            _context = context;
        }

        public async Task<Message> GetLastMessageWithUserAsync(string userId, string withUserId, string subjectId)
        {
            return await _context.Messages
                .Where(x => x.FromUser == userId && x.ToUser == withUserId && x.SubjectId == subjectId
                || x.FromUser == withUserId && x.ToUser == userId && x.SubjectId == subjectId)
                .OrderBy(x => x.SentAt)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Message>> GetMessagesByUserAsync(string userId)
        {
            return await _context.Messages
                .Where(x => x.ToUser == userId || x.FromUser == userId)
                .ToListAsync();
        }

        public async Task<List<Message>> GetMessagesWithUserAsync(string userId, string withUserId, string subjectId)
        {
            return await _context.Messages
                .Where(x => x.FromUser == userId && x.ToUser == withUserId && x.SubjectId == subjectId
                || x.FromUser == withUserId && x.ToUser == userId && x.SubjectId == subjectId)
                .ToListAsync();
        }
    }
}
