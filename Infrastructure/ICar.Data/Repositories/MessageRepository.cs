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

        public async Task<List<Message>> GetMessagesByUser(string userId)
        {
            return await _context.Messages
                .Where(x => x.ToUser == userId || x.FromUser == userId)
                .ToListAsync();
        }
    }
}
